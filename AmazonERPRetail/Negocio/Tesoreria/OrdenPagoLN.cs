using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Tesoreria;
using AccesoDatos.Tesoreria;
using Infraestructura.Enumerados;

namespace Negocio.Tesoreria
{
    public class OrdenPagoLN
    {

        public OrdenPagoE GrabarOrdenPago(OrdenPagoE OP, EnumOpcionGrabar Opcion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (Opcion == EnumOpcionGrabar.Insertar)
                    {
                        String codOrdenPago = new OrdenPagoAD().GenerarNumOrdenPago(OP.idEmpresa, OP.idLocal);
                        OP.codOrdenPago = codOrdenPago;
                        OP = new OrdenPagoAD().InsertarOrdenPago(OP);

                        if (OP.ListaOrdenPago != null)
                        {
                            foreach (OrdenPagoDetE item in OP.ListaOrdenPago)
                            {
                                item.idEmpresa = OP.idEmpresa;
                                item.idLocal = OP.idLocal;
                                item.idOrdenPago = OP.idOrdenPago;

                                new OrdenPagoDetAD().InsertarOrdenPagoDet(item);
                            }
                        }
                    }
                    else
                    {
                        OP = new OrdenPagoAD().ActualizarOrdenPago(OP);

                        if (OP.ListaOrdenPago != null)
                        {
                            new OrdenPagoDetAD().EliminarOrdenPagoDet(OP.idOrdenPago);

                            foreach (OrdenPagoDetE item in OP.ListaOrdenPago)
                            {
                                item.idEmpresa = OP.idEmpresa;
                                item.idLocal = OP.idLocal;
                                item.idOrdenPago = OP.idOrdenPago;
                                
                                new OrdenPagoDetAD().InsertarOrdenPagoDet(item);
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return OP;
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

        public OrdenPagoE InsertarOrdenPago(OrdenPagoE ordenpago)
        {
            try
            {
                return new OrdenPagoAD().InsertarOrdenPago(ordenpago);
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

        public OrdenPagoE ActualizarOrdenPago(OrdenPagoE ordenpago)
        {
            try
            {
                return new OrdenPagoAD().ActualizarOrdenPago(ordenpago);
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

        public int EliminarOrdenPago(Int32 idOrdenPago)
        {
            try
            {
                return new OrdenPagoAD().EliminarOrdenPago(idOrdenPago);
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

        public int CambiarEstadoOP(Int32 idOrdenPago, String indEstado, String UsuarioModificacion)
        {
            try
            {
                return new OrdenPagoAD().CambiarEstadoOP(idOrdenPago, indEstado, UsuarioModificacion);
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

        public List<OrdenPagoE> ListarOrdenPago(Int32 idEmpresa, Int32 idLocal, String codOrdenPago, DateTime fecIni, DateTime fecFin, String indEstado)
        {
            try
            {
                return new OrdenPagoAD().ListarOrdenPago(idEmpresa, idLocal, codOrdenPago, fecIni, fecFin, indEstado);
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

        public List<OrdenPagoE> ListarOrdenPagoPorIdPersona(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                return new OrdenPagoAD().ListarOrdenPagoPorIdPersona(idEmpresa, idLocal, idPersona, fecIni, fecFin);
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

        public OrdenPagoE ObtenerOrdenPago(Int32 idOrdenPago)
        {
            try
            {
                return new OrdenPagoAD().ObtenerOrdenPago(idOrdenPago);
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

        public OrdenPagoE ObtenerOrdenPagoCompleto(Int32 idOrdenPago, String Impresion = "N")
        {
            try
            {
                OrdenPagoE OrdenPago = new OrdenPagoAD().ObtenerOrdenPago(idOrdenPago);

                if (OrdenPago != null)
                {
                    if (Impresion == "N")
                    {
                        OrdenPago.ListaOrdenPago = new OrdenPagoDetAD().ListarOrdenPagoDet(idOrdenPago);
                    }
                    else
                    {
                        OrdenPago.ListaOrdenPago = new OrdenPagoDetAD().ListarOPagoDetCancel(idOrdenPago);
                    } 
                }

                return OrdenPago;
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

        public OrdenPagoE OpAbiertosPorIdPersona(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            try
            {
                return new OrdenPagoAD().OpAbiertosPorIdPersona(idEmpresa, idLocal, idPersona);
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

        public Int32 ObtenerOpProgramaPago(Int32 idEmpresa, Int32 idLocal, Int32 idOrdenPago)
        {
            try
            {
                return new OrdenPagoAD().ObtenerOpProgramaPago(idEmpresa, idLocal, idOrdenPago);
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
