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
using System.Text;
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

        private List<Packet> listDev0, listDev1;
        private int actual;

        private PacketCommunicator dev0;
        private PacketCommunicator dev1;
        //CONSTANTS
        private const int SNAPSHOT = 65536, TIMEOUT = 1000, AMOUNT = 0, TIME = 10000;

        public Form2()
        {
            //INIT
            InitializeComponent();
            Show();
            allDevices = LivePacketDevice.AllLocalMachine;
            thr_list = new List<Thread>();
            htLog = new Hashtable();
            enabled = false;

            foreach (LivePacketDevice row in allDevices)
            {
                listDevices.BeginInvoke(new Action(() => listDevices.Items.Add(new ListViewItem(row.Description))));
            }
            

            //open communcators
            dev0 = allDevices[0].Open(SNAPSHOT, PacketDeviceOpenAttributes.NoCaptureLocal | PacketDeviceOpenAttributes.Promiscuous, TIMEOUT);
            thr_list.Add(new Thread(Receiving0));
            thr_list[0].Start();
            
            dev1 = allDevices[1].Open(SNAPSHOT, PacketDeviceOpenAttributes.NoCaptureLocal | PacketDeviceOpenAttributes.Promiscuous, TIMEOUT);
            thr_list.Add(new Thread(Receiving1));
            thr_list[1].Start();
            
            listDev0 = new List<Packet>();
            listDev1 = new List<Packet>();
        
        }

        //ADD MAC ADDRESS WITH CALLBACK (uniq)
        delegate void callbackMACdev0(Packet packet);
        private void addMACdev0(Packet packet)
        {
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
                    textPacket.AppendText(packet.Ethernet.ToHexadecimalString() + "\n\n---------------");

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
                    textPacket.AppendText(packet.Ethernet.ToHexadecimalString() + "\n\n---------------");
                }
            }
        }
        delegate void callbackMACdev1(Packet packet);
        private void addMACdev1(Packet packet)
        {
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
                    textPacket.AppendText(packet.Ethernet.ToHexadecimalString() + "\n\n---------------");

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
                    textPacket.AppendText(packet.Ethernet.ToHexadecimalString() + "\n\n---------------");
                }


            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void PacketHandler0(Packet packet)
        {
            if (enabled)
            {
                addMACdev0(packet);
                actual = 0;
                foreach(Packet row in listDev0)
                {
                    if (row.Equals(packet))
                    {
                        return;
                    }
                }
                listDev0.Add(packet);
                dev1.SendPacket(packet);
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void PacketHandler1(Packet packet)
        {
            if (enabled)
            {
                addMACdev1(packet);
                actual = 0;
                foreach (Packet row in listDev0)
                {
                    if (row.Equals(packet))
                    {
                        return;
                    }
                }
                listDev1.Add(packet);
                dev0.SendPacket(packet);
            }
        }
        //FRAME RECEIVING
        private void Receiving0()
        {
            dev0.ReceivePackets(AMOUNT, PacketHandler0);
        }

        private void Receiving1()//i am not really using this function in this version
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
    }
}