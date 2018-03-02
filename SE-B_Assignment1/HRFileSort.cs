using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_B_Assignment1
{
    class HRFileSort
    {
        /* public string[] speed;
 public string[] heartrate;
 public string[] cadence;
 public string[] altitude;
 public string[] power;
 public string[] powerbalance; */
        public List<string> HRSpeed = new List<string>();
        public List<string> heartrate = new List<string>();
        public List<string> cadence = new List<string>();
        public List<string> altitude = new List<string>();
        public List<string> power = new List<string>();
        public List<string> powerbalance = new List<string>();
        public bool SpeedCheck, CadenceCheck, AltCheck, PowerCheck, PowerBICheck, PowerPedalCheck, HRCheck, UnitCheck, AirPressureCheck;

        public int interval;

        public void FileDataManip(List<string> HRData, List<string> Params)
        {
            SModeFalse();

            string VersionFile = Params.Where(x => x.Contains("Version")).FirstOrDefault();
            string[] version = VersionFile.Split('=');

            string SmodeFile = Params.Where(x => x.Contains("SMode")).FirstOrDefault();
            string[] Smode = SmodeFile.Split('=');
            char[] FullSMode = Smode[1].ToCharArray();

            if (version[1] == "106")
            {
                SModeCheckV106(FullSMode);
            }
            else if (version[1] == "107")
            {
                SModeCheckV107(FullSMode);
            }

            string IntervalFile = Params.Where(x => x.Contains("Interval")).FirstOrDefault();
            string[] Interval = IntervalFile.Split('=');
            interval = Int32.Parse(Interval[1]);

            string[] Splitter;
            if (!HRCheck)
            {
                foreach (var one in HRData)
                {
                    Splitter = one.Split('\t');
                    heartrate.Add(Splitter[0]);
                }
            }

            else if (PowerCheck)
            {

                foreach (var one in HRData)
                {
                    Splitter = one.Split('\t');
                    heartrate.Add(Splitter[0]);
                    HRSpeed.Add(Splitter[1]);
                    cadence.Add(Splitter[2]);
                    altitude.Add(Splitter[3]);
                    power.Add(Splitter[4]);
                    powerbalance.Add(Splitter[5]);


                }
            }
            else
            {
                foreach (var one in HRData)
                {
                    Splitter = one.Split('\t');
                    heartrate.Add(Splitter[0]);
                    HRSpeed.Add(Splitter[1]);
                    cadence.Add(Splitter[2]);
                    altitude.Add(Splitter[3]);

                }
            }
        }

        public void SModeFalse()
        {
            SpeedCheck = CadenceCheck = AltCheck = PowerCheck = PowerBICheck = PowerPedalCheck = HRCheck = UnitCheck = AirPressureCheck = false;// and so on.
            heartrate.Clear();
            HRSpeed.Clear();
            cadence.Clear();
            altitude.Clear();
            power.Clear();
            powerbalance.Clear();

        }

        public void SModeCheckV106(char[] FullSMode)
        {
            if (FullSMode[6] == '1')
            {
                HRCheck = true;
            }
            else
            {
                SpeedCheck = CadenceCheck = AltCheck = PowerCheck = PowerBICheck = PowerPedalCheck = false;
            }
            if (FullSMode[0] == '1')
            {
                SpeedCheck = true;
            }

            if (FullSMode[1] == '1')
            {
                CadenceCheck = true; 
            }
            if (FullSMode[2] == '1')
            {
                AltCheck = true; 
            }
            if (FullSMode[3] == '1')
            {
                PowerCheck = true;
            }
            if (FullSMode[4] == '1')
            {
                PowerBICheck = true;
            }
            if (FullSMode[5] == '1')
            {
                PowerPedalCheck = true;
            }
            if (FullSMode[7] == '1')
            {
                UnitCheck = true;
            }
        }

        public void SModeCheckV107(char[] FullSMode)
        {
            if (FullSMode[6] == '1')
            {
                HRCheck = true;
            }
            else
            {
                SpeedCheck = CadenceCheck = AltCheck = PowerCheck = PowerBICheck = PowerPedalCheck = false;
            }
            if (FullSMode[0] == '1')
            {
                SpeedCheck = true; 
            }
            if (FullSMode[1] == '1')
            {
                CadenceCheck = true;
            }
            if (FullSMode[2] == '1')
            {
                AltCheck = true; 
            }
            if (FullSMode[3] == '1')
            {
                PowerCheck = true; 
            }
            if (FullSMode[4] == '1')
            {
                PowerBICheck = true;
            }
            if (FullSMode[5] == '1')
            {
                PowerPedalCheck = true;
            }
            if (FullSMode[7] == '1')
            {
                UnitCheck = true;
            }
            if (FullSMode[8] == '1')
            {
                AirPressureCheck = true;
            }
        }

    }
}
