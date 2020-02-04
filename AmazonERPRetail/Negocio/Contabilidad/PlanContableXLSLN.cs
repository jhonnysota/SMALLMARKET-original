using AccesoDatos.Contabilidad;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Extensores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio.Contabilidad
{
    public class PlanContableXLSLN
    {
        public Int32 InsertarPlanContableXLS(List<PlanContableXLSE> oListaPlanContable)
        {
            try
            {
                Int32 FilasDevueltas = Variables.Cero;

                TransactionOptions Opciones = new TransactionOptions();
                Opciones.Timeout = TimeSpan.FromMinutes(240);

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    //Insertando a la BD el resultado final de la lista
                    using (DataTable oDt = Colecciones.ToDataTable<PlanContableXLSE>(oListaPlanContable))
                    {
                        FilasDevueltas = new PlanContableXLSAD().InsertarPlanContableXLS(oDt);
                    }

                    //Cerrando la transaccion
                    oTrans.Complete();
                }

                return FilasDevueltas;
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

        public Int32 ErroresPlanContableXLS(List<PlanContableXLSE> oListaErrores)
        {
            try
            {
                Int32 FilasDevueltas = Variables.Cero;

                foreach (PlanContableXLSE item in oListaErrores)
                {
                    FilasDevueltas += new PlanContableXLSAD().ProcesarPlanContableXLS(item.idEmpresa);
                }

                return FilasDevueltas;
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

        public Int32 IntegrarPlanCuentasXLS(List<PlanContableXLSE> oListaPlanContable, String Usuario,String Plan)
        {
            try
            {
                Int32 resp = 0;
               

                using (TransactionScope oTrans = new TransactionScope())
                {
                    foreach (PlanContableXLSE item in oListaPlanContable)
                    {
                        PlanCuentasE oListaCuentas = null;
                        //oPersona = new PersonaAD().ValidaRUCExistente(item.NroDocumento);
                        oListaCuentas = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(item.idEmpresa, Plan, item.Cuenta);

                        if (oListaCuentas == null)
                        {
                            PlanCuentasE oPLan = new PlanCuentasE();

                            oPLan.idEmpresa = item.idEmpresa;
                            oPLan.numVerPlanCuentas = Plan;
                            oPLan.codCuenta = item.Cuenta;
                            oPLan.Descripcion = item.Descripcion;
                            oPLan.numNivel = item.Nivel;
                            oPLan.idMoneda = item.Mon;
                            oPLan.indNaturalezaCta = item.DH;
                            oPLan.indAjuste_X_Cambio = item.AjusCambio;
                            oPLan.tipAjuste = item.TipoAjus;
                            oPLan.codCuentaGanancia = item.CtaGanan;
                            oPLan.codCuentaPerdida = item.CtaPerd;
                            oPLan.indCambio_X_Compra = item.CambioCom;
                            oPLan.indCuentaGastos = item.IndGasto;
                            oPLan.codCuentaDestino = item.CtaDest;
                            oPLan.codCuentaTransferencia = item.CtaTransf;
                            oPLan.indCuentaCierre = item.IndCierre;
                            oPLan.codCuentaCieDeb = item.CtaCierre;
                            oPLan.indCtaCte = item.CtaCte;
                            oPLan.indSolicitaAnexo = item.ConAux;
                            oPLan.indSolicitaDcto = item.ConDoc;
                            oPLan.indSolicitaCentroCosto = item.ConCC;
                            oPLan.indBalance = item.Balance;
                            oPLan.codColumnaCoven = item.ColCV;
                            oPLan.indUltNodo = item.UltNodo;
                            oPLan.UsuarioRegistro = Usuario;

                            if (item.Nivel == 1)
                            {
                                oPLan.codCuentaSup = "0";
                            }
                            else
                            {
                                oPLan.codCuentaSup = item.Cuenta.Substring(0,item.Cuenta.Length - 1);
                            }

                            if (item.UltNodo == "S")
                            {
                                oPLan.tipTituloNodo = "DE";
                            }
                            else
                            {
                                oPLan.tipTituloNodo = "TI";
                            }

                            oPLan.tipPartidaPresu = "";
                            oPLan.codPartidaPresu = "";
                            oPLan.indNotaIngreso = "";
                            oPLan.indAnexoReferencial = "";
                            oPLan.indCajaChica = "";
                            oPLan.tipoCajaChica = 0;
                            oPLan.indCtaIngreso = "";
                            oPLan.idTasaRenta = "";

                            oPLan = new PlanCuentasAD().InsertarPlanCuentas(oPLan);
                        }

                        resp++;
                    }

                    oTrans.Complete();
                }

                return resp;
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

        public Int32 EliminarPlanContableXLS(List<PlanContableXLSE> oListaPorEliminar)
        {
            try
            {
                Int32 resp = 0;

                foreach (PlanContableXLSE item in oListaPorEliminar)
                {
                    resp += new PlanContableXLSAD().EliminarPlanContableXLS(item.idEmpresa);
                }

                return resp;
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
