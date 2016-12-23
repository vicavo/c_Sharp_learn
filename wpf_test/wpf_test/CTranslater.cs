using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.IO;


namespace wpf_test
{
    class CTranslater
    {
        private readonly string str_translate_api = "https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}";
        private WebClient _webClient = null;
        private string strTargetType = string.Empty;
        private string strResultType = string.Empty;
        private readonly string _resultPattern = "\"(.*?)\"";

        private string strTranslateContent;

        public CTranslater(string strContent)
        {
            strTranslateContent = strContent;
            strTargetType = "en";
            strResultType = "zh_CN";
            /*********setting unicode********/
            this._webClient = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            this._webClient.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");

        }

        public string StartTranslate()
        {
           string strNeedTrans = string.Format(this.str_translate_api, this.strTargetType, this.strResultType, strTranslateContent);
            string strResult = string.Empty;
            // strResult = this._webClient.DownloadString(strNeedTrans);
             strResult = Encoding.UTF8.GetString(_webClient.DownloadData(strNeedTrans));

            //{ 

            //WebRequest hwr = WebRequest.Create(strNeedTrans);

            //HttpWebResponse hwp = hwr.GetResponse() as HttpWebResponse;

            //StreamReader sr;

            //string code = hwp.ContentType;

            ////得到编码了

            //code = code.Split('=')[1];

            //Stream rep = hwp.GetResponseStream();

            //    //sr = new StreamReader(rep, Encoding.GetEncoding(code));
            //    sr = new StreamReader(rep, Encoding.GetEncoding("gb2312"));

            //    strResult = sr.ReadToEnd();
            //}




            MatchCollection matches = Regex.Matches(strResult, this._resultPattern);
            if (matches.Count < 3) return strTranslateContent;


            StringBuilder builder = new StringBuilder(string.Empty);
            for (int i = 0; i < matches.Count; i++)
            {
                if (i % 2 != 0 || i == matches.Count - 1) continue;

                builder.Append(matches[i].Groups[1].Value.ToString());
            }

            return builder.ToString();
        }

    }
}
