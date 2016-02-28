using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace girisSayfasi
{
    public partial class Form2 : Form
    {
        public string myConnection = "datasource=localhost;port=3306;username=root;password=;database=newdatabase";
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            myConn.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
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
            myConn.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 formkapa = new Form2();
            formkapa.Close();
            Form3 formac = new Form3();
            formac.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 formkapa = new Form2();
            formkapa.Close();
            Form3 formac = new Form3();
            formac.Show();
            this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        }
    }

