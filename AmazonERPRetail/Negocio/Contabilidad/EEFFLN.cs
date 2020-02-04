using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;

namespace Negocio.Contabilidad
{
    public class EEFFLN
    {

        public EEFFE GuardarEEFF(EEFFE entidad)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    // LISTA ACTUAL FRM
                    List<EEFFItemE> oListaFormulario = entidad.ListaEEFFItem;
                    
                    // =======================
                    // NUEVO REGISTRO
                    // =======================
                    if (entidad.idEEFF == 0)
                    {
                       Int32 idEEFF = new EEFFAD().MaxIdConEEFF(entidad.idEmpresa);

                       entidad.idEEFF = idEEFF;

                       EEFFE entidad_ = new EEFFAD().InsertarEEFF(entidad);

                    }                    
                    else {
                        // =======================
                        // ACTUALIZAR EEFF
                        // =======================
                        new EEFFAD().ActualizarEEFF(entidad);

                        // LISTA TABLA SQL
                        List<EEFFItemE> oListaTablaSql = new EEFFItemAD().ListarEEFFItem(entidad.idEmpresa, entidad.idEEFF);

                        
                        // TABLA SQL - ITEM                  
                        foreach (EEFFItemE itemTablaSql in oListaTablaSql) {
                        
                            Boolean EliminarItem = true;

                            foreach (EEFFItemE itemFrm in oListaFormulario)
                            {
                                //  if (itemTablaSql.secItem == itemFrm.secItem){
                                if (itemTablaSql.idEEFFItem == itemFrm.idEEFFItem)
                                {
                                    EliminarItem = false;

                                    // =======================
                                    // ACTUALIZA ITEM
                                    // =======================
                                    itemFrm.UsuarioModificacion = entidad.UsuarioModificacion;
                                    itemFrm.secItem = itemFrm.secItem;

                                    new EEFFItemAD().ActualizarEEFFItem(itemFrm);

                                    #region CTA FOR

                                    // =======================
                                    // ACTUALIZA ITEM CTA
                                    // =======================

                                    if (itemFrm.ListaEEFFItemCta != null) {

                                        // LISTA TABLA SQL  CTA
                                        List<EEFFItemCtaE> oListaTablaSqlCta = new EEFFItemCtaAD().ListarEEFFItemCta(itemFrm.idEmpresa, itemFrm.idEEFF, itemFrm.idEEFFItem, 0, "", "");
                                        
                                        //COMPARAMOS - LISTA SQL vs LISTA FRM 
                                        foreach (EEFFItemCtaE itemTablaSqlCta in oListaTablaSqlCta)
                                        {
                                            Boolean EliminarCta = true;
                                            foreach (EEFFItemCtaE itemFrmCta in itemFrm.ListaEEFFItemCta)
                                            {
                                                if (itemTablaSqlCta.CodPlaCta == itemFrmCta.CodPlaCta)
                                                {
                                                    EliminarCta = false;

                                                    // =======================
                                                    // ACTUALIZA CTA
                                                    // =======================
                                                    itemFrmCta.UsuarioModificacion = entidad.UsuarioModificacion;
                                                    new EEFFItemCtaAD().ActualizarEEFFItemCta(itemFrmCta);
                                                }
                                            }
                                            // =======================
                                            // ELIMINA CTA
                                            // =======================
                                            if (EliminarCta)
                                            {
                                                new EEFFItemCtaAD().EliminarEEFFItemCta(itemTablaSqlCta.idEmpresa, itemTablaSqlCta.idEEFF, itemTablaSqlCta.idEEFFItem, itemTablaSqlCta.idEEFFItemCta);
                                            }
                                        }
                                        // =======================
                                        // NUEVO ITEM CTA
                                        // =======================
                                        foreach (EEFFItemCtaE itemFrmCta in itemFrm.ListaEEFFItemCta)
                                        {
                                            if (itemFrmCta.idEEFFItemCta == 0)
                                            {
                                                itemFrmCta.UsuarioRegistro = itemFrm.UsuarioRegistro;

                                                itemFrmCta.idEmpresa = itemFrm.idEmpresa;
                                                itemFrmCta.idEEFF = itemFrm.idEEFF;
                                                itemFrmCta.idEEFFItem = itemFrm.idEEFFItem;

                                                Int32 idEEFFItemCta = new EEFFItemCtaAD().MaxIdConEEFFItemCta(itemFrmCta.idEmpresa, itemFrmCta.idEEFF, itemFrmCta.idEEFFItem);

                                                itemFrmCta.idEEFFItemCta = idEEFFItemCta;

                                                new EEFFItemCtaAD().InsertarEEFFItemCta(itemFrmCta);
                                            }
                                        }                                        
                                    }

                                    #endregion 

                                    #region FOR

                                    // =======================
                                    // ACTUALIZA FOR
                                    // =======================
                                    if (itemFrm.ListaEEFFItemFor != null)
                                    {

                                        // LISTA TABLA SQL  FOR
                                        List<EEFFItemForE> oListaTablaSqlFor = new EEFFItemForAD().ListarEEFFItemFor(itemFrm.idEmpresa, itemFrm.idEEFF, itemFrm.idEEFFItem);

                                        foreach (EEFFItemForE itemTablaSqlFor in oListaTablaSqlFor)
                                        {
                                            Boolean EliminarFor = true;
                                            foreach (EEFFItemForE itemFrmFor in itemFrm.ListaEEFFItemFor)
                                            {
                                                if (itemTablaSqlFor.secItem == itemFrmFor.secItem)
                                                //if (itemTablaSqlFor.idEEFFItem == itemFrmFor.idEEFFItem)
                                                {
                                                    EliminarFor = false;

                                                    // =======================
                                                    // ACTUALIZA FOR
                                                    // =======================
                                                    itemFrmFor.UsuarioModificacion = entidad.UsuarioModificacion;
                                                    new EEFFItemForAD().ActualizarEEFFItemFor(itemFrmFor);
                                                }
                                            }
                                            // =======================
                                            // ELIMINA FOR
                                            // =======================
                                            if (EliminarFor)
                                            {
                                                new EEFFItemForAD().EliminarEEFFItemFor(itemTablaSqlFor.idEMPRESA, itemTablaSqlFor.idEEFF, itemTablaSqlFor.idEEFFItem, itemTablaSqlFor.idEEFFItemFor);
                                            }
                                        }
                                        // =======================
                                        // NUEVO FOR
                                        // =======================
                                        foreach (EEFFItemForE itemFrmFor in itemFrm.ListaEEFFItemFor)
                                        {
                                            if (itemFrmFor.idEEFFItemFor == 0)
                                            {
                                                itemFrmFor.UsuarioRegistro = itemFrm.UsuarioRegistro;

                                                itemFrmFor.idEMPRESA = itemFrm.idEmpresa;
                                                itemFrmFor.idEEFF = itemFrm.idEEFF;
                                                itemFrmFor.idEEFFItem = itemFrm.idEEFFItem;

                                                Int32 idEEFFItemFor = new EEFFItemForAD().MaxIdConEEFFItemFor(itemFrmFor.idEMPRESA, itemFrmFor.idEEFF, itemFrmFor.idEEFFItem);

                                                itemFrmFor.idEEFFItemFor = idEEFFItemFor;

                                                new EEFFItemForAD().InsertarEEFFItemFor(itemFrmFor);
                                            }
                                        }
                                        // ============================
                                    }

                                    #endregion

                                    #region XLS

                                    // =======================
                                    // ACTUALIZA ITEM XLS
                                    // =======================

                                    if (itemFrm.ListaEEFFItemXls != null)
                                    {

                                        // LISTA TABLA SQL  CTA
                                        List<EEFFItemXlsE> oListaTablaSqlXls = new EEFFItemXlsAD().ListarEEFFItemXls(itemFrm.idEmpresa, itemFrm.idEEFF, itemFrm.idEEFFItem);

                                        //COMPARAMOS - LISTA SQL vs LISTA FRM 
                                        foreach (EEFFItemXlsE itemTablaSqlXls in oListaTablaSqlXls)
                                        {
                                            Boolean EliminarXls = true;
                                            foreach (EEFFItemXlsE itemFrmXls in itemFrm.ListaEEFFItemXls)
                                            {
                                                if (itemTablaSqlXls.codcCostos == itemFrmXls.codcCostos)
                                                {
                                                    EliminarXls = false;

                                                    // =======================
                                                    // ACTUALIZA XLS
                                                    // =======================
                                                    itemFrmXls.UsuarioModificacion = entidad.UsuarioModificacion;
                                                    new EEFFItemXlsAD().ActualizarEEFFItemXls(itemFrmXls);
                                                }
                                            }
                                            // =======================
                                            // ELIMINA XLS
                                            // =======================
                                            if (EliminarXls)
                                            {
                                                new EEFFItemXlsAD().EliminarEEFFItemXls(itemTablaSqlXls.idEMPRESA, itemTablaSqlXls.idEEFF, itemTablaSqlXls.idEEFFItem, itemTablaSqlXls.idEEFFItemXls);
                                            }
                                        }
                                        // =======================
                                        // NUEVO ITEM XLS
                                        // =======================
                                        foreach (EEFFItemXlsE itemFrmXls in itemFrm.ListaEEFFItemXls)
                                        {
                                            if (itemFrmXls.idEEFFItemXls == 0)
                                            {
                                                itemFrmXls.UsuarioRegistro = itemFrm.UsuarioRegistro;

                                                itemFrmXls.idEMPRESA = itemFrm.idEmpresa;
                                                itemFrmXls.idEEFF = itemFrm.idEEFF;
                                                itemFrmXls.idEEFFItem = itemFrm.idEEFFItem;

                                                Int32 idEEFFItemXls = new EEFFItemXlsAD().MaxIdConEEFFItemXls(itemFrmXls.idEMPRESA, itemFrmXls.idEEFF, itemFrmXls.idEEFFItem);

                                                itemFrmXls.idEEFFItemXls = idEEFFItemXls;

                                                new EEFFItemXlsAD().InsertarEEFFItemXls(itemFrmXls);
                                            }
                                        }
                                    }

                                    #endregion 
                                }
                            }
                            // =======================
                            // ELIMINA ITEM
                            // =======================
                            if (EliminarItem)
                            {
                                new EEFFItemAD().EliminarEEFFItem(itemTablaSql.idEmpresa, itemTablaSql.idEEFF, itemTablaSql.idEEFFItem);
                            }
                        }
                        
                    }

                    // =======================
                    // NUEVO ITEM
                    // =======================
                    if (oListaFormulario != null) 
                    { 
                        foreach (EEFFItemE itemFrm in oListaFormulario)
                        {
                            if (itemFrm.idEEFFItem == 0)
                            {
                                itemFrm.UsuarioRegistro = entidad.UsuarioRegistro;

                                itemFrm.idEmpresa = entidad.idEmpresa;
                                itemFrm.idEEFF = entidad.idEEFF;
                                itemFrm.secItem = Convert.ToInt32(itemFrm.secItem).ToString("00000");

                                Int32 idEEFFItem = new EEFFItemAD().MaxIdConEEFFItem(entidad.idEmpresa,entidad.idEEFF);

                                itemFrm.idEEFFItem = idEEFFItem;

                                EEFFItemE oItem_ = new EEFFItemAD().InsertarEEFFItem(itemFrm);

                                //itemFrm.idEEFFItem = oItem_.idEEFFItem;

                                #region CTA 
                                
                                // =======================
                                // NUEVO ITEM CTA
                                // =======================

                                if (itemFrm.ListaEEFFItemCta != null)
                                {
                                    foreach (EEFFItemCtaE itemFrmCta in itemFrm.ListaEEFFItemCta)
                                    {
                                        if (itemFrmCta.idEEFFItemCta == 0)
                                        {
                                            itemFrmCta.UsuarioRegistro = itemFrm.UsuarioRegistro;

                                            itemFrmCta.idEmpresa = itemFrm.idEmpresa;
                                            itemFrmCta.idEEFF = itemFrm.idEEFF;
                                            itemFrmCta.idEEFFItem = itemFrm.idEEFFItem;

                                            Int32 idEEFFItemCta = new EEFFItemCtaAD().MaxIdConEEFFItemCta(itemFrmCta.idEmpresa, itemFrmCta.idEEFF,itemFrmCta.idEEFFItem );

                                            itemFrmCta.idEEFFItemCta = idEEFFItemCta;

                                            new EEFFItemCtaAD().InsertarEEFFItemCta(itemFrmCta);
                                        }
                                    }
                                }
                                #endregion 

                                #region FOR

                                // =======================
                                // NUEVO ITEM FOR
                                // =======================

                                if (itemFrm.ListaEEFFItemFor != null)
                                {
                                    foreach (EEFFItemForE itemFrmFor in itemFrm.ListaEEFFItemFor)
                                    {
                                        if (itemFrmFor.idEEFFItemFor == 0)
                                        {
                                            itemFrmFor.UsuarioRegistro = itemFrm.UsuarioRegistro;

                                            itemFrmFor.idEMPRESA = itemFrm.idEmpresa;
                                            itemFrmFor.idEEFF = itemFrm.idEEFF;
                                            itemFrmFor.idEEFFItem = itemFrm.idEEFFItem;

                                            new EEFFItemForAD().InsertarEEFFItemFor(itemFrmFor);
                                        }
                                    }
                                }
                                
                                #endregion

                                #region XLS

                                // =======================
                                // NUEVO ITEM XLS
                                // =======================

                                if (itemFrm.ListaEEFFItemXls != null)
                                {
                                    foreach (EEFFItemXlsE itemFrmXls in itemFrm.ListaEEFFItemXls)
                                    {
                                        if (itemFrmXls.idEEFFItemXls == 0)
                                        {
                                            itemFrmXls.UsuarioRegistro = itemFrm.UsuarioRegistro;

                                            itemFrmXls.idEMPRESA = itemFrm.idEmpresa;
                                            itemFrmXls.idEEFF = itemFrm.idEEFF;
                                            itemFrmXls.idEEFFItem = itemFrm.idEEFFItem;

                                            new EEFFItemXlsAD().InsertarEEFFItemXls(itemFrmXls);
                                        }
                                    }
                                }

                                #endregion
                            }
                        }
                    }

                    // COMPLETE
                    oTrans.Complete();
                }

                return entidad;
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

        public EEFFE InsertarEEFF(EEFFE entidad)
        {
            try
            {
                return new EEFFAD().InsertarEEFF(entidad);
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

        public EEFFE ActualizarEEFF(EEFFE periodos)
        {
            try
            {
                return new EEFFAD().ActualizarEEFF(periodos);
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

        public List<EEFFE> ListarEEFF(int idEmpresa, int idEEFF, string desSeccion, Boolean VerReporte)
        {
            try
            {
                return new EEFFAD().ListarEEFF(idEmpresa, idEEFF, desSeccion, VerReporte);
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

        public List<EEFFE> ListarEEFFParaPres(int idEmpresa)
        {
            try
            {
                return new EEFFAD().ListarEEFFParaPres(idEmpresa);
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

        public Int32 EliminarDetalleEEFF(int idEmpresa, int idEEFF)
        {
            try
            {
                Int32 Result=-1;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    Result=new EEFFItemAD().EliminarDetalleEEFFItem(idEmpresa, idEEFF);

                    Result=new EEFFAD().EliminarEEFF(idEmpresa, idEEFF);

                    oTrans.Complete();
                }

                return Result;
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

        public EEFFE ObtenerEEFFCompleto(int idEmpresa, int idEEFF)
        {
            try
            {
                //Cabecera
                EEFFE Entidad = new EEFFAD().ObtenerEEFF(idEmpresa, idEEFF);

                //Detalle
                Entidad.ListaEEFFItem = new EEFFItemAD().ListarEEFFItem(idEmpresa, idEEFF);

                return Entidad;
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

        public List<EEFFE> ListarBalanceGeneral(Int32 idEmpresa, String TipoSeccion, String AnioPeriodo, String MesPeriodo)
        {
            try
            {
                return new EEFFAD().ListarBalanceGeneral(idEmpresa, TipoSeccion, AnioPeriodo,MesPeriodo);
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

        public List<EEFFE> ListarBalanceGeneralResumen(Int32 idEmpresa, String VerPlanCuenta, Int32 TipoSeccion, String AnioPeriodo, String MesPeriodo)
        {
            try
            {
                return new EEFFAD().ListarBalanceGeneralResumen(idEmpresa, VerPlanCuenta, TipoSeccion, AnioPeriodo, MesPeriodo);
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
