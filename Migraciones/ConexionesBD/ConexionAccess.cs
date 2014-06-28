using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Migraciones.ConexionesBD
{
    public class ConexionAccess : Conexion
    {

        OleDbConnection conexion;


        public ConexionAccess(string ruta)
        {
            conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta + ";Jet OLEDB:Database Password=");
        }

        public ConexionAccess(string ruta, string password)
        {
            conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta + ";Jet OLEDB:Database Password=" + password);
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
            OleDbDataAdapter adapter = new OleDbDataAdapter(consulta, conexion);

            AbrirConexion();

            adapter.Fill(dsDatos, tablaDestino);

            CerrarConexion();
            adapter.Dispose();
        }

        public override void Consulta(string consulta)
        {
            OleDbCommand comando = new OleDbCommand();
            comando.Connection = conexion;
            comando.CommandText = consulta;

            AbrirConexion();

            comando.ExecuteNonQuery();

            CerrarConexion();
            comando.Dispose();
        }

    }
}