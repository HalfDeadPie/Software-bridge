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

            //open communcators
            dev0 = allDevices[0].Open(SNAPSHOT,PacketDeviceOpenAttributes.NoCaptureLocal, TIMEOUT);
            thr_list.Add(new Thread(Receiving0));
            thr_list[0].Start();
            /*
            dev1 = allDevices[1].Open(SNAPSHOT, PacketDeviceOpenAttributes.NoCaptureLocal, TIMEOUT);
            thr_list.Add(new Thread(Receiving1));
            thr_list[1].Start();
            */
        }

        //ADD MAC ADDRESS WITH CALLBACK (uniq)
        delegate void callbackMAC(Packet packet);
        private void addMAC(Packet packet)
        {
            if (mac_table.InvokeRequired)
            {
                callbackMAC d = new callbackMAC(addMAC);
                Invoke(d, new object[] { packet });
            }
            else
            {
                int key = packet.Ethernet.Source.GetHashCode();
                if(htLog[key] == null)//ak tuto MAC nemam este v tabulke
                {

                    ListViewItem SrcMac = new ListViewItem(allDevices[actual].Name.ToString());//adding to GUI table
                    SrcMac.SubItems.Add(packet.Ethernet.Source.ToString());
                    SrcMac.SubItems.Add(packet.Timestamp.ToLongTimeString());
                    mac_table.Items.Add(SrcMac);

                    Log log = new Log(packet.Ethernet.Source, packet.Timestamp, 1, TIME, htLog, SrcMac);//create the new log
                    htLog.Add(key, log);//add log to hashtable
                    textPacket.AppendText(packet.Ethernet.ToHexadecimalString()+"\n\n---------------");
                    
                }
                else
                {
                    ListViewItem SrcMac = new ListViewItem(allDevices[actual].Name.ToString());//adding to GUI table
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
                addMAC(packet);
                actual = 0;
            }
            //dev0.SendPacket(packet);
        }
        
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void PacketHandler1(Packet packet)
        {
            if (enabled)
            {
                addMAC(packet);
                actual = 1;
            }
            //dev1.SendPacket(packet);
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
