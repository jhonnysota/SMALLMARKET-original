using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Maestros;
using Infraestructura.Enumerados;

namespace Negocio.Maestros
{
    public class ProveedorLN
    {

        public ProveedorE GrabarProveedor(ProveedorE Proveedor, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizando las personas
                            new PersonaAD().ActualizarPersona(Proveedor.Persona);
                            //Actualizando el Provedor
                            new ProveedorAD().ActualizarProveedor(Proveedor);

                            //Detalle de Contactos de proveedor
                            if (Proveedor.ListaProveedorContacto != null && Proveedor.ListaProveedorContacto.Count > 0)
                            {
                                foreach (ProveedorContactoE oitem in Proveedor.ListaProveedorContacto)
                                {
                                    oitem.idPersona = Proveedor.IdPersona;

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new ProveedorContactoAD().InsertarProveedorContacto(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new ProveedorContactoAD().ActualizarProveedorContacto(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Eliminar:
                                            new ProveedorContactoAD().EliminarProveedorContacto(oitem.idPersona, oitem.idPersona, oitem.idItem);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            //Detalle de Cuenta Bancarias
                            if (Proveedor.ListaProveedorCuenta != null && Proveedor.ListaProveedorCuenta.Count > 0)
                            {
                                foreach (ProveedorCuentaE oitem in Proveedor.ListaProveedorCuenta)
                                {
                                    oitem.idPersona = Proveedor.IdPersona;

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new ProveedorCuentaAD().InsertarProveedorCuenta(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new ProveedorCuentaAD().ActualizarProveedorCuenta(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Anular:
                                            new ProveedorCuentaAD().AnularProveedorCuenta(oitem.idPersona, oitem.idEmpresa, oitem.idItem, true);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            break;
                        case EnumOpcionGrabar.InsertarSimple:

                            //Actualizando las personas
                            new PersonaAD().ActualizarPersona(Proveedor.Persona);
                            Proveedor.IdPersona = Proveedor.Persona.IdPersona;
                            //Insertando el proveedor
                            Proveedor = new ProveedorAD().InsertarProveedor(Proveedor);

                            if (Proveedor.ListaProveedorContacto != null && Proveedor.ListaProveedorContacto.Count > 0)
                            {
                                foreach (ProveedorContactoE oitem in Proveedor.ListaProveedorContacto)
                                {
                                    oitem.idPersona = Proveedor.IdPersona;
                                    new ProveedorContactoAD().InsertarProveedorContacto(oitem);
                                }
                            }

                            if (Proveedor.ListaProveedorCuenta != null && Proveedor.ListaProveedorCuenta.Count > 0)
                            {
                                foreach (ProveedorCuentaE oitem in Proveedor.ListaProveedorCuenta)
                                {
                                    oitem.idPersona = Proveedor.IdPersona;
                                    new ProveedorCuentaAD().InsertarProveedorCuenta(oitem);
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Insertar:

                            //Insertando personas
                            Proveedor.Persona = new PersonaAD().InsertarPersona(Proveedor.Persona);
                            Proveedor.IdPersona = Proveedor.Persona.IdPersona;
                            //Insertando el proveedor
                            Proveedor = new ProveedorAD().InsertarProveedor(Proveedor);

                            //Lista de contactos de proveedores
                            if (Proveedor.ListaProveedorContacto != null && Proveedor.ListaProveedorContacto.Count > 0)
                            {
                                foreach (ProveedorContactoE oitem in Proveedor.ListaProveedorContacto)
                                {
                                    oitem.idPersona = Proveedor.IdPersona;
                                    new ProveedorContactoAD().InsertarProveedorContacto(oitem);
                                }
                            }

                            //Lista de cuentas bancarias
                            if (Proveedor.ListaProveedorCuenta != null && Proveedor.ListaProveedorCuenta.Count > 0)
                            {
                                foreach (ProveedorCuentaE oitem in Proveedor.ListaProveedorCuenta)
                                {
                                    oitem.idPersona = Proveedor.IdPersona;
                                    new ProveedorCuentaAD().InsertarProveedorCuenta(oitem);
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return Proveedor;
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

        public ProveedorE RecuperarProveedorPorID(int idPersona, int idEmpresa, String BuscarOtros = "S", Boolean indBaja = false)
        {
            try
            {
                ProveedorE proveedor = new ProveedorAD().RecuperarProveedorPorID(idPersona, idEmpresa);

                if (BuscarOtros == "S")
                {
                    if (proveedor != null)
                    {
                        proveedor.Persona = new PersonaLN().RecuperarPersonaPorID(idPersona);
                        proveedor.ListaProveedorContacto = new ProveedorContactoAD().ListarProveedorContacto(idEmpresa, idPersona);
                        proveedor.ListaProveedorCuenta = new ProveedorCuentaAD().ListarProveedorCuenta(idEmpresa, idPersona, indBaja);
                    }
                }

                return proveedor;
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

        public int ActualizarEstadoProveedor(int idPersona, bool estado, int idEmpresa, string usuarioModificacion, DateTime fechaModificacion)
        {
            try
            {
                return new ProveedorAD().ActualizarEstadoProveedor(idPersona, estado, idEmpresa, usuarioModificacion, fechaModificacion);
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

        public List<ProveedorE> ListarProveedorPorParametro(int idEmpresa, string RazonSocial, string NroDocumento, int? TipoPersona, string indBaja)
        {
            try
            {
                return new ProveedorAD().ListarProveedorPorParametro(idEmpresa, RazonSocial, NroDocumento, TipoPersona, indBaja);
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

        public ProveedorE InsertarProveedor(ProveedorE proveedor)
        {
            try
            {
                return new ProveedorAD().InsertarProveedor(proveedor);
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

        public List<ProveedorE> BuscarProveedor(Int32 idEmpresa, String RazonSocial, String NroDocumento, Int32 TipoProveedor)
        {
            try
            {
                return new ProveedorAD().BuscarProveedor(idEmpresa, RazonSocial, NroDocumento, TipoProveedor);
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

        public int EliminarProveedor(Int32 idEmpresa , Int32 idPersona)
        {
            try
            {
                return new ProveedorAD().EliminarProveedor(idEmpresa, idPersona);
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
