using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using AccesoDatos.Maestros;
using Entidades.Maestros;
using Infraestructura.Enumerados;

namespace Negocio.Maestros
{
    public class EmpresaLN
    {

        public Empresa GrabarEntidad(Empresa empresa, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            new EmpresaAD().ActualizarEmpresa(empresa);

                            //Imagenes
                            if (empresa.ListaEmpresaImagenes != null && empresa.ListaEmpresaImagenes.Count > 0)
                            {
                                foreach (EmpresaImagenesE oitem in empresa.ListaEmpresaImagenes)
                                {
                                    oitem.idEmpresa = empresa.IdEmpresa;

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new EmpresaImagenesAD().InsertarEmpresaImagenes(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new EmpresaImagenesAD().ActualizarEmpresaImagenes(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Eliminar:
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Insertar:

                            new EmpresaAD().InsertarEmpresa(empresa);

                            //Imagenes
                            if (empresa.ListaEmpresaImagenes != null && empresa.ListaEmpresaImagenes.Count > 0)
                            {
                                foreach (EmpresaImagenesE oitem in empresa.ListaEmpresaImagenes)
                                {
                                    oitem.idEmpresa = empresa.IdEmpresa;
                                    new EmpresaImagenesAD().InsertarEmpresaImagenes(oitem);
                                }
                            }

                            break;
                        default:
                            break;

                    }

                    oTrans.Complete();
                }                 
               
                return empresa;
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

        public List<Empresa> ListarEmpresa(String parametro)
        {
            try
            {
                return new EmpresaAD().ListarEmpresa(parametro);
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

        public Empresa RecuperarEmpresaPorID(Int32 idEmpresa)
        {
            try
            {
                Empresa oEmpresa = new EmpresaAD().RecuperarEmpresaPorID(idEmpresa);
                //Recuperando las imagenes si hay....
                oEmpresa.ListaEmpresaImagenes = new EmpresaImagenesAD().ListarEmpresaImagenes(idEmpresa);

                return oEmpresa;
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

        public List<Empresa> ListarEmpresaPorEstado(String parametro, Boolean Estado1, Boolean Estado2)
        {
            try
            {
                return new EmpresaAD().ListarEmpresaPorEstado(parametro, Estado1, Estado2);
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

        public List<Empresa> ListarEmpresaPorUsuario(Int32 IdPersona)
        {
            try
            {
                return new EmpresaAD().ListarEmpresaPorUsuario(IdPersona);
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

        public Empresa RecuperarEmpresaPorRUC(String ruc)
        {
            try
            {
                return new EmpresaAD().RecuperarEmpresaPorRUC(ruc);
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

        public DateTime RecuperarFechaServidor()
        {
            try
            {
                return new EmpresaAD().RecuperarFechaServidor();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    case 2812:
                        mensaje.Append("No se ha podido obtener la fecha del servidor.");
                        break;
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
