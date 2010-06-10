using System.Collections;
using WM2010Management;
using System;
using System.Windows.Documents;

namespace WM2010.Common
{
    public class Begegnung
    {
        public string Mannschaft1Name { get; set; }
        public byte[] Mannschaft1Fahne { get; set; }

        public string Mannschaft2Name { get; set; }
        public byte[] Mannschaft2Fahne { get; set; }

        public Spiel Spiel { get; set; }

     
    }


}
