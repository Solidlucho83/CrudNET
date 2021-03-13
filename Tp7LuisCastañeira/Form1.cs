using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp7LuisCastañeira
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void limpiar()
        {
            TxtNombre.Clear();
            TxtEdad.Clear();
            TxtDni.Clear();
            CheckBox1.Checked = false;
            TxtSalario.Clear();
        }

        private void Cargar()
        {
            EmpleadosConexion conexion = new EmpleadosConexion();
            dbEmpleados.DataSource = conexion.listaEmpleados();
            this.dbEmpleados.Columns[0].Visible = false;
        }

        private void BtnAñadir_Click(object sender, EventArgs e)
        {
            try
            {


                Empleados nuevo = new Empleados();
                EmpleadosConexion conexion = new EmpleadosConexion();


                nuevo.NombreCompleto = TxtNombre.Text;
                nuevo.Edad = int.Parse(TxtEdad.Text);
                nuevo.DNI = TxtDni.Text;
                nuevo.Casado = CheckBox1.Checked;
                if (CheckBox1.Checked == true)
                {
                    nuevo.Casado = true;
                }
                else
                {

                    nuevo.Casado = false;
                }

                nuevo.Salario = decimal.Parse(TxtSalario.Text);


                limpiar();

                conexion.agregar(nuevo);
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un Error al ingresar los datos");
                MessageBox.Show(ex.Message, "ERROR");
            }
            finally
            {
                limpiar();
            }

        }



        private void dbEmpleados_cellContentClik(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                TxtId.Text = dbEmpleados.CurrentRow.Cells[0].Value.ToString();

                TxtNombre.Text = dbEmpleados.CurrentRow.Cells[1].Value.ToString();

                TxtDni.Text = dbEmpleados.CurrentRow.Cells[2].Value.ToString();
                TxtEdad.Text = dbEmpleados.CurrentRow.Cells[3].Value.ToString();
                CheckBox1.Checked = (bool)dbEmpleados.CurrentRow.Cells[4].Value;
                TxtSalario.Text = dbEmpleados.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un Error al cargar los datos");
                MessageBox.Show(ex.Message, "ERROR");
            }


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleados nuevo = new Empleados();
                EmpleadosConexion conexion = new EmpleadosConexion();

                nuevo.Id = int.Parse(TxtId.Text);
                nuevo.NombreCompleto = TxtNombre.Text;
                nuevo.Edad = int.Parse(TxtEdad.Text);
                nuevo.DNI = TxtDni.Text;
                nuevo.Casado = CheckBox1.Checked;
                if (CheckBox1.Checked == true)
                {
                    nuevo.Casado = true;
                }
                else
                {

                    nuevo.Casado = false;
                }
                nuevo.Salario = decimal.Parse(TxtSalario.Text);

                conexion.actualizar(nuevo);
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un Error al actualizar los datos");
                MessageBox.Show(ex.Message, "ERROR");
            }
            finally
            {
                limpiar();
            }

        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {


                Empleados nuevo = new Empleados();
                EmpleadosConexion conexion = new EmpleadosConexion();

                nuevo.Id = int.Parse(TxtId.Text);

                conexion.eliminar(nuevo);
                Cargar();
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un Error al Eliminar los datos");
                MessageBox.Show(ex.Message, "ERROR");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();

            Cargar();
        }




    
        

      

       
    }
}
