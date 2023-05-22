using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace blood_bank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnAdd(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string dateTimeString = now.ToString();

            Form2 form2 = new Form2(dateTimeString);
            form2.Owner = this;
            form2.ShowDialog();

            

            

        }

        private void btnRecords(object sender, EventArgs e)
        {
         
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();

        }
    }
}
