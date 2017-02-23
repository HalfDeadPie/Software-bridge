using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Arp;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.IpV4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace PSIP
{
    public partial class Form2 : Form
    {
        private IList<LivePacketDevice> allDevices;////all devices list
        private List<Thread> thr_list;//all threads list
        private Hashtable htLog;
        private Boolean enabled;
        private MacAddress myMAC1, myMAC2;
        private int downcntDev0, upcntDev0, downcntDev1, upcntDev1
            , downUdp0, upUdp0, downTcp0, upTcp0, downArp0, upArp0, downIcmp0, upIcmp0, downDropped0, upDropped0,
            downUdp1, upUdp1, downTcp1, upTcp1, downArp1, upArp1, downIcmp1, upIcmp1, downDropped1, upDropped1,
            upIp0,downIp0,upIp1,downIp1;
        private Hashtable hashDev0, hashDev1;

        private PacketCommunicator dev0;
        private PacketCommunicator dev1;
        //CONSTANTS
        private const int SNAPSHOT = 65536, TIMEOUT = 10, AMOUNT = 0, TIME = 10000;
        private int DEV0 = 0, DEV1 = 2;

        public Form2()
        {
        }


        public Form2(int first, int second)
        {
            this.DEV0 = first;
            this.DEV1 = second;
            init();
        }


        //INITIALIZATION
        public void init()
        {
            InitializeComponent();
            Show();
            allDevices = LivePacketDevice.AllLocalMachine;
            thr_list = new List<Thread>();
            htLog = new Hashtable();
            downcntDev0 = upcntDev0 = downcntDev1 = upcntDev1 =
                downUdp0 = upUdp0 = downTcp0 = upTcp0 = downArp0 = upArp0 = downIcmp0 = upIcmp0 = downDropped0 = upDropped0 =
                downUdp1 = upUdp1 = downTcp1 = upTcp1 = downArp1 = upArp1 = downIcmp1 = upIcmp1 = downDropped1 = upDropped1 =
                downIp0 = downIp1 = upIp0 = upIp1 = 0;
            enabled = false;

            //open communcators
            dev0 = allDevices[DEV0].Open(SNAPSHOT, PacketDeviceOpenAttributes.Promiscuous | PacketDeviceOpenAttributes.NoCaptureLocal, TIMEOUT);
            thr_list.Add(new Thread(Receiving0));
            thr_list[0].Start();

            dev1 = allDevices[DEV1].Open(SNAPSHOT, PacketDeviceOpenAttributes.Promiscuous | PacketDeviceOpenAttributes.NoCaptureLocal, TIMEOUT);
            thr_list.Add(new Thread(Receiving1));
            thr_list[1].Start();

            myMAC1 = PcapDotNet.Core.Extensions.LivePacketDeviceExtensions.GetMacAddress(allDevices[DEV0]);
            myMAC2 = PcapDotNet.Core.Extensions.LivePacketDeviceExtensions.GetMacAddress(allDevices[DEV1]);
            this.Text = (myMAC1.ToString() + " - " + myMAC2.ToString());

            hashDev0 = new Hashtable();
            hashDev1 = new Hashtable();
        }

        //GET PORT FROM MAC HASH TABLE
        public int getPort(MacAddress mac)
        {
            int key = mac.GetHashCode();
            int port = -1;
            if (htLog[key] != null)
            {
                Log temp = (Log)htLog[key];
                port = temp.Port;
            }
            return port;
        }
        //IS PACKET DUPLICATE FROM HASHDEV1?
        public Boolean isDuplicate1(Packet packet)
        {
            if (hashDev1[packet.GetHashCode()] != null)
            {
                return true;
            }
            return false;
        }
        //IS PACKET DUPLICATE FROM HASHDEV0?
        public Boolean isDuplicate0(Packet packet)
        {
            if (hashDev0[packet.GetHashCode()] != null)
            {
                return true;
            }
            return false;
        }
        //---------------------------------------------MAC ADDRESS HANDLING------------------------------------------
        delegate void callbackMACdev0(Packet packet);
        private void addMACdev0(Packet packet)
        {
            if (packet.Ethernet.Source.Equals(myMAC1) || packet.Ethernet.Source.Equals(myMAC2))//check if its not MAC of an actual device (switch)
            {
                return;
            }
            if (mac_table.InvokeRequired)
            {
                callbackMACdev0 d = new callbackMACdev0(addMACdev0);
                Invoke(d, new object[] { packet });
            }
            else
            {
                int key = packet.Ethernet.Source.GetHashCode();
                if (htLog[key] == null)//ak tuto MAC nemam este v tabulke
                {
                    ListViewItem SrcMac = new ListViewItem(DEV0.ToString());//adding to GUI table
                    SrcMac.SubItems.Add(packet.Ethernet.Source.ToString());
                    SrcMac.SubItems.Add(packet.Timestamp.ToLongTimeString());
                    lock (mac_table)
                    {
                        mac_table.Items.Add(SrcMac);
                        Log log = new Log(packet.Ethernet.Source, packet.Timestamp, DEV0, TIME, htLog, SrcMac);//create the new log
                        lock (htLog)
                        {
                            htLog.Add(key, log);//add log to hashtable
                        }
                    }

                }
                else
                {

                    ListViewItem SrcMac = new ListViewItem(DEV0.ToString());//adding to GUI table
                    SrcMac.SubItems.Add(packet.Ethernet.Source.ToString());
                    SrcMac.SubItems.Add(packet.Timestamp.ToLongTimeString());

                    Log temp = (Log)htLog[key];
                    lock (temp)
                    {
                        temp.Item.Remove();//here I remove address from ListView of MAC
                    }
                    //create the new log
                    lock (mac_table)
                    {
                        mac_table.Items.Add(SrcMac);
                        lock (htLog)
                        {
                            htLog.Remove(key);
                            htLog.Add(key, new Log(packet.Ethernet.Source, packet.Timestamp, DEV0, TIME, htLog, SrcMac));//add log to hashtable1
                        }
                    }


                }
            }
        }
        delegate void callbackMACdev1(Packet packet);
        private void addMACdev1(Packet packet)
        {
            if (packet.Ethernet.Source.Equals(myMAC1) || packet.Ethernet.Source.Equals(myMAC2))
            {
                return;
            }
            if (mac_table.InvokeRequired)
            {
                callbackMACdev1 d = new callbackMACdev1(addMACdev1);
                Invoke(d, new object[] { packet });
            }
            else
            {
                int key = packet.Ethernet.Source.GetHashCode();
                if (htLog[key] == null)//ak tuto MAC nemam este v tabulke
                {

                    ListViewItem SrcMac = new ListViewItem(DEV1.ToString());//adding to GUI table
                    SrcMac.SubItems.Add(packet.Ethernet.Source.ToString());
                    SrcMac.SubItems.Add(packet.Timestamp.ToLongTimeString());
                    lock (mac_table)
                    {
                        mac_table.Items.Add(SrcMac);
                        Log log = new Log(packet.Ethernet.Source, packet.Timestamp, DEV1, TIME, htLog, SrcMac);//create the new log
                        lock (htLog)
                        {
                            htLog.Add(key, log);//add log to hashtable
                        }
                    }

                }
                else
                {
                    ListViewItem SrcMac = new ListViewItem(DEV1.ToString());//adding to GUI table
                    SrcMac.SubItems.Add(packet.Ethernet.Source.ToString());
                    SrcMac.SubItems.Add(packet.Timestamp.ToLongTimeString());

                    Log temp = (Log)htLog[key];
                    lock (temp)
                    {
                        temp.Item.Remove();//here I remove address from ListView of MAC
                    }
                    //create the new log
                    lock (mac_table)
                    {
                        mac_table.Items.Add(SrcMac);
                        lock (htLog)
                        {
                            htLog.Remove(key);
                            htLog.Add(key, new Log(packet.Ethernet.Source, packet.Timestamp, DEV1, TIME, htLog, SrcMac));//add log to hashtable1
                        }
                    }


                }
            }
        }

        //------------------------------------------PACKET HANDLERS---------------------------------------------
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void PacketHandler0(Packet packet)
        {
            if (enabled)
            {
                addMACdev0(packet);//add or actualize MAC and PORT
                /*if (isDuplicate1(packet) == true)//check if it is not sended packet
                {
                    return;
                }
                hashDev1.Add(packet.GetHashCode(), packet);//add to hash table for uniq packets
                */

                allStatsDown0(packet);
                int port = getPort(packet.Ethernet.Destination);
                if (port == DEV1 || port == -1)//check if this MAC is for port1
                {
                    dev1.SendPacket(packet);//send if port-MAC are common
                    allStatsUp0(packet);
                }
                else//not for that port
                {
                    statUpDropped0();
                }
            }
            else//disabled switch
            {
                statDownDropped0();
                return;
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void PacketHandler1(Packet packet)
        {
            if (enabled)
            {
                addMACdev1(packet);//add or actualize MAC and PORT
                /*if (isDuplicate0(packet) == true)
                {
                    MessageBox.Show("dup");
                    return;
                }
                hashDev0.Add(packet.GetHashCode(), packet);*/
                
                allStatsDown1(packet);
                int port = getPort(packet.Ethernet.Destination);
                if (port == DEV0 || port == -1)//check if this MAC is for port0
                {
                    dev0.SendPacket(packet);
                    allStatsUp1(packet);
                }
                else//not for that port
                {
                    statUpDropped1();
                }
            }
            else//disabled switch
            {
                statDownDropped1();
                return;
            }
        }

        //-------------------------------------------RECEIVING FUNCTIONS--------------------------------------------
        private void Receiving0()
        {
       
                dev0.ReceivePackets(AMOUNT, PacketHandler0);
            
        }

        private void Receiving1()
        {
  
                dev1.ReceivePackets(AMOUNT, PacketHandler1);
            
        }

        //-----------------------------------------------------------------------------------------
        //BUTTON START CLICK
        private void button1_Click(object sender, EventArgs e)
        {
            enabled = true;
        }

        //BUTTON CLEAR CLICK
        private void buttonClear_Click(object sender, EventArgs e)
        {
            mac_table.Items.Clear();
            htLog.Clear();
        }
        //BUTTON STOP CLICK
        private void buttonStop_Click(object sender, EventArgs e)
        {
            enabled = false;       
        }


        //CLEAR STATS
        private void btnClearStats_Click(object sender, EventArgs e)
        {
            downcntDev0 = upcntDev0 = downcntDev1 = upcntDev1 =
            downUdp0 = upUdp0 = downTcp0 = upTcp0 = downArp0 = upArp0 = downIcmp0 = upIcmp0 = downDropped0 = upDropped0 =
            downUdp1 = upUdp1 = downTcp1 = upTcp1 = downArp1 = upArp1 = downIcmp1 = upIcmp1 = downDropped1 = upDropped1 =
            downIp0 = downIp1 = upIp0 = upIp1 = 0;
            if (labDown0.InvokeRequired)
            {
                labDown0.BeginInvoke((MethodInvoker)delegate () { labDown0.Text = downcntDev0.ToString(); ; });
            }
            else
            {
                labDown0.Text = downcntDev0.ToString();
            }
            
            if (labDown1.InvokeRequired)
            {
                labDown1.BeginInvoke((MethodInvoker)delegate () { labDown1.Text = downcntDev1.ToString(); ; });
            }
            else
            {
                labDown1.Text = downcntDev1.ToString();
            }

            if (labUp0.InvokeRequired)
            {
                labUp0.BeginInvoke((MethodInvoker)delegate () { labUp0.Text = upcntDev0.ToString(); ; });
            }
            else
            {
                labUp0.Text = upcntDev0.ToString();
            }

            if (labUp1.InvokeRequired)
            {
                labUp1.BeginInvoke((MethodInvoker)delegate () { labUp1.Text = upcntDev1.ToString(); ; });
            }
            else
            {
                labUp1.Text = upcntDev1.ToString();
            }
            //IP
            if (labUpIP0.InvokeRequired)
            {
                labUpIP0.BeginInvoke((MethodInvoker)delegate () { labUpIP0.Text = upIp0.ToString(); ; });
            }
            else
            {
                labUpIP0.Text = upIp0.ToString();
            }

            if (labUpIP1.InvokeRequired)
            {
                labUpIP1.BeginInvoke((MethodInvoker)delegate () { labUpIP1.Text = upIp1.ToString(); ; });
            }
            else
            {
                labUpIP1.Text = upIp1.ToString();
            }

            if (labUpIP0.InvokeRequired)
            {
                labDownIP0.BeginInvoke((MethodInvoker)delegate () { labDownIP0.Text = downIp0.ToString(); ; });
            }
            else
            {
                labDownIP0.Text = downIp0.ToString();
            }

            if (labUpIP1.InvokeRequired)
            {
                labDownIP1.BeginInvoke((MethodInvoker)delegate () { labDownIP1.Text = downIp1.ToString(); ; });
            }
            else
            {
                labDownIP1.Text = downIp1.ToString();
            }

            //////// UDP
          
            if (labUpUDP0.InvokeRequired)
            {
                labUpUDP0.BeginInvoke((MethodInvoker)delegate () { labUpUDP0.Text = upUdp0.ToString(); ; });
            }
            else
            {
                labUpUDP0.Text = upUdp0.ToString();
            }
  
          
            if (labDownUDP0.InvokeRequired)
            {
                labDownUDP0.BeginInvoke((MethodInvoker)delegate () { labDownUDP0.Text = downUdp0.ToString(); ; });
            }
            else
            {
                labDownUDP0.Text = downUdp0.ToString();
            }

            //TCP

            if (labUpTCP0.InvokeRequired)
            {
                labUpTCP0.BeginInvoke((MethodInvoker)delegate () { labUpTCP0.Text = upTcp0.ToString(); ; });
            }
            else
            {
                labUpTCP0.Text = upTcp0.ToString();
            }

            if (labUpIP0.InvokeRequired)
            {
                labUpIP0.BeginInvoke((MethodInvoker)delegate () { labUpIP0.Text = downTcp0.ToString(); ; });
            }
            else
            {
                labUpIP0.Text = downTcp0.ToString();
            }


            //ARP
            if (labUpARP0.InvokeRequired)
            {
                labUpARP0.BeginInvoke((MethodInvoker)delegate () { labUpARP0.Text = upArp0.ToString(); ; });
            }
            else
            {
                labUpARP0.Text = upArp0.ToString();
            }

            if (labDownARP0.InvokeRequired)
            {
                labDownARP0.BeginInvoke((MethodInvoker)delegate () { labDownARP0.Text = downArp0.ToString(); ; });
            }
            else
            {
                labDownARP0.Text = downArp0.ToString();
            }

            //ICMP
            if (labUpICMP0.InvokeRequired)
            {
                labUpICMP0.BeginInvoke((MethodInvoker)delegate () { labUpICMP0.Text = upIcmp0.ToString(); ; });
            }
            else
            {
                labUpICMP0.Text = upIcmp0.ToString();
            }

          
            if (labDownICMP0.InvokeRequired)
            {
                labDownICMP0.BeginInvoke((MethodInvoker)delegate () { labDownICMP0.Text = downIcmp0.ToString(); ; });
            }
            else
            {
                labDownICMP0.Text = downIcmp0.ToString();
            }

            //DEV1
            //////// UDP

            if (labUpUDP1.InvokeRequired)
            {
                labUpUDP1.BeginInvoke((MethodInvoker)delegate () { labUpUDP1.Text = upUdp1.ToString(); ; });
            }
            else
            {
                labUpUDP1.Text = upUdp1.ToString();
            }


            if (labDownUDP1.InvokeRequired)
            {
                labDownUDP1.BeginInvoke((MethodInvoker)delegate () { labDownUDP1.Text = downUdp1.ToString(); ; });
            }
            else
            {
                labDownUDP1.Text = downUdp1.ToString();
            }

            //TCP

            if (labUpTCP1.InvokeRequired)
            {
                labUpTCP1.BeginInvoke((MethodInvoker)delegate () { labUpTCP1.Text = upTcp1.ToString(); ; });
            }
            else
            {
                labUpTCP1.Text = upTcp1.ToString();
            }

            if (labUpIP1.InvokeRequired)
            {
                labUpIP1.BeginInvoke((MethodInvoker)delegate () { labUpIP1.Text = downTcp1.ToString(); ; });
            }
            else
            {
                labUpIP1.Text = downTcp1.ToString();
            }


            //ARP
            if (labUpARP1.InvokeRequired)
            {
                labUpARP1.BeginInvoke((MethodInvoker)delegate () { labUpARP1.Text = upArp1.ToString(); ; });
            }
            else
            {
                labUpARP1.Text = upArp1.ToString();
            }

            if (labDownARP1.InvokeRequired)
            {
                labDownARP1.BeginInvoke((MethodInvoker)delegate () { labDownARP1.Text = downArp1.ToString(); ; });
            }
            else
            {
                labDownARP1.Text = downArp1.ToString();
            }

            //ICMP
            if (labUpICMP1.InvokeRequired)
            {
                labUpICMP1.BeginInvoke((MethodInvoker)delegate () { labUpICMP1.Text = upIcmp1.ToString(); ; });
            }
            else
            {
                labUpICMP1.Text = upIcmp1.ToString();
            }


            if (labDownICMP1.InvokeRequired)
            {
                labDownICMP1.BeginInvoke((MethodInvoker)delegate () { labDownICMP1.Text = downIcmp1.ToString(); ; });
            }
            else
            {
                labDownICMP1.Text = downIcmp1.ToString();
            }

            //DROPPED
            if (labUpDropped1.InvokeRequired)
            {
                labUpDropped1.BeginInvoke((MethodInvoker)delegate () { labUpDropped1.Text = upDropped1.ToString(); ; });
            }
            else
            {
                labUpDropped1.Text = upDropped1.ToString();
            }

            if (labDownDropped1.InvokeRequired)
            {
                labDownDropped1.BeginInvoke((MethodInvoker)delegate () { labDownDropped1.Text = downDropped1.ToString(); ; });
            }
            else
            {
                labDownDropped1.Text = downDropped1.ToString();
            }
            
            if (labUpDropped0.InvokeRequired)
            {
                labUpDropped0.BeginInvoke((MethodInvoker)delegate () { labUpDropped0.Text = upDropped0.ToString(); ; });
            }
            else
            {
                labUpDropped0.Text = upDropped0.ToString();
            }
  
            if (labDownDropped0.InvokeRequired)
            {
                labDownDropped0.BeginInvoke((MethodInvoker)delegate () { labDownDropped0.Text = downDropped0.ToString(); ; });
            }
            else
            {
                labDownDropped0.Text = downDropped0.ToString();
            }
    }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        //------------------------------------------STATS---------------------------------------------


        //ALLSTATS
        public void allStatsDown0(Packet packet)
        {
            statDown0();
            if (packet.Ethernet.EtherType == EthernetType.Arp)
            {
                //ARP
                statDownARP0();
            }   
            else if (packet.Ethernet.EtherType == EthernetType.IpV4)
            {
                //IP
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Ip)
                {
                    statDownIP0();
                }
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Udp)
                {
                    //UDP
                    statDownUDP0();
                }
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Tcp)
                {
                    //TCP
                    statDownTCP0();
                }
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.InternetControlMessageProtocol)
                {
                    //ICMP
                    statDownICMP0();
                }

            }
        }
        public void allStatsUp0(Packet packet)
        {
            statUp0();
            if (packet.Ethernet.EtherType == EthernetType.Arp)
            {
                //ARP
                statUpARP0();
            }
            else if (packet.Ethernet.EtherType == EthernetType.IpV4)
            {
                //IP
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Ip)
                {
                    statUpIP0();
                }
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Udp)
                {
                    //UDP
                    statUpUDP0();
                }
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Tcp)
                {
                    //TCP
                    statUpTCP0();
                }
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.InternetControlMessageProtocol)
                {
                    //ICMP
                    statUpICMP0();
                }

            }
        }

        //ALLSTATS
        public void allStatsDown1(Packet packet)
        {
            statDown1();
            if (packet.Ethernet.EtherType == EthernetType.Arp)
            {
                //ARP
                statDownARP1();
            }
            else if (packet.Ethernet.EtherType == EthernetType.IpV4)
            {
                //IP
                if(packet.Ethernet.IpV4.Protocol == IpV4Protocol.Ip)
                {
                    statDownIP1();
                }
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Udp)
                {
                    //UDP
                    statDownUDP1();
                }
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Tcp)
                {
                    //TCP
                    statDownTCP1();
                }
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.InternetControlMessageProtocol)
                {
                    //ICMP
                    statDownICMP1();
                }

            }
        }
        public void allStatsUp1(Packet packet)
        {
            statUp1();
            if (packet.Ethernet.EtherType == EthernetType.Arp)
            {
                //ARP
                statUpARP1();
            }
            else if (packet.Ethernet.EtherType == EthernetType.IpV4)
            {
                //IP
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Ip)
                {
                    statUpIP1();
                }
                //TU DOPIŠ IP
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Udp)
                {
                    //UDP
                    statUpUDP1();
                }
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Tcp)
                {
                    //TCP
                    statUpTCP1();
                }
                if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.InternetControlMessageProtocol)
                {
                    //ICMP
                    statUpICMP1();
                }

            }
        }


        //DOWN-UP COUNTERS
        public void statDown0()
        {
            downcntDev0++;
            if (labDown0.InvokeRequired)
            {
                labDown0.BeginInvoke((MethodInvoker)delegate() { labDown0.Text = downcntDev0.ToString(); ;});
            }
            else
            {
                labDown0.Text = downcntDev0.ToString();
            }
        }
        public void statDown1()
        {
            downcntDev1++;
            if (labDown0.InvokeRequired)
            {
                labDown1.BeginInvoke((MethodInvoker)delegate() { labDown1.Text = downcntDev1.ToString(); ;});
            }
            else
            {
                labDown1.Text = downcntDev1.ToString();
            }
        }
        public void statUp0()
        {
            upcntDev0++;
            if (labUp0.InvokeRequired)
            {
                labUp0.BeginInvoke((MethodInvoker)delegate() { labUp0.Text = upcntDev0.ToString(); ;});
            }
            else
            {
                labUp0.Text = upcntDev0.ToString();
            }
        }
        public void statUp1()
        {
            upcntDev1++;
            if (labUp1.InvokeRequired)
            {
                labUp1.BeginInvoke((MethodInvoker)delegate() { labUp1.Text = upcntDev1.ToString(); ;});
            }
            else
            {
                labUp1.Text = upcntDev1.ToString();
            }
        }
        //-----------PROTOCOLS - DEV0
        //IP
        public void statUpIP0()
        {
            upIp0++;
            if (labUpIP0.InvokeRequired)
            {
                labUpIP0.BeginInvoke((MethodInvoker)delegate () { labUpIP0.Text = upIp0.ToString(); ; });
            }
            else
            {
                labUpIP0.Text = upIp0.ToString();
            }
        }
        public void statDownIP0()
        {
            downIp0++;
            if (labUpIP0.InvokeRequired)
            {
                labDownIP0.BeginInvoke((MethodInvoker)delegate () { labDownIP0.Text = downIp0.ToString(); ; });
            }
            else
            {
                labDownIP0.Text = downIp0.ToString();
            }
        }
        //UDP
        public void statUpUDP0()
        {
            upUdp0++;
            if (labUpUDP0.InvokeRequired)
            {
                labUpUDP0.BeginInvoke((MethodInvoker)delegate() { labUpUDP0.Text = upUdp0.ToString(); ;});
            }
            else
            {
                labUpUDP0.Text = upUdp0.ToString();
            }
        }
        public void statDownUDP0()
        {
            downUdp0++;
            if (labDownUDP0.InvokeRequired)
            {
                labDownUDP0.BeginInvoke((MethodInvoker)delegate() { labDownUDP0.Text = downUdp0.ToString(); ;});
            }
            else
            {
                labDownUDP0.Text = downUdp0.ToString();
            }
        }
        //TCP
        public void statUpTCP0()
        {
            upTcp0++;
            if (labUpTCP0.InvokeRequired)
            {
                labUpTCP0.BeginInvoke((MethodInvoker)delegate() { labUpTCP0.Text = upTcp0.ToString(); ;});
            }
            else
            {
                labUpTCP0.Text = upTcp0.ToString();
            }
        }
        public void statDownTCP0()
        {
            downTcp0++;
            if (labUpIP0.InvokeRequired)
            {
                labUpIP0.BeginInvoke((MethodInvoker)delegate() { labUpIP0.Text = downTcp0.ToString(); ;});
            }
            else
            {
                labUpIP0.Text = downTcp0.ToString();
            }
        }
        //ARP
        public void statUpARP0()
        {
            upArp0++;
            if (labUpARP0.InvokeRequired)
            {
                labUpARP0.BeginInvoke((MethodInvoker)delegate() { labUpARP0.Text = upArp0.ToString(); ;});
            }
            else
            {
                labUpARP0.Text = upArp0.ToString();
            }
        }
        public void statDownARP0()
        {
            downArp0++;
            if (labDownARP0.InvokeRequired)
            {
                labDownARP0.BeginInvoke((MethodInvoker)delegate() { labDownARP0.Text = downArp0.ToString(); ;});
            }
            else
            {
                labDownARP0.Text = downArp0.ToString();
            }
        }
        //ICMP
        public void statUpICMP0()
        {
            upIcmp0++;
            if (labUpICMP0.InvokeRequired)
            {
                labUpICMP0.BeginInvoke((MethodInvoker)delegate() { labUpICMP0.Text = upIcmp0.ToString(); ;});
            }
            else
            {
                labUpICMP0.Text = upIcmp0.ToString();
            }
        }
        public void statDownICMP0()
        {
            downIcmp0++;
            if (labDownICMP0.InvokeRequired)
            {
                labDownICMP0.BeginInvoke((MethodInvoker)delegate() { labDownICMP0.Text = downIcmp0.ToString(); ;});
            }
            else
            {
                labDownICMP0.Text = downIcmp0.ToString();
            }
        }

        //-----------PROTOCOLS - DEV1
        //IP
        public void statUpIP1()
        {
            upIp1++;
            if (labUpIP0.InvokeRequired)
            {
                labUpIP1.BeginInvoke((MethodInvoker)delegate () { labUpIP1.Text = upIp0.ToString(); ; });
            }
            else
            {
                labUpIP1.Text = upIp1.ToString();
            }
        }
        public void statDownIP1()
        {
            downIp1++;
            if (labUpIP1.InvokeRequired)
            {
                labDownIP1.BeginInvoke((MethodInvoker)delegate () { labDownIP1.Text = downIp1.ToString(); ; });
            }
            else
            {
                labDownIP1.Text = downIp1.ToString();
            }
        }
        //UDP
        public void statUpUDP1()
        {
            upUdp1++;
            if (labUpUDP1.InvokeRequired)
            {
                labUpUDP1.BeginInvoke((MethodInvoker)delegate() { labUpUDP1.Text = upUdp1.ToString(); ;});
            }
            else
            {
                labUpUDP1.Text = upUdp1.ToString();
            }
        }
        public void statDownUDP1()
        {
            downUdp1++;
            if (labDownUDP1.InvokeRequired)
            {
                labDownUDP1.BeginInvoke((MethodInvoker)delegate() { labDownUDP1.Text = downUdp1.ToString(); ;});
            }
            else
            {
                labDownUDP1.Text = downUdp1.ToString();
            }
        }
        //TCP
        public void statUpTCP1()
        {
            upTcp1++;
            if (labUpTCP1.InvokeRequired)
            {
                labUpTCP1.BeginInvoke((MethodInvoker)delegate() { labUpTCP1.Text = upTcp1.ToString(); ;});
            }
            else
            {
                labUpTCP1.Text = upTcp1.ToString();
            }
        }
        public void statDownTCP1()
        {
            downTcp1++;
            if (labDownTCP1.InvokeRequired)
            {
                labDownTCP1.BeginInvoke((MethodInvoker)delegate() { labDownTCP1.Text = downTcp1.ToString(); ;});
            }
            else
            {
                labDownTCP1.Text = downTcp1.ToString();
            }
        }
        //ARP
        public void statUpARP1()
        {
            upArp1++;
            if (labUpARP1.InvokeRequired)
            {
                labUpARP1.BeginInvoke((MethodInvoker)delegate() { labUpARP1.Text = upArp1.ToString(); ;});
            }
            else
            {
                labUpARP1.Text = upArp1.ToString();
            }
        }
        public void statDownARP1()
        {
            downArp1++;
            if (labDownARP1.InvokeRequired)
            {
                labDownARP1.BeginInvoke((MethodInvoker)delegate() { labDownARP1.Text = downArp1.ToString(); ;});
            }
            else
            {
                labDownARP1.Text = downArp1.ToString();
            }
        }
        //ICMP
        public void statUpICMP1()
        {
            upIcmp1++;
            if (labUpICMP1.InvokeRequired)
            {
                labUpICMP1.BeginInvoke((MethodInvoker)delegate() { labUpICMP1.Text = upIcmp1.ToString(); ;});
            }
            else
            {
                labUpICMP1.Text = upIcmp1.ToString();
            }
        }
        public void statDownICMP1()
        {
            downIcmp1++;
            if (labDownICMP1.InvokeRequired)
            {
                labDownICMP1.BeginInvoke((MethodInvoker)delegate() { labDownICMP1.Text = downIcmp1.ToString(); ;});
            }
            else
            {
                labDownICMP1.Text = downIcmp1.ToString();
            }
        }

        //Dropped
        public void statUpDropped1()
        {
            upDropped1++;
            if (labUpDropped1.InvokeRequired)
            {
                labUpDropped1.BeginInvoke((MethodInvoker)delegate() { labUpDropped1.Text = upDropped1.ToString(); ;});
            }
            else
            {
                labUpDropped1.Text = upDropped1.ToString();
            }
        }
        public void statDownDropped1()
        {
            downDropped1++;
            if (labDownDropped1.InvokeRequired)
            {
                labDownDropped1.BeginInvoke((MethodInvoker)delegate() { labDownDropped1.Text = downDropped1.ToString(); ;});
            }
            else
            {
                labDownDropped1.Text = downDropped1.ToString();
            }
        }

        //Dropped
        public void statUpDropped0()
        {
            upDropped0++;
            if (labUpDropped0.InvokeRequired)
            {
                labUpDropped0.BeginInvoke((MethodInvoker)delegate() { labUpDropped0.Text = upDropped0.ToString(); ;});
            }
            else
            {
                labUpDropped0.Text = upDropped0.ToString();
            }
        }
        public void statDownDropped0()
        {
            downDropped0++;
            if (labDownDropped0.InvokeRequired)
            {
                labDownDropped0.BeginInvoke((MethodInvoker)delegate() { labDownDropped0.Text = downDropped0.ToString(); ;});
            }
            else
            {
                labDownDropped0.Text = downDropped0.ToString();
            }
        }
    }
}

