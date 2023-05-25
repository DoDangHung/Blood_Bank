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
using System.IO;

namespace blood_bank
{

    public partial class Form3 : Form
    {
        private SqlConnection connection;

        public Form3()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=HUNG_DO\HUNGDO;Initial Catalog=BloodBankDB;Integrated Security=True;Pooling=False");

        }
        public class Person{
            public string Name { get; set; }
            public string Surname { get; set; }
            public string SocialID { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string BloodType { get; set; }
            public Image image { get; set; }

            public Person(string name, string surname, string socialID, string phoneNumber, string email, string bloodtype , Image imgage )
            {
                Name = name;
                Surname = surname;
                SocialID = socialID;
                PhoneNumber = phoneNumber;
                Email = email;
                BloodType = bloodtype;
                image = imgage;
            }
        }

        int pageIndex = 1;
        int pageSize = 10;
        int totalPages = 0; 

        void LoadData()
        {
            string query = $"select DName, DSurName, DSocialID, DPhoneNumber, DEmail, DBloodType from DonorTbl";
            /*  SqlCommand cmd = new SqlCommand(query, connection);*/
            using (SqlConnection con = new SqlConnection(@"Data Source=HUNG_DO\HUNGDO;Initial Catalog=BloodBankDB;Integrated Security=True;Pooling=False"))
            {
                con.Open();
                string coutQuery = "Select COUNT(*) from DonorTbl";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    /*SqlDataReader reader = cmd.ExecuteReader();*/
                    totalPages = Convert.ToInt32(cmd.ExecuteScalar());
                }
                int totalPage = (int)Math.Ceiling((double)totalPages / pageSize);

                if (pageIndex > totalPage)
                {
                    pageIndex = totalPage;
                }
                else if (pageIndex < 1)
                {
                    pageIndex = 1;
                }
                int skipRows = (pageIndex - 1) * pageSize;
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        string name = reader.GetString(0).ToString();
                        lblName.Text = name;
                        string surname = reader.GetString(1).ToString();
                        lblSurname.Text = surname;
                        string socialId = reader.GetString(2).ToString();
                        lblSocialID.Text = socialId;
                        string phoneNumber = reader.GetString(3).ToString();
                        lblPhoneNumber.Text = phoneNumber;
                        string email = reader.GetString(4).ToString();
                        lblEmail.Text = email;
                        string bloodtype = reader.GetString(5).ToString();
                        lblBloodType.Text = bloodtype;

                        reader.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error" + ex.Message);
                    }
                    

                }
                con.Close();


            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
           LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pageIndex++;
            LoadData();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
           pageIndex--;
           LoadData();

        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
