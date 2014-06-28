using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Migraciones.ConexionesBD
{
    public class ConexionSqlServer : Conexion
    {

        SqlConnection conexion;


        public ConexionSqlServer(string servidor, string baseDatos, string usuario, string password)
        {
            conexion = new SqlConnection(@"Server=" + servidor + "; Database=" + baseDatos + "; User Id=" + usuario + "; Password=" + password + ";");
        }

        public override void AbrirConexion()
        {
            conexion.Open();
        }

        public override void CerrarConexion()
        {
            conexion.Close();
        }

        public override void ExtraerDatosCondicionado(DataSet dsDatos, string tablaOrigen, string tablaDestino, string condicion)
        {
            string consulta = "SELECT * FROM " + tablaOrigen;
            if (condicion != null) consulta += " where " + condicion;
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);

            AbrirConexion();

            adapter.Fill(dsDatos, tablaDestino);

            CerrarConexion();
            adapter.Dispose();
        }

        public override void Consulta(string consulta)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = consulta;

            AbrirConexion();

            comando.ExecuteNonQuery();

            CerrarConexion();
            comando.Dispose();
        }

    }
}