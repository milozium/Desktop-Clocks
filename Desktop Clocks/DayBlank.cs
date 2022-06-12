using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class DayBlank : UserControl
    {
        private DateTime _currentDate;
        public DayBlank()
        {
            InitializeComponent();
        }

        public void Refresh(Color backColor, int day, DateTime date, Color foreColor)
        {
            BackColor = backColor;
            dayNumber.Text = day.ToString();
            _currentDate = date;
            if (_currentDate.ToShortDateString() == DateTime.Now.ToShortDateString())
                BackColor = Color.FromArgb(222, 255, 159, 67);

            dayNumber.ForeColor = foreColor;
        }
    }
}
