using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translater
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Count() < 4)
            {
                Console.WriteLine("Input parameters error!");
                Console.WriteLine("Usage: \r\n" +
                                  "Translater.exe inputFile outputFile srcLang dstLang \r\n" +
                                  "Locale list: http://www.science.co.il/Language/Locale-codes.php");
            }
            else
            {
                try {
                    Translater translate = new Translater(args[0], args[1], args[2], args[3]);
                    translate.StartTranslate();
                }
                catch(System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            Console.ReadKey();
        }
    }
}
