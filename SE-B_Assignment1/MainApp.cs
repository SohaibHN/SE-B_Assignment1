using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace SE_B_Assignment1
{
    public partial class Form1 : Form
    {
        /* public string[] speed;
         public string[] heartrate;
         public string[] cadence;
         public string[] altitude;
         public string[] power;
         public string[] powerbalance; */
        List<string> HRSpeed = new List<string>();
        List<string> heartrate = new List<string>();
        List<string> cadence = new List<string>();
        List<string> altitude = new List<string>();
        List<string> power = new List<string>();
        List<string> powerbalance = new List<string>();
        bool SpeedCheck, CadenceCheck, AltCheck, PowerCheck, PowerBICheck, PowerPedalCheck, HRCheck, UnitCheck, FileLoaded, AirPressureCheck;
        TimeSpan start;
        TimeSpan end;

        public int[] Speed;
        public int[] HeartRate;
        public int[] Altitude;
        public int[] Cadeance;
        public int[] Power;
        int interval;

        public Form1()
        {
            InitializeComponent();
            MPHRadio.CheckedChanged += new EventHandler(SpeedFormat);
            KMRadio.CheckedChanged += new EventHandler(SpeedFormat);

        }
#region SpeedFormat Allows Users to switch between US & EU formats for Miles/KM
        private void SpeedFormat(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            SpeedPlot();
        }

        private void SpeedPlot()
        {
            if (FileLoaded) // doesn't do anything until a file is loaded in
            {
                if (HRCheck)
                {
                    int curveIndex = zedGraphControl1.GraphPane.CurveList.IndexOf("Speed");

                    if (curveIndex != -1) // makes sure speed exists
                    {
                        zedGraphControl1.GraphPane.CurveList.RemoveAt(curveIndex);
                        zedGraphControl1.Refresh();

                    }
                    if (MPHRadio.Checked)
                    {
                        if (UnitCheck)
                        {
                            double MaxSpd = Speed.Max() / 10;
                            MaxSpeed.Text = MaxSpd.ToString("N0") + " MPH";
                            double AverageSpeed = Speed.Where(f => f > 0).Average() / 10;
                            AvgSpeed.Text = AverageSpeed.ToString("N0") + " MPH";
                            double distance = AverageSpeed * end.TotalHours;
                            Distance.Text = distance.ToString("N") + " Miles";

                            PointPairList HRSpeed1 = new PointPairList();
                            for (int i = 0; i < Speed.Length; i++)
                            {
                                if (HRCheck)
                                {
                                    double speed = Speed[i] / 10;
                                    //interval = interval + i;
                                    HRSpeed1.Add(i, speed);
                                }

                            }
                            if (SpeedCheck)
                            {
                                LineItem SpeedCurve = zedGraphControl1.GraphPane.AddCurve("Speed",
                                HRSpeed1, Color.Red, SymbolType.None);
                            }
                        }
                        else
                        {
                            double MaxSpd = Speed.Max() / 10;
                            MaxSpd = ConvertKilometersToMiles(MaxSpd);
                            MaxSpeed.Text = MaxSpd.ToString("N0") + " MPH";

                            double AverageSpeed = Speed.Where(f => f > 0).Average() / 10;
                            AverageSpeed = ConvertKilometersToMiles(AverageSpeed);
                            AvgSpeed.Text = AverageSpeed.ToString("N0") + " MPH";

                            double distance = AverageSpeed * end.TotalHours;
                            Distance.Text = distance.ToString("N") + " Miles";

                            PointPairList HRSpeed1 = new PointPairList();
                            for (int i = 0; i < Speed.Length; i++)
                            {
                                if (HRCheck)
                                {
                                    double speed = Speed[i] / 10;
                                    speed = ConvertKilometersToMiles(speed);
                                    //interval = interval + i;
                                    HRSpeed1.Add(i, speed);
                                }

                            }
                            if (SpeedCheck)
                            {
                                LineItem SpeedCurve = zedGraphControl1.GraphPane.AddCurve("Speed",
                                HRSpeed1, Color.Red, SymbolType.None);
                            }
                        }
                    }
                    else if (KMRadio.Checked)
                    {
                        if (!UnitCheck)
                        {
                            double MaxSpd = Speed.Max() / 10;
                            MaxSpeed.Text = MaxSpd.ToString("N0") + " KM/H";
                            double AverageSpeed = Speed.Where(f => f > 0).Average() / 10;
                            AvgSpeed.Text = AverageSpeed.ToString("N0") + " KM/H";
                            double distance = AverageSpeed * end.TotalHours;
                            Distance.Text = distance.ToString("N0") + " KM";

                            PointPairList HRSpeed1 = new PointPairList();
                            for (int i = 0; i < Speed.Length; i++)
                            {
                                if (HRCheck)
                                {
                                    double speed = Speed[i] / 10;
                                    //interval = interval + i;
                                    HRSpeed1.Add(i, speed);
                                }

                            }
                            if (SpeedCheck)
                            {
                                LineItem SpeedCurve = zedGraphControl1.GraphPane.AddCurve("Speed",
                                HRSpeed1, Color.Red, SymbolType.None);
                            }
                        }
                        else
                        {
                            double MaxSpd = Speed.Max() / 10;
                            MaxSpd = ConvertMilesToKilometers(MaxSpd);
                            MaxSpeed.Text = MaxSpd.ToString("N0") + " KM/H";

                            double AverageSpeed = Speed.Where(f => f > 0).Average() / 10;
                            AverageSpeed = ConvertMilesToKilometers(AverageSpeed);
                            AvgSpeed.Text = AverageSpeed.ToString("N0") + " KM/H";

                            double distance = AverageSpeed * end.TotalHours;
                            Distance.Text = distance.ToString("N") + " KM";

                            PointPairList HRSpeed1 = new PointPairList();
                            for (int i = 0; i < Speed.Length; i++)
                            {
                                if (HRCheck)
                                {
                                    double speed = Speed[i] / 10;
                                    speed = ConvertMilesToKilometers(speed);
                                    //interval = interval + i;
                                    HRSpeed1.Add(i, speed);
                                }

                            }
                            if (SpeedCheck)
                            {
                                LineItem SpeedCurve = zedGraphControl1.GraphPane.AddCurve("Speed",
                                HRSpeed1, Color.Red, SymbolType.None);
                            }
                        }
                    }
                    zedGraphControl1.Refresh();
                }
            }
        }

        public static double ConvertMilesToKilometers(double miles)
        {
            //
            // Multiply by this constant and return the result.
            //
            return miles * 1.609344;
        }

        public static double ConvertKilometersToMiles(double kilometers)
        {
            //
            // Multiply by this constant.
            //
            return kilometers * 0.621371192;
        }
#endregion

#region GraphMenuOptions Removes lines from graph
        private void HeartRateMenuItem_Click(object sender, EventArgs e)
        {
            if (FileLoaded) // doesn't do anything until a file is loaded in
            {
                if (HeartRateMenuItem.Checked == true)
                {
                    HeartRateMenuItem.Checked = false;
                    int curveIndex = zedGraphControl1.GraphPane.CurveList.IndexOf("Heart Rate");

                    if (curveIndex != -1) // makes sure speed exists
                    {
                        zedGraphControl1.GraphPane.CurveList.RemoveAt(curveIndex);
                    }

                }
                else if (HeartRateMenuItem.Checked == false)
                {
                    HeartRateMenuItem.Checked = true;
                    PlotGraph();
                }
                zedGraphControl1.Refresh();
            }
        }

        private void HRUserInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void SpeedMenuItem_Click(object sender, EventArgs e)
        {
            if (FileLoaded) // doesn't do anything until a file is loaded in
            {
                if (SpeedMenuItem.Checked == true)
                {
                    SpeedMenuItem.Checked = false;
                    int curveIndex = zedGraphControl1.GraphPane.CurveList.IndexOf("Speed");

                    if (curveIndex != -1) // makes sure speed exists
                    {
                        zedGraphControl1.GraphPane.CurveList.RemoveAt(curveIndex);
                    }

                    if (MPHRadio.Checked)
                    {
                        MPHRadio.Checked = false;
                    }
                    else if (KMRadio.Checked)
                    {
                        KMRadio.Checked = false;
                    }

                }
                else if (SpeedMenuItem.Checked == false)
                {
                    SpeedMenuItem.Checked = true;
                    if (!UnitCheck)
                    {
                        this.KMRadio.Checked = true;
                    }
                    else
                    {
                        this.MPHRadio.Checked = true;
                    }/*
                    PointPairList HRSpeed1 = new PointPairList();
                    for (int i = 0; i < Speed.Length; i++)
                    {
                        if (HRCheck)
                        {
                            double speed = Speed[i] / 10;
                            //interval = interval + i;
                            HRSpeed1.Add(i, speed);
                        }

                    }
                    LineItem SpeedCurve = zedGraphControl1.GraphPane.AddCurve("Speed",
                    HRSpeed1, Color.Red, SymbolType.None); */
                }
                zedGraphControl1.Refresh();

            }
        }

        private void CadenceMenuItem_Click(object sender, EventArgs e)
        {
            if (FileLoaded) // doesn't do anything until a file is loaded in
            {
                if (CadenceMenuItem.Checked == true)
                {
                    CadenceMenuItem.Checked = false;
                    int curveIndex = zedGraphControl1.GraphPane.CurveList.IndexOf("Cadence");

                    if (curveIndex != -1) // makes sure speed exists
                    {
                        zedGraphControl1.GraphPane.CurveList.RemoveAt(curveIndex);
                    }
                    zedGraphControl1.Refresh();

                }
                else if (CadenceMenuItem.Checked == false)
                {
                    CadenceMenuItem.Checked = true;
                    PlotGraph();
                    /*PointPairList Cadence1 = new PointPairList();
                    for (int i = 0; i < Cadeance.Length; i++)
                    {
                        if (HRCheck)
                        {
                            Cadence1.Add(i, Cadeance[i]);
                        }
                    }

                    LineItem CadenceCurve = zedGraphControl1.GraphPane.AddCurve("Cadence",
                    Cadence1, Color.Purple, SymbolType.None); */
                }
            }
        }

        private void AltitudeMenuItem_Click(object sender, EventArgs e)
        {
            if (FileLoaded) // doesn't do anything until a file is loaded in
            {
                if (AltitudeMenuItem.Checked == true)
                {
                    AltitudeMenuItem.Checked = false;
                    int curveIndex = zedGraphControl1.GraphPane.CurveList.IndexOf("Altitude");

                    if (curveIndex != -1) // makes sure speed exists
                    {
                        zedGraphControl1.GraphPane.CurveList.RemoveAt(curveIndex);
                    }


                }
                else if (AltitudeMenuItem.Checked == false)
                {
                    AltitudeMenuItem.Checked = true;
                    PlotGraph();
                }
                zedGraphControl1.Refresh();
            }
        }

        private void PowerMenuItem_Click(object sender, EventArgs e)
        {
            if (FileLoaded) // doesn't do anything until a file is loaded in
            {
                if (PowerMenuItem.Checked == true)
                {
                    PowerMenuItem.Checked = false;
                    int curveIndex = zedGraphControl1.GraphPane.CurveList.IndexOf("Power");

                    if (curveIndex != -1) // makes sure speed exists
                    {
                        zedGraphControl1.GraphPane.CurveList.RemoveAt(curveIndex);
                    }
                }
                else if (PowerMenuItem.Checked == false)
                {
                    PowerMenuItem.Checked = true;
                    PlotGraph();
                }
                zedGraphControl1.Refresh();
            }
        }
        #endregion

        private void PlotGraph()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            // Set the Titles
            myPane.Title.Text = "Cycle Chart Data";
            myPane.XAxis.Title.Text = "Seconds";
            myPane.YAxis.Title.Text = "Value";
            myPane.XAxis.Title.Text = "Time (in Seconds)";
            myPane.XAxis.Scale.MinorStep = interval;
            myPane.XAxis.Scale.MajorStep = interval * 5;
            // interval = interval * 5;
            // MessageBox.Show(interval.ToString());
            string type;
            string type2;

            /* myPane.XAxis.Scale.MajorStep = 50;
             myPane.YAxis.Scale.Mag = 0;
             myPane.XAxis.Scale.Max = 1000;*/

            PointPairList HRSpeed1 = new PointPairList();
            PointPairList HeartRate1 = new PointPairList();
            PointPairList Cadeance1 = new PointPairList();
            PointPairList Altitude1 = new PointPairList();
            PointPairList Power1 = new PointPairList();

            Speed = HRSpeed.Select(int.Parse).ToArray();
            HeartRate = heartrate.Select(int.Parse).ToArray();
            Altitude = altitude.Select(int.Parse).ToArray();
            Cadeance = cadence.Select(int.Parse).ToArray();
            Power = power.Select(int.Parse).ToArray();
            //Power = Enumerable.Range(0, 10).ToArray();
            for (int i = 0; i < HeartRate.Length; i++)
            {
                if (!HRCheck)
                {
                    HeartRate1.Add(i, HeartRate[i]);
                }
                else
                {
                    HeartRate1.Add(i, HeartRate[i]);
                    if (SpeedCheck)
                    {
                      int speed = Speed[i] / 10;
                        //interval = interval + i;
                        HRSpeed1.Add(i, speed);
                    }
                    if (CadenceCheck)
                    {
                        Cadeance1.Add(i, Cadeance[i]);
                    }
                    if (AltCheck)
                    {
                        Altitude1.Add(i, Altitude[i]);
                    }
                    if (PowerCheck)
                    {
                        Power1.Add(i, Power[i]);
                    }
                }

            }          
            
            MaxHR.Text = HeartRate.Max().ToString();
            MinHR.Text = HeartRate.Where(f => f > 0).Min().ToString();
            BPM.Text = HeartRate.Where(f => f > 0).Average().ToString("N0");

            if (SpeedMenuItem.Checked == true)
            {
                if (!UnitCheck)
                {
                    this.KMRadio.Checked = true;
                }
                else
                {
                    this.MPHRadio.Checked = true;
                }
            }

            if (HRCheck)
            {
                if (!UnitCheck)
                {
                    type = " KM/H"; type2 = " KM";
                }
                else
                {
                    type = " MPH"; type2 = " Miles";
                }

                double MaxSpd = Speed.Max() / 10;
                MaxSpeed.Text = MaxSpd.ToString("N0") + type;
                double AverageSpeed = Speed.Where(f => f > 0).Average() / 10;
                AvgSpeed.Text = AverageSpeed.ToString("N0") + type;
                double distance = AverageSpeed * end.TotalHours;
                Distance.Text = distance.ToString("N") + type2;

                if (PowerCheck)
                {
                    MaxPower.Text = Power.Max().ToString("N0") + " W";
                    AvgPower.Text = Power.Average().ToString("N0") + " W";
                }

                MaxAlt.Text = Altitude.Max().ToString() + " M";
                AvgAlt.Text = Altitude.Where(f => f > 0).Average().ToString("N0") + " M";


            }


            if (HeartRateMenuItem.Checked)
            {
                LineItem HeartRateCurve = myPane.AddCurve("Heart Rate",
                HeartRate1, Color.Blue, SymbolType.None);
            }

            if (SpeedMenuItem.Checked)
            {
                SpeedPlot();
            }

            if (AltitudeMenuItem.Checked)
            {
                LineItem AltitudeCurve = myPane.AddCurve("Altitude",
                Altitude1, Color.Green, SymbolType.None);
            }
            //LineItem SpeedCurve = myPane.AddCurve("Speed",
            //    HRSpeed1, Color.Red, SymbolType.None);

            if (CadenceMenuItem.Checked)
            {
                LineItem CadenceCurve = myPane.AddCurve("Cadence",
                  Cadeance1, Color.Purple, SymbolType.None);
            }
            if (PowerMenuItem.Checked)
            {
                LineItem PowerCurve = myPane.AddCurve("Power",
                  Power1, Color.Orange, SymbolType.None);
            }//SpeedCurve.Line.IsVisible = false;


            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
            zedGraphControl1.RestoreScale(zedGraphControl1.GraphPane);
        }

        private void SetSize()
        {
            zedGraphControl1.Location = new Point(0, 0);
            zedGraphControl1.IsShowPointValues = true;
            zedGraphControl1.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 50);

        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        public void SModeFalse()
        {
            SpeedCheck = CadenceCheck = AltCheck = PowerCheck = PowerBICheck = PowerPedalCheck = HRCheck = UnitCheck = AirPressureCheck = false;// and so on.

        }

        public void SModeCheckV106(char[] FullSMode)
        {
            if (FullSMode[6] == '1')
            {
                HRCheck = true;
                SpeedMenuItem.Checked = true; PowerMenuItem.Checked = true; CadenceMenuItem.Checked = true; AltitudeMenuItem.Checked = true;
            }
            else
            {
                SpeedCheck = CadenceCheck = AltCheck = PowerCheck = PowerBICheck = PowerPedalCheck = false;
            }
            if (FullSMode[0] == '1')
            {
                SpeedCheck = true; SpeedMenuItem.Checked = true;
            }
            else
            {
                SpeedMenuItem.Checked = false;
            }
            if (FullSMode[1] == '1')
            {
                CadenceCheck = true; CadenceMenuItem.Checked = true;
            }
            if (FullSMode[2] == '1')
            {
                AltCheck = true; AltitudeMenuItem.Checked = true;
            }
            if (FullSMode[3] == '1')
            {
                PowerCheck = true; PowerMenuItem.Checked = true;
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
                SpeedMenuItem.Checked = true; PowerMenuItem.Checked = true; CadenceMenuItem.Checked = true; AltitudeMenuItem.Checked = true;
            }
            else
            {
                SpeedCheck = CadenceCheck = AltCheck = PowerCheck = PowerBICheck = PowerPedalCheck = false;
            }
            if (FullSMode[0] == '1')
            {
                SpeedCheck = true; SpeedMenuItem.Checked = true;
            }
            else
            {
                SpeedMenuItem.Checked = false;
            }
            if (FullSMode[1] == '1')
            {
                CadenceCheck = true; CadenceMenuItem.Checked = true;
            }
            if (FullSMode[2] == '1')
            {
                AltCheck = true; AltitudeMenuItem.Checked = true;
            }
            if (FullSMode[3] == '1')
            {
                PowerCheck = true; PowerMenuItem.Checked = true;
            }
            else { PowerMenuItem.Checked = false;  }
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

        private void ResetGraphObjs()
        {
            heartrate.Clear();
            HRSpeed.Clear();
            cadence.Clear();
            altitude.Clear();
            power.Clear();
            powerbalance.Clear();
            SModeFalse();

            if (MPHRadio.Checked)
            {
                MPHRadio.Checked = false;
            }
            else if (KMRadio.Checked)
            {
                KMRadio.Checked = false;
            }
        }

        private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Open HRM File",
                Filter = "hrm|*.hrm"
            };
            //ofd.InitialDirectory = @"D:\Desktop\Work\Uni Last Year\Sem2\SE-B";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                // clears everything everytime a file is loaded
                ResetGraphObjs();
                FileLoaded = true;
                try
                {
                    List<string> HRData = File.ReadLines(ofd.FileName)
                                               .SkipWhile(line => line != "[HRData]")
                                               .Skip(1)
                                               .TakeWhile(line => line != "")
                                               .ToList();

                    List<string> Params = File.ReadLines(ofd.FileName)
                           .SkipWhile(line => line != "[Params]")
                           .Skip(1)
                           .TakeWhile(line => line != "")
                           .ToList();

                    string SmodeFile = Params.Where(x => x.Contains("SMode")).FirstOrDefault();
                    string[] Smode = SmodeFile.Split('=');
                    char[] FullSMode = Smode[1].ToCharArray();

                    string VersionFile = Params.Where(x => x.Contains("Version")).FirstOrDefault();
                    string[] version = VersionFile.Split('=');

                    //MessageBox.Show(version[1]);
                    if (version[1] == "106")
                    {
                        SModeCheckV106(FullSMode);
                    }
                    else if (version[1] == "107")
                    {
                        SModeCheckV107(FullSMode);
                    }

                    listBox1.DataSource = Params;
                    listBox2.DataSource = HRData;

                    string DateFile = Params.Where(x => x.Contains("Date")).FirstOrDefault();
                    string[] Date = DateFile.Split('=');

                    string TimeFile = Params.Where(x => x.Contains("Start")).FirstOrDefault();
                    string[] Time = TimeFile.Split('=');

                    string DurationFile = Params.Where(x => x.Contains("Length")).FirstOrDefault();
                    string[] Duration = DurationFile.Split('=');

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
                            //powerbalance.Add(Splitter[5]);
                            //MessageBox.Show(info13[0]);

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

                    string DisplayDate = DateTime.ParseExact(Date[1], "yyyymmdd", CultureInfo.InvariantCulture).ToString("dd/mm/yyyy");
                    DateOfFile.Text = DisplayDate;
                    var StartTimeSpan = TimeSpan.ParseExact(Time[1], "c", System.Globalization.CultureInfo.InvariantCulture);
                    StartTime.Text = StartTimeSpan.ToString("hh\\:mm\\:ss");

                    var EndTimeSpan = TimeSpan.ParseExact(Duration[1], "c", System.Globalization.CultureInfo.InvariantCulture);
                    end = EndTimeSpan;
                    EndTimeSpan = StartTimeSpan.Add(EndTimeSpan);
                    EndTime.Text = EndTimeSpan.ToString("hh\\:mm\\:ss");

                    start = StartTimeSpan;

                }
                catch (Exception)
                {
                    MessageBox.Show("File is incorrect format, please use a correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //error message on incorrect file types
                    return;
                }
                PlotGraph();
                DataGridViewPlot();
            }
            else { FileLoaded = false; }
        }

        private void DataGridViewPlot()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Interval Time (Seconds)");
            dt.Columns.Add("HeartRate");
            int timer = interval;
            if (!HRCheck)
            {
                for (int i = 0; i < HeartRate.Length; i++)
                {

                    DataRow dr = dt.NewRow();
                    dr["HeartRate"] = HeartRate[i];
                    dr["Interval Time (Seconds)"] = timer;
                    dt.Rows.Add(dr);
                    //MessageBox.Show(timer.ToString());
                    timer = interval + timer;
                }
            }
            else if (PowerCheck)
            {

                string type, type2;
                if (!UnitCheck)
                {
                    type = " KM/H"; type2 = " (KM)";
                }
                else
                {
                    type = " MPH"; type2 = " (Miles)";
                }

                dt.Columns.Add("Speed" + type2);
                dt.Columns.Add("Cadence");
                dt.Columns.Add("Altitude");
                dt.Columns.Add("Power (Watts)");

                for (int i = 0; i < HeartRate.Length; i++)
                {
                    int speed = Speed[i] / 10;
                    string speedstring = speed.ToString("N0") + type;
                    //interval = interval + i;
                    DataRow dr = dt.NewRow();
                    dr["HeartRate"] = HeartRate[i];
                    dr["Speed" + type2] = speedstring;
                    dr["Cadence"] = cadence[i];
                    dr["Altitude"] = Altitude[i];
                    dr["Power (Watts)"] = Power[i];
                    dr["Interval Time (Seconds)"] = timer;
                    dt.Rows.Add(dr);
                    timer = interval + timer;
                }
            }
            else
            {

                string type, type2;
                if (!UnitCheck)
                {
                    type = " KM/H"; type2 = " (KM)";
                }
                else
                {
                    type = " MPH"; type2 = " (Miles)";
                }

                dt.Columns.Add("Speed" + type2);
                dt.Columns.Add("Cadence");
                dt.Columns.Add("Altitude");

                for (int i = 0; i < HeartRate.Length; i++)
                {
                    int speed = Speed[i] / 10;
                    string speedstring = speed.ToString("N0") + type;
                    //interval = interval + i;
                    DataRow dr = dt.NewRow();
                    dr["HeartRate"] = HeartRate[i];
                    dr["Speed" + type2] = speedstring;
                    dr["Cadence"] = cadence[i];
                    dr["Altitude"] = Altitude[i];
                    dr["Interval Time (Seconds)"] = timer;
                    dt.Rows.Add(dr);
                    timer = interval + timer;
                }
            }

            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}