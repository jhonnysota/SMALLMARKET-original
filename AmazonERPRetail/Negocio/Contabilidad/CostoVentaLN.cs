using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;

namespace Negocio.Contabilidad
{
    public class CostoVentaLN
    {

        public List<CostoVentaE> ReporteCostoVentas(Int32 idEmpresa, int tipAlmacen, String tipoOperacion, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                return new CostoVentaAD().ReporteCostoVentas(idEmpresa, tipAlmacen, tipoOperacion, fecIni, fecFin);
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

        public Int32 GenerarAsientoCostoVentas(Int32 idEmpresa, Int32 idLocal, int tipAlmacen, String tipoOperacion, String RucEmpresa, DateTime fecIni, DateTime fecFin, String Usuario)
        {
            try
            {
                return new CostoVentaAD().GenerarAsientoCostoVentas(idEmpresa, idLocal, tipAlmacen, tipoOperacion, RucEmpresa, fecIni, fecFin, Usuario);
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
