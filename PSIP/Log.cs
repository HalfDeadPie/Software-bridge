using PcapDotNet.Packets.Ethernet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIP
{
    class Log
    {
        public Log(MacAddress MAC, DateTime timestamp, int port)
        {
            this.MAC = MAC;
            this.timestamp = timestamp;
            this.port = port;
        }
        public Log()
        {
        }

        private MacAddress MAC;//mac address

        public MacAddress MAC1
        {
            get { return MAC; }
            set { MAC = value; }
        }
        private DateTime timestamp;//time of last received

        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
        private int port;//pertaining port

        public int Port
        {
            get { return port; }
            set { port = value; }
        }            
    }
}
