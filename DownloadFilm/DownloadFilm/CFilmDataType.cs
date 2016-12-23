using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadFilm
{
    class CFilmDataType
    {
        public string _strName  { get; set; }
        public string _strUrl { get; set; }
        public string _strTime { get; set; }
        public CFilmDataType(string strUrl,string strName,string strTime)
        {
            _strUrl = strUrl;
            _strName = strName;
            _strTime = strTime;
        }
        

    }

}
