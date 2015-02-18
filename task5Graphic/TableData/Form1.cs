using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableData
{
    public partial class Form1 : Form
    {
        
        Module GraphicsModule { get; set; }
        object graphic;
        public Form1(Module graphics, object targetWindow)
        {
            GraphicsModule = graphics;
            graphic = targetWindow;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Rows.Add(" ", " ", " ", " ");
            dataGridView1.Rows.Add(" ", " ", " ", " ");
            dataGridView1.AllowUserToAddRows = false;
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> firstRow = new List<string>();
            List<int> secondRow = new List<int>();
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                firstRow.Add( dataGridView1[i, 0].Value.ToString());
                secondRow.Add (Convert.ToInt32(dataGridView1[i,1].Value));
            }
           
            GraphicsModule.GetType("GraphicDrawer.Form1").GetMethod("setParameters").
                Invoke(graphic, new object[] { firstRow, secondRow });

            
        }

       
    }
}
