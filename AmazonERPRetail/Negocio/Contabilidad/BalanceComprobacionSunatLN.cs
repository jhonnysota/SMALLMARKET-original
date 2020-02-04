using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using AccesoDatos;
using Infraestructura;
using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;

namespace Negocio.Contabilidad
{
    public class BalanceComprobacionSunatLN 
    {
        public BalanceComprobacionSunatE InsertarBalanceComprobacionSunat(BalanceComprobacionSunatE balancecomprobacionsunat)
        {
            try
            {
                return new BalanceComprobacionSunatAD().InsertarBalanceComprobacionSunat(balancecomprobacionsunat);
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

        public BalanceComprobacionSunatE ActualizarBalanceComprobacionSunat(BalanceComprobacionSunatE balancecomprobacionsunat)
        {
            try
            {
                return new BalanceComprobacionSunatAD().ActualizarBalanceComprobacionSunat(balancecomprobacionsunat);
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

        public int EliminarBalanceComprobacionSunat(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String codCuentaSunat)
        {
            try
            {
                return new BalanceComprobacionSunatAD().EliminarBalanceComprobacionSunat(idEmpresa, AnioPeriodo, MesPeriodo, codCuentaSunat);
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

        public List<BalanceComprobacionSunatE> ListarBalanceComprobacionSunat(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo)
        {
            try
            {
                return new BalanceComprobacionSunatAD().ListarBalanceComprobacionSunat(idEmpresa,AnioPeriodo,MesPeriodo);
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

        public BalanceComprobacionSunatE ObtenerBalanceComprobacionSunat(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String codCuentaSunat)
        {
            try
            {
                return new BalanceComprobacionSunatAD().ObtenerBalanceComprobacionSunat(idEmpresa, AnioPeriodo, MesPeriodo, codCuentaSunat);
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
