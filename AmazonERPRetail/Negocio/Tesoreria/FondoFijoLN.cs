using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.Tesoreria;
using AccesoDatos.Tesoreria;
using AccesoDatos.Maestros;
using Infraestructura.Enumerados;
using Entidades.Maestros;

namespace Negocio.Tesoreria
{
    public class FondoFijoLN 
    {

        public FondoFijoE GrabarFondo(FondoFijoE Fondo, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizando las personas
                            new PersonaAD().ActualizarPersona(Fondo.Persona);

                            if (Fondo.TipoFondo == "168")
                            {
                                Fondo.numFondo = Fondo.Persona.RUC;
                            }

                            //Actualizando el Fondo Fijo
                            new FondoFijoAD().ActualizarFondoFijo(Fondo);

                            break;
                        case EnumOpcionGrabar.InsertarSimple:

                            //Actualizando las personas
                            new PersonaAD().ActualizarPersona(Fondo.Persona);
                            Fondo.idPersona = Fondo.Persona.IdPersona;

                            //Insertando el Fondo Fijo
                            if (Fondo.TipoFondo == "102")
                            {
                                String numFondoFijo = new FondoFijoAD().NroFondoFijo(Fondo.idEmpresa, Fondo.idLocal);

                                Fondo.Persona.RUC = Fondo.Persona.NroDocumento = numFondoFijo;
                                Fondo.numFondo = numFondoFijo;
                            }
                            else
                            {
                                Fondo.numFondo = Fondo.Persona.RUC;
                            }

                            Fondo = new FondoFijoAD().InsertarFondoFijo(Fondo);

                            break;
                        case EnumOpcionGrabar.Insertar:

                            if (Fondo.TipoFondo == "102")
                            {
                                String numFondoFijo = new FondoFijoAD().NroFondoFijo(Fondo.idEmpresa, Fondo.idLocal);

                                Fondo.Persona.RUC = Fondo.Persona.NroDocumento = numFondoFijo;
                                Fondo.numFondo = numFondoFijo;
                            }
                            else
                            {
                                Fondo.numFondo = Fondo.Persona.RUC;
                            }

                            Persona VerPersona = new PersonaAD().RecuperarPersonaPorID(Fondo.idPersonaResponsable.Value);


                            if (VerPersona == null)
                            {
                                Fondo.Persona = new PersonaAD().InsertarPersona(Fondo.Persona);
                            }
                            else
                            {
                                Fondo.Persona = VerPersona;
                                new PersonaAD().ActualizarPersona(Fondo.Persona);
                                Fondo.idPersona = Fondo.Persona.IdPersona;
                            }                     
                         
                           

                            //Insertando el Fondo Fijo
                            Fondo = new FondoFijoAD().InsertarFondoFijo(Fondo);

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return Fondo;
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

        public FondoFijoE InsertarFondoFijo(FondoFijoE fondofijo)
        {
            try
            {
                return new FondoFijoAD().InsertarFondoFijo(fondofijo);
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

        public FondoFijoE ActualizarFondoFijo(FondoFijoE fondofijo)
        {
            try
            {
                return new FondoFijoAD().ActualizarFondoFijo(fondofijo);
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

        public int EliminarFondoFijo(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            try
            {
                return new FondoFijoAD().EliminarFondoFijo(idEmpresa, idLocal, idPersona);
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

        public List<FondoFijoE> ListarFondoFijo(Int32 idEmpresa, Int32 idLocal, String TipoFondo)
        {
            try
            {
                return new FondoFijoAD().ListarFondoFijo(idEmpresa, idLocal, TipoFondo);
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

        public FondoFijoE ObtenerFondoFijo(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            try
            {
                return new FondoFijoAD().ObtenerFondoFijo(idEmpresa, idLocal, idPersona);
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

        public List<FondoFijoE> FondoFijoCuentas(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, Int32 idBanco = 0)
        {
            try
            {
                List <FondoFijoE> oListaFondo = new FondoFijoAD().FondoFijoCuentas(idEmpresa, idLocal, idPersona);
                List<FondoFijoE> oListadevuelta = new List<FondoFijoE>();

                if (idBanco > 0)
                {
                    oListaFondo = (from x in oListaFondo where x.idPersonaBanco == idBanco select x).ToList();
                }

                if (oListaFondo != null)
                {
                    foreach (FondoFijoE item in oListaFondo)
                    {
                        FondoFijoE oFondoTemp = new FondoFijoE();

                        if (!String.IsNullOrWhiteSpace(item.numCuenta))
                        {
                            oFondoTemp.idPersonaBanco = item.idPersonaBanco;
                            oFondoTemp.tipCuenta = item.tipCuenta;
                            oFondoTemp.idMonedaCuenta = item.idMonedaCuenta;
                            oFondoTemp.desCuenta = "CTA.        " + item.numCuenta;
                            oFondoTemp.numCuenta = item.numCuenta;

                            oListadevuelta.Add(oFondoTemp);
                        }

                        if (!String.IsNullOrWhiteSpace(item.numInterbancaria))
                        {
                            oFondoTemp = new FondoFijoE();
                            oFondoTemp.idPersonaBanco = item.idPersonaBanco;
                            oFondoTemp.tipCuenta = item.tipCuenta;
                            oFondoTemp.idMonedaCuenta = item.idMonedaCuenta;
                            oFondoTemp.desCuenta = "CTA.INT. " + item.numInterbancaria;
                            oFondoTemp.numCuenta = item.numInterbancaria;

                            oListadevuelta.Add(oFondoTemp);
                        } 
                    }
                }

                return oListadevuelta;
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

        public int FondoFijoPorTipoFondoResp(Int32 idEmpresa, Int32 idLocal, String TipoFondo, Int32 idPersonaResponsable)
        {
            try
            {
                return new FondoFijoAD().FondoFijoPorTipoFondoResp(idEmpresa, idLocal, TipoFondo, idPersonaResponsable);
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

        public List<FondoFijoE> ListarFondoFijoPorResponsable(Int32 idEmpresa, Int32 idLocal, Int32 idPersonaResponsable)
        {
            try
            {
                return new FondoFijoAD().ListarFondoFijoPorResponsable(idEmpresa, idLocal, idPersonaResponsable);
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
