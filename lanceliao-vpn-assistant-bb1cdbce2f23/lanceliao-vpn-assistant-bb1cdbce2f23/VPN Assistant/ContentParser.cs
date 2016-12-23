using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Text.RegularExpressions;

namespace Com.Shuyz.VPN_Assistant
{
    public class ContentParser 
    {
        private static ContentParser _instance = null;
        private static readonly object syncObject = new object();

        private readonly String serverLinePattern = @"\<td class=\'vg_table_row_[0,1]{1}\' style=\'text-align\: center\;\'\>\<img src\=.*\<\/td\>";
        private readonly String lineItemsPattern = @"\<td.*?\<\/td>";

        private readonly String countryPattern = @"\<br\>.*\<\/td\>";
        private readonly String ipPattern = @"([0-9]{1,3}\.){3}[0-9]{1,3}";
        private readonly String sessionPattern = @"\d+ sessions";
        private readonly String uptimePattern = @"9pt\;\'\>.*\<\/span\>";
        private readonly String lineQualityPattern = @"10pt\;\'\>.*\<\/span\>";
        private readonly String transfersPattern = @"\<BR\>\<BR\>\<b\>.*\<\/b\>";
        private readonly String sslVPNPattern = @"TCP: \d+|UDP: Supported";
        private readonly String l2tpPattern = @"L2TP\/IPsec";
        private readonly String openVPNPattern = @"TCP: \d+|UDP: \d+";
        private readonly String msSSTPPattern = @"SSTP Hostname.*\>(.*\..*\..*?)<\/span>";
        private readonly String operatorPattern = @"\<b\>.*\<\/b\>";
        private readonly String scorePattern = @"[0123456789,]+\<\/span\>";

        /// <summary>
        /// Get the instance of the class
        /// </summary>
        public static ContentParser Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (syncObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new ContentParser();
                        }
                    }
                }

                return _instance;
            }
        }

        #region - Parse Items -

        /// <summary>
        /// <td class='vg_table_row_1' style='text-align: center;'><img src='../images/flags/KR.png' width='32' height='32' /><br>Korea Republic of</td>
        /// </summary>
        /// <param name="locationRaw"></param>
        /// <returns></returns>
        private String ParseLocation(String locationRaw)
        {
            Match match = Regex.Match(locationRaw, this.countryPattern);
            if (match.Success)
            {
                String tmp = match.Value.ToString();
                tmp =  tmp.Substring(4, tmp.Length - 4 - 5);

                return tmp;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawAddress"></param>
        /// <returns></returns>
        private String ParseIPAddress(String rawAddress)
        {
            MatchCollection matchs = Regex.Matches(rawAddress, this.ipPattern); // we may got more than one IP address here

            if (matchs.Count >= 0)
            {
                return matchs[0].Value.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawSession"></param>
        /// <returns></returns>
        private Int32 ParseSession(String rawSession)
        {
            Match match = Regex.Match(rawSession, this.sessionPattern);

            if (match.Success)
            {
                String tmp = match.Value.ToString();

                tmp = tmp.Substring(0, tmp.Length - 9);

                return Convert.ToInt32(tmp);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uptimeRaw"></param>
        /// <returns></returns>
        private String ParseUptime(String uptimeRaw)
        {
            Match match = Regex.Match(uptimeRaw, this.uptimePattern);

            if(match.Success)
            {
                String tmp = match.Value.ToString();

                tmp = tmp.Substring(6, tmp.Length - 6 - 7);

                return tmp;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qualityRaw"></param>
        /// <returns></returns>
        private String ParseLineQuality(String qualityRaw)
        {
            Match match = Regex.Match(qualityRaw, this.lineQualityPattern);

            if (match.Success)
            {
                String tmp = match.Value.ToString();
                tmp = tmp.Substring(7, tmp.Length - 7 - 7);

                return tmp;
            }

            else
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transferRaw"></param>
        /// <returns></returns>
        private String ParseTransfer(String transferRaw)
        {
            Match match = Regex.Match(transferRaw, this.transfersPattern);

            if (match.Success)
            {
                String tmp = match.Value.ToString();
                tmp = tmp.Substring(11, tmp.Length - 11 - 4);

                return tmp;
            }

            else
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sslVPNRaw"></param>
        /// <returns></returns>
        private String ParseSSLVPN(String sslVPNRaw)
        {
            MatchCollection matches = Regex.Matches(sslVPNRaw, this.sslVPNPattern);

            String tmp = "";

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    tmp += match.Value.ToString() + ";";
                }

                return tmp;
            }

            else
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l2tpRaw"></param>
        /// <returns></returns>
        private String ParseL2TP(String l2tpRaw)
        {
            Match match = Regex.Match(l2tpRaw, this.l2tpPattern);

            if (match.Success)
            {
                return "Supported";
            }

            else
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operatorRaw"></param>
        /// <returns></returns>
        private String  ParseOperator(String operatorRaw)
        {
            Match match = Regex.Match(operatorRaw, this.operatorPattern);

            if (match.Success)
            {
                String tmp = match.Value.ToString();

                tmp = tmp.Substring(3, tmp.Length - 3 -4);

                return tmp;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// <td class="vg_table_row_0" style="text-align: center;"><a href="do_openvpn.aspx?fqdn=&amp;ip=118.35.102.69&amp;tcp=995&amp;udp=1195&amp;sid=1371037711587&amp;hid=16441"><img height="33" src="../images/yes_33.png" width="33"><br><b>OpenVPN<br>Config file</b></a><br>TCP: 995<br>UDP: 1195</td>
        /// </summary>
        /// <param name="openVPNRaw"></param>
        /// <returns></returns>
        private String ParseOpenVPN(String openVPNRaw)
        {
            MatchCollection matches = Regex.Matches(openVPNRaw, this.openVPNPattern);

            String tmp = "";

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    tmp += match.Value.ToString() + ";";
                }

                return tmp;
            }

            else
            {
                return "";
            }
        }

        /// <summary>
        /// <td class="vg_table_row_0" style="text-align: center; word-break: break-all; white-space: normal;"><a href="howto_sstp.aspx"><img height="33" src="../images/yes_33.png" width="33"><br><b>MS-SSTP<br>Connect guide</b></a><p style="text-align: left"><span style="font-size: 8pt;">SSTP Hostname :<br><b><span style="color: #006600;">vg33157524.opengw.net:995</span></b></span></p></td>
        /// OR
        /// <td class="vg_table_header"><b>MS-SSTP</b><br>Windows Vista,<br>7, 8, RT<br>No client required</td>
        /// </summary>
        /// <param name="msSSTPRaw"></param>
        /// <returns></returns>
        private String ParseMS_SSTP(String msSSTPRaw)
        {
            Match match = Regex.Match(msSSTPRaw, this.msSSTPPattern);

            if (match.Success)
            {
                return match.Groups[1].Value.ToString();
            }

            else
            {
                return "";
            }
        }

        /// <summary>
        /// <td class='vg_table_row_0' style='text-align: right;'><b><span style='font-size: 9pt;'>78,483</span></b></td>
        /// </summary>
        /// <param name="scoreRaw"></param>
        /// <returns></returns>
        private Int32 ParseScore(String scoreRaw)
        {
            Match match = Regex.Match(scoreRaw, this.scorePattern);

            if (match.Success)
            {
                String tmp = match.Value.ToString();

                tmp = tmp.Substring(0, tmp.Length - 7);
                tmp = tmp.Replace(",", "");

                return Convert.ToInt32(tmp);
            }
            else
            {
                return 0;
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="lineContent"></param>
        /// <returns></returns>
       private bool ParseOneLine(ref ServerInfo info, String lineContent)
        {
            Match serverInfoLine = Regex.Match(lineContent, this.serverLinePattern);

            if (serverInfoLine.Success)
            {
                MatchCollection rawItems = Regex.Matches(serverInfoLine.Value.ToString(), this.lineItemsPattern);

                if (10 == rawItems.Count) // one row has 10 items
                {
                    info.location = this.ParseLocation(rawItems[0].Value.ToString());
                    info.ipAddress = this.ParseIPAddress(rawItems[1].Value.ToString());

                    info.sessions = this.ParseSession(rawItems[2].Value.ToString());
                    info.uptime = this.ParseUptime(rawItems[2].Value.ToString());

                    //ping(do not parse ping)
                    info.ping = 0;

                    info.lineQuality = this.ParseLineQuality(rawItems[3].Value.ToString());
                    info.transfers = this.ParseTransfer(rawItems[3].Value.ToString());

                    info.sslVPN = this.ParseSSLVPN(rawItems[4].Value.ToString());
                    info.l2tp = this.ParseL2TP(rawItems[5].Value.ToString());
                    info.openVPN = this.ParseOpenVPN(rawItems[6].Value.ToString());
                    info.msSSTP = this.ParseMS_SSTP(rawItems[7].Value.ToString());
                    info.operatorInfo = this.ParseOperator(rawItems[8].Value.ToString());
                    info.score = this.ParseScore(rawItems[9].Value.ToString());

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverList"></param>
        /// <param name="rawContent"></param>
       public void ParseAll(ref List<ServerInfo> serverList, ref StreamReader rawContent)
       {
           ServerInfo info = new ServerInfo();

           while (!rawContent.EndOfStream)
           {
               String str = rawContent.ReadLine();

               if (this.ParseOneLine(ref info, str))
               {
                   serverList.Add(info);
               }

               else
               {
                   continue;
               }
           }
       }

    }
}
