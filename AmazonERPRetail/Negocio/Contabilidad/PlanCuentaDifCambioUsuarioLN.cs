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
    public class PlanCuentaDifCambioUsuarioLN //: BaseLN
    {
        public Int32 GuardaPlanCuentasDifCambioUsuario(List<PlanCuentasDifCambioUsuarioE> oLista)
        {
            try
            {

                List<PlanCuentasDifCambioUsuarioE> oListaSql = new PlanCuentaDifCambioUsuarioAD().ObtenerPlanCuentasDifCambioUsuario(oLista[0].idEmpresa, oLista[0].numVerPlanCuentas, oLista[0].UsuarioAsignado);

                for (int i = 0; i < oListaSql.Count; i++)
                {
                    Boolean oExiste = true;

                    for (int ii = 0; ii < oLista.Count; ii++)
                    {
                        if(oListaSql[i].codCuenta == oLista[ii].codCuenta)
                        {
                            new PlanCuentaDifCambioUsuarioAD().ActualizarPlanCuentasDifCambioUsuario(oLista[i]);
                            oExiste = false;
                        }
                    }

                    if(oExiste)
                        new PlanCuentaDifCambioUsuarioAD().EliminarPlanCuentasDifCambioUsuario(oListaSql[i]);

                }

                for (int i = 0; i < oLista.Count; i++)
                {
                    Boolean oExiste = true;

                    for (int ii = 0; ii < oListaSql.Count; ii++)
                    {
                        if (oListaSql[ii].codCuenta == oLista[i].codCuenta)
                            oExiste = false;
                    }

                    if (oExiste)
                        new PlanCuentaDifCambioUsuarioAD().InsertarPlanCuentasDifCambioUsuario(oLista[i]);
                }

                return 0;
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


        public List<PlanCuentasDifCambioUsuarioE> ListarPlanCuentasDifCambioUsuario(int idEmpresa, string numVerPlanCuentas, string UsuarioAsignado)
        {
            try
            {
                return new PlanCuentaDifCambioUsuarioAD().ListarPlanCuentasDifCambioUsuario(idEmpresa, numVerPlanCuentas, UsuarioAsignado);
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

        public List<PlanCuentasDifCambioUsuarioE> ObtenerPlanCuentasDifCambioUsuario(int idEmpresa, string numVerPlanCuentas, string UsuarioAsignado)
        {
            try
            {
                return new PlanCuentaDifCambioUsuarioAD().ObtenerPlanCuentasDifCambioUsuario(idEmpresa, numVerPlanCuentas, UsuarioAsignado);
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

        public List<PlanCuentasDifCambioUsuarioE> ObtenerPlanCuentasDifCambioUsuarioDolar(int idEmpresa, string numVerPlanCuentas, string UsuarioAsignado)
        {
            try
            {
                return new PlanCuentaDifCambioUsuarioAD().ObtenerPlanCuentasDifCambioUsuarioDolar(idEmpresa, numVerPlanCuentas, UsuarioAsignado);
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

        public List<PlanCuentasDifCambioUsuarioE> ObtenerPlanCuentasDifCambioUsuarioSoles(int idEmpresa, string numVerPlanCuentas, string UsuarioAsignado)
        {
            try
            {
                return new PlanCuentaDifCambioUsuarioAD().ObtenerPlanCuentasDifCambioUsuarioSoles(idEmpresa, numVerPlanCuentas, UsuarioAsignado);
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
