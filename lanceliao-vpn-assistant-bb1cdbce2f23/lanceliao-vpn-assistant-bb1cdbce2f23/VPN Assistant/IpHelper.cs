using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Net.NetworkInformation;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Com.Shuyz.VPN_Assistant
{
    public class IpHelper
    {
        private static IpHelper _instance = null;
        private static readonly object syncObject = new object();

        private Thread pingThread = null;
        private Thread locateThread = null;

        private List<String> pingList = new List<String>();
        private List<String> locateList = new List<String>();

        private readonly String geoIPAPI = "http://freegeoip.net/xml/{0}";

        /// <summary>
        /// initialize thread on constructor
        /// </summary>
        private IpHelper()
        {
            pingThread = new Thread(new ThreadStart(ThreadPing));
            pingThread.IsBackground = true;

            locateThread = new Thread(new ThreadStart(ThreadLocate));
            locateThread.IsBackground = true;

            pingThread.Start();
            locateThread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        public static IpHelper Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (syncObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new IpHelper();
                        }
                    }
                }

                return _instance;
            }
        }

        #region - Locate -

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipAddress"></param>
        public void AddLocateItem(String ipAddress)
        {
            lock (this.locateList)
            {
                this.locateList.Add(ipAddress);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        private String LocateIP(String ipAddress)
        {
            StringBuilder location = new StringBuilder();

            try
            {
                using (WebClient webClient1 = new WebClient())
                {
                    var searchUrl = new Uri(string.Format(this.geoIPAPI, ipAddress));

                    string pageContent = Encoding.UTF8.GetString(webClient1.DownloadData(searchUrl));

                    using (XmlTextReader reader = new XmlTextReader(new StringReader(pageContent)))
                    {
                        StringBuilder country = new StringBuilder();
                        StringBuilder region = new StringBuilder();
                        StringBuilder city = new StringBuilder();

                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                switch (reader.Name)
                                {
                                    case "CountryName": country.Append(reader.ReadString()); break;
                                    case "RegionName": region.Append(reader.ReadString()); break;
                                    case "City": city.Append(reader.ReadString()); break;
                                    default: ; break;
                                }
                            }
                        }

                        location.Append(String.Empty == city.ToString() ? "" : city.ToString() + ", ");
                        location.Append(String.Empty == region.ToString() ? "" : region.ToString() + ", ");
                        location.Append(String.Empty == country.ToString() ? "" : country.ToString());
                    }
                }

                return location.ToString();
            }

            catch (System.Exception ex)
            {
                throw (new System.Exception("Failed to locate IP: " + ex.Message.ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadLocate()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(200);

                if (0 != this.locateList.Count)
                {
                    String firstItem = this.locateList[0];
                    String location = "";

                    try
                    {
                        location = this.LocateIP(firstItem);
                    }

                    catch (System.Exception)
                    {
                        location = "Failed to locate IP";
                    }

                    finally
                    {
                        if (MainForm.Instance.InvokeRequired)
                        {
                            MainForm.Instance.Invoke(new MethodInvoker(delegate()
                            {
                                UserMsg.SendMessage(MainForm.Instance.Handle, (Int32)UserMsg.Messages.WM__LOCATE_RESULT, location, firstItem);
                            }));
                        }
                        else
                        {
                            UserMsg.SendMessage(MainForm.Instance.Handle, (Int32)UserMsg.Messages.WM__LOCATE_RESULT, location, firstItem);
                        }  

                        lock (this.locateList)
                        {
                            this.locateList.RemoveAt(0);
                        }
                    }
                }
            }
        }

        #endregion

        #region - Ping -

        /// <summary>
        /// Add ip address to ping task list
        /// </summary>
        /// <param name="ipAddress"></param>
        public void AddPingItem(String ipAddress)
        {
            lock (this.pingList)
            {
                this.pingList.Add(ipAddress);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        private Int32 PingIP(String ipAddress)
        {
            byte[] pingData = Encoding.ASCII.GetBytes("today is sunny, I went out for hiking");
            PingOptions options = new PingOptions();
            options.DontFragment = true;

            using(Ping pingItem = new Ping())
            {
                PingReply reply = pingItem.Send(ipAddress, 1000, pingData, options);

                if (reply.Status == IPStatus.Success)
                {
                    return (Int32)reply.RoundtripTime;
                }
                else
                {
                   throw(new System.Exception("Destination " + ipAddress + " unreachable!"));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadPing()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(200);

                if (0 != this.pingList.Count)
                {
                    String firstItem = this.pingList[0];

                    Int32 delay = 0;

                    try
                    {
                        delay = this.PingIP(firstItem); 
                    }

                    catch (System.Exception)
                    {
                        delay = -1;
                    }

                    finally
                    {
                        if (MainForm.Instance.InvokeRequired)
                        {
                            MainForm.Instance.Invoke(new MethodInvoker(delegate()
                            {
                                UserMsg.SendMessage(MainForm.Instance.Handle, (Int32)UserMsg.Messages.WM_PING_RESULT, delay, firstItem);
                            }));
                        }
                        else
                        {
                            UserMsg.SendMessage(MainForm.Instance.Handle, (Int32)UserMsg.Messages.WM_PING_RESULT, delay, firstItem);
                        }  

                        lock (this.pingList)
                        {
                            this.pingList.RemoveAt(0);
                        }
                    }
                }
            }
        }

        #endregion

    }
}
