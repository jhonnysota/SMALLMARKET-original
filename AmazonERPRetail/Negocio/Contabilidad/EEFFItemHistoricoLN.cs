using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using AccesoDatos;
using Infraestructura;
using AccesoDatos.Contabilidad;
using Entidades.Contabilidad;

namespace Negocio.Contabilidad
{
    public class EEFFItemHistoricoLN 
    {
        public EEFFItemHistoricoE InsertarEEFFItemHistorico(EEFFItemHistoricoE eeffitemhistorico)
        {
            try
            {
                return new EEFFItemHistoricoAD().InsertarEEFFItemHistorico(eeffitemhistorico);
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

        public EEFFItemHistoricoE ActualizarEEFFItemHistorico(EEFFItemHistoricoE eeffitemhistorico)
        {
            try
            {
                return new EEFFItemHistoricoAD().ActualizarEEFFItemHistorico(eeffitemhistorico);
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

        public int EliminarEEFFItemHistorico(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFItem, String AnioPeriodo)
        {
            try
            {
                return new EEFFItemHistoricoAD().EliminarEEFFItemHistorico(idEmpresa, idEEFF, idEEFFItem, AnioPeriodo);
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

        public List<EEFFItemHistoricoE> ListarEEFFItemHistorico(Int32 idEmpresa, Int32 idEEFF, String AnioPeriodo)
        {
            try
            {
                return new EEFFItemHistoricoAD().ListarEEFFItemHistorico(idEmpresa, idEEFF, AnioPeriodo);
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

        public EEFFItemHistoricoE ObtenerEEFFItemHistorico(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFItem, String AnioPeriodo)
        {
            try
            {
                return new EEFFItemHistoricoAD().ObtenerEEFFItemHistorico(idEmpresa, idEEFF, idEEFFItem, AnioPeriodo);
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
