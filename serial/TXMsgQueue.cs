using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using  Shuyz.Communication.Protocol;

namespace Shuyz.Communication.PLC
{
    /// <summary>
    /// threading-safe message queue
    /// </summary>
    public sealed class TXMsgQueue
    {
        private Queue<TXMsg> PLCMsgs = new Queue<TXMsg>();
        private readonly object syncObject = new object();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int32 Count()
        {
            lock (this.syncObject)
            {
                return this.PLCMsgs.Count();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void Enqueue(TXMsg msg)
        {
            lock (this.syncObject)
            {
                this.PLCMsgs.Enqueue(msg);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dequeue()
        {
            lock (this.syncObject)
            {
                if (this.PLCMsgs.Count > 0)
                {
                    this.PLCMsgs.Dequeue();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TXMsg Peek()
        {
            lock (this.syncObject)
            {
                if (this.PLCMsgs.Count > 0)
                {
                    return this.PLCMsgs.Peek();
                }
                else
                {
                    return new TXMsg();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void PeekErrAdd()
        {
            lock (this.syncObject)
            {
                if (this.PLCMsgs.Count > 0)
                {
                    this.PLCMsgs.Peek().failedCnt++;
                }
            }
        }
    }
}
