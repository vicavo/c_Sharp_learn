using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shuyz.Communication.Protocol;

namespace Shuyz.Communication.PLC
{
    /// <summary>
    /// serial communication event listener
    /// </summary>
    public interface PLCListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="result"></param>
        void HandlePLCReceivedData(string portName, RXMsg result);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="dt"></param>
        /// <param name="sendMsg"></param>
        /// <param name="errMsg"></param>
        void HandlePLCCommunicationErrs(string portName, DateTime dt, TXMsg sendMsg, String errMsg);
    }
}
