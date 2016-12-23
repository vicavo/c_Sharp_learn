using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcCmdTime
{
    class CTimeCalc
    {


        public CTimeCalc()
        {

        }

        public static string stringTimeMinus(string strStartTime,string strEndTime)
        {

            DateTime StartTime = new DateTime();
            StartTime = DateTime.Parse(strStartTime);
            DateTime EndTime = new DateTime();
            EndTime = DateTime.Parse(strEndTime);
            TimeSpan TimeDiff = EndTime - StartTime;

            return TimeDiff.ToString();
        }

    }
}
