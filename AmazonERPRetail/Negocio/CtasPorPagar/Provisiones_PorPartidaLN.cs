using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using AccesoDatos;
using Infraestructura;
using Entidades.CtasPorPagar;
using AccesoDatos.CtasPorPagar;
//using Negocio.Base;

namespace Negocio.CtasPorPagar
{
    public class Provisiones_PorPartidaLN //: BaseLN
    {
        public Provisiones_PorPartidaE InsertarProvisiones_PorPartida(Provisiones_PorPartidaE provisiones_porpartida)
        {
            try
            {
                return new Provisiones_PorPartidaAD().InsertarProvisiones_PorPartida(provisiones_porpartida);
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

        public Provisiones_PorPartidaE ActualizarProvisiones_PorPartida(Provisiones_PorPartidaE provisiones_porpartida)
        {
            try
            {
                return new Provisiones_PorPartidaAD().ActualizarProvisiones_PorPartida(provisiones_porpartida);
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

        public int EliminarProvisiones_PorPartida(Int32 idEmpresa, Int32 idLocal, Int32 idProvision)
        {
            try
            {
                return new Provisiones_PorPartidaAD().EliminarProvisiones_PorPartida(idEmpresa, idLocal, idProvision);
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

        public List<Provisiones_PorPartidaE> ListarProvisiones_PorPartida()
        {
            try
            {
                return new Provisiones_PorPartidaAD().ListarProvisiones_PorPartida();
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

        public Provisiones_PorPartidaE ObtenerProvisiones_PorPartida(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, Int32 idItem)
        {
            try
            {
                return new Provisiones_PorPartidaAD().ObtenerProvisiones_PorPartida(idEmpresa, idLocal, idProvision, idItem);
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
