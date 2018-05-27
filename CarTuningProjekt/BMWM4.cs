using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningProjekt
{
    class BMWM4 : Fahrzeug
    {
        public BMWM4(int pferdestaerke, List<string> modifikation, string marke)
        {
            Modifikationen = modifikation;
            Pferdestärke = pferdestaerke;
            Marke = marke;
        }
        public int Pferdestärke { get; set; }
        public List<string> Modifikationen { get; set; }
        public string Marke { get; set; }
        public override string ToString()
        {
            string modi = "";
            foreach (var item in Modifikationen)
            {
                modi += item + ",";
            }
            if (modi != "")
            {
                modi = modi.Substring(0, modi.Length - 1);
            }
            return Pferdestärke.ToString() + ";" + modi + ";" + Marke;
        }
    }
}
