using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura;
//using Negocio.Base;

namespace Negocio.Contabilidad
{
    public class PlanCuentasEstrucLN //: BaseLN
    {
        public PlanCuentasEstrucE InsertarPlanCuentasEstruc(PlanCuentasEstrucE plancuentasestruc)
        {
            try
            {
                return new PlanCuentasEstrucAD().InsertarPlanCuentasEstruc(plancuentasestruc);
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

        public PlanCuentasEstrucE ActualizarPlanCuentasEstruc(PlanCuentasEstrucE plancuentasestruc)
        {
            try
            {
                return new PlanCuentasEstrucAD().ActualizarPlanCuentasEstruc(plancuentasestruc);
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

        public List<PlanCuentasEstrucE> ListarPlanCuentasEstruc(Int32 idEmpresa, String numVerPlanCuentas)
        {
            try
            {
                return new PlanCuentasEstrucAD().ListarPlanCuentasEstruc(idEmpresa, numVerPlanCuentas);
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

        public int EliminarPlanCuentasEstruc(int idEmpresa, string numVerPlanCuentas, int numNivelEstruc)
        {
            try
            {
                return new PlanCuentasEstrucAD().EliminarPlanCuentasEstruc(idEmpresa, numVerPlanCuentas, numNivelEstruc);
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

        public PlanCuentasEstrucE ObtenerPlanCuentasEstruc(int idEmpresa, string numVerPlanCuentas, int numNivelEstruc)
        {
            try
            {
                return new PlanCuentasEstrucAD().ObtenerPlanCuentasEstruc(idEmpresa, numVerPlanCuentas, numNivelEstruc);
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
