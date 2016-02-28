using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;  

namespace girisSayfasi
{
    public partial class Form5 : Form
    {
        public string myConnection = "datasource=localhost;port=3306;username=root;password=;database=newdatabase";
        
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string sql = "SELECT * FROM kullanici";
            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            command.CommandText = sql;
            command.Connection = myConn;
            adapter.SelectCommand = command;
            myConn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["idkullanici"].Value.ToString();
            textBox2.Text = row.Cells["kullaniciAdi"].Value.ToString();
            
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = GetMD5(textBox3.Text);
            try
            {

                //This is my connection string i have assigned the database file address path 

                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=;database=newdatabase";

                //This is my update query in which i am taking input from the user through windows forms and update the record. 

                string Query = "update kullanici set idkullanici='" + this.textBox1.Text + "',kullaniciAdi='" + this.textBox2.Text + "', kullaniciSifre='" + this.textBox3.Text + "' where idkullanici='" + this.textBox1.Text + "';";

                //This is  MySqlConnection here i have created the object and pass my connection string. 

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

                MySqlDataReader MyReader2;

                MyConn2.Open();

                MyReader2 = MyCommand2.ExecuteReader();

                if (textBox1.Text=="0" || textBox1.Text==null)
                {
                    MessageBox.Show("Lütfen geçerli bir değer giriniz.");
                }
                else 
                {        
                MessageBox.Show("Veri başarılı bir şekilde güncellendi.");
                }

                while (MyReader2.Read())
                {
                }

                MyConn2.Close();//Connection closed here 

            }

            catch (Exception ex)
            {



                MessageBox.Show(ex.Message);

            } 
            
        }
            

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 formkapa = new Form5();
            formkapa.Close();
            Form3 formac = new Form3();
            formac.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public string GetMD5(string Text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i].ToString());
            }
            return str.ToString();
        }  

    }
}
