using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;

namespace Com.Shuyz.VPN_Assistant
{
    public class SiteFetcher
    {
        private static SiteFetcher _instance = null;
        private static readonly object syncObject = new object();

        private WebClient webClient = new WebClient();
        private StreamReader reader = null;

        /// <summary>
        /// Ignore all SSL certificate errors
        /// </summary>
        private SiteFetcher()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        /// <summary>
        /// Get the instance of the class
        /// </summary>
        public static SiteFetcher Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (syncObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new SiteFetcher();
                        }
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// Read raw data from specified url
        /// </summary>
        /// <param name="webUrl"></param>
        /// <returns></returns>
        public StreamReader GetData(String webUrl)
        {
            this.reader = new StreamReader(this.webClient.OpenRead(webUrl));

            return this.reader;
        }

    }
}
