using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;
        public Conexion()
        {
                cn = new SqlConnection("Data Source=LENOVO-Y510P;Initial Catalog=PROG_BD;Integrated Security=True");
                cn.Open();
            
        }
        public string insertar(int numero, string nombre, string apep, string apem, string direc, string tel, Boolean sex, string correo, string fecha)
        {
            String salida = "Registro Guardado";
            try { cmd = new SqlCommand("insert into Alumno(no_control, nombre_a, apaterno_a, amaterno_a,direccion_a, telefono_a, sexo_a, email_a, fecha_alta_d) values(" + numero+ ",'" + nombre + "','" + apep + "','" + apem + "','" + direc + "', '" + tel + "', '" + sex + "', '" + correo + "', '" + fecha + "')",cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex){ salida = "No Se Conecto" + ex.ToString(); }

            return salida;
        }

        public int PersonaRegistrada(int numero)
        {
            int contador = 0;
            try
            {
                cmd = new SqlCommand("Select * from Alumno where no_control="+numero+"",cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contador++;
                }
                dr.Close();
            }
            catch (Exception ex) { MessageBox.Show("No Se pudo consultar bien: " + ex.ToString()); }

            return contador;
        }

        public void CargarPersonas(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("Select * from alumno", cn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch(Exception ex) {
                MessageBox.Show("No Se Puede Llenar la tabla"+ex.ToString());
            }
        }

        public void llenarTexBoxconsulta(int numero, TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5, TextBox textBox6, TextBox textBox7, TextBox textBox8, DateTimePicker dateTimePicker1)
        {
            try
            {
                cmd = new SqlCommand("Select * from alumno where no_control=" + numero + "", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr["nombre_a"].ToString();
                    textBox3.Text = dr["apaterno_a"].ToString();
                    textBox4.Text = dr["amaterno_a"].ToString();
                    textBox5.Text = dr["direccion_a"].ToString();
                    textBox6.Text = dr["telefono_a"].ToString();
                    textBox7.Text = dr["sexo_a"].ToString();
                    textBox8.Text = dr["email_a"].ToString();
                    dateTimePicker1.Text = dr["fecha_alta_d"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex){ MessageBox.Show("No Se Puedo Encontrar La Wea"+ex.ToString()); }
        }
        public string actuali(int numero, string nombre, string apep, string apem, string direc, string tel, Boolean sex, string correo, string fecha)
        {
            String salida = "Registro Actualizado";
            try
            {
                cmd = new SqlCommand("update alumno set nombre_a='"+ nombre + "', apaterno_a='"+apep +"', amaterno_a='"+apem+"', direccion_a='"+direc+"', telefono_a='"+tel+"', sexo_a='"+sex+"', email_a='"+correo+ "', fecha_alta_d='"+fecha+"' where no_control="+numero+"", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { salida = "No Se Conecto" + ex.ToString(); }

            return salida;
        }
        public string eliminar(int numero)
        {

            String salida = "Registro Eliminado Correctamente";
            
            cmd = new SqlCommand("delete from alumno where no_control="+numero+"", cn);
                cmd.ExecuteNonQuery();
            return salida;
        }
    }

}
