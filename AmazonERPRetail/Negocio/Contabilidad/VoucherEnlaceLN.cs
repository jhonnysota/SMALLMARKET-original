using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;

namespace Negocio.Contabilidad
{
    public class VoucherEnlaceLN
    {
        public VoucherEnlaceE InsertarVoucherEnlace(VoucherEnlaceE voucherenlace)
        {
            try
            {
                return new VoucherEnlaceAD().InsertarVoucherEnlace(voucherenlace);
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

        //public VoucherEnlaceE ActualizarVoucherEnlace(VoucherEnlaceE voucherenlace)
        //{
        //    try
        //    {
        //        return new VoucherEnlaceAD().ActualizarVoucherEnlace(voucherenlace);
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

        public int EliminarVoucherEnlace(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile, String numItem)//, Int32 idEmpresaD, Int32 idLocalD, String AnioPeriodoD, String MesPeriodoD, String numVoucherD, String idComprobanteD, String numFileD)
        {
            try
            {
                return new VoucherEnlaceAD().EliminarVoucherEnlace(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobante, numFile, numItem);//, idEmpresaD, idLocalD, AnioPeriodoD, MesPeriodoD, numVoucherD, idComprobanteD, numFileD);
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

        public List<VoucherEnlaceE> ListarVoucherEnlace()
        {
            try
            {
                return new VoucherEnlaceAD().ListarVoucherEnlace();
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

        public VoucherEnlaceE ObtenerVoucherEnlace(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile)//, String numItem, Int32 idEmpresaD, Int32 idLocalD, String AnioPeriodoD, String MesPeriodoD, String numVoucherD, String idComprobanteD, String numFileD)
        {
            try
            {
                return new VoucherEnlaceAD().ObtenerVoucherEnlace(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobante, numFile);//, numItem, idEmpresaD, idLocalD, AnioPeriodoD, MesPeriodoD, numVoucherD, idComprobanteD, numFileD);
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
