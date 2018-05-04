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
    public class IntervalViewTests
    {
        /// <summary>  
        /// Tests the formula for Intenisty Factor produce the expetced result
        /// Sets normalised power to the same result as the example file
        /// AdvancedMetricsIF expects FTP (User Input) and the Normalised Power
        /// </summary> 
        [TestMethod()]
        public void AdvancedMetricsIFTest()
        {
            var Interval = new IntervalView();
            double ftp = 10;
            double power = 232;
            double count = Interval.AdvancedMetricsIF(ftp, power); // Gets intensity factor based on normaizsed power and user input ftp

            Assert.IsTrue(count == 23.2, "Correct result"); // Correct result
        }

        /// <summary>  
        /// Tests the formula for Training Stress Score produce the expetced result
        /// Sets normalised power to the same result as the example file
        /// AdvancedMetricsTSS expects FTP (User Input), IF from previous method, the Normalised Power and time taken of the file
        /// </summary> 
        [TestMethod()]
        public void AdvancedMetricsTSSTest()
        {
            var Interval = new IntervalView();
            double ftp = 300;
            double power = 232;
            int time = 1 * 3979;
            double IF = Interval.AdvancedMetricsIF(ftp, power); // Gets intensity factor based on normaizsed power and user input ftp

            double TSS = Interval.AdvancedMetricsTSS(ftp, power, IF, time); // Gets intensity factor based on normaizsed power and user input ftp

            Assert.IsTrue(TSS == 66, "Correct result"); // Correct result
        }

        /// <summary>  
        /// Tests the zoom componenet works when the list is being cut to display on visible components
        /// Expects 3979 initially but they are cut down to 99 using the range method of lists
        /// SummaryZoomCalc expects StartPoint, EndPoint and Difference
        /// </summary> 
        [TestMethod()]
        public void ZoomSummaryTest()
        {
            var MainApp = new Form1(); // new main form context
            string filename = "D:\\Desktop\\Work\\Uni Last Year\\Sem2\\ASDBExampleCycleComputerData.hrm";
            MainApp.ParseFile(filename);
            var Interval = new IntervalView();
            Interval.SetFileVars();
            Interval.SummaryZoomCalc(1, 100, 99);
            int count = Interval.HeartRate.Count();
            Assert.IsTrue(count == 99, "Zoomed summary reduces list size to the values specified (99 in this case)"); // Correct result
        }
    }
}