using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Ventas;

namespace Negocio.Ventas
{
    public class LetrasCanjeLN
    {

        public LetrasCanjeE InsertarLetrasCanje(LetrasCanjeE letrascanje)
        {
            try
            {
                return new LetrasCanjeAD().InsertarLetrasCanje(letrascanje);
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

        public LetrasCanjeE ActualizarLetrasCanje(LetrasCanjeE letrascanje)
        {
            try
            {
                return new LetrasCanjeAD().ActualizarLetrasCanje(letrascanje);
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

        //public int EliminarLetrasCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        //{
        //    try
        //    {
        //        return new LetrasCanjeAD().EliminarLetrasCanje(idEmpresa, idLocal, tipCanje, codCanje);
        //    }
        //    catch (SqlException ex)
        //    {
        //        SqlError err = ex.Errors[0];
        //        StringBuilder mensaje = new StringBuilder();

        //        switch (err.Number)
        //        {                    
        //            default:
        //                mensaje.Append("Mensaje: " + err.Message + "\n");
        //                mensaje.Append("N° Linea: " + err.LineNumber + "\n");
        //                mensaje.Append("Origen: " + err.Source + "\n");
        //                mensaje.Append("Procedimiento: " + err.Procedure + "\n");
        //                mensaje.Append("N° Error: " + err.Number);
        //                break;
        //        }

        //        throw new Exception(mensaje.ToString());
        //    }
        //}

        public List<LetrasCanjeE> ListarLetrasCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {
            try
            {
                return new LetrasCanjeAD().ListarLetrasCanje(idEmpresa, idLocal, tipCanje, codCanje);
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

        public LetrasCanjeE ObtenerLetrasCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {
            try
            {
                return new LetrasCanjeAD().ObtenerLetrasCanje(idEmpresa, idLocal, tipCanje, codCanje);
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

        public LetrasCanjeE LetrasCanjePorDocumento(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, string numDocumento)
        {
            try
            {
                return new LetrasCanjeAD().LetrasCanjePorDocumento(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
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

        public Int32 ActualizarLetrasCanjeConta(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String idComprobante, String numFile, String Anio, String Mes, String Voucher, String Usuario)
        {
            try
            {
                return new LetrasCanjeAD().ActualizarLetrasCanjeConta(idEmpresa, idLocal, tipCanje, codCanje, idComprobante, numFile, Anio, Mes, Voucher, Usuario);
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
