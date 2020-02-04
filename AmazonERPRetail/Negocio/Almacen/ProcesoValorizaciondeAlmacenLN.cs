using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

using AccesoDatos.Almacen;
using Entidades.Almacen;

namespace Negocio.Almacen
{
    public class ProcesoValorizaciondeAlmacenLN
    {

        public int ValorizaciondeAlmacen(Int32 idEmpresa, Int32 idAlmacen, Int32 idArticulo, String AnioInicio, String MesInicio, String AnioFin, String MesFin, String ValConversion)
        {
            try
            {
                return new ProcesoValorizaciondeAlmacenAD().ValorizaciondeAlmacen(idEmpresa, idAlmacen, idArticulo, AnioInicio, MesInicio, AnioFin, MesFin, ValConversion);

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

        public int PasarStock(Int32 idEmpresa, String AnioInicio, String MesInicio, String AnioFin, String MesFin)
        {
            try
            {
                List<AlmacenE> ListaAlmacenes = new AlmacenAD().ListarAlmacenPorEmpresa(idEmpresa);
                int resp = 0;

                foreach (AlmacenE item in ListaAlmacenes)
                {
                    resp += new ProcesoValorizaciondeAlmacenAD().ValorizaciondeAlmacen(idEmpresa, item.idAlmacen, 0, AnioInicio, MesInicio, AnioFin, MesFin, "N");
                }

                return resp;
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
