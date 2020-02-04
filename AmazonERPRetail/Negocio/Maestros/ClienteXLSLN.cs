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
    public class ClienteXLSLN
    {
        public Int32 InsertarClienteXLS(List<ClienteXLSE> oListaCliente)
        {
            try
            {
                Int32 FilasDevueltas = Variables.Cero;

                TransactionOptions Opciones = new TransactionOptions();
                Opciones.Timeout = TimeSpan.FromMinutes(240);

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    //Insertando a la BD el resultado final de la lista
                    using (DataTable oDt = Colecciones.ToDataTable<ClienteXLSE>(oListaCliente))
                    {
                        FilasDevueltas = new ClienteXLSAD().InsertarClienteXLS(oDt);
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

        public Int32 ErroresClienteXLS(List<ClienteXLSE> oListaErrores)
        {
            try
            {
                Int32 FilasDevueltas = Variables.Cero;

                foreach (ClienteXLSE item in oListaErrores)
                {
                    FilasDevueltas += new ClienteXLSAD().ProcesarClienteXLS(item.idEmpresa);
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

        public Int32 IntegrarClienteXLS(List<ClienteXLSE> oListaAuxiliares, String Tipo, String Usuario)
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
                            Persona oAuxiliar = new Persona();

                            oAuxiliar.TipoPersona = item.TipoPersona;

                            if (item.TipoPersona == 102002 || item.TipoPersona == 102003)
                            {                             
                                oAuxiliar.RazonSocial = item.ApePaterno + " " + item.ApeMaterno + " " + item.Nombres;
                            }
                            else
                            {
                                oAuxiliar.RazonSocial = item.RazonSocial;
                            }

                            oAuxiliar.RUC = item.NroDocumento;
                            oAuxiliar.ApePaterno = item.ApePaterno;
                            oAuxiliar.ApeMaterno = item.ApeMaterno;
                            oAuxiliar.Nombres = item.Nombres;
                            //jurica natura o naturalruc
                            oAuxiliar.TipoDocumento = item.TipoDocumento;
                            if (item.TipoDocumento == 101001 )//DNI
                            {
                                oAuxiliar.NroDocumento = item.NroDocumento;
                            }
                            else if(item.TipoDocumento == 101004)//RUC
                            {
                                oAuxiliar.NroDocumento = oAuxiliar.RUC;
                            }
                            else if(item.TipoDocumento == 101002 || item.TipoDocumento == 101005)//OTROS
                            {
                                oAuxiliar.NroDocumento = item.NroDocumento;
                            }                           

                            oAuxiliar.Telefonos = String.Empty;
                            oAuxiliar.Fax = String.Empty;
                            oAuxiliar.Correo = String.Empty;
                            oAuxiliar.Web = String.Empty;
                            oAuxiliar.DireccionCompleta = item.DireccionCompleta;
                            oAuxiliar.idPais = item.idPais;
                            oAuxiliar.idUbigeo = String.Empty;
                            oAuxiliar.PrincipalContribuyente = false;
                            oAuxiliar.AgenteRetenedor = false;
                            oAuxiliar.idCanalVenta = item.idCanalVenta;
                            oAuxiliar.UsuarioRegistro = Usuario;

                            oAuxiliar = new PersonaAD().InsertarPersona(oAuxiliar);

                            if (Tipo == "C")
                            {
                                ClienteE oCliente = new ClienteE()
                                {
                                    idPersona = oAuxiliar.IdPersona,
                                    idEmpresa = item.idEmpresa,
                                    SiglaComercial = item.ApePaterno + " " + item.ApeMaterno + " " + item.Nombres ,
                                    TipoCliente = 104006,
                                    fecInscripcion = (DateTime?)null,
                                    fecInicioEmpresa = (DateTime?)null,
                                    tipConstitucion = 0,
                                    tipRegimen = 0,
                                    catCliente = 0,
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
                                    SiglaComercial = item.ApePaterno + " " + item.ApeMaterno + " " + item.Nombres,
                                    TipoCliente = 104006,
                                    fecInscripcion = (DateTime?)null,
                                    fecInicioEmpresa = (DateTime?)null,
                                    tipConstitucion = 0,
                                    tipRegimen = 0,
                                    catCliente = 0,
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

        public Int32 EliminarClienteXLS(List<ClienteXLSE> oListaPorEliminar)
        {
            try
            {
                Int32 resp = 0;

                foreach (ClienteXLSE item in oListaPorEliminar)
                {
                    resp += new ClienteXLSAD().EliminarClienteXLS(item.idEmpresa);
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
