using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector; //Referencia al paquete o conector


namespace Renting
{
    internal class Conexion
    {
        //Variables globales para esta clase.

        static MySqlConnection Conn = new MySqlConnection(); //Variable de conexion
        static MySqlCommand comando = new MySqlCommand();
        static MySqlDataReader datareader = null;

        //Función para crear la cadena de conexión.
        public static bool ObtenerConexion()
        {
            //Cadena de conexión de MariaDB
            MySqlConnectionStringBuilder strBuidler = new MySqlConnectionStringBuilder();
            strBuidler.UserID = "fmarin";
            strBuidler.Password = "12345";
            strBuidler.Server = "127.0.0.1";
            strBuidler.Database = "bdrenting";

            //Cadena de conexión para Mysql Server
            //strBuidler.UserID = "root";
            //strBuidler.Port = 3307;
            strBuidler.SslMode = 0;

            Conn = new MySqlConnection(strBuidler.ConnectionString);

            try
            {
                Conn.Open();
               // Conn.Close();
                return true;
            }
                catch { return false; }
        }

        public static int CrearCuenta(string pNUsuario, string pContrasena)
        {
            int resultado = 0;
            //Conn.Open();
            ObtenerConexion();
            comando = new MySqlCommand(string.Format("Insert Into usuarios (NUsuario,Contrasena) values ('{0}' ,'{1}')", pNUsuario,Seguridad.MD5Hash(pContrasena)),Conn);
            resultado = comando.ExecuteNonQuery();
            Conn.Close();
            return resultado;
        }

        public static int Autentificar(string pNombre, string pContrasena)
        {
            int resultado = -1;

            Conn.Open();
            comando = new MySqlCommand(string.Format("Select * from usuarios where NUsuario = '{0}' and Contrasena = '{1}'", pNombre, Seguridad.MD5Hash(pContrasena)), Conn);
            datareader = comando.ExecuteReader();

            while (datareader.Read()) 
            {
                resultado = 50;                           
            }
            Conn.Close();
            return resultado;
        }
    }
}
