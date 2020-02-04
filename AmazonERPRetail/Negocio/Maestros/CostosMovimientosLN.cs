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
using Infraestructura.Enumerados;

namespace Negocio.Maestros
{
    public class CostosMovimientosLN 
    {
        public CostosMovimientosE GrabarCostosMovimientos(CostosMovimientosE CostosMov, EnumOpcionGrabar Opcion)
        {
            try
            {
                if (Opcion == EnumOpcionGrabar.Insertar)
                {
                    //Insertando el articulo
                    CostosMov = new CostosMovimientosAD().InsertarCostosMovimientos(CostosMov);

                    //Insertando detalle si hubiera
                    if (CostosMov.ListaCostosMovimientos != null && CostosMov.ListaCostosMovimientos.Count > 0)
                    {
                        foreach (CostosMovimientosItemE oitem in CostosMov.ListaCostosMovimientos)
                        {
                            oitem.Anio = CostosMov.Anio;
                            oitem.idElemento = CostosMov.idElemento;
                            oitem.CodClasificacion = CostosMov.CodClasificacion;
                            new CostosMovimientosItemAD().InsertarCostosMovimientosItem(oitem);
                        }
                    }
     
                }
                else
                {
                    //Actualizando el articulo
                    new CostosMovimientosAD().ActualizarCostosMovimientos(CostosMov);

                    //Actualizando detalle si hubiera
                    if (CostosMov.ListaCostosMovimientos != null && CostosMov.ListaCostosMovimientos.Count > 0)
                    {
                        foreach (CostosMovimientosItemE oitem in CostosMov.ListaCostosMovimientos)
                        {
                            oitem.Anio = CostosMov.Anio;
                            oitem.idElemento = CostosMov.idElemento;
                            oitem.CodClasificacion = CostosMov.CodClasificacion;

                            switch (oitem.Opcion)
                            {
                                case (Int32)EnumOpcionGrabar.Insertar:
                                    new CostosMovimientosItemAD().InsertarCostosMovimientosItem(oitem);
                                    break;
                                case (Int32)EnumOpcionGrabar.Actualizar:
                                    new CostosMovimientosItemAD().ActualizarCostosMovimientosItem(oitem);
                                    break;
                                case (Int32)EnumOpcionGrabar.Eliminar:
                                    new CostosMovimientosItemAD().EliminarCostosMovimientosItem(oitem.idEmpresa, oitem.idElemento, oitem.CodClasificacion,oitem.Mes,oitem.Anio);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

                return CostosMov;
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



        public CostosMovimientosE InsertarCostosMovimientos(CostosMovimientosE costosmovimientos)
        {
            try
            {
                return new CostosMovimientosAD().InsertarCostosMovimientos(costosmovimientos);
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

        public CostosMovimientosE ActualizarCostosMovimientos(CostosMovimientosE costosmovimientos)
        {
            try
            {
                return new CostosMovimientosAD().ActualizarCostosMovimientos(costosmovimientos);
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

        public int EliminarCostosMovimientos(Int32 idEmpresa,String CodClasificacion, Int32 idElemento, String Anio)
        {
            try
            {
                return new CostosMovimientosAD().EliminarCostosMovimientos(idEmpresa, CodClasificacion, idElemento, Anio);
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

        public List<CostosMovimientosE> ListarCostosMovimientos(Int32 idEmpresa,Int32 idElemento, String Anio)
        {
            try
            {
                return new CostosMovimientosAD().ListarCostosMovimientos(idEmpresa, idElemento, Anio);
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

        public CostosMovimientosE ObtenerCostosMovimientos(Int32 idEmpresa,String CodClasificacion, Int32 idElemento, String Anio)
        {
            try
            {
                return new CostosMovimientosAD().ObtenerCostosMovimientos(idEmpresa, CodClasificacion, idElemento, Anio);
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
