using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Shuyz.VPN_Assistant
{
    public struct ServerInfo
    {
        public String location;
        public String ipAddress;
        public Int32 sessions;
        public String uptime;
        public Int32 ping;
        public String lineQuality;
        public String transfers;
        public String sslVPN;
        public String l2tp;
        public String openVPN;
        public String msSSTP;
        public String operatorInfo;
        public Int32 score;
    }
}
