using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thailand1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void Geo_load()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=thailand.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT GEO_ID,GEO_NAME from geography";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = rdr[1].ToString();
                item.Value = rdr[0];

                comboBox1.Items.Add(item);
                //comboBox1.SelectedIndex = 0;
            }
            rdr.Close();
        }

        private void Province_load()
        {
            ComboboxItem selectedV = (ComboboxItem)comboBox1.SelectedItem;
            int selecteVal = Convert.ToInt32(selectedV.Value);
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=thailand.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT PROVINCE_ID,PROVINCE_NAME from province where GEO_ID = "+ selecteVal + "";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = rdr[1].ToString();
                item.Value = rdr[0];

                comboBox2.Items.Add(item);
                //comboBox1.SelectedIndex = 0;
            }
            
            rdr.Close();
        }

        private void Amphur_load()
        {
            ComboboxItem selectedV = (ComboboxItem)comboBox2.SelectedItem;
            int selecteVal = Convert.ToInt32(selectedV.Value);
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=thailand.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT AMPHUR_ID,AMPHUR_NAME,AMPHUR_CODE from amphur where PROVINCE_ID = " + selecteVal + "";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = rdr[1].ToString();
                item.Value = rdr[0];

                comboBox3.Items.Add(item);
                //comboBox1.SelectedIndex = 0;
            }

            rdr.Close();
        }

        private void District_load()
        {
            ComboboxItem selectedV = (ComboboxItem)comboBox3.SelectedItem;
            int selecteVal = Convert.ToInt32(selectedV.Value);
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=thailand.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT DISTRICT_ID,DISTRICT_NAME from district where AMPHUR_ID = " + selecteVal + "";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = rdr[1].ToString();
                item.Value = rdr[0];

                comboBox4.Items.Add(item);
                //comboBox1.SelectedIndex = 0;
            }

            rdr.Close();
        }

        private void Amphur_Code()
        {
            ComboboxItem selectedV = (ComboboxItem)comboBox3.SelectedItem;
            int selecteVal = Convert.ToInt32(selectedV.Value);
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=thailand.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT AMPHUR_CODE from amphur where AMPHUR_ID = " + selecteVal + "";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                textBox1.Text = rdr[0].ToString();
                //comboBox1.SelectedIndex = 0;
            }

            rdr.Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            Province_load();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            Amphur_load();
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();

            District_load();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Geo_load();
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            Amphur_Code();
        }
    }
}
