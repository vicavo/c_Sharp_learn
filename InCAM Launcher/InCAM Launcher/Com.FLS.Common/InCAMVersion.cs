using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace Com.FLS.Common
{
    /// <summary>
    /// InCAM version parser
    /// parse version no, changelist information from a version name
    /// </summary>
    public class InCAMVersion
    {
        private readonly string pattern = @"(InCAM)\.([\d,\.]*)([\d,\S]*)\.(\d+)\.(.*)";

        /* Example : InCAM.2.30SP5.135187.Win64 */
        private string _fullName = "";

        /* InCAM */
        private string _incamName = "";
        /* 2.30 */
        private string _mainVer = "";
        /* SP5 */
        private string _subVer = "";
        /* 135178 */
        private string _changelist = "";
        /* Win64 */
        private string _subfix = "";

        private bool _is_parsed = false;
        private bool _is_nameValid = false;

        public string FullName
        {
            get
            {
                return this._fullName;
            }
        }

        public bool IsNameValid
        {
            get
            {
                if (!_is_parsed)
                {
                    this.parse();
                }

                return this._is_nameValid;
            }
        }

        public string InCAMName
        {
            get
            {
                if(!_is_parsed)
                {
                    this.parse();
                }

                return this._incamName;
            }
        }

        public string MainVer
        {
            get
            {
                if (!_is_parsed)
                {
                    this.parse();
                }

                return this._mainVer;
            }
        }

        public string SubVer
        {
            get
            {
                if (!_is_parsed)
                {
                    this.parse();
                }

                return this._subVer;
            }
        }

        public string Changelist
        {
            get
            {
                if (!_is_parsed)
                {
                    this.parse();
                }

                return this._changelist;
            }
        }

        public string Subfix
        {
            get
            {
                if (!_is_parsed)
                {
                    this.parse();
                }

                return this._subfix;
            }
        }
          



        public InCAMVersion(string fullName)
        {
            this._fullName = fullName;

            /* parse when needed to speed up */
            //this.parse();
        }

        private void parse()
        {
            try
            {
                Match match = Regex.Match(this._fullName, this.pattern, RegexOptions.IgnoreCase);

                this._is_nameValid = match.Success;

                if (_is_nameValid)
                {
                    this._incamName = match.Groups[1].Value.ToString();
                    this._mainVer = match.Groups[2].Value.ToString();
                    this._subVer = match.Groups[3].Value.ToString();
                    this._changelist = match.Groups[4].Value.ToString();
                    this._subfix = match.Groups[5].Value.ToString();
                }
            }
            catch
            {
                this._is_nameValid = false;
            }
           
            this._is_parsed = true;
        }
    }
}
