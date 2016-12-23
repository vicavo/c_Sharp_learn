using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CalcCmdTime
{
    class CWriteFile
    {
        public string _strWriteFileDir;

        public CWriteFile(string strDir)
        {
            _strWriteFileDir = strDir;
        }

        public void WriteFile(List<string> listContent)
        {
            StreamWriter CSFile = new StreamWriter(this._strWriteFileDir);

           for(int i =0; i<listContent.Count();i++)
            {
                CSFile.WriteLine(listContent[i]);
            }
            CSFile.Close();
        }
    }
}
