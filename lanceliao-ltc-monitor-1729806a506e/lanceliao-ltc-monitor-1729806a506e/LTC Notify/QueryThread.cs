using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.IO;

namespace LTC_Notify
{
    public class QueryThread
    {
        private List<ThreadListener> listeners = new List<ThreadListener>();
        private Thread queryThread = null;
        private volatile Int32 heartBeatTotal = 0;

        private QueryResult queryResult = new QueryResult();

        private readonly string ltcApi = @"https://www.okcoin.com/api/ticker.do?symbol=ltc_cny";
        private readonly string btcApi = @"https://www.okcoin.com/api/ticker.do";
        private SiteFetcher fetcher = new SiteFetcher(); 
        private ContentParser parser = new ContentParser();

        /// <summary>
        /// 
        /// </summary>
        public QueryThread()
        {
            this.queryThread = new Thread(new ThreadStart(this.QueryThreadDo));
            this.queryThread.IsBackground = true;
            this.queryThread.Name = "Query Thread";            
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartQuery()
        {
            this.queryThread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        public void QueryNow()
        {
            this.heartBeatTotal = Config.Instance.queryConfig.Interval;
        }

        /// <summary>
        /// 
        /// </summary>
        private void QueryThreadDo()
        {
            while (true)
            {
                try
                {
                    if (Config.Instance.queryConfig.Interval - this.heartBeatTotal <= 0)
                    {
                        this.heartBeatTotal = 0;

                        // start
                        foreach (ThreadListener listener in this.listeners)
                        {
                            listener.OnStartQuery(DateTime.Now);
                        }

                        // query
                        StreamReader webContent = this.fetcher.GetData(Config.Instance.queryConfig.isBTC ? this.btcApi : this.ltcApi);
                        this.parser.ParseAll(ref this.queryResult, ref webContent);

                        // receive
                        foreach (ThreadListener listener in this.listeners)
                        {
                            listener.OnDataReceived(this.queryResult);
                        }
                    }
                   
                    // heartbeat
                    foreach (ThreadListener listener in this.listeners)
                    {
                        listener.OnHeartBeat((Config.Instance.queryConfig.Interval - this.heartBeatTotal) < 0 ? 0 : (UInt32)(Config.Instance.queryConfig.Interval - this.heartBeatTotal));
                    }
                    Thread.Sleep(Config.Instance.queryConfig.heartBeat);
                    this.heartBeatTotal += Config.Instance.queryConfig.heartBeat;

                }
                catch (System.Exception ex)
                {
                    foreach (ThreadListener listener in this.listeners)
                    {
                        listener.OnErrors(DateTime.Now, ex.Message.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listener"></param>
        public void RegisterReceiveListener(ThreadListener listener)
        {
            if (!this.listeners.Contains(listener))
            {
                this.listeners.Add(listener);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listener"></param>
        public void DeRegisterReceiveListener(ThreadListener listener)
        {
            if (this.listeners.Contains(listener))
            {
                this.listeners.Remove(listener);
            }
        }
    }
}
