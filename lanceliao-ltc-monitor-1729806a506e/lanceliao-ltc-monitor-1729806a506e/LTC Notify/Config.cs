using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

using System.IO.Ports;

namespace LTC_Notify
{
    /// <summary>
    /// System Configuration singleton class
    /// </summary>
    public sealed class Config
    {
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        #region - Singleton -

        private static Config _instance = null;
        private static readonly object syncObject = new object();

        /// <summary>
        /// Construction method
        /// </summary>
        private Config()
        {
            this.ReadConfig();
        }

        /// <summary>
        /// Get the instance of configuration
        /// </summary>
        public static Config Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (syncObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new Config();
                        }
                    }
                }

                return _instance;
            }
        }
        #endregion

        private static readonly String configFile = System.Environment.CurrentDirectory + "\\Config.ini";
        public QueryConfig queryConfig = new QueryConfig();

        /// <summary>
        /// write config file
        /// </summary>
        /// <returns></returns>
        public bool WriteConfig()
        {
            if (System.IO.File.Exists(configFile))
            {
                bool result = true;
                this.validateConfig();

                result &= this.WriteIniData("QUERYCFG", "ApiType", this.queryConfig.isBTC ? "BTC" : "LTC", configFile);
                result &= this.WriteIniData("QUERYCFG", "Interval", this.queryConfig.Interval.ToString(),configFile);
                result &= this.WriteIniData("QUERYCFG", "HeartBeat", this.queryConfig.heartBeat.ToString(),configFile);
                result &= this.WriteIniData("QUERYCFG", "NotifyBuyPrice", this.queryConfig.NotifyBuyPrice.ToString(), configFile);
                result &= this.WriteIniData("QUERYCFG", "NotifySellPrice", this.queryConfig.NotifySellPrice.ToString(), configFile);
                result &= this.WriteIniData("QUERYCFG", "PriceDeviation", this.queryConfig.PriceDeviation.ToString(), configFile);

                return result;
            }
            else
            {
                throw new System.InvalidOperationException("配置文件" + configFile + "不存在!请检查安装文件是否完整！");
            }
        }

        /// <summary>
        /// Read config file
        /// </summary>
        private void ReadConfig()
        {
            if (System.IO.File.Exists(configFile))
            {
                // API type
                this.queryConfig.isBTC = ("BTC" == this.ReadIniData("QUERYCFG", "ApiType", "LTC", configFile) ? true : false);

                // Interval
                this.queryConfig.Interval = Int32.Parse(this.ReadIniData("QUERYCFG", "Interval", "2000", configFile));

                // HeartBeat
                this.queryConfig.heartBeat = Int32.Parse(this.ReadIniData("QUERYCFG", "HeartBeat", "200", configFile));

                // NotifyBuyPrice
                this.queryConfig.NotifyBuyPrice = float.Parse(this.ReadIniData("QUERYCFG", "NotifyBuyPrice", "260.0", configFile));

                // NotifySellPrice
                this.queryConfig.NotifySellPrice = float.Parse(this.ReadIniData("QUERYCFG", "NotifySellPrice", "265.0", configFile));
                
                // PriceDevition
                this.queryConfig.PriceDeviation = float.Parse(this.ReadIniData("QUERYCFG", "PriceDeviation", "0.1", configFile));
        
                this.validateConfig();
            }
            else
            {
                throw new System.InvalidOperationException("配置文件" + configFile + "不存在!请检查安装文件是否完整！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void validateConfig()
        {
            this.queryConfig.Interval =  this.queryConfig.Interval < 1000 ? 1000 : this.queryConfig.Interval;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="NoText"></param>
        /// <param name="iniFilePath"></param>
        /// <returns></returns>
        private String ReadIniData(String Section, String Key, String NoText, String iniFilePath)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
            
            return temp.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <param name="iniFilePath"></param>
        /// <returns></returns>
        private bool WriteIniData(string Section, string Key, string Value, string iniFilePath)
        {
            return WritePrivateProfileString(Section, Key, Value, iniFilePath);
        }
    }
}
