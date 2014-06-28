using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Migraciones.ConexionesBD
{
    public abstract class Conexion
    {

        public abstract void AbrirConexion();
        public abstract void CerrarConexion();
        public void ExtraerDatos(DataSet dsDatos, string tabla)
        {
            ExtraerDatosCondicionado(dsDatos, tabla, tabla, null);
        }
        public void ExtraerDatos(DataSet dsDatos, string tablaOrigen, string tablaDestino)
        {
            ExtraerDatosCondicionado(dsDatos, tablaOrigen, tablaDestino, null);
        }
        public void ExtraerDatosCondicionado(DataSet dsDatos, string tabla, string condicion)
        {
            ExtraerDatosCondicionado(dsDatos, tabla, tabla, condicion);
        }
        public abstract void ExtraerDatosCondicionado(DataSet dsDatos, string tablaOrigen, string tablaDestino, string condicion);
        public abstract void Consulta(string consulta);

    }
}
