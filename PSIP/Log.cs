using PcapDotNet.Packets.Ethernet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace PSIP
{
    class Log
    {
        //MAIN CONSTRUCTOR
        public Log(MacAddress MAC, DateTime timestamp, int port, int time, Hashtable ht, ListViewItem item)
        {
            this.mac = MAC;
            this.timestamp = timestamp;
            this.port = port;
            this.parent = ht;
            this.item = item;
            this.timer = new System.Timers.Timer(time);
            this.timer.Start();
            timer.Elapsed += OnTimedEvent;
        }
        //PARENT LIST VIEW
        

        //ITEM IN LIST VIEW
        public ListViewItem item;
        public ListViewItem Item
        {
            get { return item; }
            set { item = value; }
        }

        //PARENT HASHTABLE
        private Hashtable parent;
        public Hashtable Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        //TIMER ELAPSED METHOD
        public System.Timers.Timer timer;
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            this.item.Remove();
            this.parent.Remove(this);
        }

        //MACADDRESS
        private MacAddress mac;//mac address
        public MacAddress MAC
        {
            get { return mac; }
            set { mac = value; }
        }
        //TIMESTAMP
        private DateTime timestamp;//time of last received
        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
        //PERTAINING PORT
        private int port;
        public int Port
        {
            get { return port; }
            set { port = value; }
        }
        //CONSTRUCTOR
        public Log()
        {
        } 
    }
}
