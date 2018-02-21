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

        TimeSpan start;
        TimeSpan end;

        DateTime starts;

        int interval;

        public Form1()
        {
            InitializeComponent();
           
        }

        private int[] buildTeamAData()
        {
            int[] goalsScored = new int[10];
            for (int i = 0; i < 10; i++)
            {
                goalsScored[i] = (i + 1) * 10;
            }
            return goalsScored;
        }

        private int[] buildTeamBData()
        {
            int[] goalsScored = new int[10];
            for (int i = 0; i < 10; i++)
            {
                goalsScored[i] = (i + 10) * 11;
            }
            return goalsScored;
        }

        private void plotGraph()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            // Set the Titles
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "Seconds";
            myPane.YAxis.Title.Text = "Value";
            myPane.XAxis.Title.Text = "Time (in Seconds)";
            myPane.XAxis.Scale.Min = new XDate(start.TotalDays);
            myPane.XAxis.Scale.Max = new XDate(DateTime.Now);
            myPane.XAxis.Scale.MinorStep = interval;
            myPane.XAxis.Scale.MajorStep = interval * 5;

            /* myPane.XAxis.Scale.MajorStep = 50;
             myPane.YAxis.Scale.Mag = 0;
             myPane.XAxis.Scale.Max = 1000;*/

            PointPairList HRSpeed1 = new PointPairList();
            PointPairList HeartRate1 = new PointPairList();
            PointPairList Cadeance1 = new PointPairList();
            PointPairList Altitude1 = new PointPairList();
            PointPairList Power1 = new PointPairList();
            PointPairList PB1 = new PointPairList();

            int[] Speed = HRSpeed.Select(int.Parse).ToArray();
            int[] HeartRate = heartrate.Select(int.Parse).ToArray();
            int[] Altitude = altitude.Select(int.Parse).ToArray();
            int[] Cadeance = cadence.Select(int.Parse).ToArray();
            int[] Power = power.Select(int.Parse).ToArray();
            int[] PB = powerbalance.Select(int.Parse).ToArray();

            for (int i = 0; i < Speed.Length; i++)
            {
                //int speed = Speed[i] / 10;
                //interval = interval + i;
                HRSpeed1.Add(i, Speed[i]);
                HeartRate1.Add(i, HeartRate[i]);
                Altitude1.Add(i, Altitude[i]);
                Cadeance1.Add(i, Cadeance[i]);
                Power1.Add(i, Power[i]);
                PB1.Add(i, PB[i]);
            }
            MaxHR.Text = HeartRate.Max().ToString();
            MinHR.Text = HeartRate.Where(f => f > 0).Min().ToString();
            //MinHR.Text = Speed.Where(f => f > 0).Min().ToString();

            LineItem HeartRateCurve = myPane.AddCurve("Heart Rate",
                HeartRate1, Color.Blue, SymbolType.Diamond);

            LineItem AltitudeCurve = myPane.AddCurve("Altitude",
                Altitude1, Color.Green, SymbolType.Diamond);

            LineItem SpeedCurve = myPane.AddCurve("Speed",
                   HRSpeed1, Color.Red, SymbolType.Diamond);



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

        private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // clear lists everytime a file is loaded
            heartrate.Clear();
            HRSpeed.Clear();
            cadence.Clear();
            altitude.Clear();
            power.Clear();
            powerbalance.Clear();
            
            // Show the dialog and get result.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Text File";
            ofd.Filter = "hrm|*.hrm";
            //ofd.InitialDirectory = @"D:\Desktop\Work\Uni Last Year\Sem2\SE-B";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string[] lines = System.IO.File.ReadAllLines(ofd.FileName);
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
                    listBox1.DataSource = Params;

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

                    foreach (var one in HRData)
                    {
                        Splitter = one.Split('\t');
                        heartrate.Add(Splitter[0]);
                        HRSpeed.Add(Splitter[1]);
                        cadence.Add(Splitter[2]);
                        altitude.Add(Splitter[3]);
                        power.Add(Splitter[4]);
                        powerbalance.Add(Splitter[5]);
                        //MessageBox.Show(info13[0]);

                    }
                    string DisplayDate = DateTime.ParseExact(Date[1], "yyyymmdd", CultureInfo.InvariantCulture).ToString("dd/mm/yyyy");
                    DateOfFile.Text = DisplayDate;
                    var StartTimeSpan = TimeSpan.ParseExact(Time[1], "c", System.Globalization.CultureInfo.InvariantCulture);
                    StartTime.Text = StartTimeSpan.ToString();

                    var EndTimeSpan = TimeSpan.ParseExact(Duration[1], "c", System.Globalization.CultureInfo.InvariantCulture);
                    EndTimeSpan = StartTimeSpan.Add(EndTimeSpan);
                    EndTime.Text = EndTimeSpan.ToString("hh\\:mm\\:ss");

                    start = StartTimeSpan;
                    end = EndTimeSpan;

                }
                catch (Exception)
                {
                    MessageBox.Show("File is incorrect format, please use a correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //error message on incorrect file types
                    return;
                }
                plotGraph();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}