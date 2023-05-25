using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace blood_bank
{
    public partial class Form2 : Form
    {
        private string dateTimeString;
       function fn = new function();    
        public Form2(string dateTimeString)
        {
            InitializeComponent();
            this.dateTimeString = dateTimeString;
        }
        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblDateTimes.Text = dateTimeString;

       
        }

        private void btn_BackToMenu(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        byte[] imageData;
        private void btnAddPhoto(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(imagePath);
            }
          

        }

        SqlConnection Con = new SqlConnection(@"Data Source=HUNG_DO\HUNGDO;Initial Catalog=BloodBankDB;Integrated Security=True;Pooling=False");
        private void Reset()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtSocialId.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtComboBox1.SelectedIndex = -1;
            pictureBox1.Image = null;
        }
        private void btnSave(object sender, EventArgs e)
        {
            Image pimg = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            var ImageConvert  = converter.ConvertTo(pimg, typeof(byte[])); 
            if (txtName.Text == "" || txtSurname.Text == "" || txtSocialId.Text == "" || txtPhoneNumber.Text == "" || txtEmail.Text == "" || txtComboBox1.SelectedIndex == -1 || pictureBox1.Image == null)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    /*string query = "insert into DonorTbl values('" + txtName.Text + "','" + txtSurname.Text + "','" + txtSocialId.Text + "','" + txtPhoneNumber.Text +"','" + txtEmail.Text +"','"+ txtComboBox1.SelectedItem.ToString()+"','"+pictureBox1.Image+")";*/

                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into DonorTbl values(@DName,@DSurName,@DSocialID,@DPhoneNumber,@DEmail,@DBloodType,@Image)",Con);
                   
                    cmd.Parameters.AddWithValue("@DName", txtName.Text);
                    cmd.Parameters.AddWithValue("@DSurName", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@DSocialID", txtSocialId.Text);
                    cmd.Parameters.AddWithValue("@DPhoneNumber", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@DEmail", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@DBloodType", txtComboBox1.Text);
                    cmd.Parameters.AddWithValue("@Image", ImageConvert);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Donor Successfully Saved");
                    Con.Close();
                    Reset();
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
  