using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura;

namespace Negocio.Contabilidad
{
    public class conCtaCteItemLN //: BaseLN
    {
        public conCtaCteItemE InsertarConCtaCteItem(conCtaCteItemE ctacteitem)
        {
            try
            {
                return new conCtaCteItemAD().InsertarConCtaCteItem(ctacteitem);
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

        public conCtaCteItemE ActualizarConCtaCteItem(conCtaCteItemE ctacteitem)
        {
            try
            {
                return new conCtaCteItemAD().ActualizarConCtaCteItem(ctacteitem);
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

        public Int32 EliminarConCtaCteItem(Int32 idCtaCte, Int32 idCtaCteItem)
        {
            try
            {
                return new conCtaCteItemAD().EliminarConCtaCteItem(idCtaCte, idCtaCteItem);
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

        public List<conCtaCteItemE> ListarConCtaCteItemPorCodigo(Int32 idCtaCte)
        {
            try
            {
                return new conCtaCteItemAD().ListarConCtaCteItemPorCodigo(idCtaCte);
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

        public conCtaCteItemE ObtenerConCtaCteItem(Int32 idCtaCte, Int32 idCtaCteItem)
        {
            try
            {
                return new conCtaCteItemAD().ObtenerConCtaCteItem(idCtaCte, idCtaCteItem);
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

        public List<conCtaCteItemE> ListarConCtaCtePendientes(Int32 idEmpresa, String numVerPlanCuentas, String codCuenta, Int32 idPersona, DateTime fecFiltro)
        {
            try
            {
                //conCtaCteItemE ItemTmp = null;
                List<conCtaCteItemE> oListaCtaCtePendientes = new conCtaCteItemAD().ListarConCtaCtePendientes(idEmpresa, numVerPlanCuentas, codCuenta, idPersona, fecFiltro);

                //foreach (conCtaCteItemE item in oListaCtaCtePendientes)
                //{
                //    ItemTmp = new conCtaCteItemAD().RecuperarNaturalezaCargoCtaCte(item.idCtaCte, item.idDocumento, item.serDocumento, item.numDocumento);

                //    if (ItemTmp.indDebeHaber == Variables.ValorDebe)
                //    {
                //        item.indDebeHaber = Variables.ValorHaber;
                //    }
                //    else
                //    {
                //        item.indDebeHaber = Variables.ValorDebe;
                //    }
                //}

                foreach (conCtaCteItemE item in oListaCtaCtePendientes)
                {
                    if (item.SaldoSoles > Variables.Cero && item.SaldoDolares > 0)
                    {
                        if (item.indDebeHaber == Variables.Debe)
                        {
                            item.indDebeHaber = Variables.Haber;
                        }
                        else
                        {
                            item.indDebeHaber = Variables.Debe;
                        }    
                    }
                }

                return oListaCtaCtePendientes; // new conCtaCteItemAD().ListarConCtaCtePendientes(idEmpresa, numVerPlanCuentas, codCuenta, idPersona, fecFiltro);
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
