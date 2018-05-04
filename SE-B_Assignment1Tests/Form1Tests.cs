using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE_B_Assignment1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_B_Assignment1.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        // used as the example file for multiple tests
        string filename = "D:\\Desktop\\Work\\Uni Last Year\\Sem2\\ASDBExampleCycleComputerData.hrm";

        /// <summary>  
        ///  Tests the powering up method
        ///  PowerUp takes a list and value to use for the power of
        /// </summary>  
        [TestMethod()]
        public void PowerUpTest()
        {
            List<double> List = new List<double>();
            var MainApp = new Form1(); // new main form context
            List.Add(2);
            var List2 = MainApp.PowerUp(List, 4);
            Assert.IsTrue(List2[0] == 16, "Result is powered up as expected"); // Result is powered up as expected
        }

        /// <summary>  
        ///  Tests the extension method that allows splitting any lists/arrays into smaller 3d versions
        ///  Split is an extension for any lists
        ///  Test ensures the list was split up into the request value (3)
        /// </summary> 
        [TestMethod()]
        public void TestChunking()
        {
            List<double> List = new List<double>();
            var MainApp = new Form1(); // new main form context
            for (int i = 0; i < 10; i++)
            {
                List.Add(i);
            }
            var List2 = List.Split(3);
            Assert.IsTrue(List2.Count() == 3, "List is split up as requested"); // List is split up as requested
        }

        /// <summary>  
        ///  Tests the file input method with the default file
        ///  Returns false if the file is unable to be split into the correct arrays, bools etc.
        /// </summary> 
        [TestMethod()]
        public void ParseFileTest()
        {
            var MainApp = new Form1(); // new main form context
            // string filename = "D:\\Desktop\\Work\\Uni Last Year\\Sem2\\ASDBExampleCycleComputerData.hrm";
            Assert.IsTrue(MainApp.ParseFile(filename)); //standard file is read in like normal
        }

        /// <summary>  
        ///  Tests the bools set from loading the file correctly prevent plotting to the datagrid
        /// </summary> 
        [TestMethod()]
        public void DataGridViewPlotTest()
        {
            List<double> List = new List<double>();
            var MainApp = new Form1(); // new main form context
            var count = MainApp.DataGridViewPlot();
            Assert.IsTrue(count == 0, "Bool variables stop plotting as the lists do not exist/no file is loaded"); // List is split up as requested
        }

        /// <summary>  
        ///  Tests the file is plotted to the datagrid correctly
        /// </summary> 
        [TestMethod()]
        public void DataGridViewPlotTest2()
        {
            var MainApp = new Form1(); // new main form context
            // string filename = "D:\\Desktop\\Work\\Uni Last Year\\Sem2\\ASDBExampleCycleComputerData.hrm";
            MainApp.ParseFile(filename);
            var count = MainApp.DataGridViewPlot();
            Assert.IsTrue(count > 0, "File is plotted to datagrid as expected");
        }

        /// <summary>  
        /// Tests the file is plotted to the zedgraph component as expected with the default file (5 curves)
        /// </summary> 
        [TestMethod()]
        public void ExampleFilePlotGraph()
        {
            var MainApp = new Form1(); // new main form context
            // string filename = "D:\\Desktop\\Work\\Uni Last Year\\Sem2\\ASDBExampleCycleComputerData.hrm";
            MainApp.ParseFile(filename);
            var count = MainApp.PlotGraph();
            Assert.IsTrue(count == 5, "5 Curves are plotted as expectec");
        }

        /// <summary>  
        /// Checks after loading a file the lists etc. are cleared correctly
        /// </summary> 
        [TestMethod()]
        public void ClearObjectsTest()
        {

            var MainApp = new Form1(); // new main form context
            // string filename = "D:\\Desktop\\Work\\Uni Last Year\\Sem2\\ASDBExampleCycleComputerData.hrm";
            MainApp.ParseFile(filename);
            MainApp.ResetGraphObjs();
            Assert.IsTrue(MainApp.heartrate.Count == 0, "lists are set to 0 as expected after loading in an initial file"); // List is split up as requested
        }

        /// <summary>  
        /// Tests GUI options/values are altered based on the file input
        /// By Default SpeedMenuItem.Checked returns false unless a file has the speed column
        /// </summary> 
        [TestMethod()]
        public void GraphOptionsChangeTest()
        {
            var MainApp = new Form1(); // new main form context
            // string filename = "D:\\Desktop\\Work\\Uni Last Year\\Sem2\\ASDBExampleCycleComputerData.hrm";
            MainApp.ParseFile(filename);
            Assert.IsTrue(MainApp.SpeedMenuItem.Checked == true, "Bool values from HRM File Class alter values in Main App and the GUI"); // List is split up as requested
        }

        /// <summary>  
        /// Tests Normalised Power is the expected result from the example file
        /// Loads in the normal file and calcs the normalzied power
        /// </summary> 
        [TestMethod()]
        public void CalculateNormalizedPowerTest()
        {
            var MainApp = new Form1(); // new main form context
            // string filename = "D:\\Desktop\\Work\\Uni Last Year\\Sem2\\ASDBExampleCycleComputerData.hrm";
            MainApp.ParseFile(filename);
            double power = MainApp.CalculateNormalizedPower();
            power = Math.Round(power, 0, MidpointRounding.AwayFromZero);
            Assert.IsTrue(power == 232, "Expected normalised power from the example file is rounded up to 232"); // List is split up as requested
        }

        /// <summary>  
        /// Tests Speed Format/Convert options
        /// </summary> 
        [TestMethod()]
        public void ConvertMilesToKilometersTest()
        {
            var MainApp = new Form1(); // new main form context
            double miles = 1;
            double km = MainApp.ConvertMilesToKilometers(miles);
            km = Math.Round(km, 5, MidpointRounding.AwayFromZero);
            Assert.IsTrue(km == 1.60934, "lists are set to null as expected after loading in a file"); // List is split up as requested
        }

        [TestMethod()]
        public void ConvertKilometersToMilesTest()
        {
            var MainApp = new Form1(); // new main form context
            double km = 1;
            double miles = MainApp.ConvertKilometersToMiles(km);
            miles = Math.Round(miles, 6, MidpointRounding.AwayFromZero);
            Assert.IsTrue(miles == 0.621371, "lists are set to null as expected after loading in a file"); // List is split up as requested
        }
    }
}