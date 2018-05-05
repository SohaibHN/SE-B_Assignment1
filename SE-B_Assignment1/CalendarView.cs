using Calendar.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_B_Assignment1
{
    public partial class CalendarView : Form
    {
        public CalendarView()
        {
            InitializeComponent();
        }
        public DateTime SelectedDay = DateTime.Now;
        int StartX = 0;
        int StartY = 0;
        int cellWidth = 0;
        int cellHeight = 0;
        private void CalendarView_Load(object sender, EventArgs e)
        {

        }

        private void calendar1_Click(object sender, EventArgs e)
        {

        }
    }
}
