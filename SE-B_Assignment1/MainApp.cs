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
        List<string> heartrate = new List<string>();
        List<string> HRSpeed = new List<string>();
        List<string> cadence = new List<string>();
        List<string> altitude = new List<string>();
        List<string> power = new List<string>();
        List<string> powerbalance = new List<string>();
        //List<string> HRSpeed, heartrate, cadence, altitude, power, powerbalance = new List<string>();
        //List<string> HRSpeed2, heartrate2, cadence2, altitude2, power2, powerbalance2 = new List<string>();
        List<string> heartrate2 = new List<string>();
        List<string> HRSpeed2 = new List<string>();
        List<string> cadence2 = new List<string>();
        List<string> altitude2 = new List<string>();
        List<string> power2 = new List<string>();
        List<string> powerbalance2 = new List<string>();

        List<string> heartrate3 = new List<string>();
        List<string> HRSpeed3 = new List<string>();
        List<string> cadence3 = new List<string>();
        List<string> altitude3 = new List<string>();
        List<string> power3 = new List<string>();
        List<string> powerbalance3 = new List<string>();

        bool SpeedCheck, CadenceCheck, AltCheck, PowerCheck, PowerBICheck, PowerPedalCheck, HRCheck, UnitCheck, FileLoaded, AirPressureCheck;
        bool OptionChanged = false;
        static TimeSpan start;
        TimeSpan end;

        public int[] Speed;
        public int[] HeartRate;
        public int[] Altitude;
        public int[] Cadeance;
        public int[] Power;
        public int[] PowerBalance;
        public static int interval;
        public string type, type2, altitudetype;
        HRFileSort HRFS = new HRFileSort();

        public Form1()
        {
            InitializeComponent();
            MPHRadio.CheckedChanged += new EventHandler(SpeedFormat);
            KMRadio.CheckedChanged += new EventHandler(SpeedFormat);
            tabPage1.Text = @"Raw Data";
            tabPage2.Text = @"Table Data";
            tabPage3.Text = @"Comparsion Data";
            FTPInput.Maximum = 1000;
            HRUserInput.Maximum = 300;
            this.zedGraphControl1.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zedGraphControl1_PointValueEvent);
        }
        #region IntervalDetection
        double potentialIntervalStart;
        double detectedIntervalEnd;
        List<string> detectedIntervals = new List<string>();
        List<string> detectedInterval = new List<string>();

        public void IntervalDetection()
        {

            int detected = 0;
            detectedIntervals.Clear();
            detectedInterval.Clear();

            for (int i = 0; i < HeartRate.Length; i++)
            {
                bool potentialIntervalDetected = false;
                bool intervalDetected = false;

                for (int p = i; p < Power.Length; p++)
                {
                    // get average of proceeding 14 seconds of powers - time taken for rider to reach maximum power
                    List<double> currentPowers = new List<double>();
                    List<double> futurepowers = new List<double>();

                    for (int x = 0; x < 10; x++)
                    {
                        if (p + (x + 1) < Power.Length)
                        {
                            if (Power[p + x] == 0) // rider must be applying power for next 10 seconds
                            {
                                break;
                            }
                            currentPowers.Add(Power[p + x]); // get power for the next 10 seconds
                           futurepowers.Add(Power[p + (x + 1)]); // get power for the next 10 seconds starting at current power +1
                        }
                    }

                    if (currentPowers.Count == 0) // no powers added to the last
                    {
                        break;
                    }

                    double currentPowersAverage = currentPowers.Average();
                    double futurepowersAverage = futurepowers.Average();

                    // check for potential interval
                    if (currentPowersAverage < futurepowersAverage)
                    {
                        if (!potentialIntervalDetected)
                        {
                            potentialIntervalStart = p;
                            potentialIntervalDetected = true;
                        }
                    }
                    else // possible that cyclist built up speed and reached interval speed to maintain
                    {

                        int maintain = Power[p];

                        // int percentage = ((maintain * 50) / 100);
                        int percentage = maintain / 2;
                        int minpower = maintain - percentage;
                        int maxpower = maintain + percentage;
                        int minInterval = 22; // interval power must be maintained for atleast 20 seconds

                        int timer = 0;
                        int counter = 1;
                   
                        for (int q = p; q < Power.Length; q++)
                        {
                        //if (q == 0) { q = 1; }

                            if (Power[q] > minpower && Power[q] < maxpower)
                            //if (Power[q] > minpower)
                            {
                                timer += interval * counter;
                            }
                            else
                            {
                                if (timer >= minInterval)
                                {
                                    intervalDetected = true;
                                    detected = detected + 1;
                                    detectedIntervalEnd = q;
                                    detectedInterval.Add(potentialIntervalStart.ToString() + ":" + detectedIntervalEnd.ToString());

                                    detectedIntervalEnd = q * interval;
                                    potentialIntervalStart = potentialIntervalStart * interval;

                                    TimeSpan starting = new TimeSpan();
                                    starting = start.Add(TimeSpan.FromSeconds(potentialIntervalStart));
                                    TimeSpan ending = new TimeSpan();
                                    ending = start.Add(TimeSpan.FromSeconds(detectedIntervalEnd));

                                    
                                    detectedIntervals.Add("Interval " + detected + "     " + starting.ToString("hh\\:mm\\:ss") + " - " + ending.ToString("hh\\:mm\\:ss"));

                                }
                                break;
                            }
                        }
                    }

                    if (intervalDetected)
                    {
                        i = (int)detectedIntervalEnd; // loop is set to end of detection
                        potentialIntervalStart = detectedIntervalEnd; // loop is set to end of detection
                        break;
                    }
                    
                }
            }
            
            detectedIntervals.ForEach(Console.WriteLine);
            DetectedIntervalBox.DataSource = detectedIntervals;
            potentialIntervalStart = 0;
        }
#endregion    


        private string zedGraphControl1_PointValueEvent(ZedGraph.ZedGraphControl sender, ZedGraph.GraphPane pane, ZedGraph.CurveItem curve, int iPt)
        {
            //MessageBox.Show(curve.ValueAxis(pane).ToString());

            int pointvalue = 0;
            int xpoint = (int)curve[iPt].X;
            //MessageBox.Show(xpoint.ToString());
            if (xpoint < HeartRate.Length)
            {
                if (curve.Label.Text.Contains("Power"))
                {                 
                    pointvalue = Power[xpoint];
                }
                if (curve.Label.Text.Contains("Heart"))
                {
                    pointvalue = HeartRate[xpoint];
                }
                if (curve.Label.Text.Contains("Speed"))
                {
                    pointvalue = Speed[xpoint];
                }
                if (curve.Label.Text.Contains("Altitude"))
                {
                    pointvalue = Altitude[xpoint];
                }
                if (curve.Label.Text.Contains("Cadence"))
                {
                    pointvalue = Cadeance[xpoint];
                }
            }
            string value = pointvalue.ToString();
            return curve.Label.Text + " - " + value;
            //return "X = " + curve[iPt].X.ToString() + " Y = " + curve[iPt].Y.ToString() + " Name = " + curve.Label.Text;
        }

        #region SpeedFormat Plots Speed Curve & Allows Users to switch between US & EU formats for Miles/KM
        private void SpeedFormat(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            OptionChanged = true; //used for later settings (removing graph lines)
            SpeedPlot();
        }

        private void SpeedPlot() // plots speeds based on user choice or default file set in file
        {
            if (FileLoaded) // doesn't do anything until a file is loaded in
            {
                if (SpeedCheck) // checks there is speed data
                {
                    int curveIndex = zedGraphControl1.GraphPane.CurveList.IndexOf("Speed");

                    if (curveIndex != -1) // makes sure speed exists
                    {
                        zedGraphControl1.GraphPane.CurveList.RemoveAt(curveIndex);
                        zedGraphControl1.Refresh();

                    }
                    if (MPHRadio.Checked)
                    {
                        if (UnitCheck) //eu or us
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
                            LineItem SpeedCurve = zedGraphControl1.GraphPane.AddCurve("Speed",
                            HRSpeed1, Color.Red, SymbolType.None);

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
                            LineItem SpeedCurve = zedGraphControl1.GraphPane.AddCurve("Speed",
                            HRSpeed1, Color.Red, SymbolType.None);

                        }
                    }
                    else if (KMRadio.Checked)
                    {
                        if (!UnitCheck) //eu or us
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
                                if (SpeedCheck)
                                {
                                    double speed = Speed[i] / 10;
                                    //interval = interval + i;
                                    HRSpeed1.Add(i, speed);
                                }

                            }
                            LineItem SpeedCurve = zedGraphControl1.GraphPane.AddCurve("Speed",
                            HRSpeed1, Color.Red, SymbolType.None);
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
                                if (SpeedCheck)
                                {
                                    double speed = Speed[i] / 10;
                                    speed = ConvertMilesToKilometers(speed);
                                    //interval = interval + i;
                                    HRSpeed1.Add(i, speed);
                                }

                            }
                            LineItem SpeedCurve = zedGraphControl1.GraphPane.AddCurve("Speed",
                            HRSpeed1, Color.Red, SymbolType.None);
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

        #region GraphMenuOptions Removes/Adds lines from graph
        private void HeartRateMenuItem_Click(object sender, EventArgs e)
        {
            if (FileLoaded) // doesn't do anything until a file is loaded in
            {
                if (HeartRateMenuItem.Checked == true)
                {
                    HeartRateMenuItem.Checked = false;
                    int curveIndex = zedGraphControl1.GraphPane.CurveList.IndexOf("Heart Rate");

                    if (curveIndex != -1) // makes sure curve exists
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
                zedGraphControl1.RestoreScale(zedGraphControl1.GraphPane);

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
                    if (CadenceCheck)
                    {
                        CadenceMenuItem.Checked = true;
                        PlotGraph();
                    }
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
                    if (AltCheck)
                    {
                        AltitudeMenuItem.Checked = true;
                        PlotGraph();
                    }
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
                    if (PowerCheck)
                    {
                        PowerMenuItem.Checked = true;
                        PlotGraph();
                    }
                }
                zedGraphControl1.Refresh();
            }
        }
        #endregion

        #region Zoom In Summary
        double lastXAxisMax, lastXAxisMin, lastYAxisMax, lastYAxisMin;
        bool zoomIn;
        private bool zedGraphControl1_MouseDownEvent(ZedGraphControl sender, MouseEventArgs e)
        {
            // Save the zoom values
            lastXAxisMax = sender.GraphPane.XAxis.Scale.Max;
            lastXAxisMin = sender.GraphPane.XAxis.Scale.Min;
            lastYAxisMax = sender.GraphPane.YAxis.Scale.Max;
            lastYAxisMin = sender.GraphPane.YAxis.Scale.Min;
            zoomIn = false;
            return false;
        }

        private void zedGraphControl1_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            if (((lastYAxisMax - lastYAxisMin) * (lastXAxisMax - lastXAxisMin)) > ((sender.GraphPane.XAxis.Scale.Max - sender.GraphPane.XAxis.Scale.Min) * (sender.GraphPane.YAxis.Scale.Max - sender.GraphPane.YAxis.Scale.Min)))
            {
                zoomIn = true;
            }
            else
            {
                zoomIn = false;
            }


            int StartPoint = (int)sender.GraphPane.XAxis.Scale.Min;
            int EndPoint = (int)sender.GraphPane.XAxis.Scale.Max - 1;
            int Difference = EndPoint - StartPoint;


            if (heartrate.Count > StartPoint && heartrate.Count >= EndPoint && FileLoaded)
            {

                //Heart Rate
                List<int> HeartRateList = heartrate.ConvertAll(int.Parse);
                List<int> UpdatedHeartRate;
                UpdatedHeartRate = HeartRateList.GetRange(StartPoint, Difference);
                HeartRate = UpdatedHeartRate.ToArray();

                if (SpeedCheck)
                {
                    //Speed
                    List<int> SpeedList = HRSpeed.ConvertAll(int.Parse);
                    List<int> UpdatedSpeedList;
                    UpdatedSpeedList = SpeedList.GetRange(StartPoint, Difference);
                    Speed = UpdatedSpeedList.ToArray();
                }

                if (AltCheck)
                {

                    //Altitude
                    List<int> AltitudeList = altitude.ConvertAll(int.Parse);
                    List<int> UpdatedAltitudeList;
                    UpdatedAltitudeList = AltitudeList.GetRange(StartPoint, Difference);
                    Altitude = UpdatedAltitudeList.ToArray();
                }
                if (CadenceCheck)
                {
                    //Cadence
                    List<int> CadenceList = cadence.ConvertAll(int.Parse);
                    List<int> UpdatedCadenceList;
                    UpdatedCadenceList = CadenceList.GetRange(StartPoint, Difference);
                    Cadeance = UpdatedCadenceList.ToArray();
                }
                if (PowerCheck)
                {
                    //Power
                    List<int> PowerList = power.ConvertAll(int.Parse);
                    List<int> UpdatedPowerList;
                    UpdatedPowerList = PowerList.GetRange(StartPoint, Difference);
                    Power = UpdatedPowerList.ToArray();
                }
                SummaryData();
            }

        }
        #endregion

        static string Axis_ScaleFormatEvent(GraphPane pane, Axis axis, double val, int index) //lets the x axis change to interval timespan rather than leaving it in seconds format
        {
            double time = val * interval;
            TimeSpan timeVal = start.Add(TimeSpan.FromSeconds(time)); return timeVal.ToString("hh\\:mm\\:ss");
        }

        private void PlotGraph()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.XAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(Axis_ScaleFormatEvent); //lets the x axis change to interval timespan rather than leaving it in seconds format

            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            // Set the Titles
            myPane.Title.Text = "Cycle Chart Data";
            myPane.XAxis.Title.Text = "Seconds";
            myPane.YAxis.Title.Text = "Value";
            myPane.XAxis.Title.Text = "Time";
            TimeSpan timer = new TimeSpan();
            timer = timer.Add(TimeSpan.FromSeconds(interval));
            zedGraphControl1.IsShowPointValues = true;
            //myPane.XAxis.Scale.MinorStep = timer.TotalSeconds;
            //myPane.XAxis.Scale.MajorStep = timer.TotalSeconds * 5;
            // myPane.XAxis.Scale.MajorStep = timer.TotalSeconds * 5;
            // interval = interval * 5
            myPane.XAxis.Scale.Max = heartrate.Count;
            //myPane.XAxis.Scale.MaxAuto = true;
            PointPairList HRSpeed1 = new PointPairList();
            PointPairList HeartRate1 = new PointPairList();
            PointPairList Cadeance1 = new PointPairList();
            PointPairList Altitude1 = new PointPairList();
            PointPairList Power1 = new PointPairList();
            /*
*/
            HeartRate = heartrate.Select(int.Parse).ToArray();
            if (SpeedCheck)
            {
                Speed = HRSpeed.Select(int.Parse).ToArray();
            }

            if (AltCheck)
            {
                Altitude = altitude.Select(int.Parse).ToArray();
            }
            if (CadenceCheck)
            {
                Cadeance = cadence.Select(int.Parse).ToArray();
            }
            if (PowerCheck)
            {
                Power = power.Select(int.Parse).ToArray();
            }
            if (PowerBICheck)
            {
                PowerBalance = powerbalance.Select(int.Parse).ToArray();
            }


            // plot to curves
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


            if (SpeedMenuItem.Checked && !MPHRadio.Checked && !KMRadio.Checked) //selects EU or US option first load
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

            SummaryData();

            //loads curves based if they are selected in the options & checked in smode

            if (HeartRateMenuItem.Checked)
            {
                LineItem HeartRateCurve = myPane.AddCurve("Heart Rate",
                HeartRate1, Color.Blue, SymbolType.None);
            }

            if (SpeedMenuItem.Checked && SpeedCheck)
            {
                SpeedPlot();
            }

            if (AltitudeMenuItem.Checked && AltCheck)
            {
                LineItem AltitudeCurve = myPane.AddCurve("Altitude",
                Altitude1, Color.Green, SymbolType.None);
            }

            if (CadenceMenuItem.Checked && CadenceCheck)
            {
                LineItem CadenceCurve = myPane.AddCurve("Cadence",
                  Cadeance1, Color.Purple, SymbolType.None);
            }
            if (PowerMenuItem.Checked && PowerCheck)
            {
                LineItem PowerCurve = myPane.AddCurve("Power",
                  Power1, Color.Orange, SymbolType.None);
            }


            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
            //zedGraphControl1.RestoreScale(zedGraphControl1.GraphPane); //unzooms graph whenever it is reloaded
        }

        private void SummaryData() // summary data calculations to display in gui
        {
            MaxHR.Text = HeartRate.Max().ToString() + " bpm";
            MinHR.Text = HeartRate.Where(f => f > 0).Min().ToString() + " bpm";
            BPM.Text = HeartRate.Where(f => f > 0).Average().ToString("N0") + " bpm";
            //BPM.Text = PowerBalance.Where(f => f > 0).Average().ToString("N0") + " bpm";
            //int PowerB = (int)PowerBalance.Where(f => f > 0).Average(); //16 bit digit

            //byte left = (byte)(PowerB & 0xFFu); // lower 8 bits 

            //int right = 100 - left;
            //BPM.Text = left.ToString() + "/" + right.ToString();

            if (!UnitCheck)
            {
                type = " KM/H"; type2 = " KM";
            }
            else
            {
                type = " MPH"; type2 = " Miles";
            }

            if (SpeedCheck)
            {
                double MaxSpd = Speed.Max() / 10;
                MaxSpeed.Text = MaxSpd.ToString("N0") + type;
                double AverageSpeed = Speed.Where(f => f > 0).Average() / 10;
                AvgSpeed.Text = AverageSpeed.ToString("N0") + type;
                double distance = AverageSpeed * end.TotalHours;
                Distance.Text = distance.ToString("N") + type2;
            }
            if (PowerCheck)
            {

                MaxPower.Text = Power.Max().ToString("N0") + " Watts";
                AvgPower.Text = Power.Average().ToString("N0") + " Watts";

                CalculateNormalizedPower();
                FTPMaxCalc();

            }
            if (AltCheck)
            {
                MaxAlt.Text = Altitude.Max().ToString() + " M";
                AvgAlt.Text = Altitude.Average().ToString("N0") + " M";
            }

        }
        double NormalPowerCalc;
        public void CalculateNormalizedPower()
        {
            var powers = new List<double>();

            for (var x = 0; x < Power.Length; x++)
            {
                if (((x + 1) * interval) >= 30) // start rolling average at 30 seconds
                {
                    powers.Add(Power[x]);
                }
            }

            if (powers.Any() || powers.Count > 30) // 30 required to calculate moving average
            {

                try
                {
                    // calculate a rolling 30 second average of the preceding time points after 30 seconds
                    int timeset = 30 / interval;
                    List<double> movingAverages = Enumerable
                    .Range(0, powers.Count - timeset)
                    .Select(n => powers.Skip(n).Take(timeset).Average())
                    .ToList();

                    // raise all the moving averages to the fourth power
                    List<double> averagesToFourthPower = PowerUp(movingAverages, 4);

                    // find the average of values raised to fourth power
                    double PowerAverage = averagesToFourthPower.Average();

                    // take the fourth root of the average values raised to the fourth power
                    NormalPowerCalc = Math.Round(Math.Pow(PowerAverage, 1.0 / 4), 2, MidpointRounding.AwayFromZero);

                    NormalPower.Text = NormalPowerCalc.ToString("N0") + " Watts";
                }
                catch
                {
                    MessageBox.Show("30 Points required for Normalized Power Calc");
                }
            }
        }

        public List<double> PowerUp(List<double> AverageList, int p)
        {
            for (var x = 0; x < AverageList.Count; x++)
            {
                AverageList[x] = Math.Pow(AverageList[x], p);
            }

            return AverageList;
        }


        private void compareFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Open HRM File",
                Filter = "hrm|*.hrm"
            };


            HRSpeed2 = HRSpeed.ToList();
            heartrate2 = heartrate.ToList();
            cadence2 = cadence.ToList();
            altitude2 = altitude.ToList();
            power2 = power.ToList();
            powerbalance2 = powerbalance.ToList();

            //ofd.InitialDirectory = @"D:\Desktop\Work\Uni Last Year\Sem2\SE-B";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                // clears everything everytime a file is loaded
                ResetGraphObjs();

                try
                {
                    List<string> HRData = File.ReadLines(ofd.FileName)
                                               .SkipWhile(line => line != "[HRData]")
                                               .Skip(1) //skips [HRDATA] line
                                               .TakeWhile(line => line != "") //until blank space/next section
                                               .ToList();

                    List<string> Params = File.ReadLines(ofd.FileName)
                           .SkipWhile(line => line != "[Params]")
                           .Skip(1) //skips [Params] line
                           .TakeWhile(line => line != "[") //until blank space/next section
                           .ToList();

                    //listBox1.DataSource = Params;
                    //listBox2.DataSource = HRData;

                    //FileDataManip(HRData, Params);
                    HRFS.FileDataManip(HRData, Params);
                    //FileDataLabels(Params);
                    //FileNameLabel.Text = FileNameLabel.Text + " " + System.IO.Path.GetFileName(ofd.FileName);

                    FileLoaded = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("File is incorrect format, please use a correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //error message on incorrect file types
                    return;
                }

                SetFileVars(); //set varSort Class
                PlotGraphCompare();
                /* List<string> HRSpeed3, heartrate3, cadence3, altitude3, power3, powerbalance3 = new List<string>();

                HRSpeed3 = HRSpeed;
                heartrate3 = heartrate;
                cadence3 = cadence;
                altitude3 = altitude;
                power3 = power;
                powerbalance3 = powerbalance; */

                HRSpeed3 = HRSpeed.ToList();
                heartrate3 = heartrate.ToList();
                cadence3 = cadence.ToList();
                altitude3 = altitude.ToList();
                power3 = power.ToList();
                powerbalance3 = powerbalance.ToList();

                HRSpeed = HRSpeed2.ToList();
                heartrate = heartrate2.ToList();
                cadence = cadence2.ToList();
                altitude = altitude2.ToList();
                power = power2.ToList();
                powerbalance = powerbalance2.ToList();

                DataGridViewPlotCompare();
            }
        }

        private void PlotGraphCompare()
        {

            //myPane.XAxis.Scale.MinorStep = timer.TotalSeconds;
            //myPane.XAxis.Scale.MajorStep = timer.TotalSeconds * 5;
            // myPane.XAxis.Scale.MajorStep = timer.TotalSeconds * 5;
            // interval = interval * 5
            //myPane.XAxis.Scale.MaxAuto = true;
            PointPairList HRSpeed1 = new PointPairList();
            PointPairList HeartRate1 = new PointPairList();
            PointPairList Cadeance1 = new PointPairList();
            PointPairList Altitude1 = new PointPairList();
            PointPairList Power1 = new PointPairList();
            /*
*/
            HeartRate = heartrate.Select(int.Parse).ToArray();
            if (SpeedCheck)
            {
                Speed = HRSpeed.Select(int.Parse).ToArray();
            }

            if (AltCheck)
            {
                Altitude = altitude.Select(int.Parse).ToArray();
            }
            if (CadenceCheck)
            {
                Cadeance = cadence.Select(int.Parse).ToArray();
            }
            if (PowerCheck)
            {
                Power = power.Select(int.Parse).ToArray();
            }
            if (PowerBICheck)
            {
                PowerBalance = powerbalance.Select(int.Parse).ToArray();
            }


            // plot to curves
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


            if (SpeedMenuItem.Checked && !MPHRadio.Checked && !KMRadio.Checked) //selects EU or US option first load
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

            SummaryData();

            //loads curves based if they are selected in the options & checked in smode

            if (HeartRateMenuItem.Checked)
            {
                LineItem HeartRateCurve = zedGraphControl1.GraphPane.AddCurve("Heart Rate (Comparison)",
                HeartRate1, Color.DarkBlue, SymbolType.None);
            }

            if (SpeedMenuItem.Checked && SpeedCheck)
            {
                SpeedPlot();
            }

            if (AltitudeMenuItem.Checked && AltCheck)
            {
                LineItem AltitudeCurve = zedGraphControl1.GraphPane.AddCurve("Altitude (Comparison)",
                Altitude1, Color.DarkGreen, SymbolType.None);
            }

            if (CadenceMenuItem.Checked && CadenceCheck)
            {
                LineItem CadenceCurve = zedGraphControl1.GraphPane.AddCurve("Cadence (Comparison)",
                  Cadeance1, Color.MediumPurple, SymbolType.None);
            }
            if (PowerMenuItem.Checked && PowerCheck)
            {
                LineItem PowerCurve = zedGraphControl1.GraphPane.AddCurve("Power (Comparison)",
                  Power1, Color.DarkOrange, SymbolType.None);
            }


            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
            //zedGraphControl1.RestoreScale(zedGraphControl1.GraphPane); //unzooms graph whenever it is reloaded
        }

        private void SetFileVars() //sets all vars from HRFileSort Class
        {
            heartrate = HRFileSort.heartrate;
            HRSpeed = HRFileSort.HRSpeed;
            altitude = HRFileSort.altitude;
            cadence = HRFileSort.cadence;
            power = HRFileSort.power;
            powerbalance = HRFileSort.powerbalance;
            interval = HRFileSort.interval;

            SpeedCheck = HRFileSort.SpeedCheck;
            CadenceCheck = HRFileSort.CadenceCheck;
            PowerCheck = HRFileSort.PowerCheck;
            PowerBICheck = HRFileSort.PowerBICheck;
            PowerPedalCheck = HRFileSort.PowerPedalCheck;
            HRCheck = HRFileSort.HRCheck;
            UnitCheck = HRFileSort.UnitCheck;
            AirPressureCheck = HRFileSort.AirPressureCheck;
            AltCheck = HRFileSort.AltCheck;

            if (HRCheck) { SpeedMenuItem.Checked = true; PowerMenuItem.Checked = true; CadenceMenuItem.Checked = true; AltitudeMenuItem.Checked = true; }
            if (!SpeedCheck) { SpeedMenuItem.Checked = false; }
            if (!PowerCheck) { PowerMenuItem.Checked = false; }
            if (!CadenceCheck) { CadenceMenuItem.Checked = false; }
            if (!AltCheck) { AltitudeMenuItem.Checked = false; }
            //unchecks graph options based on smode values

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        #region UI elemennts
        private void button1_Click(object sender, EventArgs e)
        {
            FTPMaxCalc();
        }

        private void ViewIntervalDetails_Click(object sender, EventArgs e)
        {
            string text = DetectedIntervalBox.GetItemText(DetectedIntervalBox.SelectedItem);
            int row = DetectedIntervalBox.SelectedIndex;
            string pointvals = detectedInterval[row];
            string[] SplitPoints = pointvals.Split(':');
            //MessageBox.Show(rowNumber.ToString());

            IntervalView IntervalView = new IntervalView();
            IntervalView.PointsArray = SplitPoints;
            IntervalView.ShowDialog();
        }

        private void FTPMaxCalc() //Average % calc of user input against max power (watts)
        {
            double intValue = 0;
            if (!Double.TryParse(FTPInput.Text, out intValue))
            {
                MessageBox.Show("Not a number");
                IFLabel.Text = "Enter an FTP Value";
                TSSLabel.Text = "Enter an FTP Value";
            }
            else
            {
                //intValue = intValue * 0.93;
                if (PowerCheck)
                {
                    int percentage = (int)Math.Round((double)(100 * Power.Max()) / intValue);
                    FTPLabel.Text = "(%) of Max Power: " + percentage.ToString() + "%";
                    if (intValue == 0)
                    {
                        IFLabel.Text = "Enter an FTP Value";
                        TSSLabel.Text = "Enter an FTP Value";
                    }
                    else
                    {
                        AdvancedMetricsCalc(intValue);
                    }                
                }
            }
        }
        
        public void AdvancedMetricsCalc(double FTPValue)
        {

            double IF = Math.Round(NormalPowerCalc / FTPValue, 2, MidpointRounding.AwayFromZero);
            IFLabel.Text = IF.ToString();

            int secondstime = Power.Length * interval;
            double TSS = Math.Round(((secondstime * NormalPowerCalc * IF) / (FTPValue * 3600)) * 100, MidpointRounding.AwayFromZero);
            TSSLabel.Text = TSS.ToString();
        }

        private void FTPInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void BPMCalc_Click(object sender, EventArgs e)
        {
            HeartCalcMax();
        }

        private void HeartCalcMax() //Average % calc of user input against max heart rate
        {
            double intValue = 0;
            if (!Double.TryParse(HRUserInput.Text, out intValue))
            {
                MessageBox.Show("Not a number");
            }
            else
            {
                //intValue = intValue * 0.93;
                if (FileLoaded)
                {
                    int percentage = (int)Math.Round((double)(100 * HeartRate.Max()) / intValue);
                    HRCalcLabel.Text = "(%) of Max HR: " + percentage.ToString() + "%";
                }

            }
        }

        private void HRUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BPMCalc_Click(this, new EventArgs());
            }
        }

#endregion

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        public void SModeFalse()
        {
            SpeedCheck = CadenceCheck = AltCheck = PowerCheck = PowerBICheck = PowerPedalCheck = HRCheck = UnitCheck = AirPressureCheck = OptionChanged = false;//reset everything for a new file

        }

        private void ResetGraphObjs() //reset everything for a new file
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
                DetectedIntervalBox.DataSource = null;
                DetectedIntervalBox.Items.Clear();
                try
                {
                    List<string> HRData = File.ReadLines(ofd.FileName)
                                               .SkipWhile(line => line != "[HRData]")
                                               .Skip(1) //skips [HRDATA] line
                                               .TakeWhile(line => line != "[") //until blank space/next section
                                               .ToList();

                    List<string> Params = File.ReadLines(ofd.FileName)
                           .SkipWhile(line => line != "[Params]")
                           .Skip(1) //skips [Params] line
                           .TakeWhile(line => line != "[") //until blank space/next section
                           .ToList();

                    listBox1.DataSource = Params;
                    listBox2.DataSource = HRData;

                    //FileDataManip(HRData, Params);
                    HRFS.FileDataManip(HRData, Params);
                    FileDataLabels(Params);
                    FileNameLabel.Text = System.IO.Path.GetFileName(ofd.FileName);

                    FileLoaded = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("File is incorrect format, please use a correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //error message on incorrect file types
                    return;
                }


                SetFileVars(); //set varSort Class
                PlotGraph(); 
                DataGridViewPlot();
                if (PowerCheck)
                {
                    IntervalDetection();
                }
            }
           
        }


        // method to extract data such as date of race and display in labels.
        private void FileDataLabels(List<string> Params)
        {
            string IntervalFile = Params.Where(x => x.Contains("Interval")).FirstOrDefault();
            string[] Interval = IntervalFile.Split('=');
            interval = Int32.Parse(Interval[1]);
            IntervalLabel.Text = Interval[1];

            string DateFile = Params.Where(x => x.Contains("Date")).FirstOrDefault();
            string[] Date = DateFile.Split('=');

            string TimeFile = Params.Where(x => x.Contains("Start")).FirstOrDefault();
            string[] Time = TimeFile.Split('=');

            string DurationFile = Params.Where(x => x.Contains("Length")).FirstOrDefault();
            string[] Duration = DurationFile.Split('=');

            string DisplayDate = DateTime.ParseExact(Date[1], "yyyymmdd", CultureInfo.InvariantCulture).ToString("dd/mm/yyyy"); //display date to uk format
            DateOfFile.Text = DisplayDate;

            var StartTimeSpan = TimeSpan.ParseExact(Time[1], "c", System.Globalization.CultureInfo.InvariantCulture);
            StartTime.Text = StartTimeSpan.ToString("hh\\:mm\\:ss"); //start time in hh:mm:ss

            var EndTimeSpan = TimeSpan.ParseExact(Duration[1], "c", System.Globalization.CultureInfo.InvariantCulture); 
            end = EndTimeSpan; 
            LengthLabel.Text = EndTimeSpan.ToString("hh\\:mm\\:ss"); //length time in hh:mm:ss

            EndTimeSpan = StartTimeSpan.Add(EndTimeSpan); //adds length to start time for end race time
            EndTime.Text = EndTimeSpan.ToString("hh\\:mm\\:ss");

            start = StartTimeSpan; //assign start to use in PlotGraph/DataGridViewPlot
        }

        private void DataGridViewPlot()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Interval Time (Seconds)");
            dt.Columns.Add("Heart Rate (BPM)");
            //int timer = interval;
            TimeSpan timer = start; // sets timer to start time

            //adds columns to datagrid based on smode values
            if (SpeedCheck)
            {
                dt.Columns.Add("Speed " + "(" + type2 + ")");
            }
            if (CadenceCheck)
            {
                dt.Columns.Add("Cadence (RPM)");
            }
            if (AltCheck)
            {
                dt.Columns.Add("Altitude (M)");
            }
            if (PowerCheck)
            {
                dt.Columns.Add("Power (Watts)");
            }
            if (PowerBICheck)
            {
                dt.Columns.Add("Power Balancing (Left/Right)");
                dt.Columns.Add("Power Pedaling Index");
            }
            for (int i = 0; i < HeartRate.Length; i++)
            {
                DataRow dr = dt.NewRow();
                string balance = null;
                byte index = new byte();
                dr["Heart Rate (BPM)"] = HeartRate[i];
                dr["Interval Time (Seconds)"] = timer.ToString("hh\\:mm\\:ss");

                if (SpeedCheck)
                {
                    int speed = Speed[i] / 10;
                    string speedstring = speed.ToString("N0") + type;
                    dr["Speed " + "(" + type2 + ")"] = speedstring;
                }

                if (PowerBICheck)
                {
                    int PowerB = PowerBalance[i]; //16 bit digit

                    byte left = (byte)(PowerB & 0xFFu); // lower 8 bits 
                    index = (byte)((PowerB >> 8) & 0xFFu); // top 8 bits

                    int right = 100 - left;
                    balance = left.ToString() + "/" + right.ToString();
                    //interval = interval + i;
                    dr["Power Balancing (Left/Right)"] = balance;
                    dr["Power Pedaling Index"] = index;
                }

                if (CadenceCheck)
                {
                    dr["Cadence (RPM)"] = cadence[i];
                }
                if (AltCheck)
                {
                    dr["Altitude (M)"] = Altitude[i];
                }
                if (PowerCheck)
                {
                    dr["Power (Watts)"] = Power[i];
                }
                
                dt.Rows.Add(dr);
                timer = timer.Add(TimeSpan.FromSeconds(interval));
            }
            dataGridView1.DataSource = dt;
            //listBox3.DataSource = dt;
        }

        private void DataGridViewPlotCompare()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("File");
            dt.Columns.Add("Interval Time (Seconds)");
            dt.Columns.Add("Heart Rate (BPM)");
            //int timer = interval;
            TimeSpan timer = start; // sets timer to start time

            //adds columns to datagrid based on smode values
            if (SpeedCheck)
            {
                dt.Columns.Add("Speed " + "(" + type2 + ")");
            }
            if (CadenceCheck)
            {
                dt.Columns.Add("Cadence (RPM)");
            }
            if (AltCheck)
            {
                dt.Columns.Add("Altitude (M)");
            }
            if (PowerCheck)
            {
                dt.Columns.Add("Power (Watts)");
            }
            if (PowerBICheck)
            {
                dt.Columns.Add("Power Balancing (Left/Right)");
                dt.Columns.Add("Power Pedaling Index");
            }
            for (int i = 0; i < heartrate3.Count; i++) 
            {
                    DataRow dr = dt.NewRow();
                    string balance = null;
                    byte index = new byte();
                    dr["File"] = "File 1";
                    dr["Heart Rate (BPM)"] = heartrate[i];
                    dr["Interval Time (Seconds)"] = timer.ToString("hh\\:mm\\:ss");

                    if (SpeedCheck)
                    {
                        int speed = Int32.Parse(HRSpeed[i]) / 10;
                        string speedstring = speed.ToString("N0") + type;
                        dr["Speed " + "(" + type2 + ")"] = speedstring;
                    }

                    if (PowerBICheck)
                    {
                        int PowerB = PowerBalance[i]; //16 bit digit

                        byte left = (byte)(PowerB & 0xFFu); // lower 8 bits 
                        index = (byte)((PowerB >> 8) & 0xFFu); // top 8 bits

                        int right = 100 - left;
                        balance = left.ToString() + "/" + right.ToString();
                        //interval = interval + i;
                        dr["Power Balancing (Left/Right)"] = balance;
                        dr["Power Pedaling Index"] = index;
                    }

                    if (CadenceCheck)
                    {
                        dr["Cadence (RPM)"] = cadence[i];
                    }
                    if (AltCheck)
                    {
                        dr["Altitude (M)"] = altitude[i];
                    }
                    if (PowerCheck)
                    {
                        dr["Power (Watts)"] = power[i];
                    }

                    dt.Rows.Add(dr);
               
                    dr = dt.NewRow();
                    balance = null;
                    index = new byte();
                    dr["File"] = "File 2";
                    dr["Heart Rate (BPM)"] = heartrate3[i];
                    dr["Interval Time (Seconds)"] = timer.ToString("hh\\:mm\\:ss");

                    if (SpeedCheck)
                    {
                        int speed = Int32.Parse(HRSpeed3[i]) / 10;
                        string speedstring = speed.ToString("N0") + type;
                        dr["Speed " + "(" + type2 + ")"] = speedstring;
                    }

                    if (PowerBICheck)
                    {
                        int PowerB = PowerBalance[i]; //16 bit digit

                        byte left = (byte)(PowerB & 0xFFu); // lower 8 bits 
                        index = (byte)((PowerB >> 8) & 0xFFu); // top 8 bits

                        int right = 100 - left;
                        balance = left.ToString() + "/" + right.ToString();
                        //interval = interval + i;
                        dr["Power Balancing (Left/Right)"] = balance;
                        dr["Power Pedaling Index"] = index;
                    }

                    if (CadenceCheck)
                    {
                        dr["Cadence (RPM)"] = cadence3[i];
                    }
                    if (AltCheck)
                    {
                        dr["Altitude (M)"] = altitude3[i];
                    }
                    if (PowerCheck)
                    {
                        dr["Power (Watts)"] = power3[i];
                    }

                    dt.Rows.Add(dr);
                

                    dr = dt.NewRow();
                    balance = null;
                    index = new byte();
                    int difference;
                    dr["File"] = "+/-";
                    int hrcompare1 = Int32.Parse(heartrate[i]);
                    int hrcompare2 = Int32.Parse(heartrate3[i]);
                    difference = hrcompare1 - hrcompare2;
                    dr["Heart Rate (BPM)"] = difference;
                    dr["Interval Time (Seconds)"] = timer.ToString("hh\\:mm\\:ss");

                    if (SpeedCheck)
                    {
                        int speedcompare1 = Int32.Parse(HRSpeed[i]) / 10;
                        int speedcompare2 = Int32.Parse(HRSpeed3[i]) / 10;

                        difference = speedcompare1 - speedcompare2;

                        //string speedstring = difference.ToString("N0") + type;
                        dr["Speed " + "(" + type2 + ")"] = difference;
                    }

                    if (PowerBICheck)
                    {
                        int PowerB = PowerBalance[i]; //16 bit digit

                        byte left = (byte)(PowerB & 0xFFu); // lower 8 bits 
                        index = (byte)((PowerB >> 8) & 0xFFu); // top 8 bits

                        int right = 100 - left;
                        balance = left.ToString() + "/" + right.ToString();
                        //interval = interval + i;
                        dr["Power Balancing (Left/Right)"] = balance;
                        dr["Power Pedaling Index"] = index;
                    }

                    if (CadenceCheck)
                    {
                        int compare1 = Int32.Parse(cadence[i]);
                        int compare2 = Int32.Parse(cadence3[i]);
                        difference = compare1 - compare2;
                        dr["Cadence (RPM)"] = difference;
                    }
                    if (AltCheck)
                    {
                        int compare1 = Int32.Parse(altitude[i]);
                        int compare2 = Int32.Parse(altitude3[i]);
                        difference = compare1 - compare2;
                        dr["Altitude (M)"] = difference;
                    }
                    if (PowerCheck)
                    {
                        int compare1 = Int32.Parse(power[i]);
                        int compare2 = Int32.Parse(power3[i]);
                        difference = compare1 - compare2;
                        dr["Power (Watts)"] = difference;
                    }

                    dt.Rows.Add(dr);
                    timer = timer.Add(TimeSpan.FromSeconds(interval));
                }
            CompareGridView.DataSource = dt;
            tabControl1.SelectTab(2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}