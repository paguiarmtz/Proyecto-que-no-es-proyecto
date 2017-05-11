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
    public partial class Form4 : Form
    {
        Conexion sd = new Conexion();
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            


            if (sd.PersonaRegistrada(Convert.ToInt32(textBox1.Text)) > 0)
            {
                

                sd.llenarTexBoxconsulta(Convert.ToInt32(textBox1.Text), textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, dateTimePicker1);
                if(textBox7.Text == "True")
                { textBox7.Text = "Hombre"; }else{ textBox7.Text = "Mujer"; }
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                dateTimePicker1.Enabled = true;

            }
            else
            {
                MessageBox.Show("Registro No Encontrado");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Conexion sd = new Conexion();

          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

                MessageBox.Show(sd.actuali(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, true, textBox8.Text, dateTimePicker1.Text));
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            dateTimePicker1.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sd.eliminar(Convert.ToInt32(textBox1.Text)));
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form4 frm4 = new Form4();
            
            this.Close();
        }
    }
}
