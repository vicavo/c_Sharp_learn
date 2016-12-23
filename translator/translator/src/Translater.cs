using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Translater
{
    public class Translater
    {
        private WebClient _webClient = null;

        private readonly string _api = "https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}";
        private readonly string _strPattern = @"\>(.*?)\<\/sys\:String";
        private readonly string _resultPattern = "\"(.*?)\"";

        private string _inputFile = string.Empty;
        private string _outputFile = string.Empty;
        private string _srcLang = string.Empty;
        private string _dstLang = string.Empty;

        public Translater(string inputFile, string outputFile, string srcLang, string dstLang)
        {
            this._inputFile = inputFile;
            this._outputFile = outputFile;
            this._srcLang = srcLang;
            this._dstLang = dstLang;

            this._webClient = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            this._webClient.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");
        }

        public void StartTranslate()
        {
            Thread thread1 = new Thread(ProcessFile);
            thread1.IsBackground = true;
            thread1.Start();
        }

        private void ProcessFile()
        {
            if(!File.Exists(this._inputFile))
            {
                Console.WriteLine("Invalid input file: " + this._inputFile);
                return;
            }

            using(StreamReader reader = new StreamReader(this._inputFile))
            {
                if (File.Exists(this._outputFile)) File.Delete(this._outputFile);

                using (StreamWriter writer = new StreamWriter(this._outputFile))
                {
                    while (!reader.EndOfStream)
                    {
                        string rawContent = reader.ReadLine();
                        string translatedRawContent = this.ProcessOneLine(rawContent);

                        writer.WriteLine(translatedRawContent);
                    }
                }
            }

            Console.WriteLine("Translation done!");
        }

        private string ProcessOneLine(string rawContent)
        {
            Console.WriteLine(rawContent);

            if (string.Empty == rawContent) return rawContent;

            MatchCollection collection = Regex.Matches(rawContent, this._strPattern);
            if (collection.Count == 0) return rawContent;

            foreach(Match match in collection)
            {
                //string srcStr = (match as Capture).Value.ToString();
                string srcStr = match.Groups[1].Value.ToString();
                string dstStr = this.GetTranslate(srcStr);

                Console.WriteLine(srcStr + " -> " + dstStr);
                rawContent = rawContent.Replace(">" + srcStr + "<", ">" + dstStr + "<");
            }

            return rawContent;
        }

        private string GetTranslate(string content)
        {
            string url = string.Format(this._api, this._srcLang, this._dstLang, content);

            // [[["自动冰柜管理系统","Automatic Freezer Management System",,,3]],,"en"]
            // [[["您确定要删除此用户吗？","Are you sure you want to delete this user?",,,3],["您可以禁用此用户，而不是删除。","You could disable this user instead of deleting.",,,3]],,"en"]
            string raw = this._webClient.DownloadString(url);

            MatchCollection matches = Regex.Matches(raw, this._resultPattern);
            if (matches.Count < 3) return content;

            StringBuilder builder = new StringBuilder(string.Empty);
            for(int i = 0; i< matches.Count; i++)
            {
                if (i % 2 != 0 || i == matches.Count-1) continue;

                builder.Append(matches[i].Groups[1].Value.ToString());
            }

            return builder.ToString();
        }
    }
}
