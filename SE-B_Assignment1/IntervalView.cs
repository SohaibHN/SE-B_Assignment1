using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace SE_B_Assignment1
{
    public partial class IntervalView : Form
    {
        HRFileSort HRFS = new HRFileSort();
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

        bool SpeedCheck, CadenceCheck, AltCheck, PowerCheck, PowerBICheck, PowerPedalCheck, HRCheck, UnitCheck, AirPressureCheck;
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

        /// <summary>  
        /// Class to display interval points only in graph/summary data from MainApp.cs
        /// Uses many of the samy classes from MainApp.cs with minor differences.
        /// </summary> 
        public IntervalView()
        {
            InitializeComponent();

            FTPInput.Maximum = 1000;
            HRUserInput.Maximum = 300;
        }
        /// <summary>  
        /// Gets detected interval list from MainApp.cs.
        /// </summary> 
        public string[] PointsArray { get; set; }

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

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            
        }
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
        int StartPoint;
        int EndPoint;
        int Difference;
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


            StartPoint = (int)sender.GraphPane.XAxis.Scale.Min;
            EndPoint = (int)sender.GraphPane.XAxis.Scale.Max - 1;
            Difference = EndPoint - StartPoint;
            
            SummaryZoomCalc();
        }

        public void SummaryZoomCalc()
        {
            int test = Difference + StartPoint;

            if (heartrate.Count > StartPoint && heartrate.Count >= EndPoint && test < heartrate.Count)
            {

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
                SummaryData();
            }
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

        static string Axis_ScaleFormatEvent(GraphPane pane, Axis axis, double val, int index) //lets the x axis change to interval timespan rather than leaving it in seconds format
        {
            double time = val * interval;
            TimeSpan timeVal = start.Add(TimeSpan.FromSeconds(time)); return timeVal.ToString("hh\\:mm\\:ss");
        }

        private void PlotGraph()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;

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
            int start = Int32.Parse(PointsArray[0]);
            int end = Int32.Parse(PointsArray[1]);
            StartPoint = start;
            EndPoint = end;
            Difference = EndPoint - StartPoint;
            myPane.XAxis.Scale.Max = Difference;
            myPane.XAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(Axis_ScaleFormatEvent); //lets the x axis change to interval timespan rather than leaving it in seconds format

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

            int i2 = 0;
            // plot to curves
            for (int i = start; i < end; i++)
            {
                i2 = i2 + 1;
                if (!HRCheck)
                {
                    HeartRate1.Add(i2, HeartRate[i]);
                }
                else
                {
                    HeartRate1.Add(i2, HeartRate[i]);
                    if (SpeedCheck)
                    {
                        int speed = Speed[i] / 10;
                        HRSpeed1.Add(i2, speed);
                    }
                    if (CadenceCheck)
                    {
                        Cadeance1.Add(i2, Cadeance[i]);
                    }
                    if (AltCheck)
                    {
                        Altitude1.Add(i2, Altitude[i]);
                    }
                    if (PowerCheck)
                    {
                        Power1.Add(i2, Power[i]);
                    }
                }

            }

            //loads curves based if they are selected in the options & checked in smode

                LineItem HeartRateCurve = myPane.AddCurve("Heart Rate",
                HeartRate1, Color.Blue, SymbolType.None);

            if (SpeedCheck)
            {
                LineItem AltitudeCurve = myPane.AddCurve("Speed",
                HRSpeed1, Color.Red, SymbolType.None);
            }

            if (AltCheck)
            {
                LineItem AltitudeCurve = myPane.AddCurve("Altitude",
                Altitude1, Color.Green, SymbolType.None);
            }

            if (CadenceCheck)
            {
                LineItem CadenceCurve = myPane.AddCurve("Cadence",
                  Cadeance1, Color.Purple, SymbolType.None);
            }
            if (PowerCheck)
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
                double time = interval * Difference;
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
                    //MessageBox.Show("30 Points required for Normalized Power Calc");
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

        #region UI elemennts
        private void button1_Click(object sender, EventArgs e)
        {
            FTPMaxCalc();
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

                int percentage = (int)Math.Round((double)(100 * HeartRate.Max()) / intValue);
                HRCalcLabel.Text = "(%) of Max HR: " + percentage.ToString() + "%";

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

        private void IntervalView_Load(object sender, EventArgs e)
        {
            SetFileVars();
            PlotGraph();
            SummaryZoomCalc();
            
        }
    }
}
