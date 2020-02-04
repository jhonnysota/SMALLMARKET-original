using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Ventas;

namespace Negocio.Maestros
{
    public class EstablecimientosLN
    {
        public EstablecimientosE InsertarEstablecimientos(EstablecimientosE establecimientos)
        {
            try
            {
                return new EstablecimientosAD().InsertarEstablecimientos(establecimientos);
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

        public EstablecimientosE ActualizarEstablecimientos(EstablecimientosE establecimientos)
        {
            try
            {
                return new EstablecimientosAD().ActualizarEstablecimientos(establecimientos);
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

        public Int32 EliminarEstablecimientos(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento)
        {
            try
            {
                return new EstablecimientosAD().EliminarEstablecimientos(idEmpresa, idLocal, idEstablecimiento);
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

        public List<EstablecimientosE> ListarEstablecimientos(Int32 idEmpresa, Int32 idLocal)
        {
            try
            {
                return new EstablecimientosAD().ListarEstablecimientos(idEmpresa, idLocal);
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


        public EstablecimientosE ObtenerEstablecimientosPorDescripcionEstablecimiento(String Descripcion)
        {
            try
            {
                return new EstablecimientosAD().ObtenerEstablecimientosPorDescripcionEstablecimiento(Descripcion);
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

        public EstablecimientosE ObtenerEstablecimientos(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento)
        {
            try
            {
                return new EstablecimientosAD().ObtenerEstablecimientos(idEmpresa, idLocal, idEstablecimiento);
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

        public Int32 DarBajaEstablecimiento(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento, String UsuarioModificacion)
        {
            try
            {
                return new EstablecimientosAD().DarBajaEstablecimiento(idEmpresa, idLocal, idEstablecimiento, UsuarioModificacion);
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

        public List<EstablecimientosE> ListarEstablecimientosZonas(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento)
        {
            try
            {
                return new EstablecimientosAD().ListarEstablecimientosZonas(idEmpresa, idLocal, idEstablecimiento);
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
