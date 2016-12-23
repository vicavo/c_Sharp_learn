using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.FLS.Common
{
    public class IncamJobStep
    {
        private string _stepPath = "";
        private string _stepName = "";
        private List<string> _layers = new List <string>();
        private List<string> _checklists = new List <string>();

        public string StepPath
        {
            get
            {
                return this._stepPath;
            }
        }

        public string StepName
        {
            get
            {
                return this._stepName;
            }
        }

        public List<string> Layers
        {
            get
            {
                return this._layers;
            }
        }

        public List<string> CheckLists
        {
            get
            {
                return this._checklists;
            }
        }

        public IncamJobStep(string stepPath, string stepName)
        {
            this._stepPath = stepPath;
            this._stepName = stepName;

            string[] lys = DirHelper.getSubDirNames(stepPath + @"\" + stepName + @"\layers");
            string[] chks = DirHelper.getSubDirNames(stepPath + @"\" + stepName + @"\chk");

            /* Sometimes the layer name and checklist name of InCAM end with #incam#
             * If we pass it to script directly, the char '#' will cause error */
            foreach (string ly in lys)
            {
                string ly2 = ly.Replace("#incam#", "");

                if (!this._layers.Contains(ly2))
                {
                    this._layers.Add(ly2);
                }
            }

            foreach (string chk in chks)
            {
                string chk2 = chk.Replace("#incam#", "");

                if (!this._checklists.Contains(chk2))
                {
                    this._checklists.Add(chk2);
                }
            }

            this._layers.Sort();
            this._checklists.Sort();
        }

        public IncamJobStep()
        {

        }
    }
}
