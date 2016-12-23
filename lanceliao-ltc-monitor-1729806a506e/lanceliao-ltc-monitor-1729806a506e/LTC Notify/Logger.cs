using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace LTC_Notify
{
    public  sealed class Logger
    {
        private static Logger _instance = null;
        private static readonly object syncObject = new object();

        private String logFIleFullName;

        private BinaryWriter writer = null;
        private Stream stream = null;

        /// <summary>
        /// Construction method
        /// </summary>
        private Logger()
        {
            this.createLogFile();
        }

        /// <summary>
        /// 
        /// </summary>
        ~Logger()
        {
            this.writer.Close();
            this.stream.Close();
        }

        /// <summary>
        /// Get the instance of class
        /// </summary>
        public static Logger Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (syncObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new Logger();
                        }
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void createLogFile()
        {
            this.logFIleFullName = "ltc.log";

            this.stream = new FileStream(this.logFIleFullName, FileMode.Append);
            this.writer = new BinaryWriter(this.stream);

//             this.writeLog("更新时间" + "\t"
//                 + "买入价格" + "\t"
//                 + "卖出价格" + "\t"
//                 + "最高价" + "\t"
//                 + "最低价" + "\t"
//                 + "最后成交价" + "\t"
//                 + "交易量");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool writeLog(String content)
        {
            if (null != this.stream)
            {
                this.writer.Write(content + "\r\n");
                this.writer.Flush();
            }
          
            return true;
        }
    }
}
