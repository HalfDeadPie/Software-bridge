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
        private List<MacAddress> mac_buffer;//MAC buffer
        private IList<LivePacketDevice> allDevices;////all devices list
        private List<Thread> thr_list;//all threads list
        private List<PacketCommunicator> com_list;//all communicators list
        private int actual;
        private Hashtable htLog;
        private Boolean enabled;
        //CONSTANTS
        private const int SNAPSHOT = 65536, TIMEOUT = 1000, AMOUNT = -1, TIME = 10000;

        public Form2()
        {
            actual = 0;
            
            //INIT
            InitializeComponent();
            Show();
            mac_buffer = new List<MacAddress>();
            allDevices = LivePacketDevice.AllLocalMachine;
            com_list = new List<PacketCommunicator>();
            thr_list = new List<Thread>();
            htLog = new Hashtable();

            enabled = false;

            //open communicators and set threads
            for (int i = 0; i < allDevices.Count; i++)
            {
                LivePacketDevice tempDevice = allDevices[i];
                ListViewItem row = new ListViewItem(tempDevice.Name);
                listDevices.Items.Add(row);
                com_list.Add(tempDevice.Open
                (SNAPSHOT, PacketDeviceOpenAttributes.NoCaptureLocal, TIMEOUT));
                thr_list.Add(new Thread(Receiving));
                thr_list[i].Start();
            }
        }

        //add MAC address with callback
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

        //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void PacketHandler(Packet packet)
        {
            if (enabled)
            {
                addMAC(packet);
                com_list[actual].SendPacket(packet);
            }

        }

        //FRAME RECEIVING
        private void Receiving()
        {
            com_list[actual].ReceivePackets(AMOUNT, PacketHandler);
        }

        //BUTTON START CLICK
        private void button1_Click(object sender, EventArgs e)
        {
            enabled = true;
        }

        //BUTTON CLEAR CLICK
        private void buttonClear_Click(object sender, EventArgs e)
        {
            mac_table.Items.Clear();
            mac_buffer.Clear();
            htLog.Clear();
        }
        //BUTTON STOP CLICK
        private void buttonStop_Click(object sender, EventArgs e)
        {
            enabled = false;

        }
        //TABLE EVENT
        private void pktView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textPacket_TextChanged(object sender, EventArgs e)
        {

        }

        private void listDevices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
