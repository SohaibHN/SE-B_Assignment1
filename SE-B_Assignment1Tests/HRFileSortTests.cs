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
    public class HRFileSortTests
    {
        string filename = "D:\\Desktop\\Work\\Uni Last Year\\Sem2\\ASDBExampleCycleComputerData.hrm";

        /// <summary>  
        /// Tests the file is correctly sorted/parsed with the example file
        /// Expects 3979 rows being stored into the Heartrate list
        /// </summary> 
        [TestMethod()]
        public void FileDataManipTest()
        {
            var MainApp = new Form1(); // new main form context
            //string filename = "D:\\Desktop\\Work\\Uni Last Year\\Sem2\\ASDBExampleCycleComputerData.hrm";
            MainApp.ParseFile(filename);
            var HRFS = new HRFileSort();
            int count = HRFileSort.heartrate.Count;

            Assert.IsTrue(count == 3979, "Example file has been parsed with all the results going into the list"); // Correct result
        }

        /// <summary>  
        /// Tests after the file is correctly loaded in that SMODE is processed correctly
        /// Done by checking the bool values have been cvhanged to true (false by default)
        /// </summary> 
        [TestMethod()]
        public void FileBoolTest()
        {
            var MainApp = new Form1(); // new main form context
            //string filename = "D:\\Desktop\\Work\\Uni Last Year\\Sem2\\ASDBExampleCycleComputerData.hrm";
            MainApp.ParseFile(filename);
            var HRFS = new HRFileSort();
            int count = HRFileSort.heartrate.Count;
            
            Assert.IsTrue(HRFileSort.SpeedCheck && HRFileSort.CadenceCheck && HRFileSort.AltCheck && HRFileSort.PowerCheck && HRFileSort.PowerBICheck && HRFileSort.HRCheck, "Example file has been parsed with correct bools being set"); // Correct result
        }
    }
}