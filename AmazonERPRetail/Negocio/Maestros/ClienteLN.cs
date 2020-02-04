using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Maestros;
using AccesoDatos.Ventas;
using Infraestructura.Enumerados;
using Entidades.Generales;
using AccesoDatos.Generales;
using AccesoDatos.Maestros;

namespace Negocio.Maestros
{
    public class ClienteLN
    {

        public ClienteE GrabarCliente(ClienteE Cliente, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizando las personas
                            new PersonaAD().ActualizarPersona(Cliente.Persona);
                            //Actualizando el Cliente
                            new ClienteAD().ActualizarCliente(Cliente);

                            //Sucursales
                            if (Cliente.Persona.ListaPersonaDireccion != null && Cliente.Persona.ListaPersonaDireccion.Count > 0)
                            {
                                foreach (PersonaDireccionE oitem in Cliente.Persona.ListaPersonaDireccion)
                                {
                                    oitem.IdPersona = Cliente.Persona.IdPersona;

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new PersonaDireccionAD().InsertarPersonaDireccion(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new PersonaDireccionAD().ActualizarPersonaDireccion(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Eliminar:
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            if (Cliente.ListaClienteAsociados != null && Cliente.ListaClienteAsociados.Count > 0 && Cliente.TipoCliente == 104010)
                            {
                                foreach (ClienteAsociadosE oitem in Cliente.ListaClienteAsociados)
                                {
                                    oitem.idPersona = Cliente.idPersona;
                                    oitem.IdEmpresa = Cliente.idEmpresa;

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new ClienteAsociadosAD().InsertarClienteAsociados(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new ClienteAsociadosAD().ActualizarClienteAsociados(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Eliminar:
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            if (Cliente.ListaAvales != null && Cliente.ListaAvales.Count > 0)
                            {
                                Int32 Corre = 1;
                                new ClienteAvalAD().EliminarClienteAval(Cliente.idEmpresa, Cliente.idPersona);

                                foreach (ClienteAvalE item in Cliente.ListaAvales)
                                {
                                    item.idPersona = Cliente.idPersona;
                                    item.idAval = Corre;
                                    new ClienteAvalAD().InsertarClienteAval(item);
                                    Corre++;
                                }
                            }

                            break;
                        case EnumOpcionGrabar.InsertarSimple:

                            //Actualizando las personas
                            new PersonaAD().ActualizarPersona(Cliente.Persona);
                            Cliente.idPersona = Cliente.Persona.IdPersona;

                            //Insertando el Cliente
                            Cliente = new ClienteAD().InsertarCliente(Cliente);

                            //Sucursales
                            if (Cliente.Persona.ListaPersonaDireccion != null && Cliente.Persona.ListaPersonaDireccion.Count > 0)
                            {
                                foreach (PersonaDireccionE oitem in Cliente.Persona.ListaPersonaDireccion)
                                {
                                    oitem.IdPersona = Cliente.Persona.IdPersona;
                                    new PersonaDireccionAD().InsertarPersonaDireccion(oitem);
                                }
                            }

                            //Avales
                            if (Cliente.ListaAvales != null && Cliente.ListaAvales.Count > 0)
                            {
                                foreach (ClienteAvalE item in Cliente.ListaAvales)
                                {
                                    item.idPersona = Cliente.idPersona;
                                    new ClienteAvalAD().InsertarClienteAval(item);
                                }
                            }

                            if (Cliente.ListaClienteAsociados != null && Cliente.ListaClienteAsociados.Count > 0 && Cliente.TipoCliente == 104010)
                            {
                                foreach (ClienteAsociadosE oitem in Cliente.ListaClienteAsociados)
                                {
                                    oitem.idPersona = Cliente.idPersona;
                                    oitem.IdEmpresa = Cliente.idEmpresa;
                                    new ClienteAsociadosAD().InsertarClienteAsociados(oitem);
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Insertar:

                            //Insertando personas
                            Cliente.Persona = new PersonaAD().InsertarPersona(Cliente.Persona);
                            Cliente.idPersona = Cliente.Persona.IdPersona;
                            //Insertando el Cliente
                            Cliente = new ClienteAD().InsertarCliente(Cliente);

                            //Sucursales
                            if (Cliente.Persona.ListaPersonaDireccion != null && Cliente.Persona.ListaPersonaDireccion.Count > 0)
                            {
                                foreach (PersonaDireccionE oitem in Cliente.Persona.ListaPersonaDireccion)
                                {
                                    oitem.IdPersona = Cliente.Persona.IdPersona;
                                    new PersonaDireccionAD().InsertarPersonaDireccion(oitem);
                                }
                            }

                            //Avales
                            if (Cliente.ListaAvales != null && Cliente.ListaAvales.Count > 0)
                            {
                                foreach (ClienteAvalE item in Cliente.ListaAvales)
                                {
                                    item.idPersona = Cliente.idPersona;
                                    new ClienteAvalAD().InsertarClienteAval(item);
                                }
                            }

                            //Clientes Asociados - Referentes
                            if (Cliente.ListaClienteAsociados != null && Cliente.ListaClienteAsociados.Count > 0 && Cliente.TipoCliente == 104010)
                            {
                                foreach (ClienteAsociadosE oitem in Cliente.ListaClienteAsociados)
                                {
                                    oitem.idPersona = Cliente.idPersona;
                                    oitem.IdEmpresa = Cliente.idEmpresa;
                                    new ClienteAsociadosAD().InsertarClienteAsociados(oitem);
                                }
                            } 

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return Cliente;
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

        public ClienteE InsertarCliente(ClienteE cliente)
        {
            try
            {
                return new ClienteAD().InsertarCliente(cliente);
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

        public ClienteE ActualizarCliente(ClienteE cliente)
        {
            try
            {
                return new ClienteAD().ActualizarCliente(cliente);
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

        public List<ClienteE> BuscarClientes(Int32 idEmpresa, String RazonSocial, String NroDocumento, Int32 TipoCliente)
        {
            try
            {
                return new ClienteAD().BuscarClientes(idEmpresa, RazonSocial, NroDocumento, TipoCliente);
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

        public Int32 AnularCliente(Int32 idPersona, Int32 idEmpresa, Boolean indBaja, String UsuarioModificacion)
        {
            try
            {
                return new ClienteAD().AnularCliente(idPersona, idEmpresa, indBaja, UsuarioModificacion);
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

        public Int32 EliminarCliente(Int32 idEmpresa, Int32 idPersona)
        {
            try
            {
                return new ClienteAD().EliminarCliente(idEmpresa, idPersona);
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

        public ClienteE RecuperarClientePorId(Int32 idPersona, Int32 idEmpresa, String BuscarOtros = "S")
        {
            try
            {
                ClienteE oCliente = new ClienteAD().RecuperarClientePorId(idPersona, idEmpresa);

                if (BuscarOtros == "S")
                {
                    if (oCliente != null)
                    {
                        //Persona
                        oCliente.Persona = new PersonaAD().RecuperarPersonaPorID(idPersona);

                        //Sucursales - Direcciones
                        if (oCliente.Persona != null)
                        {
                            oCliente.Persona.ListaPersonaDireccion = new PersonaDireccionAD().ListarPersonaDireccion(idPersona);
                        }

                        //Avales
                        oCliente.ListaAvales = new ClienteAvalAD().ListarClienteAval(idEmpresa, idPersona);

                        //Clientes Asociados - Referentes
                        ParTabla parTipoCliente = new ParTablaAD().ParTablaPorNemo("TIPCLIREF");

                        if (parTipoCliente != null)
                        {
                            if (oCliente.TipoCliente == parTipoCliente.IdParTabla)
                            {
                                oCliente.ListaClienteAsociados = new ClienteAsociadosAD().ListarClienteAsociados(idEmpresa, idPersona);
                            } 
                        }
                    } 
                }
                
                return oCliente;
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

        public List<ClienteE> ListarClientePorParametro(Int32 idEmpresa, String RazonSocial, String NroDocumento, Boolean activo, Boolean inactivo)
        {
            try
            {
                return new ClienteAD().ListarClientePorParametro(idEmpresa, RazonSocial, NroDocumento, activo, inactivo);
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
