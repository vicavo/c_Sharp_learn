using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTC_Notify
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class QueryResult
    {
        public DateTime refreshDate { get; set; }
        public float highPrice { get; set; }
        public float lowPrice { get; set; }
        public float buyPrice { get; set; }
        public float sellPrice { get; set; }
        public float lastPrice { get; set; }
        public float vol { get; set; }
    }
}
