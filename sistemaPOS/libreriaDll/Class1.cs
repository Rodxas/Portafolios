using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace libreriaDll
{
    public class Biblioteca
    {
        public static DataSet Herramientas(string cmd)
        {                                              //Aquí debajo va la cadena de conexión del explorador de servidores
                                                       //Se recomienda pooner una contraseña
            SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=Sistema;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            conexion.Open();

            DataSet dll = new DataSet();
            SqlDataAdapter dll1 = new SqlDataAdapter(cmd, conexion);

            dll1.Fill(dll);

            conexion.Close();

            return dll;
        }
    }
}
