using PcapDotNet.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Retrieve the device list from the local machine
            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;

            if (allDevices.Count == 0)
            {
                Console.WriteLine("No interfaces found! Make sure WinPcap is installed.");
                return;
            }

            // Print the list
            for (int i = 0; i != allDevices.Count; i++)
            {
                LivePacketDevice device = allDevices[i];
                firstDev.Items.Add(new ListViewItem(device.Description.ToString()));
                secondDev.Items.Add(new ListViewItem(device.Description.ToString()));
            }
        }


        private void btnOpen_Click_1(object sender, EventArgs e)
        {
            int first = firstDev.SelectedIndices[0];
            int second = secondDev.SelectedIndices[0];
            var mainform = new Form2(first, second);
            mainform.Closed += (s, args) => this.Close();
            mainform.Show();
            this.Hide();
        }
    }
}
