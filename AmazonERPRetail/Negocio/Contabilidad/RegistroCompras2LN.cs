using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura;

namespace Negocio.Contabilidad
{
    public class RegistroCompras2LN
    {

        public RegistroCompras2E InsertarRegistroCompras(RegistroCompras2E registrocompras)
        {
            try
            {
                Int32 numVoucher = Variables.Cero;

                if (registrocompras.numVoucher == Variables.Cero.ToString())
                {
                    numVoucher = new VoucherAD().GenerarNumVoucher(registrocompras.idEmpresa, registrocompras.idLocal, registrocompras.AnioPeriodo, registrocompras.MesPeriodo, registrocompras.idComprobante, registrocompras.numFile);
                    numVoucher++;
                    registrocompras.numVoucher = numVoucher.ToString("000000000");
                }

                return new RegistroCompras2AD().InsertarRegistroCompras(registrocompras);
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

        public RegistroCompras2E ActualizarRegistroCompras(RegistroCompras2E registrocompras)
        {
            try
            {
                return new RegistroCompras2AD().ActualizarRegistroCompras(registrocompras);
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

        public RegistroCompras2E InsertarRegistroComprasNoDom(RegistroCompras2E registrocompras)
        {
            try
            {
                Int32 numVoucher = Variables.Cero;

                if (registrocompras.numVoucher == Variables.Cero.ToString())
                {
                    numVoucher = new VoucherAD().GenerarNumVoucher(registrocompras.idEmpresa, registrocompras.idLocal, registrocompras.AnioPeriodo, registrocompras.MesPeriodo, registrocompras.idComprobante, registrocompras.numFile);
                    numVoucher++;
                    registrocompras.numVoucher = numVoucher.ToString("000000000");
                }

                return new RegistroCompras2AD().InsertarRegistroComprasNoDom(registrocompras);
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

        public RegistroCompras2E ActualizarRegistroComprasNoDom(RegistroCompras2E registrocompras)
        {
            try
            {
                Int32 numVoucher = Variables.Cero;

                if (registrocompras.numVoucher == Variables.Cero.ToString())
                {
                    numVoucher = new VoucherAD().GenerarNumVoucher(registrocompras.idEmpresa, registrocompras.idLocal, registrocompras.AnioPeriodo, registrocompras.MesPeriodo, registrocompras.idComprobante, registrocompras.numFile);
                    numVoucher++;
                    registrocompras.numVoucher = numVoucher.ToString("000000000");
                }

                return new RegistroCompras2AD().ActualizarRegistroComprasNoDom(registrocompras);
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

        public int EliminarRegistroCompras(Int32 idRegCompras)
        {
            try
            {
                return new RegistroCompras2AD().EliminarRegistroCompras(idRegCompras);
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

        public List<RegistroCompras2E> ListarRegistroCompras(int idEmpresa, int idLocal, Int32 TipoCompra, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                return new RegistroCompras2AD().ListarRegistroCompras(idEmpresa, idLocal, TipoCompra, fecIni, fecFin);
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

        public RegistroCompras2E ObtenerRegistroCompras(Int32 idRegCompras)
        {
            try
            {
                return new RegistroCompras2AD().ObtenerRegistroCompras(idRegCompras);
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

        public RegistroCompras2E GenerarAsientoCompras(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, String Usuario)
        {
            try
            {
                return new RegistroCompras2AD().GenerarAsientoCompras(idEmpresa, idLocal, idProvision, Usuario);
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
