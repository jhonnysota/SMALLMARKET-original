using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Maestros;

namespace Negocio.Maestros
{
    public class ImpresionBarrasDetDetLN
    {

        public ImpresionBarrasDetDetE InsertarImpresionBarrasDetDet(ImpresionBarrasDetDetE impresionbarrasdetdet)
        {
            try
            {
                return new ImpresionBarrasDetDetAD().InsertarImpresionBarrasDetDet(impresionbarrasdetdet);
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

        public ImpresionBarrasDetDetE ActualizarImpresionBarrasDetDet(ImpresionBarrasDetDetE impresionbarrasdetdet)
        {
            try
            {
                return new ImpresionBarrasDetDetAD().ActualizarImpresionBarrasDetDet(impresionbarrasdetdet);
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

        public int EliminarImpresionBarrasDetDet(Int32 idImpresion, Int32 idArticulo, Int32 Item)
        {
            try
            {
                return new ImpresionBarrasDetDetAD().EliminarImpresionBarrasDetDet(idImpresion, idArticulo, Item);
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

        public List<ImpresionBarrasDetDetE> ListarImpresionBarrasDetDet(Int32 idImpresion, Int32 idArticulo)
        {
            try
            {
                return new ImpresionBarrasDetDetAD().ListarImpresionBarrasDetDet(idImpresion, idArticulo);
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

        public ImpresionBarrasDetDetE ObtenerImpresionBarrasDetDet(Int32 idImpresion, Int32 idArticulo, Int32 Item)
        {
            try
            {
                return new ImpresionBarrasDetDetAD().ObtenerImpresionBarrasDetDet(idImpresion, idArticulo, Item);
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

        public List<ImpresionBarrasDetDetE> ListarImpresionCodigoBarras(Int32 idImpresion)
        {
            try
            {
                return new ImpresionBarrasDetDetAD().ListarImpresionCodigoBarras(idImpresion);
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

        public ImpresionBarrasDetDetE ObtenerImpresionDetDetPorBarras(Int32 idEmpresa, String codBarras)
        {
            try
            {
                ImpresionBarrasDetDetE oDetalle = new ImpresionBarrasDetDetAD().ObtenerImpresionDetDetPorBarras(idEmpresa, codBarras);

                if (oDetalle != null)
                {
                    oDetalle.oArticulo = new ArticuloServAD().ObtenerArticuloCalzado(idEmpresa, oDetalle.idArticulo);
                }

                return oDetalle;
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
