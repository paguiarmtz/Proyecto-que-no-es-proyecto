using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        Conexion sd = new Conexion();
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
           
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Conexion sd = new Conexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.Text == "Hombre")
            {

                if (sd.PersonaRegistrada(Convert.ToInt32(textBox1.Text)) == 0)
                {
                    MessageBox.Show(sd.insertar(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, true, textBox7.Text, dateTimePicker1.Text));
                }
                else
                {
                    MessageBox.Show("Imposible de registrar, el registro ya existe");
                }


            }
            if (comboBox1.Text == "Mujer")
            {


                if (sd.PersonaRegistrada(Convert.ToInt32(textBox1.Text)) == 0)
                {
                    MessageBox.Show(sd.insertar(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, false, textBox7.Text, dateTimePicker1.Text));
                }
                else
                {
                    MessageBox.Show("Imposible de registrar, el registro ya existe");
                }

            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.ResetText();
            dateTimePicker1.ResetText();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
