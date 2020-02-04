using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using AccesoDatos;
using Infraestructura;
using Entidades.Maestros;
using AccesoDatos.Maestros;

namespace Negocio.Maestros
{
    public class CostosMovimientosItemLN //: BaseLN
    {
        public CostosMovimientosItemE InsertarCostosMovimientosItem(CostosMovimientosItemE costosmovimientositem)
        {
            try
            {
                return new CostosMovimientosItemAD().InsertarCostosMovimientosItem(costosmovimientositem);
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

        public CostosMovimientosItemE ActualizarCostosMovimientosItem(CostosMovimientosItemE costosmovimientositem)
        {
            try
            {
                return new CostosMovimientosItemAD().ActualizarCostosMovimientosItem(costosmovimientositem);
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

        public int EliminarCostosMovimientosItem(Int32 idEmpresa, Int32 idElemento, String CodClasificacion, String Mes, String Anio)
        {
            try
            {
                return new CostosMovimientosItemAD().EliminarCostosMovimientosItem(idEmpresa, idElemento, CodClasificacion, Mes, Anio);
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

        public List<CostosMovimientosItemE> ListarCostosMovimientosItem(Int32 idEmpresa, Int32 idElemento, String CodClasificacion)
        {
            try
            {
                return new CostosMovimientosItemAD().ListarCostosMovimientosItem(idEmpresa, idElemento, CodClasificacion);
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

        public CostosMovimientosItemE ObtenerCostosMovimientosItem(Int32 idEmpresa, Int32 idElemento, String CodClasificacion, String Mes, String Anio)
        {
            try
            {
                return new CostosMovimientosItemAD().ObtenerCostosMovimientosItem(idEmpresa, idElemento, CodClasificacion, Mes, Anio);
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
