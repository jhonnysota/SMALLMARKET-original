using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using AccesoDatos;
using Infraestructura;
using AccesoDatos.CtasPorPagar;
using Entidades.CtasPorPagar;
//using Negocio.Base;

namespace Negocio.CtasPorPagar
{
    public class Provisiones_PorCCostoLN //: BaseLN
    {
        public Provisiones_PorCCostoE InsertarProvisiones_PorCCosto(Provisiones_PorCCostoE provisiones_porccosto)
        {
            try
            {
                return new Provisiones_PorCCostoAD().InsertarProvisiones_PorCCosto(provisiones_porccosto);
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

        public Provisiones_PorCCostoE ActualizarProvisiones_PorCCosto(Provisiones_PorCCostoE provisiones_porccosto)
        {
            try
            {
                return new Provisiones_PorCCostoAD().ActualizarProvisiones_PorCCosto(provisiones_porccosto);
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

        public int EliminarProvisiones_PorCCosto(Int32 idEmpresa, Int32 idLocal, Int32 idProvision)
        {
            try
            {
                return new Provisiones_PorCCostoAD().EliminarProvisiones_PorCCosto(idEmpresa, idLocal, idProvision);
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

        public List<Provisiones_PorCCostoE> ListarProvisiones_PorCCosto()
        {
            try
            {
                return new Provisiones_PorCCostoAD().ListarProvisiones_PorCCosto();
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

        public Provisiones_PorCCostoE ObtenerProvisiones_PorCCosto(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, Int32 idItem)
        {
            try
            {
                return new Provisiones_PorCCostoAD().ObtenerProvisiones_PorCCosto(idEmpresa, idLocal, idProvision, idItem);
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
