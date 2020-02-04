using AccesoDatos.Maestros;
using Entidades.Maestros;
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

namespace Negocio.Maestros
{
    public class ImportacionComprasXLSLN
    {
        public Int32 InsertarComprasXLS(List<ImportacionComprasXLSE> oListaCompras)
        {
            try
            {
                Int32 FilasDevueltas = Variables.Cero;

                TransactionOptions Opciones = new TransactionOptions();
                Opciones.Timeout = TimeSpan.FromMinutes(240);

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    //Insertando a la BD el resultado final de la lista
                    using (DataTable oDt = Colecciones.ToDataTable<ImportacionComprasXLSE>(oListaCompras))
                    {
                        FilasDevueltas = new ImportacionComprasXLSAD().InsertarComprasXLS(oDt);
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

        //public Int32 ErroresPlanContableXLS(List<ImportacionVentasXLSE> oListaErrores)
        //{
        //    try
        //    {
        //        Int32 FilasDevueltas = Variables.Cero;

        //        foreach (ImportacionVentasXLSE item in oListaErrores)
        //        {
        //            FilasDevueltas += new ImportacionVentasXLSAD().ProcesarLibroImportacionVentasXLS(item.idEmpresa);
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

        public Int32 IntegrarImportacionCompras(List<ImportacionComprasXLSE> oListaImportacionCompras, String Usuario)
        {
            try
            {
                Int32 resp = 0;


                using (TransactionScope oTrans = new TransactionScope())
                {
                    foreach (ImportacionComprasXLSE item in oListaImportacionCompras)
                    {
                        //ImportacionVentasXLSE oListaCuentas = null;
                        ////oListaCuentas = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(item.idEmpresa, Plan, item.Cuenta);

                        //if (oListaCuentas == null)
                        //{
                        ImportacionComprasXLSE oIV = new ImportacionComprasXLSE();

                        oIV.idEmpresa = item.idEmpresa;
                        oIV.idLocal = item.idLocal;
                        oIV.Diario = item.Diario;
                        oIV.numFile = item.numFile;
                        oIV.numCorrelativo = item.numCorrelativo;
                        oIV.fecOperacion = item.fecOperacion;
                        oIV.fecEmision = item.fecEmision;
                        oIV.fecVencimiento = item.fecVencimiento;
                        oIV.idTipo = item.idTipo;
                        oIV.SerieDocumento = item.SerieDocumento;
                        oIV.NumeroDocumento = item.NumeroDocumento;
                        oIV.TipoDocIdentidad = item.TipoDocIdentidad;
                        oIV.NumeroDocIdentidad = item.NumeroDocIdentidad;
                        oIV.RazonSocial = item.RazonSocial;
                        oIV.Glosa = item.Glosa;
                        oIV.Moneda = item.Moneda;
                        oIV.BaseImponibleExportacion = item.BaseImponibleExportacion;
                        oIV.BaseImponibleGravada = item.BaseImponibleGravada;
                        oIV.ImporteTotalExonerada = item.ImporteTotalExonerada;
                        oIV.ImporteTotalInafecto = item.ImporteTotalInafecto;
                        oIV.ISC = item.ISC;
                        oIV.IGV = item.IGV;
                        oIV.OtrosCargos = item.OtrosCargos;
                        oIV.ImporteTotal = item.ImporteTotal;
                        oIV.TipoCambio = item.TipoCambio;
                        oIV.FechaRef = item.FechaRef;
                        oIV.idDocumentoRef = item.idDocumentoRef;
                        oIV.serDocumentoRef = item.serDocumentoRef;
                        oIV.numDocumentoRef = item.numDocumentoRef;
                        oIV.porIgv = item.porIgv;
                        oIV.VTA = item.VTA;
                        oIV.visaEgresos = item.visaEgresos;
                        oIV.masterEgresos = item.masterEgresos;
                        oIV.dinnersEgresos = item.dinnersEgresos;
                        oIV.americaEgresos = item.americaEgresos;
                        oIV.efectivoEgresos = item.efectivoEgresos;
                        oIV.ncEgresos = item.ncEgresos;
                        oIV.DiarioEgresos = item.DiarioEgresos;
                        oIV.numFileEgresos = item.numFileEgresos;
                        oIV.FechaEgresos = item.FechaEgresos;
                        oIV.CuentaEgresos = item.CuentaEgresos;
                        oIV.CentroCostos = item.CentroCostos;
                        oIV.Cuenta1 = item.Cuenta1;
                        oIV.Cuenta2 = item.Cuenta2;
                        oIV.Cuenta3 = item.Cuenta3;
                        oIV.UsuarioModificacion = Usuario;
                        oIV.UsuarioRegistro = Usuario;
                        oIV.FechaRegistro = item.FechaRegistro;
                        oIV.FechaModificacion = item.FechaRegistro;

                        //oIV = new ImportacionComprasXLSLN().InsertarComprasXLS(oIV);


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

        //public Int32 EliminarPlanContableXLS(List<ImportacionVentasXLSE> oListaPorEliminar)
        //{
        //    try
        //    {
        //        Int32 resp = 0;

        //        foreach (ImportacionVentasXLSE item in oListaPorEliminar)
        //        {
        //            resp += new ImportacionVentasXLSE().EliminarPlanContableXLS(item.idEmpresa);
        //        }

        //        return resp;
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
    }
}
