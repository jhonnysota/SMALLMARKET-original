using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Maestros;
using AccesoDatos.Maestros;

namespace Negocio.Maestros
{
    public class PersonaLN
    {

        public Persona InsertarPersona(Persona persona)
        {
            try
            {
                return new PersonaAD().InsertarPersona(persona);
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

        public Persona ActualizarPersona(Persona persona)
        {
            try
            {
                return new PersonaAD().ActualizarPersona(persona);
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

        public Persona RecuperarPersonaPorID(int idPersona, Int32 idEmpresa = 0, String conAvales = "N")
        {
            try
            {
                Persona oPersona = new PersonaAD().RecuperarPersonaPorID(idPersona);

                if (conAvales == "S")
                {
                    oPersona.oListaAvales = new ClienteAvalAD().ListarClienteAval(idEmpresa, idPersona);
                }

                return oPersona;
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

        public Persona RecuperarPersonaPorRUC(int tipoDocumento, string ruc)
        {
            try
            {
                return new PersonaAD().RecuperarPersonaPorRUC(tipoDocumento, ruc);
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

        public Persona RecuperarPersonaPorDNI(String DNI)
        {
            try
            {
                return new PersonaAD().RecuperarPersonaPorDNI(DNI);
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

        public List<Persona> BusquedaPersonaPorTipo(String Tipo, Int32 idEmpresa, String RazonSocial, String nroDocumento, Boolean EsReferente = false)
        {
            try
            {
                return new PersonaAD().BusquedaPersonaPorTipo(Tipo, idEmpresa, RazonSocial, nroDocumento, EsReferente);
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

        public Persona ObtenerPersonaPorNroRuc(String Ruc, Int32 idEmpresa = 0)
        {
            try
            {
                return new PersonaAD().ObtenerPersonaPorNroRuc(Ruc, idEmpresa);
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

        public List<Persona> ListarPersonaPorFiltro(Int32 idEmpresa, String Tipo, String Filtro)
        {
            try
            {
                return new PersonaAD().ListarPersonaPorFiltro(idEmpresa, Tipo, Filtro);
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

        public List<Persona> ListarCorreosTrabajador()
        {
            try
            {
                return new PersonaAD().ListarCorreosTrabajador();
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

        /************************************************************************************************************************/

        public Persona RecuperarPersonaPorNroDocumento(string nroDocumento)
        {
            try
            {
                return new PersonaAD().RecuperarPersonaPorNroDocumento(nroDocumento);
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

        public Persona ValidaNroDocumentoExistente(int tipoDocumento, string nroDocumento, int IdPersona)
        {
            try
            {
                return new PersonaAD().ValidaNroDocumentoExistente(tipoDocumento, nroDocumento, IdPersona);
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

        public Persona ValidaRUCExistente(string RUC)
        {
            try
            {
                return new PersonaAD().ValidaRUCExistente(RUC);
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

        public List<Persona> ListarCarteraClientesPorFiltro(Int32 idEmpresa, String Tipo, String Filtro, Int32 idVendedor)
        {
            try
            {
                return new PersonaAD().ListarCarteraClientesPorFiltro(idEmpresa, Tipo, Filtro, idVendedor);
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

        public List<Persona> ListarPersonasPorTipPer(Int32 idEmpresa, String Tipo, String Filtro, String TipoPersona)
        {
            try
            {
                return new PersonaAD().ListarPersonasPorTipPer(idEmpresa, Tipo, Filtro, TipoPersona);
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


        /****************************** Importacion de Clientes y Proveedores *****************************/
        public Int32 GrabarPersonaMasivo(List<ClienteXLSE> oListaAuxiliares, String Tipo, String Usuario)
        {
            try
            {
                Int32 resp = 0;
                List<Persona> oListaPersona = null;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    foreach (ClienteXLSE item in oListaAuxiliares)
                    {
                        //oPersona = new PersonaAD().ValidaRUCExistente(item.NroDocumento);
                        oListaPersona = new PersonaAD().ListarPersonaPorFiltro(item.idEmpresa, "RU", item.NroDocumento.Trim());

                        if (oListaPersona.Count == 0)
                        {
                            Persona oAuxiliar = new Persona()
                            {
                                TipoPersona = item.TipoPersona,
                                RazonSocial = item.RazonSocial,
                                RUC = item.NroDocumento,
                                ApePaterno = item.ApePaterno,
                                ApeMaterno = item.ApeMaterno,
                                Nombres = item.Nombres,
                                TipoDocumento = item.TipoDocumento,
                                Telefonos = String.Empty,
                                Fax = String.Empty,
                                Correo = String.Empty,
                                Web = String.Empty,
                                DireccionCompleta = item.DireccionCompleta,
                                idPais = item.idPais,
                                idUbigeo = String.Empty,
                                PrincipalContribuyente = false,
                                AgenteRetenedor = false,
                                idCanalVenta = item.idCanalVenta,
                                UsuarioRegistro = Usuario
                            };

                            oAuxiliar = new PersonaAD().InsertarPersona(oAuxiliar);

                            if (Tipo == "C")
                            {
                                ClienteE oCliente = new ClienteE()
                                {
                                    idPersona = oAuxiliar.IdPersona,
                                    idEmpresa = item.idEmpresa,
                                    SiglaComercial = item.RazonSocial,
                                    TipoCliente = 104006,
                                    fecInscripcion = (DateTime?)null,
                                    fecInicioEmpresa = (DateTime?)null,
                                    tipConstitucion = (Int32?)null,
                                    tipRegimen = (Int32?)null,
                                    catCliente = (Int32?)null,
                                    indEstado = false,
                                    fecBaja = (DateTime?)null,
                                    UsuarioRegistro = Usuario
                                };

                                new ClienteAD().InsertarCliente(oCliente);
                            }
                            else
                            {
                                ProveedorE oProveedor = new ProveedorE()
                                {
                                    IdPersona = oAuxiliar.IdPersona,
                                    IdEmpresa = item.idEmpresa,
                                    TipoProveedor = 283001,
                                    SiglaComercial = item.RazonSocial,
                                    fecInscripcion = (DateTime?)null,
                                    fecInicioActividad = (DateTime?)null,
                                    tipConstitucion = (Int32?)null,
                                    tipRegimen = (Int32?)null,
                                    catProveedor = (Int32?)null,
                                    indBaja = "N",
                                    fecBaja = (DateTime?)null,
                                    UsuarioRegistro = Usuario
                                };

                                new ProveedorAD().InsertarProveedor(oProveedor);
                            }
                        }
                        else if (oListaPersona.Count == 1)
                        {
                            if (Tipo == "C" && !oListaPersona[0].Cli)
                            {
                                ClienteE oCliente = new ClienteE()
                                {
                                    idPersona = oListaPersona[0].IdPersona,
                                    idEmpresa = item.idEmpresa,
                                    SiglaComercial = item.RazonSocial,
                                    TipoCliente = 104006,
                                    fecInscripcion = (DateTime?)null,
                                    fecInicioEmpresa = (DateTime?)null,
                                    tipConstitucion = (Int32?)null,
                                    tipRegimen = (Int32?)null,
                                    catCliente = (Int32?)null,
                                    indEstado = false,
                                    fecBaja = (DateTime?)null,
                                    UsuarioRegistro = Usuario
                                };

                                new ClienteAD().InsertarCliente(oCliente);
                            }
                            else if (Tipo == "P" && !oListaPersona[0].Pro)
                            {
                                ProveedorE oProveedor = new ProveedorE()
                                {
                                    IdPersona = oListaPersona[0].IdPersona,
                                    IdEmpresa = item.idEmpresa,
                                    TipoProveedor = 283001,
                                    SiglaComercial = item.RazonSocial,
                                    fecInscripcion = (DateTime?)null,
                                    fecInicioActividad = (DateTime?)null,
                                    tipConstitucion = (Int32?)null,
                                    tipRegimen = (Int32?)null,
                                    catProveedor = (Int32?)null,
                                    indBaja = "N",
                                    fecBaja = (DateTime?)null,
                                    UsuarioRegistro = Usuario
                                };

                                new ProveedorAD().InsertarProveedor(oProveedor);
                            }
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

    }
}
