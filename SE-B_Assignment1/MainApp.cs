using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            myPane.XAxis.Title.Text = "Time";
            myPane.YAxis.Title.Text = "Value";
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
                HRSpeed1.Add(i, Speed[i]);
                HeartRate1.Add(i, HeartRate[i]);
                Altitude1.Add(i, Altitude[i]);
                Cadeance1.Add(i, Cadeance[i]);
                Power1.Add(i, Power[i]);
                PB1.Add(i, PB[i]);
            }


            LineItem HeartRateCurve = myPane.AddCurve("Heart Rate",
                HeartRate1, Color.Blue, SymbolType.Diamond);

            LineItem AltitudeCurve = myPane.AddCurve("Altitude",
                Altitude1, Color.Green, SymbolType.Diamond);

            LineItem SpeedCurve = myPane.AddCurve("Speed",
                   HRSpeed1, Color.Red, SymbolType.Diamond);



            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void SetSize()
        {
            zedGraphControl1.Location = new Point(0, 0);
            zedGraphControl1.IsShowPointValues = true;
            zedGraphControl1.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 50);

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Text File";
            ofd.Filter = "hrm|*.hrm";
            ofd.InitialDirectory = @"D:\Desktop\Work\Uni Last Year\Sem2\SE-B";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string[] lines = System.IO.File.ReadAllLines(ofd.FileName);
                try
                {
                    List<string> HRData = File.ReadLines(ofd.FileName)
                                               .SkipWhile(line => line != "[HRData]")
                                               .Skip(1)
                                               .ToList();

                    List<string> Params = File.ReadLines(ofd.FileName)
                           .Take(10).SkipWhile(line => line != "[Params]")
                           .Skip(1)
                           .ToList();


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
                    

                }
                catch (Exception)
                {
                    MessageBox.Show("File is incorrect format, please use a correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //error message on incorrect file types
                }
                plotGraph();
            }
        }
    }
}