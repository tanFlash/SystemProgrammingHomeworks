using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GraphicDrawer
{
    public partial class Form1 : Form
    {
        List<string> seriesList;
        List<int> pointsList;
        public Form1()
        {
            InitializeComponent();
        }

        public void setParameters(List<string> ListString, List<int> ListInt)
        {
            seriesList = ListString;
            pointsList = ListInt;

            this.chart1.Titles.Add("Temperatures");

            for (int i = 0; i < seriesList.Count; i++)
            {
                // Add series.
                Series series = this.chart1.Series.Add(seriesList[i]);

                // Add point.
                series.Points.Add(pointsList[i]);
            }
        }
    }
}
