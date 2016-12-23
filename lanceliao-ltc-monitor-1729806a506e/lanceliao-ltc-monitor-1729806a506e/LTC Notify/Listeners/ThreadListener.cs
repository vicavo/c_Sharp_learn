using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTC_Notify
{
    /// <summary>
    /// broadcast receiver from thread
    /// </summary>
    public interface ThreadListener
    {
        void OnStartQuery(DateTime lastQueryTime);
        void OnDataReceived(QueryResult result);
        void OnHeartBeat(UInt32 timeLeft);
        void OnErrors(DateTime lastErrTime, string errMsg);
    }
}
