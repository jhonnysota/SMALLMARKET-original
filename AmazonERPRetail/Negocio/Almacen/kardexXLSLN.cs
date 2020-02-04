using AccesoDatos.Almacen;
using Entidades.Almacen;
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

namespace Negocio.Almacen
{
    public class kardexXLSLN
    {
        public Int32 InsertarkardexXLS(List<kardexXLSE> oListaKardexXLS)
        {
            try
            {
                Int32 FilasDevueltas = Variables.Cero;

                TransactionOptions Opciones = new TransactionOptions();
                Opciones.Timeout = TimeSpan.FromMinutes(240);

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    //Insertando a la BD el resultado final de la lista
                    using (DataTable oDt = Colecciones.ToDataTable<kardexXLSE>(oListaKardexXLS))
                    {
                        FilasDevueltas = new kardexXLSAD().InsertarkardexXLS(oDt);
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

        //public Int32 ErroresPlanContableXLS(List<kardexXLSE> oListaErrores)
        //{
        //    try
        //    {
        //        Int32 FilasDevueltas = Variables.Cero;

        //        foreach (kardexXLSE item in oListaErrores)
        //        {
        //            FilasDevueltas += new kardexXLSAD().ProcesarPlanContableXLS(item.idEmpresa);
        //        }

        //        return FilasDevueltas;
        //    }
        //    catch (SqlException ex)
        //    {
        //        SqlError err = ex.Errors[0];
        //        StringBuilder mensaje = new StringBuilder();

        //        switch (err.Number)
        //        {
        //            default:
        //                mensaje.Append("Mensaje: " + err.Message + "\n");
        //                mensaje.Append("N° Linea: " + err.LineNumber + "\n");
        //                mensaje.Append("Origen: " + err.Source + "\n");
        //                mensaje.Append("Procedimiento: " + err.Procedure + "\n");
        //                mensaje.Append("N° Error: " + err.Number);
        //                break;
        //        }

        //        throw new Exception(mensaje.ToString());
        //    }
        //}

        public Int32 IntegrarKardexXLS(List<kardexXLSE> oListaKardexXLS, String Usuario, String Plan)
        {
            try
            {
                Int32 resp = 0;


                using (TransactionScope oTrans = new TransactionScope())
                {
                    foreach (kardexXLSE item in oListaKardexXLS)
                    {
                        //PlanCuentasE oListaCuentas = null;
                        //oListaCuentas = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(item.idEmpresa, Plan, item.Cuenta);

                        //if (oListaCuentas == null)
                        //{
                        //    PlanCuentasE oPLan = new PlanCuentasE();

                        //    oPLan.idEmpresa = item.idEmpresa;
                        //    oPLan.numVerPlanCuentas = Plan;
                        //    oPLan.codCuenta = item.Cuenta;
                        //    oPLan.Descripcion = item.Descripcion;
                        //    oPLan.numNivel = item.Nivel;
                        //    oPLan.idMoneda = item.Mon;
                        //    oPLan.indNaturalezaCta = item.DH;
                        //    oPLan.indAjuste_X_Cambio = item.AjusCambio;
                        //    oPLan.tipAjuste = item.TipoAjus;
                        //    oPLan.codCuentaGanancia = item.CtaGanan;
                        //    oPLan.codCuentaPerdida = item.CtaPerd;
                        //    oPLan.indCambio_X_Compra = item.CambioCom;
                        //    oPLan.indCuentaGastos = item.IndGasto;
                        //    oPLan.codCuentaDestino = item.CtaDest;
                        //    oPLan.codCuentaTransferencia = item.CtaTransf;
                        //    oPLan.indCuentaCierre = item.IndCierre;
                        //    oPLan.codCuentaCieDeb = item.CtaCierre;
                        //    oPLan.indCtaCte = item.CtaCte;
                        //    oPLan.indSolicitaAnexo = item.ConAux;
                        //    oPLan.indSolicitaDcto = item.ConDoc;
                        //    oPLan.indSolicitaCentroCosto = item.ConCC;
                        //    oPLan.indBalance = item.Balance;
                        //    oPLan.codColumnaCoven = item.ColCV;
                        //    oPLan.indUltNodo = item.UltNodo;
                        //    oPLan.UsuarioRegistro = Usuario;

                        //    if (item.Nivel == 1)
                        //    {
                        //        oPLan.codCuentaSup = "0";
                        //    }
                        //    else
                        //    {
                        //        oPLan.codCuentaSup = item.Cuenta.Substring(0, item.Cuenta.Length - 1);
                        //    }

                        //    if (item.UltNodo == "S")
                        //    {
                        //        oPLan.tipTituloNodo = "DE";
                        //    }
                        //    else
                        //    {
                        //        oPLan.tipTituloNodo = "TI";
                        //    }

                        //    oPLan.tipPartidaPresu = "";
                        //    oPLan.codPartidaPresu = "";
                        //    oPLan.indNotaIngreso = "";
                        //    oPLan.indAnexoReferencial = "";
                        //    oPLan.indCajaChica = "";
                        //    oPLan.tipoCajaChica = 0;
                        //    oPLan.indCtaIngreso = "";
                        //    oPLan.idTasaRenta = "";

                        //    oPLan = new PlanCuentasAD().InsertarPlanCuentas(oPLan);
                        //}

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

        public Int32 EliminaKardexXLS(List<kardexXLSE> oListaPorEliminar)
        {
            try
            {
                Int32 resp = 0;

                foreach (kardexXLSE item in oListaPorEliminar)
                {
                    resp += new kardexXLSAD().EliminaKardexXLS(item.idEmpresa);
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
