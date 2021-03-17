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
using System.Data;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        
        public enum datatypes
        {
        bit_=1,
        float_=2,
        int_ = 3,
        datetime_ = 4,
        date_=5,
        time_=6,

        decimal_ = 7,
        char_ = 8,
        string_ = 9,
        bytearray_=10,
        boolean_=11,
        

        };
        public Form1()
        {
            InitializeComponent();

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MsSql b1 = new MsSql();
            b1.tabloEkle(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySql b2 = new MySql();
            b2.tabloEkle(textBox1.Text);
            textBox1.Text = "";
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int deger = Convert.ToInt32(textBox2.Text);
            label1.Text = ((datatypes)deger).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            if (textBox6.Text == "")
            {
                MsSql b3 = new MsSql();
                b3.fieldEkle(textBox3.Text, textBox4.Text, (datatypes)Convert.ToInt32(textBox5.Text));
            }
            else
            {
                MsSql b3 = new MsSql();
                b3.fieldEkle(textBox3.Text, textBox4.Text, (datatypes)Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox6.Text=="")
            {
                MySql b9 = new MySql();
                b9.fieldEkle(textBox3.Text, textBox4.Text, (datatypes)Convert.ToInt32(textBox5.Text));
            }
            else
            {
                MySql b9 = new MySql();
                b9.fieldEkle(textBox3.Text, textBox4.Text, (datatypes)Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text));
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MsSql b3 = new MsSql();
            b3.foreignKeyEkle(textBox7.Text, textBox8.Text,textBox9.Text,textBox10.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MySql b8 = new MySql();
            b8.foreignKeyEkle(textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            List<enumvalues> enumlar = new List<enumvalues>();

            enumvalues enum1 = new enumvalues();
            enumvalues enum2 = new enumvalues();
            enumvalues enum3 = new enumvalues();
            enumvalues enum4 = new enumvalues();

            enum1.enumValue = 1;
            enum1.EnumName = "Enum Name 1";
            enum2.enumValue = 2;
            enum2.EnumName = "Enum Name 2";
            enum3.enumValue = 3;
            enum3.EnumName = "Enum Name 3";
            enum4.enumValue = 4;
            enum4.EnumName = "Enum Name 4";
            enumlar.Add(enum1);
            enumlar.Add(enum2);
            enumlar.Add(enum3);
            enumlar.Add(enum4);
            MsSql b20 = new MsSql();
            b20.createDbEnum("EnumOlusturma9",enumlar);
        }



        
    }



}
