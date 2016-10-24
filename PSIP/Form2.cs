﻿using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Arp;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.IpV4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSIP
{
    public partial class Form2 : Form
    {
        private Packet packet;//packet
        private int mac_cnt;//MAC counter
        private List<MacAddress> mac_buffer;//MAC buffer
        private IList<LivePacketDevice> allDevices;////all devices list
        private List<Thread> thr_list;//all threads list
        private List<PacketCommunicator> com_list;//all communicators list
        private int actual;
        //CONSTANTS
        private const int SNAPSHOT = 65536, TIMEOUT = 1000, AMOUNT = 5;
        public Form2()
        {
            //INIT
            InitializeComponent();
            Show();
            mac_cnt = 0;
            mac_buffer = new List<MacAddress>();
            allDevices = LivePacketDevice.AllLocalMachine;
            com_list = new List<PacketCommunicator>();
            thr_list = new List<Thread>();
            //open communicators and set threads
            for (int i = 0; i < allDevices.Count; i++)
            {
                LivePacketDevice tempDevice = allDevices[i];
                ListViewItem row = new ListViewItem(tempDevice.Name);
                listDevices.Items.Add(row);
                com_list.Add(tempDevice.Open
                (SNAPSHOT, PacketDeviceOpenAttributes.Promiscuous | PacketDeviceOpenAttributes.NoCaptureLocal, TIMEOUT));
                thr_list.Add(new Thread(Receiving));
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
                ListViewItem SrcMac = new ListViewItem(mac_cnt.ToString());//MAC id
                SrcMac.SubItems.Add(packet.Ethernet.Source.ToString());//MAC address
                SrcMac.SubItems.Add(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff"));//timestamps
                mac_table.Items.Add(SrcMac);//add SRC to MAC Table
                mac_buffer.Add(packet.Ethernet.Source);//add to MAC buffer
                mac_cnt++;
            }
        }

        //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void PacketHandler(Packet packet)
        {
            addMAC(packet);
        }

        //FRAME RECEIVING
        private void Receiving()
        {
            com_list[actual].ReceivePackets(AMOUNT, PacketHandler);
        }

        

        //BUTTON START CLICK
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < thr_list.Count; i++)
            {
                actual = i;
                if (thr_list[i].ThreadState.ToString().Equals("Suspended"))
                {
                    thr_list[i].Resume();
                }
                else
                {
                    thr_list[i].Start();
                }
            }
        }
        //BUTTON CLEAR CLICK
        private void buttonClear_Click(object sender, EventArgs e)
        {
            mac_table.Items.Clear();
            mac_buffer.Clear();
            mac_cnt = 0;
        }
        //BUTTON STOP CLICK
        private void buttonStop_Click(object sender, EventArgs e)
        {
        }
        //TABLE EVENT
        private void pktView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
