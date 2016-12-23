using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Com.FLS.Common
{
    public class IncamDBItem
    {
        private string _access = "";
        private string _winpath = "";
        private string _nfspath = "";
        private string _name = "";

        public string Access
        {
            get
            {
                return this._access;
            }
        }

        public string ValidPath
        {
            get
            {
                if(Directory.Exists(this._access))
                {
                    return this._winpath;
                }
                else
                {
                    return this._nfspath;
                }
            }
        }

       /* public string Winpath
        {
            get
            {
                return this._winpath;
            }
        }

        public string Nfspath
        {
            get
            {
                return this._nfspath;
            }
        }*/

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public IncamDBItem(string access, string winpath, string nfspath, string name)
        {
            this._access = access;
            this._winpath = winpath;
            this._nfspath = nfspath;
            this._name = name;
        }
    }
}
