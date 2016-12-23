using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LTC_Notify
{
    public class ContentParser 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverList"></param>
        /// <param name="rawContent"></param>
       public void ParseAll(ref QueryResult result, ref StreamReader rawContent)
       {
           string str = rawContent.ReadToEnd();

           var items = JsonConvert.DeserializeObject<dynamic>(str);

           result.refreshDate = DateTime.Now;
           result.highPrice = items.ticker.high;
           result.lowPrice = items.ticker.low;
           result.lastPrice = items.ticker.last;
           result.vol = items.ticker.vol;
           result.buyPrice = items.ticker.buy;
           result.sellPrice = items.ticker.sell;

           rawContent.Close();
       }

    }
}
