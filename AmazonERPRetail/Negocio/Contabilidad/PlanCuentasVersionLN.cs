using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura;
using System.Transactions;
using Infraestructura.Enumerados;
//using Negocio.Base;

namespace Negocio.Contabilidad
{
    public class PlanCuentasVersionLN //: BaseLN
    {

        public PlanCuentasVersionE GrabarPlanCuentasVersion(PlanCuentasVersionE PlanCuenta, EnumOpcionGrabar OpcionGrabacion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabacion)
                    {
                        case EnumOpcionGrabar.Insertar:

                            PlanCuenta = new PlanCuentasVersionAD().InsertarPlanCuentasVersion(PlanCuenta);

                            if (PlanCuenta.ListaEstructura != null && PlanCuenta.ListaEstructura.Count > 0)
                            {
                                foreach (PlanCuentasEstrucE item in PlanCuenta.ListaEstructura)
                                {
                                    item.idEmpresa = PlanCuenta.idEmpresa;
                                    item.numVerPlanCuentas = PlanCuenta.numVerPlanCuentas;
                                    new PlanCuentasEstrucAD().InsertarPlanCuentasEstruc(item);                                  
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            PlanCuenta = new PlanCuentasVersionAD().ActualizarPlanCuentasVersion(PlanCuenta);

                            if (PlanCuenta.ListaEstructura != null && PlanCuenta.ListaEstructura.Count > 0)
                            {
                                foreach (PlanCuentasEstrucE item in PlanCuenta.ListaEstructura)
                                {
                                    item.idEmpresa = PlanCuenta.idEmpresa;
                                    item.numVerPlanCuentas = PlanCuenta.numVerPlanCuentas;
                                    if (item.Opcion == (Int32)EnumOpcionGrabar.Actualizar)
                                    {
                                        new PlanCuentasEstrucAD().ActualizarPlanCuentasEstruc(item);
                                    }
                                    else if (item.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                                    {
                                        new PlanCuentasEstrucAD().InsertarPlanCuentasEstruc(item);
                                    }

                                    
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return PlanCuenta;
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

        public List<PlanCuentasVersionE> ListarPlanCuentasVersion(Int32 idEmpresa)
        {
            try
            {
                return new PlanCuentasVersionAD().ListarPlanCuentasVersion(idEmpresa);
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

        public PlanCuentasVersionE ObtenerPlanCuentasVersionCompleto(Int32 idEmpresa,  String numVerPlanCuentas)
        {
            try
            {
                PlanCuentasVersionE PlanCuenta = new PlanCuentasVersionAD().ObtenerPlanCuentasVersion(idEmpresa,numVerPlanCuentas);
                PlanCuenta.ListaEstructura = new PlanCuentasEstrucAD().ListarPlanCuentasEstruc(idEmpresa, numVerPlanCuentas);
                return PlanCuenta;
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

        public PlanCuentasVersionE VersionPlanCuentasActual(Int32 idEmpresa)
        {
            try
            {
                return new PlanCuentasVersionAD().VersionPlanCuentasActual(idEmpresa);
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
