using PcapDotNet.Packets.Ethernet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIP
{
    class Filter
    {
        private String srcIP;

        public String SrcIP
        {
            get { return srcIP; }
            set { srcIP = value; }
        }
        private String dstIP;

        public String DstIP
        {
            get { return dstIP; }
            set { dstIP = value; }
        }
        private String srcMAC;

        public String SrcMAC
        {
            get { return srcMAC; }
            set { srcMAC = value; }
        }
        private String dstMAC;

        public String DstMAC
        {
            get { return dstMAC; }
            set { dstMAC = value; }
        }
        Boolean UDP, TCP, ARP, ICMP;

        public Boolean ICMP1
        {
            get { return ICMP; }
            set { ICMP = value; }
        }

        public Boolean ARP1
        {
            get { return ARP; }
            set { ARP = value; }
        }

        public Boolean TCP1
        {
            get { return TCP; }
            set { TCP = value; }
        }

        public Boolean UDP1
        {
            get { return UDP; }
            set { UDP = value; }
        }
        public Filter(String srcIp, String dstIP, String srcMAC, String dstMAC, Boolean UDP, Boolean TCP, Boolean ARP, Boolean ICMP)
        {
            this.srcIP = srcIP;
            this.dstIP = dstIP;
            this.srcMAC = srcMAC;
            this.dstMAC = dstMAC;
            this.UDP = UDP;
            this.TCP = TCP;
            this.ARP = ARP;
            this.ICMP = ICMP;
        }
    }
}
