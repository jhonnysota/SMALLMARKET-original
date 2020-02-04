using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using System.Transactions;
using Entidades.Maestros;
using AccesoDatos.Maestros;

namespace Negocio.Contabilidad
{
    public class ErrorImportGeneralLN
    {

        public ErrorImportGeneralE InsertarErrorImportGeneral(ErrorImportGeneralE errorimportgeneral)
        {
            try
            {
                return new ErrorImportGeneralAD().InsertarErrorImportGeneral(errorimportgeneral);
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

        public int EliminarErrorImportGeneral(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, String Archivo)
        {
            try
            {
                return new ErrorImportGeneralAD().EliminarErrorImportGeneral(idEmpresa, idLocal, idUsuario, Archivo);
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

        public List<ErrorImportGeneralE> ListarErrorImportGeneral(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, String Archivo)
        {
            try
            {
                return new ErrorImportGeneralAD().ListarErrorImportGeneral(idEmpresa, idLocal, idUsuario, Archivo);
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

        public int CrearAuxiliares(List<ErrorImportGeneralE> ListaClientesErrores, String Usuario)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                { 
                    foreach (ErrorImportGeneralE item in ListaClientesErrores)
                    {
                        Persona oPersona = new Persona()
                        {
                            TipoPersona = 102001,
                            RazonSocial = item.RazonSocial,
                            RUC = item.ValorCampo,
                            ApePaterno = String.Empty,
                            ApeMaterno = String.Empty,
                            Nombres = String.Empty,
                            TipoDocumento = 101004,
                            NroDocumento = item.ValorCampo,
                            PrincipalContribuyente = false,
                            AgenteRetenedor = false,
                            UsuarioRegistro = Usuario
                        };

                        oPersona = new PersonaAD().InsertarPersona(oPersona);

                        ClienteE oCliente = new ClienteE()
                        {
                            idPersona = oPersona.IdPersona,
                            idEmpresa = item.idEmpresa,
                            SiglaComercial = item.RazonSocial,
                            TipoCliente = 104006,
                            indEstado = false,
                            UsuarioRegistro = Usuario
                        };

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

    }
}
