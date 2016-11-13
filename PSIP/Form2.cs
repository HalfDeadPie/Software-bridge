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
        private Packet packet;//packet
        private IList<LivePacketDevice> allDevices;////all devices list
        private List<Thread> thr_list;//all threads list
        private Hashtable htLog;
        private Boolean enabled;
        private MacAddress myMAC1,myMAC2;
        private int downcntDev0, upcntDev0, downcntDev1, upcntDev1
            , downUdp0, upUdp0, downTcp0, upTcp0, downArp0, upArp0, downIcmp0, upIcmp0, downDropped0, upDropped0,
            downUdp1, upUdp1, downTcp1, upTcp1, downArp1, upArp1, downIcmp1, upIcmp1, downDropped1, upDropped1;
        private List<Packet> listDev0, listDev1;
        private Hashtable hashDev0, hashDev1;
            
        //private List<Packet> listDev0, listDev1;
        private PacketCommunicator dev0;
        private PacketCommunicator dev1;
        //CONSTANTS
        private const int SNAPSHOT = 65536, TIMEOUT = 1000, AMOUNT = -1, TIME = 10000, DEV0 = 0, DEV1 = 1;

        public Form2()
        {
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
                downUdp1 = upUdp1 = downTcp1 = upTcp1 = downArp1 = upArp1 = downIcmp1 = upIcmp1 = downDropped1 = upDropped1 = 0;
            enabled = false;

            //open communcators
            dev0 = allDevices[DEV0].Open(SNAPSHOT, PacketDeviceOpenAttributes.NoCaptureLocal | PacketDeviceOpenAttributes.Promiscuous, TIMEOUT);
            thr_list.Add(new Thread(Receiving0));
            thr_list[0].Start();

            dev1 = allDevices[DEV1].Open(SNAPSHOT, PacketDeviceOpenAttributes.NoCaptureLocal | PacketDeviceOpenAttributes.Promiscuous, TIMEOUT);
            thr_list.Add(new Thread(Receiving1));
            thr_list[1].Start();

            myMAC1 = PcapDotNet.Core.Extensions.LivePacketDeviceExtensions.GetMacAddress(allDevices[DEV0]);
            myMAC2 = PcapDotNet.Core.Extensions.LivePacketDeviceExtensions.GetMacAddress(allDevices[DEV1]);
            this.Text = (myMAC1.ToString() + " - " + myMAC2.ToString());

            listDev0 = new List<Packet>();
            listDev1 = new List<Packet>();
            hashDev0 = new Hashtable();
            hashDev1 = new Hashtable();

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
                    ListViewItem SrcMac = new ListViewItem("0");//adding to GUI table
                    SrcMac.SubItems.Add(packet.Ethernet.Source.ToString());
                    SrcMac.SubItems.Add(packet.Timestamp.ToLongTimeString());
                    mac_table.Items.Add(SrcMac);

                    Log log = new Log(packet.Ethernet.Source, packet.Timestamp, 1, TIME, htLog, SrcMac);//create the new log
                    htLog.Add(key, log);//add log to hashtable
                }
                else
                {
                    ListViewItem SrcMac = new ListViewItem("0");//adding to GUI table
                    SrcMac.SubItems.Add(packet.Ethernet.Source.ToString());
                    SrcMac.SubItems.Add(packet.Timestamp.ToLongTimeString());

                    Log temp = (Log)htLog[key];
                    temp.Item.Remove();//here I remove address from ListView of MAC
                    htLog.Remove(key);
                    //create the new log
                    htLog.Add(key, new Log(packet.Ethernet.Source, packet.Timestamp, 1, TIME, htLog, SrcMac));//add log to hashtable1
                    mac_table.Items.Add(SrcMac);
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

                    ListViewItem SrcMac = new ListViewItem("1");//adding to GUI table
                    SrcMac.SubItems.Add(packet.Ethernet.Source.ToString());
                    SrcMac.SubItems.Add(packet.Timestamp.ToLongTimeString());
                    mac_table.Items.Add(SrcMac);

                    Log log = new Log(packet.Ethernet.Source, packet.Timestamp, 1, TIME, htLog, SrcMac);//create the new log
                    htLog.Add(key, log);//add log to hashtable

                }
                else
                {
                    ListViewItem SrcMac = new ListViewItem("1");//adding to GUI table
                    SrcMac.SubItems.Add(packet.Ethernet.Source.ToString());
                    SrcMac.SubItems.Add(packet.Timestamp.ToLongTimeString());

                    Log temp = (Log)htLog[key];
                    temp.Item.Remove();//here I remove address from ListView of MAC
                    htLog.Remove(key);
                    //create the new log
                    htLog.Add(key, new Log(packet.Ethernet.Source, packet.Timestamp, 1, TIME, htLog, SrcMac));//add log to hashtable1
                    mac_table.Items.Add(SrcMac);
                }
            }
        }

        //------------------------------------------PACKET HANDLERS---------------------------------------------
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void PacketHandler0(Packet packet)
        {
            if (enabled)
            {
                statDown0();
                statDownUDP0();
                statDownTCP0();
                statDownARP0();
                statDownICMP0();
                addMACdev0(packet);
                int key = packet.GetHashCode();
                if ( hashDev1[key]!=null )
                {
                    return;
                }
                hashDev1.Add(key, packet);
                dev1.SendPacket(packet);
                statUp0();
                statUpUDP0();
                statUpTCP0();
                statUpARP0();
                statUpICMP0();
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void PacketHandler1(Packet packet)
        {
            if (enabled)
            {
                statDown1();
                statDownUDP1();
                statDownTCP1();
                statDownARP1();
                statDownICMP1();
                addMACdev1(packet);
                int key = packet.GetHashCode();
                if (hashDev0[key] != null)
                {
                    return;
                }
                hashDev0.Add(key, packet);
                dev0.SendPacket(packet);
                statUp1();
                statUpUDP1();
                statUpTCP1();
                statUpARP1();
                statUpICMP1();
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
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void labDown1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void labDev0_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void labUpARP0_Click(object sender, EventArgs e)
        {

        }


        //------------------------------------------STATS---------------------------------------------
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
                labDown1.Text = upcntDev1.ToString();
            }
        }

        //-----------PROTOCOLS - DEV0
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
            if (labDownTCP0.InvokeRequired)
            {
                labDownTCP0.BeginInvoke((MethodInvoker)delegate() { labDownTCP0.Text = downTcp0.ToString(); ;});
            }
            else
            {
                labDownTCP0.Text = downTcp0.ToString();
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
    }
}

