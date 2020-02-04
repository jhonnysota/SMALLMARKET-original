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
//using Negocio.Base;

namespace Negocio.Maestros
{
    public class ComisionesConfiguracionLN //: BaseLN
    {
        public void GuardarComisiones(ComisionesConfiguracionE oEntidad)
        {
            try
            {

                if (oEntidad.idComision == 0)
                {
                    oEntidad.TipoTabla = "comision";
                    ComisionesConfiguracionE oInsert = new ComisionesConfiguracionAD().InsertarComisionesConfiguracion(oEntidad);
                    oEntidad.idComision = oInsert.idComision;
                }
                else
                {
                    new ComisionesConfiguracionAD().ActualizarComisionesConfiguracion(oEntidad);
                }

                // Eliminamos Detalles
                new ComisionesConfiguracionAD().EliminarComisionesConfiguracionDetalle(oEntidad.idEmpresa, oEntidad.idComision);

                // CATEGORIA
                foreach(ComisionesConfiguracionE oItem in oEntidad.oListaCategoria)
                {
                    oItem.TipoTabla = "categoria";
                    oItem.idComision = oEntidad.idComision;
                    new ComisionesConfiguracionAD().InsertarComisionesConfiguracion(oItem);
                }
                // LINEA
                foreach (ComisionesConfiguracionE oItem in oEntidad.oListaLinea)
                {
                    oItem.TipoTabla = "linea";
                    oItem.idComision = oEntidad.idComision;
                    new ComisionesConfiguracionAD().InsertarComisionesConfiguracion(oItem);
                }
                // criterio
                foreach (ComisionesConfiguracionE oItem in oEntidad.oListaCriterio)
                {
                    oItem.TipoTabla = "criterio";
                    oItem.idComision = oEntidad.idComision;
                    new ComisionesConfiguracionAD().InsertarComisionesConfiguracion(oItem);
                }
                // tarifario
                foreach (ComisionesConfiguracionE oItem in oEntidad.oListaTarifario)
                {
                    oItem.TipoTabla = "tarifario";
                    oItem.idComision = oEntidad.idComision;
                    new ComisionesConfiguracionAD().InsertarComisionesConfiguracion(oItem);
                }
                // vendedor
                foreach (ComisionesConfiguracionE oItem in oEntidad.oListaVendedor)
                {
                    oItem.TipoTabla = "vendedor";
                    oItem.idComision = oEntidad.idComision;
                    new ComisionesConfiguracionAD().InsertarComisionesConfiguracion(oItem);
                }


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

        public ComisionesConfiguracionE InsertarComisionesConfiguracion(ComisionesConfiguracionE comisionesconfiguracion)
        {
            try
            {
                return new ComisionesConfiguracionAD().InsertarComisionesConfiguracion(comisionesconfiguracion);
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

        public ComisionesConfiguracionE ActualizarComisionesConfiguracion(ComisionesConfiguracionE comisionesconfiguracion)
        {
            try
            {
                return new ComisionesConfiguracionAD().ActualizarComisionesConfiguracion(comisionesconfiguracion);
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

        public int EliminarComisionesConfiguracion(Int32 idEmpresa, Int32 idComision)
        {
            try
            {
                return new ComisionesConfiguracionAD().EliminarComisionesConfiguracion(idEmpresa, idComision);
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

        public List<ComisionesConfiguracionE> ListarComisionesConfiguracion(Int32 idEmpresa, Int32 idComision, String TipoReporte)
        {
            try
            {
                return new ComisionesConfiguracionAD().ListarComisionesConfiguracion( idEmpresa,  idComision, TipoReporte);
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
  
        public List<ComisionesConfiguracionE> ListarComisionesConfiguracionPeriodo(Int32 idEmpresa, Int32 idPeriodo, String Busqueda)
        {
            try
            {
                return new ComisionesConfiguracionAD().ListarComisionesConfiguracionPeriodo( idEmpresa,  idPeriodo, Busqueda);
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


        public ComisionesConfiguracionE ObtenerComisionesConfiguracion(Int32 idEmpresa, Int32 idComision)
        {
            try
            {
                return new ComisionesConfiguracionAD().ObtenerComisionesConfiguracion(idEmpresa, idComision);
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
