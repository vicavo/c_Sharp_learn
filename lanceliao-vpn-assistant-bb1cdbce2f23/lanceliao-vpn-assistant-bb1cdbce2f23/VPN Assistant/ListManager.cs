using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Com.Shuyz.VPN_Assistant
{
    public class ListManager
    {
        private static ListManager _instance = null;
        private static readonly object syncObject = new object();

        /// <summary>
        /// 
        /// </summary>
        public static ListManager Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (syncObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new ListManager();
                        }
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// Find specified IP address in the list and set ping value of the row
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ipAddress"></param>
        /// <param name="value"></param>
        public void SetPingValue(ref DataGridView list, String ipAddress, Int32 value)
        {
            foreach (DataGridViewRow row in list.Rows)
            {
                if ((null != row.Cells[3].Value) && (row.Cells[3].Value.ToString() == ipAddress))
                {
                    row.Cells[6].Value = value;

                    break;
                }
            }
        }

        /// <summary>
        /// Find specified IP address in the list and set location value of the row
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ipAddress"></param>
        /// <param name="geoAddress"></param>
        public void SetLocateValue(ref DataGridView list, String ipAddress, String geoAddress)
        {
            foreach (DataGridViewRow row in list.Rows)
            {
                if ((null != row.Cells[3].Value) && (row.Cells[3].Value.ToString() == ipAddress))
                {
                    row.Cells[2].Value = geoAddress;

                    break;
                }
            }
        }

        /// <summary>
        /// Save the content of DataGridView to file
        /// </summary>
        /// <param name="list"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool SerializeList(ref DataGridView list, String fileName)
        {
            try
            {
                if (0 == list.Rows.Count)
                {
                    return false;
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        StringBuilder builder = null;
                        foreach (DataGridViewRow row in list.Rows)
                        {
                            builder = new StringBuilder();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                builder.Append(cell.Value.ToString() + ";\t");
                            }
                            writer.WriteLine(builder.ToString());
                        }
                        writer.Close();
                    }

                    return true;
                }
            }
            catch (System.Exception ex)
            {
                throw (new System.Exception("Failed to serialize server list, " + ex.Message.ToString()));
            }
        }

        /// <summary>
        /// Load the content of DataGridView from file
        /// </summary>
        /// <param name="list"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool ParseList(ref DataGridView list, String fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] info = Regex.Split(reader.ReadLine(), ";\t");
                        if (16 == info.Count())
                        {
                            list.Rows.Add(false, list.Rows.Count + 1, info[2], info[3], Convert.ToInt32(info[4]), info[5], Convert.ToInt32(info[6]), info[7], info[8], info[9], info[10], info[11], info[12], info[13], Convert.ToInt32(info[14]));
                        }
                    }
                    reader.Close();
                }

                return true;
            }
            catch (System.Exception ex)
            {
                throw (new System.Exception("Failed to load list content from file! " + ex.Message.ToString()));
            }
        }

    }
}
