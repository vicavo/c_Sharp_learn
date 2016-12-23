using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTC_Notify
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class QueryConfig
    {
        public bool isBTC    { get; set; }  // true: BTC false: LTC
        public Int32 Interval { get; set; }
        public Int32 heartBeat { get; set; }
        public float NotifyBuyPrice { get; set; }
        public float NotifySellPrice { get; set; }
        public float PriceDeviation { get; set; }
    }
}
