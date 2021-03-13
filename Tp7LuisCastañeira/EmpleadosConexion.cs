using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp7LuisCastañeira
{
    class EmpleadosConexion
    {
        private string cadena = "data source=localhost;Initial Catalog=EMPLEADOS_DB;Integrated Security=sspi";
        private SqlDataReader lector;
        private object lista;

        public List<Empleados> listaEmpleados()
        {
            List<Empleados> lista = new List<Empleados>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            conexion.ConnectionString = cadena; 
            comando.CommandType = System.Data.CommandType.Text;

            //comando.CommandText = "select  id,NombreCompleto, DNI, Edad, Casado, Salario from Empleados ";
            comando.CommandText = "SELECT * from Empleados";
            comando.Connection = conexion;
            conexion.Open();

            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Empleados aux = new Empleados();
                aux.Id = lector.GetInt32(0);
                aux.NombreCompleto = lector.GetString(1);
                aux.DNI = lector.GetString(2);
                aux.Edad = lector.GetInt32(3);
                aux.Casado = lector.GetBoolean(4);
                aux.Salario = lector.GetDecimal(5);


                lista.Add(aux);




            }
            conexion.Close();

            return lista;
        }

        public void agregar(Empleados nuevo)
        {
            SqlConnection conexion = new SqlConnection(cadena);
            SqlCommand comando = new SqlCommand();
            

            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "insert into Empleados(NombreCompleto, DNI, Edad, Casado, Salario) values('"+ nuevo.NombreCompleto +"', '"+ nuevo.DNI + "'," + nuevo.Edad + ",'" + nuevo.Casado +"',"+ nuevo.Salario + ")";
            
            conexion.Open();
            comando.ExecuteNonQuery();

         

            conexion.Close();


        }

        public void actualizar(Empleados nuevo)
        {


            SqlConnection conexion = new SqlConnection(cadena);
            SqlCommand comando = new SqlCommand();


            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Update Empleados Set NombreCompleto=@NombreCompleto, edad=@edad, dni=@dni, casado=@casado, salario=@salario WHERE ID=@id";
            conexion.Open();
            comando.Parameters.AddWithValue("@id", nuevo.Id);
            comando.Parameters.AddWithValue("@NombreCompleto", nuevo.NombreCompleto);
            comando.Parameters.AddWithValue("@edad", nuevo.Edad);
            comando.Parameters.AddWithValue("@dni", nuevo.DNI);
            comando.Parameters.AddWithValue("@casado", nuevo.Casado);
            comando.Parameters.AddWithValue("@salario", nuevo.Salario);




            comando.ExecuteNonQuery();



            conexion.Close();
           



        }

        public void eliminar(Empleados nuevo)
        {
            SqlConnection conexion = new SqlConnection(cadena);
            SqlCommand comando = new SqlCommand();


            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "delete Empleados  WHERE ID=@id";
            conexion.Open();
            comando.Parameters.AddWithValue("@id", nuevo.Id);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        

        
    }
    
}
