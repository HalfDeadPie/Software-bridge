using PcapDotNet.Core;
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
        private Packet packet;//paket
        private int mac_cnt;//pocitadlo unikatnych mac adries
        private List<MacAddress> mac_buffer;//buffer s mac adresami
        private IList<LivePacketDevice> allDevices;////list so vsetkymi zariadeniami
        private List<Thread> thr_list;//list so vsetkymi threadmi
        private List<PacketCommunicator> com_list;//list so vsetkymi komunikatormi
        private int actual;
        //KONSTANTY
        private const int SNAPSHOT = 65536, TIMEOUT = 1000, AMOUNT = 5;
        public Form2()
        {
            //INICIALIZACIA
            InitializeComponent();
            Show();
            mac_cnt = 0;
            mac_buffer = new List<MacAddress>();
            allDevices = LivePacketDevice.AllLocalMachine;
            com_list = new List<PacketCommunicator>();
            thr_list = new List<Thread>();
            //otvori komunikator pre kazde zariadenie a prida ho do com_list + vypis do tabulky
            for (int i = 0; i < allDevices.Count; i++)
            {
                LivePacketDevice tempDevice = allDevices[i];
                ListViewItem row = new ListViewItem(tempDevice.Name);
                listDevices.Items.Add(row);//tu asi vytvor temp communicator
                com_list.Add(tempDevice.Open
                (SNAPSHOT, PacketDeviceOpenAttributes.Promiscuous | PacketDeviceOpenAttributes.NoCaptureLocal, TIMEOUT));
                thr_list.Add(new Thread(Receiving));
            }
        }


        //HLAVNY HANLDER
        //spracovanie ramcov
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void PacketHandler(Packet packet)
        {
            ListViewItem SrcMac = new ListViewItem(mac_cnt.ToString());//id unikatnej MAC adresy
            SrcMac.SubItems.Add(packet.Ethernet.Source.ToString());//MAC ADRESA
            SrcMac.SubItems.Add(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff"));//cas prijatia posledneho ramca
            mac_table.Items.Add(SrcMac);//pridanie do tabulky MAC adries

            mac_buffer.Add(packet.Ethernet.Source);//pridanie do bufferu mac adries
            mac_cnt++;//inkrementacia pocitadla uniq mac adries
            //textPacket.AppendText("/nDST:" + packet.Ethernet.IpV4.Destination.ToString());
            //textPacket.AppendText("/nSRC:" + packet.Ethernet.IpV4.Source.ToString());
            //communicator.SendPacket(packet);//odoslanie paketu tam, odkial prišiel

           // textPacket.AppendText(Thread.CurrentThread.ApartmentState.ToString() + "\n");
            textPacket.AppendText(packet.Ethernet.ToHexadecimalString()+"\n-----------\n");
        }
        //manualaneodoslanie vybraneho ramca na vybrane zariadenie --toto netreba brať do uvahy

        //prijatie ramcov
        private void Receiving()
        {
            com_list[actual].ReceivePackets(AMOUNT, PacketHandler);
        }
        //akcia pri zmene oznaceneho ramca
        private void pktView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = Int32.Parse(mac_table.SelectedItems[0].Text);
                MacAddress tmpMAC = mac_buffer.ElementAt(index);
                textPacket.ResetText();

            }
            catch (Exception E)
            {
            }
        }

        //akcie tlacidiel - tu skusim spustit vsetky thready nacitame v liste
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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            mac_table.Items.Clear();
            mac_buffer.Clear();
            mac_cnt = 0;
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            thr_list[0].Suspend();
        }
    }
}
