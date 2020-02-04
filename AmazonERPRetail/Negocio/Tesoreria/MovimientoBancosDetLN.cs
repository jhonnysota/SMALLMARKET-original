using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Tesoreria;

namespace Negocio.Tesoreria
{
    public class MovimientoBancosDetLN
    {

        public MovimientoBancosDetE InsertarMovimientoBancosDet(MovimientoBancosDetE movimientobancosdet)
        {
            try
            {
                return new MovimientoBancosDetAD().InsertarMovimientoBancosDet(movimientobancosdet);
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

        public MovimientoBancosDetE ActualizarMovimientoBancosDet(MovimientoBancosDetE movimientobancosdet)
        {
            try
            {
                return new MovimientoBancosDetAD().ActualizarMovimientoBancosDet(movimientobancosdet);
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

        public int EliminarMovimientoBancosDet(Int32 idMovBanco, Int32 Item)
        {
            try
            {
                return new MovimientoBancosDetAD().EliminarMovimientoBancosDet(idMovBanco, Item);
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

        public int EliminarMovBancosDetPorId(Int32 idMovBanco)
        {
            try
            {
                return new MovimientoBancosDetAD().EliminarMovBancosDetPorId(idMovBanco);
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

        public List<MovimientoBancosDetE> ListarMovimientoBancosDet(Int32 idMovBanco, Int32 idEmpresa)
        {
            try
            {
                return new MovimientoBancosDetAD().ListarMovimientoBancosDet(idMovBanco, idEmpresa);
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

        public MovimientoBancosDetE ObtenerMovimientoBancosDet(Int32 idMovBanco, Int32 Item)
        {
            try
            {
                return new MovimientoBancosDetAD().ObtenerMovimientoBancosDet(idMovBanco, Item);
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

        public List<MovimientoBancosDetE> MovBancosDetallePorDocumento(List<CtaCteE> ListaCtaCte, String Usuario, DateTime Fecha)
        {
            try
            {
                List<MovimientoBancosDetE> ListaDevuelta = new List<MovimientoBancosDetE>();
                Int32 numItem = 1;

                foreach (CtaCteE item in ListaCtaCte)
                {
                    MovimientoBancosDetE oMovDetalle = new MovimientoBancosDetAD().MovBancosDetallePorDocumento(item.idEmpresa, item.idDocumento, item.numSerie, item.numDocumento);

                    if (oMovDetalle != null)
                    {
                        oMovDetalle.Item = numItem;
                        oMovDetalle.idPersona = null;
                        oMovDetalle.UsuarioRegistro = oMovDetalle.UsuarioModificacion = Usuario;
                        oMovDetalle.FechaRegistro = oMovDetalle.FechaModificacion = Fecha;
                        ListaDevuelta.Add(oMovDetalle);
                        numItem++;
                    }
                }

                return ListaDevuelta;
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
