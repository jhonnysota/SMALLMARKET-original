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
    public class SaldoSegunBancoLN 
    {
        public SaldoSegunBancoE InsertarSaldoSegunBanco(SaldoSegunBancoE saldosegunbanco)
        {
            try
            {
                return new SaldoSegunBancoAD().InsertarSaldoSegunBanco(saldosegunbanco);
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

        public SaldoSegunBancoE ActualizarSaldoSegunBanco(SaldoSegunBancoE saldosegunbanco)
        {
            try
            {
                return new SaldoSegunBancoAD().ActualizarSaldoSegunBanco(saldosegunbanco);
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

        public int EliminarSaldoSegunBanco(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta)
        {
            try
            {
                return new SaldoSegunBancoAD().EliminarSaldoSegunBanco(idEmpresa, AnioPeriodo, MesPeriodo, numVerPlanCuentas, codCuenta);
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

        public List<SaldoSegunBancoE> ListarSaldoSegunBanco()
        {
            try
            {
                return new SaldoSegunBancoAD().ListarSaldoSegunBanco();
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

        public SaldoSegunBancoE ObtenerSaldoSegunBanco(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta)
        {
            try
            {
                return new SaldoSegunBancoAD().ObtenerSaldoSegunBanco(idEmpresa, AnioPeriodo, MesPeriodo, numVerPlanCuentas, codCuenta);
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
