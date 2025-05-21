using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика_20_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "Путевка";
            tabPage2.Text = "Туристическая путевка";
            tabPage3.Text = "Санаторная путевка";

            panel1.Visible = false;
            panel2.Visible = false;

            tabPage2.Enabled = false;
            tabPage3.Enabled = false;

            List<string> Travels = new List<string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            
        }

        public int SelectedIndex { get; set; }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Турагенство.SelectedIndex = 1;
            tabPage2.Enabled = true;
            label11.Visible = false;
            panel1.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Турагенство.SelectedIndex = 2;
            panel2.Visible = true;
            label12.Visible = false;
            tabPage3.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
