using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningProjekt
{
    class KTMDUKE : Fahrzeug
    {
        public int Pferdestärke { get; set; }
        public List<string> Modifikationen { get; set; }
        public string Marke { get; set; }

            
        public KTMDUKE(int pferdestaerke, List<string> modifikationen, string marke)
        {
            Modifikationen = modifikationen;
            Pferdestärke = pferdestaerke;
            Marke = marke;
        }
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
