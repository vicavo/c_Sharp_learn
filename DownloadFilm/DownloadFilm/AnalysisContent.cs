using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DownloadFilm
{
    class AnalysisContent
    {
        string _strContent;
        string _strAnalysis = "<li><a href=\"(.*?)\".*FF0000'>(.*?)<\\/font.*red>(.*?)<\\/font";

        List<CFilmDataType> _list_result;
        
        public AnalysisContent(string strcontent)
        {
            this._strContent = strcontent;
            
            this._list_result = new List<CFilmDataType>();

        }
        public List<CFilmDataType> ProcessContentWithUsingRegularExpression()
        {
            MatchCollection matches = Regex.Matches(_strContent, this._strAnalysis);
            // if (matches.Count < 3) return strTranslateContent;

            string strUrl = string.Empty;
            string strName = string.Empty;
            string strTime = string.Empty;
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Groups.Count < 4) continue;

                strUrl = matches[i].Groups[1].Value.ToString();
                strName = matches[i].Groups[2].Value.ToString();
                strTime = matches[i].Groups[3].Value.ToString();
                this._list_result.Add(new CFilmDataType(strUrl, strName, strTime));               
            }
            return this._list_result;
        }
       










    }
}
