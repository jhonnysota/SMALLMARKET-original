using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Almacen;

namespace Negocio.Almacen
{
    public class HojaCostoAlmacenLN 
    {
        public HojaCostoAlmacenE InsertarHojaCostoAlmacen(HojaCostoAlmacenE hojacostoalmacen)
        {
            try
            {
                return new HojaCostoAlmacenAD().InsertarHojaCostoAlmacen(hojacostoalmacen);
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

        public HojaCostoAlmacenE ActualizarHojaCostoAlmacen(HojaCostoAlmacenE hojacostoalmacen)
        {
            try
            {
                return new HojaCostoAlmacenAD().ActualizarHojaCostoAlmacen(hojacostoalmacen);
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

        public int EliminarHojaCostoAlmacen(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 tipMovimiento, Int32 idDocumentoAlmacen)
        {
            try
            {
                return new HojaCostoAlmacenAD().EliminarHojaCostoAlmacen(idEmpresa, idLocal, idHojaCosto, tipMovimiento, idDocumentoAlmacen);
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

        public List<HojaCostoAlmacenE> ListarHojaCostoAlmacen()
        {
            try
            {
                return new HojaCostoAlmacenAD().ListarHojaCostoAlmacen();
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

        public HojaCostoAlmacenE ObtenerHojaCostoAlmacen(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 tipMovimiento, Int32 idDocumentoAlmacen)
        {
            try
            {
                return new HojaCostoAlmacenAD().ObtenerHojaCostoAlmacen(idEmpresa, idLocal, idHojaCosto, tipMovimiento, idDocumentoAlmacen);
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
