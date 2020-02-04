using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using AccesoDatos.Contabilidad;
using Entidades.Contabilidad;

namespace Negocio.Contabilidad
{
    public class BancosConciliarLN 
    {

        public BancosConciliarE InsertarBancosConciliar(BancosConciliarE bancosconciliar)
        {
            try
            {
                return new BancosConciliarAD().InsertarBancosConciliar(bancosconciliar);
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

        public BancosConciliarE ActualizarBancosConciliar(BancosConciliarE bancosconciliar)
        {
            try
            {
                return new BancosConciliarAD().ActualizarBancosConciliar(bancosconciliar);
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

        public int EliminarBancosConciliar(Int32 idPersona, Int32 idEmpresa, DateTime FechaIni, DateTime FechaFin, String CodCuenta)
        {
            try
            {
                return new BancosConciliarAD().EliminarBancosConciliar( idPersona, idEmpresa, FechaIni, FechaFin,CodCuenta);
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

        public List<BancosConciliarE> ListarBancosConciliar(Int32 idPersona, Int32 idEmpresa, Int32 AnioPeriodo, Int32 MesPeriodo, String CodCuenta)
        {
            try
            {
                return new BancosConciliarAD().ListarBancosConciliar(idPersona, idEmpresa, AnioPeriodo, MesPeriodo, CodCuenta);
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
