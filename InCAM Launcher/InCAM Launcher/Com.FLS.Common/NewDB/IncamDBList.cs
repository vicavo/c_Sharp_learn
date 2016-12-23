using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.IO;

namespace Com.FLS.Common
{
    public class IncamDBlist
    {
        private string _dbListFile = "";
        private int _dbCount = 0;
        private List<IncamDBItem> _dbList = new List<IncamDBItem>();

        public string DbListFile
        {
            get
            {
                return this._dbListFile;
            }
        }

        public int DbCount
        {
            get
            {
                return this._dbCount;
            }
        }

        public List<IncamDBItem> DbList
        {
            get
            {
                return this._dbList;
            }
        }

        public IncamDBlist(string dbListFile)
        {
            this._dbListFile = dbListFile;

            this.parseDbListItems(this._dbListFile);
        }

        private void parseDbListItems(string dbListFile)
        {
            using (XmlReader reader = XmlReader.Create(dbListFile))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(dbListFile);

                var dbs = doc.GetElementsByTagName("db");
                this._dbCount = dbs.Count;

                foreach (XmlElement db in dbs)
                {
                    string access = db.GetAttribute("access");
                    string winpath = db.GetAttribute("winpath");
                    string nfspath = db.GetAttribute("nfspath");
                    string name = db.GetAttribute("name");

                    IncamDBItem item = new IncamDBItem(access, winpath, nfspath, name);

                    this._dbList.Add(item);
                }
            }
        }
    }
}

