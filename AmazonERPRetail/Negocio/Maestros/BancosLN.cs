using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Maestros;
using AccesoDatos.Maestros;
using Infraestructura.Enumerados;

namespace Negocio.Maestros
{
    public class BancosLN
    {

        public BancosE GrabarBanco(BancosE oBanco, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Insertar:

                            //Insertando persona o auxiliar
                            oBanco.Persona = new PersonaAD().InsertarPersona(oBanco.Persona);
                            oBanco.idPersona = oBanco.Persona.IdPersona;
                            //Insertando el Banco
                            oBanco = new BancosAD().InsertarBancos(oBanco);

                            //Cuentas de los Bancos
                            if (oBanco.ListaCuentas != null)
                            {
                                foreach (BancosCuentasE item in oBanco.ListaCuentas)
                                {
                                    item.idPersona = oBanco.idPersona;
                                    new BancosCuentasAD().InsertarBancosCuentas(item);
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizando la Persona o Auxiliar
                            new PersonaAD().ActualizarPersona(oBanco.Persona);
                            //Actualizando el Banco
                            new BancosAD().ActualizarBancos(oBanco);

                            if (oBanco.ListaCuentas != null)
                            {
                                new BancosCuentasAD().EliminarTodoBancosCuentas(oBanco.idPersona, oBanco.idEmpresa);

                                foreach (BancosCuentasE item in oBanco.ListaCuentas)
                                {
                                    item.idPersona = oBanco.idPersona;
                                    item.idEmpresa = oBanco.idEmpresa;

                                    new BancosCuentasAD().InsertarBancosCuentas(item);
                                }
                            }

                            break;
                        case EnumOpcionGrabar.InsertarSimple:

                            //Actualizando las persona o auxiliar
                            new PersonaAD().ActualizarPersona(oBanco.Persona);
                            oBanco.idPersona = oBanco.Persona.IdPersona;

                            //Insertando el Banco
                            oBanco = new BancosAD().InsertarBancos(oBanco);

                            //Avales
                            if (oBanco.ListaCuentas != null)
                            {
                                foreach (BancosCuentasE item in oBanco.ListaCuentas)
                                {
                                    item.idPersona = oBanco.idPersona;
                                    new BancosCuentasAD().InsertarBancosCuentas(item);
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Eliminar:
                            break;
                        case EnumOpcionGrabar.Anular:
                            break;
                        default:
                            break;
                    }
                     //// NUEVO
                     //if (oBanco.idPersona == 0)
                     //{
                     //    if (oBanco.Persona.IdPersona == 0)
                     //    {
                     //        oBanco.idPersona = (new PersonaAD().InsertarPersona(oBanco.Persona)).IdPersona;
                     //    }
                     //    else
                     //    {
                     //        new PersonaAD().ActualizarPersona(oBanco.Persona);
                     //        oBanco.idPersona = oBanco.Persona.IdPersona;
                     //    }

                    //    new BancosAD().InsertarBancos(oBanco);

                    //    //if (oBanco.ListaCuentas != null)
                    //    //{
                    //    //    foreach (BancosCuentasE itemFrm in oBanco.ListaCuentas)
                    //    //    {
                    //    //        if (itemFrm.idBancosCuentas == 0)
                    //    //        {
                    //    //            itemFrm.idEmpresa = oBanco.idEmpresa;
                    //    //            itemFrm.idPersona = oBanco.idPersona;

                    //    //            new BancosCuentasAD().InsertarBancosCuentas(itemFrm);
                    //    //        }
                    //    //    }
                    //    //}
                    //}
                    //else //ACTUALIZAR
                    //{
                    //    new BancosAD().ActualizarBancos(oBanco);

                    //    // LISTA TABLA SQL
                    //    List<BancosCuentasE> oListaTablaSql = new BancosCuentasAD().ListarBancosCuentas(oBanco.idEmpresa, oBanco.idPersona);

                    //    // TABLA SQL - ITEM                  
                    //    foreach (BancosCuentasE itemTablaSql in oListaTablaSql)
                    //    {
                    //        Boolean EliminarCta = true;

                    //        foreach (BancosCuentasE itemFrm in oBanco.ListaCuentas)
                    //        {
                    //            if (itemTablaSql.codCuenta == itemFrm.codCuenta)
                    //            {
                    //                EliminarCta = false;
                    //                // =======================
                    //                // ACTUALIZA CTA
                    //                // =======================
                    //                itemFrm.UsuarioModificacion = oBanco.UsuarioModificacion;
                    //                new BancosCuentasAD().ActualizarBancosCuentas(itemFrm);
                    //            }
                    //        }
                    //        // =======================
                    //        // ELIMINA CTA
                    //        // =======================
                    //        if (EliminarCta)
                    //        {
                    //            new BancosCuentasAD().EliminarBancosCuentas(itemTablaSql.idPersona, itemTablaSql.idEmpresa, itemTablaSql.idBancosCuentas);
                    //        }
                    //    }

                    //    //ACTUALIZA PERSONA
                    //    new PersonaAD().ActualizarPersona(oBanco.Persona);
                    //}

                    //// =======================
                    //// NUEVO CTA
                    //// =======================
                    //if (oBanco.ListaCuentas != null)
                    //{ 
                    //    foreach (BancosCuentasE itemFrm in oBanco.ListaCuentas)
                    //    {
                    //        if (itemFrm.idBancosCuentas == 0)
                    //        {
                    //            itemFrm.UsuarioRegistro = oBanco.UsuarioRegistro;
                    //            itemFrm.idEmpresa = oBanco.idEmpresa;
                    //            itemFrm.idPersona = oBanco.idPersona;

                    //            new BancosCuentasAD().InsertarBancosCuentas(itemFrm);
                    //        }
                    //    }
                    //}

                    oTrans.Complete();
                }

                return oBanco;
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

        public BancosE InsertarBancos(BancosE bancos)
        {
            try
            {
                return new BancosAD().InsertarBancos(bancos);
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

        public BancosE ActualizarBancos(BancosE bancos)
        {
            try
            {
                return new BancosAD().ActualizarBancos(bancos);
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

        public Int32 EliminarBancos(Int32 idPersona, Int32 idEmpresa)
        {
            try
            {
                int Result = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    Result = new BancosCuentasAD().EliminarTodoBancosCuentas(idPersona, idEmpresa);
                    Result = new BancosAD().EliminarBancos(idPersona, idEmpresa);

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

        public List<BancosE> ListarBancos(Int32 idEmpresa)
        {
            try
            {
                return new BancosAD().ListarBancos(idEmpresa);
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

        public BancosE ObtenerBancos(Int32 idPersona, Int32 idEmpresa)
        {
            try
            {
                return new BancosAD().ObtenerBancos(idPersona, idEmpresa);
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

        public BancosE RecuperarBancoPorRUC(Int32 idEmpresa, string ruc)
        {
            try
            {
                return new BancosAD().RecuperarBancoPorRUC(idEmpresa,ruc);
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

        public BancosE RecuperarBancoPorId(Int32 idPersona, Int32 idEmpresa, String BuscarOtros = "S")
        {
            try
            {
                BancosE oBanco = new BancosAD().ObtenerBancos(idPersona, idEmpresa);

                if (BuscarOtros == "S" && oBanco != null)
                {
                    oBanco.ListaCuentas = new BancosCuentasAD().ListarBancosCuentas(idEmpresa, idPersona);
                    //Persona
                    oBanco.Persona = new PersonaAD().RecuperarPersonaPorID(idPersona);
                }

                return oBanco;
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
