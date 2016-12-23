using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;

namespace LTC_Notify
{
    public class SiteFetcher
    {
        private WebClient webClient = new WebClient();
        private StreamReader reader = null;

        /// <summary>
        /// Ignore all SSL certificate errors
        /// </summary>
        public SiteFetcher()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
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
