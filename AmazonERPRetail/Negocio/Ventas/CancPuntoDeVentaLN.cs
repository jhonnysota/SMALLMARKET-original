using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using AccesoDatos;
using Infraestructura;
using Entidades.Ventas;
using AccesoDatos.Ventas;

namespace Negocio.Ventas
{
    public class CancPuntoDeVentaLN
    {
        public List<CancPuntoDeVentaE> ListarCancPuntoDeVenta(Int32 idEmpresa, DateTime Fecha, String PuntoVenta)
        {
            try
            {
                return new CancPuntoDeVentaAD().ListarCancPuntoDeVenta(idEmpresa, Fecha, PuntoVenta);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

    }
}
