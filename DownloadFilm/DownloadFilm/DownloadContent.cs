using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DownloadFilm
{
    class DownloadContent
    {

        private WebClient _webClient = null;
        string _strUrl = string.Empty;
        string _strtemp = string.Empty;
        public DownloadContent(string strUrl)
        {
            this._webClient = new WebClient { Encoding = System.Text.Encoding.UTF8};
            this._webClient.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");
            _strUrl = strUrl;
         }

       public string GetDownloadContent()
        {
            string strResult = string.Empty;
            // strResult = Encoding.UTF8.GetString(this._webClient.DownloadData(_strUrl));
            //  return this._webClient.DownloadData(_strUrl).ToString();
            strResult = this._webClient.DownloadString(_strUrl);

            return strResult;
        }
    }
}
