using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Maestros;
using AccesoDatos.Ventas;
using AccesoDatos.Maestros;
using Infraestructura.Enumerados;

namespace Negocio.Maestros
{
    public class VendedoresLN
    {

        public VendedoresE GrabarVendedor(VendedoresE Vendedor, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizando las personas
                            new PersonaAD().ActualizarPersona(Vendedor.Persona);
                            //Actualizando el Vendedor
                            new VendedoresAD().ActualizarVendedores(Vendedor);

                            //Detalle de la lista de precios
                            if (Vendedor.ListaVendedoresCartera != null && Vendedor.ListaVendedoresCartera.Count > 0)
                            {
                                foreach (VendedoresCarteraE oitem in Vendedor.ListaVendedoresCartera)
                                {
                                    oitem.idVendedor = Vendedor.idPersona;

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new VendedoresCarteraAD().InsertarVendedoresCartera(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new VendedoresCarteraAD().ActualizarVendedoresCartera(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Eliminar:
                                            new VendedoresCarteraAD().EliminarVendedoresCartera(oitem.idEmpresa, oitem.idVendedor, oitem.idCliente);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            break;
                        case EnumOpcionGrabar.InsertarSimple:

                            //Actualizando las personas
                            new PersonaAD().ActualizarPersona(Vendedor.Persona);
                            Vendedor.idPersona = Vendedor.Persona.IdPersona;
                            //Insertando el Vendedor
                            Vendedor = new VendedoresAD().InsertarVendedores(Vendedor);

                            break;
                        case EnumOpcionGrabar.Insertar:

                            //Insertando la Persona si en caso nueva
                            Vendedor.Persona = new PersonaAD().InsertarPersona(Vendedor.Persona);
                            Vendedor.idPersona = Vendedor.Persona.IdPersona;
                            //Insertando el Vendedor
                            Vendedor = new VendedoresAD().InsertarVendedores(Vendedor);

                            if (Vendedor.ListaVendedoresCartera != null && Vendedor.ListaVendedoresCartera.Count > 0)
                            {
                                foreach (VendedoresCarteraE oitem in Vendedor.ListaVendedoresCartera)
                                {
                                    oitem.idVendedor = Vendedor.idPersona;
                                    new VendedoresCarteraAD().InsertarVendedoresCartera(oitem);
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return Vendedor;
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

        public VendedoresE InsertarVendedores(VendedoresE vendedores)
        {
            try
            {
                return new VendedoresAD().InsertarVendedores(vendedores);
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

        public VendedoresE ActualizarVendedores(VendedoresE vendedores)
        {
            try
            {
                return new VendedoresAD().ActualizarVendedores(vendedores);
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

        public int EliminarVendedores(Int32 idPersona, Int32 idEmpresa)
        {
            try
            {
                return new VendedoresAD().EliminarVendedores(idPersona, idEmpresa);
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

        public List<VendedoresE> ListarVendedores(Int32 idEmpresa, String parambusqueda , Boolean indEstado)
        {
            try
            {
                return new VendedoresAD().ListarVendedores(idEmpresa, parambusqueda, indEstado);
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

        public List<VendedoresE> BusquedaVendedores(Int32 idEmpresa)
        {
            try
            {
                return new VendedoresAD().BusquedaVendedores(idEmpresa);
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

        public VendedoresE RecuperarVendedorPorId(Int32 idPersona, Int32 idEmpresa)
        {
            try
            {
                return new VendedoresAD().RecuperarVendedorPorId(idPersona, idEmpresa);
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

        public VendedoresE RecuperarIDPersonaPorVendedor(Int32 idPersona, Int32 idEmpresa)
        {
            try
            {
                return new VendedoresAD().RecuperarIDPersonaPorVendedor(idPersona, idEmpresa);
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

        public Int32 DarBajaVendedores(Int32 idPersona, Int32 idEmpresa, String UsuarioModificacion)
        {
            try
            {
                return new VendedoresAD().DarBajaVendedores(idPersona, idEmpresa, UsuarioModificacion);
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
