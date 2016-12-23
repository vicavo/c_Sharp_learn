using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.IO;

namespace Com.Shuyz.VPN_Assistant
{
    public class ExportHelper
    {
        private static ExportHelper _instance = null;
        private static readonly object syncObject = new object();

        /// <summary>
        /// 
        /// </summary>
        public static ExportHelper Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (syncObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new ExportHelper();
                        }
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// Export Packetix VPN Client connection setting
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <param name="hubname"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool ExportSSL_VPNSetting(String hostname, String port, String hubname, String username)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "VPN Connection Setting Files (*.VPN)|*.VPN";
                dialog.FileName = hostname + "(" + hubname + ").VPN";

                if (DialogResult.OK == dialog.ShowDialog())
                {
                    String accountname = System.IO.Path.GetFileName(dialog.FileName);
                    accountname = accountname.Substring(0, accountname.Length - 4); // remove the extension

                    // read template from resource file
                    byte[] content = global::Com.Shuyz.VPN_Assistant.Properties.Resources.ssl_vpn_tpl;
                    string tpl = System.Text.UTF8Encoding.UTF8.GetString(content);

                    StringBuilder builder = new StringBuilder();
                    builder.Append(tpl);

                    builder.Replace("#accountname#", accountname);
                    builder.Replace("#hostname#", hostname);
                    builder.Replace("#port#", port);
                    builder.Replace("#hubname#", hubname);
                    builder.Replace("#username#", username);

                    using (StreamWriter writer = new StreamWriter(dialog.FileName))
                    {
                        writer.Write(builder.ToString());
                        writer.Close();
                    }

                    return true;
                }
            }

            return false;
        }

    }
}
