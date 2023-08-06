using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockRecords
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List();
        }
        private void List() // in order to see the records of DB
        {
            Connection.Open();
            SqlDataAdapter DA = new SqlDataAdapter("Select *from Goods", Connection);
            DataTable tablo = new DataTable();
            DA.Fill(tablo);
            dataGridView1.DataSource = tablo;
            Connection.Close();
        }

        private void analyzToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        SqlConnection Connection = new SqlConnection("Data Source=DESKTOP-J2S0G2N\\SQLEXPRESS01;Initial Catalog=stock;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            // Add button
            String t1 = textBox1.Text; //code
            String t2 = textBox2.Text; //name   
            String t3 = textBox3.Text; //annualSale
            String t4 = textBox4.Text; //unitPrice
            String t5 = textBox5.Text; //minStock
            String t6 = textBox6.Text; //procurmentTime
            Connection.Open();
            SqlCommand Command =new SqlCommand("INSERT INTO Goods (GoodsCode, GoodsName, AnnualSale, UnitPrice, MinStock, ProcurmentTime) VALUES ('"+t1+ "','"+t2+ "','"+t3+"','"+t4+"','"+t5+"','" +t6+ "')",Connection);    
            Command.ExecuteNonQuery();
            Connection.Close();
            List();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Delete
            String t1 = textBox1.Text; // take the textBox's string 
            Connection.Open();
            SqlCommand Command =new SqlCommand("DELETE FROM Goods WHERE GoodsCode= ('"+t1+"')", Connection); 
            Command.ExecuteNonQuery();
            Connection.Close() ;
            List();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Update
            String t1 = textBox1.Text; //code
            String t2 = textBox2.Text; //name   
            String t3 = textBox3.Text; //annualSale
            String t4 = textBox4.Text; //unitPrice
            String t5 = textBox5.Text; //minStock
            String t6 = textBox6.Text; //procurmentTime
            Connection.Open();
            SqlCommand Command = new SqlCommand("UPDATE Goods SET GoodsCode='"+t1+ "', GoodsName='"+t2+ "', AnnualSale='"+t3+ "',UnitPrice='"+t4+ "', MinStock='"+t5+ "', ProcurmentTime='"+t6+"' WHERE GoodsCode='"+t1+"'", Connection);
            Command.ExecuteNonQuery();
            Connection.Close() ;
            List();
        }
    }
}
