using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

using Entidades.CtasPorPagar;
using AccesoDatos.CtasPorPagar;

namespace Negocio.CtasPorPagar
{
    public class RetencionItemLN
    {
        public RetencionItemE InsertarRetencionItem(RetencionItemE RetencionItem)
        {
            try
            {
                return new RetencionItemAD().InsertarRetencionItem(RetencionItem);
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

        public RetencionItemE ActualizarRetencionItem(RetencionItemE RetencionItem)
        {
            try
            {
                return new RetencionItemAD().ActualizarRetencionItem(RetencionItem);
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

        public int EliminarRetencionItem(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete, String Item)
        {
            try
            {
                return new RetencionItemAD().EliminarRetencionItem(idEmpresa, idLocal, serieCompRete, numeroCompRete, Item);
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

        public List<RetencionItemE> ListarRetencionItem(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete)
        {
            try
            {
                return new RetencionItemAD().ListarRetencionItem(idEmpresa, idLocal, serieCompRete, numeroCompRete);
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

        public RetencionItemE ObtenerRetencionItem(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete, String Item)
        {
            try
            {
                return new RetencionItemAD().ObtenerRetencionItem(idEmpresa, idLocal, serieCompRete, numeroCompRete, Item);
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
