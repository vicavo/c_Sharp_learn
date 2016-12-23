using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalcCmdTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartProcess();
        }

        public void StartProcess()
        {
            CReadFile readlog = new CReadFile("C:\\Users\\vicavo\\AppData\\Roaming\\Skype\\My Skype Received Files\\20161214.log");

            List<KeyValuePair<string, string>> listTimeInfo = new List<KeyValuePair<string, string>>();
            List<string> listString = new List<string>();
            KeyValuePair<string, string> pairValue;
            listTimeInfo = readlog.Read();

            for(int i =0; i< listTimeInfo.Count();i++)
            {
                pairValue = listTimeInfo[i];
                listString.Add(CTimeCalc.stringTimeMinus(pairValue.Key, pairValue.Value));
            }

            CWriteFile writeLog = new CWriteFile("C:\\Users\\vicavo\\Desktop\\result\\result.txt");

            writeLog.WriteFile(listString);

        }
    }
}
