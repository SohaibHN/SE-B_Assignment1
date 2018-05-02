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

        List<int> heartrate3 = new List<int>();
        List<int> HRSpeed3 = new List<int>();
        List<int> cadence3 = new List<int>();
        List<int> altitude3 = new List<int>();
        List<int> power3 = new List<int>();
        List<int> powerbalance3 = new List<int>();

        bool SpeedCheck, CadenceCheck, AltCheck, PowerCheck, PowerBICheck, PowerPedalCheck, HRCheck, UnitCheck, FileLoaded, AirPressureCheck, FileComparsion;
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
            tabPage4.Text = @"Summary Section Data";
            tabControl1.TabPages.Remove(tabPage1);
            FTPInput.Maximum = 1000;
            HRUserInput.Maximum = 300;
            this.zedGraphControl1.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zedGraphControl1_PointValueEvent);
        }

        #region IntervalDetection
        double potentialIntervalStart;
        double detectedIntervalEnd;
        List<string> detectedIntervals = new List<string>();
        List<string> detectedInterval = new List<string>();

        /// <summary>  
        /// After a file is loaded/plotted and has power values the intervals are detected
        /// </summary> 
        public void IntervalDetection()
        {

            int detected = 0; // checks how many were found
            detectedIntervals.Clear(); // clears both lists for a new file
            detectedInterval.Clear();

            for (int i = 0; i < HeartRate.Length; i++)
            {
                bool potentialIntervalDetected = false;
                bool intervalDetected = false;

                for (int p = i; p < Power.Length; p++)
                {
                    List<double> currentPowers = new List<double>();
                    List<double> futurepowers = new List<double>();

                    for (int x = 0; x < 10; x++) // rider must be applying power for next 10 seconds
                    {
                        if (p + (x + 1) < Power.Length)
                        {
                            if (Power[p + x] == 0) //if power drops to 0 then the loop is broken and restarts
                            {
                                break;
                            }
                            currentPowers.Add(Power[p + x]); // get power for the next 10 seconds
                           futurepowers.Add(Power[p + (x + 1)]); // get power for the next 10 seconds starting at current power +1
                        }
                    }

                    if (currentPowers.Count < 9) // not enough powers added to the last
                    {
                        break;
                    }

                    double currentPowersAverage = currentPowers.Average();
                    double futurepowersAverage = futurepowers.Average();
                    //Console.WriteLine(currentPowersAverage.ToString() + "/" + futurepowersAverage.ToString());

                    // check for potential interval
                    if (currentPowersAverage < futurepowersAverage)
                    {
                        if (!potentialIntervalDetected)
                        {
                            potentialIntervalStart = p;
                            potentialIntervalDetected = true;
                            //Console.WriteLine(potentialIntervalStart);
                        }
                    }
                    else // possible that cyclist built up speed
                    {

                        int maintain = Power[p];
                        //Console.WriteLine(p.ToString());
                        int percentage = ((maintain * 50) / 100);
                        int minpower = maintain - percentage;
                        int maxpower = maintain + percentage;
                        int minInterval = 15; // interval power must be maintained for atleast 15 seconds

                        int timer = 0;
                        int counter = 1;
                   
                        for (int q = p; q < Power.Length; q++)
                        {
                            if (q == 0) { q = 1; }
                            maintain = Power[q];
                            percentage = ((maintain * 30) / 100);
                            maxpower = maintain + percentage;
                            minpower = maintain - percentage;
                            // gets max/min for every last point

                            if (Power[q] > minpower && Power[q] < maxpower)
                            //if (Power[q] > minpower)
                            {
                                timer = interval * counter;
                                counter++;                             
                            }
                            else
                            {
                                if (timer >= minInterval)
                                {
                                    intervalDetected = true;
                                    detected = detected + 1;
                                    detectedIntervalEnd = q;
                                    detectedInterval.Add(potentialIntervalStart.ToString() + ":" + detectedIntervalEnd.ToString()); //used in intervalview.cs

                                    double intervalend = detectedIntervalEnd * interval;
                                    double intervalstart = potentialIntervalStart * interval;
                                    // time/second values of the intervals

                                    TimeSpan starting = new TimeSpan();
                                    starting = start.Add(TimeSpan.FromSeconds(intervalstart));
                                    TimeSpan ending = new TimeSpan();
                                    ending = start.Add(TimeSpan.FromSeconds(intervalend));
                                    // full timer with starting time
                                    
                                    detectedIntervals.Add("Interval " + detected + "     " + starting.ToString("hh\\:mm\\:ss") + " - " + ending.ToString("hh\\:mm\\:ss"));

                                }
                                break;
                            }
                        }
                    }

                    if (intervalDetected)
                    {
                        i = (int)detectedIntervalEnd; // loop is set to end of detection
                        potentialIntervalStart = detectedIntervalEnd; // potentialIntervalStart is set to end of detection
                        break;
                    }
                    
                }
            }
            
            detectedIntervals.ForEach(Console.WriteLine);
            DetectedIntervalBox.DataSource = detectedIntervals; //viewable list box
            potentialIntervalStart = 0; // reset for future files
        }
        #endregion

        #region SpeedFormat Plots Speed Curve & Allows Users to switch between US & EU formats for Miles/KM

        /// <summary>  
        /// Runs whenever the option is selected in the GUI
        /// </summary> 
        private void SpeedFormat(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            OptionChanged = true; //used for later settings (removing graph lines)
            SpeedPlot();
        }

        /// <summary>  
        ///  plots speeds based on user choice or default file set in file
        /// </summary> 
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

        /// <summary>  
        ///  Converts KM -> Miles
        /// </summary> 
        public static double ConvertMilesToKilometers(double miles)
        {
            // Multiply by this constant and return the result.
            return miles * 1.609344;
        }

        /// <summary>  
        ///  Converts Miles -> KM
        /// </summary>
        public static double ConvertKilometersToMiles(double kilometers)
        {
            // Multiply by this constant.
            return kilometers * 0.621371192;
        }
        #endregion

        #region GraphMenuOptions Removes/Adds lines from graph
        /// <summary>  
        ///  Different Methods for whenever an option is selected in the menu (Removing or Adding hte Line Curve)
        /// </summary> 
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

        /// <summary>  
        ///  Save the zoom values
        /// </summary> 
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

        /// <summary>  
        ///  on any zoom event updates the lists with the points viewable (out/in)
        /// </summary> 
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
            int EndPoint = (int)sender.GraphPane.XAxis.Scale.Max;
            int Difference = EndPoint - StartPoint;


            if (heartrate.Count > StartPoint && heartrate.Count >= EndPoint && FileLoaded)
            {

                zoomIn = true;
                //Heart Rate
                List<int> HeartRateList = heartrate.ConvertAll(int.Parse);
                List<int> UpdatedHeartRate;
                if (StartPoint < 0) { StartPoint = System.Math.Abs(StartPoint); }
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
                if (PowerBICheck)
                {
                    //Power
                    List<int> PowerList = powerbalance.ConvertAll(int.Parse);
                    List<int> UpdatedPowerList;
                    UpdatedPowerList = PowerList.GetRange(StartPoint, Difference);
                    PowerBalance = UpdatedPowerList.ToArray();
                }
                SummaryData();

            }

        }
        #endregion

        #region Plotting to ZedGraph/Summary Data
        /// <summary>  
        ///  //lets the x axis change to interval timespan rather than leaving it in seconds format
        /// </summary> 
        static string Axis_ScaleFormatEvent(GraphPane pane, Axis axis, double val, int index) //lets the x axis change to interval timespan rather than leaving it in seconds format
        {
            double time = val * interval;
            TimeSpan timeVal = start.Add(TimeSpan.FromSeconds(time)); return timeVal.ToString("hh\\:mm\\:ss");
        }

        /// <summary>  
        ///  Allows hovering over each point to display a tooltip e.g. Power(Comparison) - 1000 (+100)
        /// </summary> 
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
        }

        /// <summary>  
        ///  Plots the lists into a zedgraph 
        /// </summary> 
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
            zedGraphControl1.IsShowPointValues = true;
            myPane.XAxis.Scale.Max = heartrate.Count; // graph scales to points in list
            PointPairList HRSpeed1 = new PointPairList();
            PointPairList HeartRate1 = new PointPairList();
            PointPairList Cadeance1 = new PointPairList();
            PointPairList Altitude1 = new PointPairList();
            PointPairList Power1 = new PointPairList();

            // parses lists to int arrays for plotting
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
        }

        /// <summary>  
        ///  summary data calculations to display in gui based on bools set in file loading
        /// </summary> 
        private void SummaryData() // summary data calculations to display in gui
        {
            if (HeartRate.Length == 0) { return; }
            MaxHR.Text = HeartRate.Max().ToString() + " bpm";
            MinHR.Text = HeartRate.Where(f => f > 0).Min().ToString() + " bpm";
            BPM.Text = HeartRate.Where(f => f > 0).Average().ToString("N0") + " bpm";

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
                double time = interval * Speed.Length;
                TimeSpan hours = TimeSpan.FromSeconds(time);
                double distance = AverageSpeed * hours.TotalHours;
                Distance.Text = distance.ToString("0.##") + type2;
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
            if (SummarySec1.Value != 0 && FileLoaded) { DataGridSummarySectionsPlot(); }
        }

        /// <summary>  
        ///  Plots comparions data into the graph
        /// </summary> 
        private void PlotGraphCompare()
        {


            PointPairList HRSpeed1 = new PointPairList();
            PointPairList HeartRate1 = new PointPairList();
            PointPairList Cadeance1 = new PointPairList();
            PointPairList Altitude1 = new PointPairList();
            PointPairList Power1 = new PointPairList();

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
        }
#endregion

        #region Normalized Power Calculation
        double NormalPowerCalc;

        /// <summary>  
        /// uses moving averages to calculate the normalized power. Raises each point in the lsit to the 4th power before averaging.
        /// </summary> 
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
                    MessageBox.Show("More points are required for the Normalized Power Calculation");
                    NormalPower.Text = "More points are required";
                }
            }
        }

        /// <summary>  
        ///  Takes each value in the list and powers it up to x value in the calculation
        /// </summary> 
        public List<double> PowerUp(List<double> AverageList, int p)
        {
            for (var x = 0; x < AverageList.Count; x++)
            {
                AverageList[x] = Math.Pow(AverageList[x], p);
            }

            return AverageList;
        }
#endregion
    
        #region UI elemennts
        /// <summary>  
        /// gets FTP Value for Intensity Factor and TSS & Plots summary sections if the value is not 0
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            FTPMaxCalc();
            if (SummarySec1.Value != 0 && FileLoaded) { DataGridSummarySectionsPlot(); }
        }

        /// <summary>
        /// Used for opening another form to display interval values
        /// </summary>
        /// <remarks>
        /// the class opened just displays the only the intervals on a graph/summary data
        /// </remarks>
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

        /// <summary>  
        /// Plots summary sections if the value is not 0 and on any changes
        /// </summary>
        private void SummarySec1_ValueChanged(object sender, EventArgs e)
        {
            if (SummarySec1.Value != 0 && FileLoaded) { DataGridSummarySectionsPlot(); }
        }

        /// <summary>  
        /// gets FTP Value for Intensity Factor and TSS
        /// </summary>
        private void FTPMaxCalc() //Average % calc of user input against max power (watts)
        {
            double FTPValue = (double)FTPInput.Value;

            if (PowerCheck)
            {
                int percentage = (int)Math.Round((double)(100 * Power.Max()) / FTPValue);
                FTPLabel.Text = "(%) of Max Power: " + percentage.ToString() + "%";

                if (FTPValue == 0)
                {
                    IFLabel.Text = "Enter an FTP Value";
                    TSSLabel.Text = "Enter an FTP Value";
                }
                else
                {
                    AdvancedMetricsCalc(FTPValue);
                }                               
            }
        }

        /// <summary>  
        /// Calculates Intensity Factor and TSS based on normalised power and FTP Value
        /// </summary>
        public void AdvancedMetricsCalc(double FTPValue)
        {

            double IF = Math.Round(NormalPowerCalc / FTPValue, 2, MidpointRounding.AwayFromZero);
            IFLabel.Text = IF.ToString();

            int secondstime = Power.Length * interval;
            double TSS = Math.Round(((secondstime * NormalPowerCalc * IF) / (FTPValue * 3600)) * 100, MidpointRounding.AwayFromZero);
            TSSLabel.Text = TSS.ToString();
        }

        /// <summary>  
        /// IF enter is pressed FTPCalc is called
        /// </summary>
        private void FTPInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        /// <summary>  
        /// On value changed for Heart Rate User Input
        /// </summary>
        private void BPMCalc_Click(object sender, EventArgs e)
        {
            HeartCalcMax();
        }

        /// <summary>  
        /// User input for entered heart rate compares against max heart rate
        /// </summary>
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

        /// <summary>  
        /// IF enter is pressed BPMCalc is called
        /// </summary>
        private void HRUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BPMCalc_Click(this, new EventArgs());
            }
        }

        #endregion

        #region File Loading/Information
        /// <summary>  
        ///  Sets variables for inital loading of file
        /// </summary> 
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
        /// <summary>  
        ///  Loads file and passes it to the HRFS Class/File for sorting before plotting
        /// </summary> 
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
                zoomIn = false;
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
                    FileComparsion = false;
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

        /// <summary>  
        /// method to extract data such as date of race and display in labels
        /// </summary>
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

        /// <summary>  
        /// Reset bools called everytime a file is loaded
        /// </summary>
        public void SModeFalse()
        {
            SpeedCheck = CadenceCheck = AltCheck = PowerCheck = PowerBICheck = PowerPedalCheck = HRCheck = UnitCheck = AirPressureCheck = OptionChanged = false;//reset everything for a new file
        }

        /// <summary>  
        /// Clears lists
        /// </summary>
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

        /// <summary>  
        ///  Loads file and passes it to the HRFS Class/File for sorting before plotting
        /// </summary> 
        private void compareFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Open HRM File",
                Filter = "hrm|*.hrm"
            };


            HRSpeed2 = HRSpeed.ToList(); // stores original variables to temporary list
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

                    HRFS.FileDataManip(HRData, Params);
                    FileComparsion = true;

                }
                catch (Exception)
                {
                    MessageBox.Show("File is incorrect format, please use a correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //error message on incorrect file types
                    return;
                }

                SetFileVars(); //set varSort Class
                PlotGraphCompare();

                HRSpeed3 = Speed.ToList(); // stores the variables after they have been plotted to the graph into a different list for the datagrids
                heartrate3 = HeartRate.ToList();
                cadence3 = Cadeance.ToList();
                altitude3 = Altitude.ToList();
                power3 = Power.ToList();
                powerbalance3 = PowerBalance.ToList();

                HRSpeed = HRSpeed2.ToList();
                heartrate = heartrate2.ToList();
                cadence = cadence2.ToList();
                altitude = altitude2.ToList();
                power = power2.ToList();
                powerbalance = powerbalance2.ToList();

                DataGridViewPlotCompare();
                DataGridSummarySectionsPlot();

                HRSpeed2.Clear();
                heartrate2.Clear();
                cadence2.Clear();
                altitude2.Clear();
                power2.Clear();
                powerbalance2.Clear();
            }
        }
#endregion

        #region DataGrid Plotting Methods
        /// <summary>  
        ///  Plots file data into datagridview with proper calcuations e.g. Power Balance, Speed etc.
        /// </summary> 
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
            
        }

        /// <summary>  
        ///  Plots summary data into gridview based on user input on how many sections and for a file comparions (if applicable)
        /// </summary> 
        private void DataGridSummarySectionsPlot()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("File");


            dt.Columns.Add("Section");
            dt.Columns.Add("Average Heart Rate (BPM)");

            var SplitHeartRate = HeartRate.Split((int)SummarySec1.Value);
            var SplitSpeed = Speed.Split((int)SummarySec1.Value);
            var SplitAlt = Altitude.Split((int)SummarySec1.Value);
            var SplitCadence = Cadeance.Split((int)SummarySec1.Value);
            var SplitPower = Power.Split((int)SummarySec1.Value);
            var SplitPowerBI = PowerBalance.Split((int)SummarySec1.Value);
            string balance = null;
            byte index = new byte();
            byte index2 = new byte();
            double AverageSpeed, AverageSpeed2, AverageCadence, AverageCadence2, AverageAlt, AverageAlt2, AveragePower, AveragePower2, NormalPowerCalc2, IF, IF2, TSS, TSS2;
            AverageSpeed = AverageSpeed2 = AverageCadence = AverageCadence2 = AverageAlt = AverageAlt2 = AveragePower = AveragePower2 = NormalPowerCalc2 = IF = IF2 = TSS = TSS2 = 0;
            //adds columns to datagrid based on smode values
            if (SpeedCheck)
            {
                dt.Columns.Add("Average Speed " + "(" + type2 + ")");
            }
            if (CadenceCheck)
            {
                dt.Columns.Add("Average Cadence (RPM)");
            }
            if (AltCheck)
            {
                dt.Columns.Add("Average Altitude (M)");
            }
            if (PowerCheck)
            {
                dt.Columns.Add("Average Power (Watts)");
            if (PowerBICheck)
            {
                dt.Columns.Add("Average Power Balancing (Left/Right)");
                dt.Columns.Add("Average Power Pedaling Index");
            }
                dt.Columns.Add("Normalised Power (Watts)");
                dt.Columns.Add("Intensitiy Factor");
                dt.Columns.Add("Training Stress Score");
            }

            for (int i = 0; i < SummarySec1.Value; i++)
            {
                DataRow dr = dt.NewRow(); // First FILE
                dr["File"] = FileNameLabel.Text;

                int section = i + 1;

                var ResultList = SplitHeartRate.ElementAt(i).ToList();
                if (ResultList.Count == 0) { break; }
                double AverageHR = ResultList.Average();
                string AverageString = AverageHR.ToString("0.##");
                dr["Average Heart Rate (BPM)"] = AverageString;
                dr["Section"] = "Section " + section;


                if (SpeedCheck)
                {
                    ResultList = SplitSpeed.ElementAt(i).ToList();
                    double TotalAverageSpeed = ResultList.Average();
                    AverageSpeed = TotalAverageSpeed / 10;
                    string speedstring = AverageSpeed.ToString("0.##") + type;
                    dr["Average Speed " + "(" + type2 + ")"] = speedstring;
                }
                if (CadenceCheck)
                {
                    ResultList = SplitCadence.ElementAt(i).ToList();
                    AverageCadence = ResultList.Average();
                    AverageString = AverageCadence.ToString("0.##");
                    dr["Average Cadence (RPM)"] = AverageString;
                }
                if (AltCheck)
                {
                    ResultList = SplitAlt.ElementAt(i).ToList();
                    AverageAlt = ResultList.Average();
                    AverageString = AverageAlt.ToString("0.##");
                    dr["Average Altitude (M)"] = AverageString;
                }
                if (PowerBICheck)
                {
                    ResultList = SplitPowerBI.ElementAt(i).ToList();
                    int PowerB = (int)ResultList.Where(f => f > 0).Average(); //16 bit digit

                    byte left = (byte)(PowerB & 0xFFu); // lower 8 bits 
                    index = (byte)((PowerB >> 8) & 0xFFu); // top 8 bits

                    int right = 100 - left;
                    balance = left.ToString() + "/" + right.ToString();

                    dr["Average Power Balancing (Left/Right)"] = balance;
                    dr["Average Power Pedaling Index"] = index;
                }
                if (PowerCheck)
                {
                    ResultList = SplitPower.ElementAt(i).ToList();
                    AveragePower = ResultList.Average();
                    AverageString = AveragePower.ToString("0.##");
                    dr["Average Power (Watts)"] = AverageString;
                    try
                    {
                        // calculate a rolling 30 second average of the preceding time points after 30 seconds
                        int timeset = 30 / interval;

                        List<double> movingAverages = Enumerable
                        .Range(0, ResultList.Count - timeset)
                        .Select(n => ResultList.Skip(n).Take(timeset).Average())
                        .ToList();

                        List<double> averagesToFourthPower = PowerUp(movingAverages, 4);

                        // find the average of values raised to fourth power
                        double PowerAverage = averagesToFourthPower.Average();

                        // take the fourth root of the average values raised to the fourth power
                        NormalPowerCalc = Math.Round(Math.Pow(PowerAverage, 1.0 / 4), 2, MidpointRounding.AwayFromZero);
                        AverageString = NormalPowerCalc.ToString("0.##");
                        dr["Normalised Power (Watts)"] = AverageString;
                        double FTPValue = (double)FTPInput.Value;
                        string AverageString1, AverageString2;
                        if (FTPValue == 0)
                        {
                            AverageString1 = AverageString2 = "Enter an FTP Value";
                        }
                        else
                        {
                            //MessageBox.Show(FTPValue.ToString());
                            IF = Math.Round(NormalPowerCalc / FTPValue, 2, MidpointRounding.AwayFromZero);
                            int secondstime = ResultList.Count * interval;
                            TSS = Math.Round(((secondstime * NormalPowerCalc * IF) / (FTPValue * 3600)) * 100, MidpointRounding.AwayFromZero);
                            AverageString1 = IF.ToString("0.##");
                            AverageString2 = TSS.ToString("0.##");
                        }

                        dr["Intensitiy Factor"] = AverageString1;
                        dr["Training Stress Score"] = AverageString2;
                    }
                    catch { MessageBox.Show("Not enough data to calculate Normalised Power"); }
                }

                dt.Rows.Add(dr);

                if (FileComparsion)
                {
                    dr = dt.NewRow(); // file 2
                    SplitHeartRate = heartrate3.Split((int)SummarySec1.Value);
                    SplitSpeed = HRSpeed3.Split((int)SummarySec1.Value);
                    SplitAlt = altitude3.Split((int)SummarySec1.Value);
                    SplitCadence = cadence3.Split((int)SummarySec1.Value);
                    SplitPower = power3.Split((int)SummarySec1.Value);
                    SplitPowerBI = powerbalance3.Split((int)SummarySec1.Value);

                    //balance = null;
                    index2 = new byte();
                    dr["File"] = "File 2";

                    ResultList = SplitHeartRate.ElementAt(i).ToList();
                    if (ResultList.Count == 0) { break; }
                    double AverageHR2 = ResultList.Average();
                    AverageString = AverageHR2.ToString("0.##");
                    dr["Average Heart Rate (BPM)"] = AverageString;
                    dr["Section"] = "Section " + section;

                    if (SpeedCheck)
                    {
                        ResultList = SplitSpeed.ElementAt(i).ToList();
                        double TotalAverageSpeed = ResultList.Average();
                        AverageSpeed2 = TotalAverageSpeed / 10;
                        string speedstring = AverageSpeed2.ToString("0.##") + type;
                        dr["Average Speed " + "(" + type2 + ")"] = speedstring;
                    }
                    if (CadenceCheck)
                    {
                        ResultList = SplitCadence.ElementAt(i).ToList();
                        AverageCadence2 = ResultList.Average();
                        AverageString = AverageCadence2.ToString("0.##");
                        dr["Average Cadence (RPM)"] = AverageString;
                    }
                    if (AltCheck)
                    {
                        ResultList = SplitAlt.ElementAt(i).ToList();
                        AverageAlt2 = ResultList.Average();
                        AverageString = AverageAlt2.ToString("0.##");
                        dr["Average Altitude (M)"] = AverageString;
                    }
                    if (PowerBICheck)
                    {
                        ResultList = SplitPowerBI.ElementAt(i).ToList();
                        int PowerB = (int)ResultList.Where(f => f > 0).Average(); //16 bit digit

                        byte left = (byte)(PowerB & 0xFFu); // lower 8 bits 
                        index2 = (byte)((PowerB >> 8) & 0xFFu); // top 8 bits

                        int right = 100 - left;
                        balance = left.ToString() + "/" + right.ToString();

                        dr["Average Power Balancing (Left/Right)"] = balance;
                        dr["Average Power Pedaling Index"] = index2;
                    }
                    if (PowerCheck)
                    {
                        ResultList = SplitPower.ElementAt(i).ToList();
                        AveragePower2 = ResultList.Average();
                        AverageString = AveragePower2.ToString("0.##");
                        dr["Average Power (Watts)"] = AverageString;
                        try
                        {
                            // calculate a rolling 30 second average of the preceding time points after 30 seconds
                            int timeset = 30 / interval;

                            List<double> movingAverages = Enumerable
                            .Range(0, ResultList.Count - timeset)
                            .Select(n => ResultList.Skip(n).Take(timeset).Average())
                            .ToList();

                            List<double> averagesToFourthPower = PowerUp(movingAverages, 4);

                            // find the average of values raised to fourth power
                            double PowerAverage = averagesToFourthPower.Average();

                            // take the fourth root of the average values raised to the fourth power
                            NormalPowerCalc2 = Math.Round(Math.Pow(PowerAverage, 1.0 / 4), 2, MidpointRounding.AwayFromZero);                           
                            AverageString = NormalPowerCalc.ToString("0.##");
                            dr["Normalised Power (Watts)"] = AverageString;
                            double FTPValue = (double)FTPInput.Value;
                            string AverageString1, AverageString2;
                            if (FTPValue == 0)
                            {
                                AverageString1 = AverageString2 = "Enter an FTP Value";
                            }
                            else
                            {
                                //MessageBox.Show(FTPValue.ToString());
                                IF2 = Math.Round(NormalPowerCalc2 / FTPValue, 2, MidpointRounding.AwayFromZero);
                                int secondstime = ResultList.Count * interval;
                                TSS2 = Math.Round(((secondstime * NormalPowerCalc2 * IF2) / (FTPValue * 3600)) * 100, MidpointRounding.AwayFromZero);
                                AverageString1 = IF2.ToString("0.##");
                                AverageString2 = TSS2.ToString("0.##");
                            }

                            dr["Intensitiy Factor"] = AverageString1;
                            dr["Training Stress Score"] = AverageString2;
                        }
                        catch { MessageBox.Show("Not enough data to calculate Normalised Power"); }
                    }

                    dt.Rows.Add(dr);

                    dr = dt.NewRow(); // difference
                    balance = null;
                    index = new byte();
                    double difference;
                    dr["File"] = "Difference (+/-)";
                    difference = AverageHR - AverageHR2;
                    dr["Average Heart Rate (BPM)"] = difference;
                    dr["Section"] = "Section " + section;

                    if (SpeedCheck)
                    {
                        difference = AverageSpeed - AverageSpeed2;
                        string speedstring = difference.ToString("0.##");
                        dr["Average Speed " + "(" + type2 + ")"] = speedstring;
                    }
                    if (CadenceCheck)
                    {
                        difference = AverageCadence - AverageCadence2;
                        AverageString = difference.ToString("0.##");

                        dr["Average Cadence (RPM)"] = AverageString;
                    }
                    if (AltCheck)
                    {
                        difference = AverageCadence - AverageCadence2;
                        AverageString = difference.ToString("0.##");

                        dr["Average Altitude (M)"] = AverageString;
                    }
                    if (PowerBICheck)
                    {
                        ResultList = SplitPowerBI.ElementAt(i).ToList();
                        int PowerB = (int)ResultList.Where(f => f > 0).Average(); //16 bit digit

                        byte left = (byte)(PowerB & 0xFFu); // lower 8 bits 
                        index2 = (byte)((PowerB >> 8) & 0xFFu); // top 8 bits

                        int right = 100 - left;
                        balance = left.ToString() + "/" + right.ToString();

                       // dr["Average Power Balancing (Left/Right)"] = balance;
                       // dr["Average Power Pedaling Index"] = index2;
                    }
                    if (PowerCheck)
                    {
                        difference = AveragePower - AveragePower2;
                        AverageString = difference.ToString("0.##");
                        dr["Average Power (Watts)"] = AverageString;
                    }
                    if (PowerBICheck)
                    {
                        difference = NormalPowerCalc - NormalPowerCalc2;
                        AverageString = difference.ToString("0.##");

                        dr["Normalised Power (Watts)"] = AverageString;
                        double FTPValue = (double)FTPInput.Value;
                        string AverageString1, AverageString2;
                        if (FTPValue == 0)
                        {
                            AverageString1 = AverageString2 = "Enter an FTP Value";
                        }
                        else
                        {
                            //MessageBox.Show(FTPValue.ToString());
                            difference = IF - IF2;
                            AverageString1 = difference.ToString("0.##");

                            difference = TSS - TSS2;
                            AverageString2 = difference.ToString("0.##");
                        }

                        dr["Intensitiy Factor"] = AverageString1;
                        dr["Training Stress Score"] = AverageString2;
                    }
                    dt.Rows.Add(dr);
                }                
            }
            SummarySections.DataSource = dt;
        }

        /// <summary>  
        ///  Plots the file data for comparsions for a different with every point/time interval
        /// </summary> 
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
            for (int i = 0; i < heartrate.Count; i++) 
            {
                    DataRow dr = dt.NewRow(); //file one
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
               
                    dr = dt.NewRow(); // file 2
                    balance = null;
                    index = new byte();
                    dr["File"] = "File 2";
                    dr["Heart Rate (BPM)"] = heartrate3[i];
                    dr["Interval Time (Seconds)"] = timer.ToString("hh\\:mm\\:ss");

                    if (SpeedCheck)
                    {
                        int speed = HRSpeed3[i] / 10;
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
                

                    dr = dt.NewRow(); // difference
                    balance = null;
                    index = new byte();
                    int difference;
                    dr["File"] = "+/-";
                    int hrcompare1 = Int32.Parse(heartrate[i]);
                    int hrcompare2 = heartrate3[i];
                    difference = hrcompare1 - hrcompare2;
                    dr["Heart Rate (BPM)"] = difference;
                    dr["Interval Time (Seconds)"] = timer.ToString("hh\\:mm\\:ss");

                    if (SpeedCheck)
                    {
                        int speedcompare1 = Int32.Parse(HRSpeed[i]) / 10;
                        int speedcompare2 = HRSpeed3[i] / 10;

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
                        int compare2 = cadence3[i];
                        difference = compare1 - compare2;
                        dr["Cadence (RPM)"] = difference;
                    }
                    if (AltCheck)
                    {
                        int compare1 = Int32.Parse(altitude[i]);
                        int compare2 = altitude3[i];
                        difference = compare1 - compare2;
                        dr["Altitude (M)"] = difference;
                    }
                    if (PowerCheck)
                    {
                        int compare1 = Int32.Parse(power[i]);
                        int compare2 = power3[i];
                        difference = compare1 - compare2;
                        dr["Power (Watts)"] = difference;
                    }

                    dt.Rows.Add(dr);
                    timer = timer.Add(TimeSpan.FromSeconds(interval));
                }
            CompareGridView.DataSource = dt;
            tabControl1.SelectTab(2);
        }

#endregion

    } // end of partial form 1 class

    /// <summary>  
    ///  Extension class for list to split it into smaller versions based on user input
    /// </summary> 
    public static class Extensions
    {
        public static IEnumerable<List<T>> Split<T>(this IEnumerable<T> source, int parts)
        {
            var list = new List<T>(source);
            int defaultSize = (int)((double)list.Count / (double)parts);
            int offset = list.Count % parts;
            int position = 0;

            for (int i = 0; i < parts; i++)
            {
                int size = defaultSize;
                if (i < offset)
                    size++; // Just add one to the size (it's enough).

                yield return list.GetRange(position, size);

                // Set the new position after creating a part list, so that it always start with position zero on the first yield return above.
                position += size;
            }
        }
    }
}