using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using AccesoDatos;
using Infraestructura;
using Entidades.CtasPorPagar;
using AccesoDatos.CtasPorPagar;
using System.Transactions;
using Infraestructura.Enumerados;

namespace Negocio.CtasPorPagar
{
    public class NumControlCompraLN
    {

        public NumControlCompraE GrabarNumControlCompra(NumControlCompraE numControl, EnumOpcionGrabar OpcionGrabacion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabacion)
                    {
                        case EnumOpcionGrabar.Insertar:

                            numControl = new NumControlCompraAD().InsertarNumControlCompra(numControl);

                            if (numControl.ListaNumControlCompra != null && numControl.ListaNumControlCompra.Count > 0)
                            {
                                foreach (NumControlCompraDetE item in numControl.ListaNumControlCompra)
                                {
                                    item.idEmpresa = numControl.idEmpresa;
                                    item.idLocal = numControl.idLocal;
                                    item.idControl = numControl.idControl;

                                    new NumControlCompraDetAD().InsertarNumControlCompraDet(item);
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            numControl = new NumControlCompraAD().ActualizarNumControlCompra(numControl);

                            if (numControl.ListaNumControlCompra != null && numControl.ListaNumControlCompra.Count > 0)
                            {
                                foreach (NumControlCompraDetE item in numControl.ListaNumControlCompra)
                                {
                                    item.idEmpresa = numControl.idEmpresa;
                                    item.idLocal = numControl.idLocal;
                                    item.idControl = numControl.idControl;

                                    switch (item.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new NumControlCompraDetAD().InsertarNumControlCompraDet(item);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new NumControlCompraDetAD().ActualizarNumControlCompraDet(item);
                                            break;
                                        case (int)EnumOpcionGrabar.Eliminar:
                                            new NumControlCompraDetAD().EliminarNumControlCompraDet(item.idEmpresa, item.idLocal, item.idControl, item.item);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return numControl;
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


        public NumControlCompraE InsertarNumControlCompra(NumControlCompraE numcontrolcompra)
        {
            try
            {
                return new NumControlCompraAD().InsertarNumControlCompra(numcontrolcompra);
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

        public NumControlCompraE ActualizarNumControlCompra(NumControlCompraE numcontrolcompra)
        {
            try
            {
                return new NumControlCompraAD().ActualizarNumControlCompra(numcontrolcompra);
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

        public int EliminarNumControlCompra(Int32 idEmpresa, Int32 idLocal, Int32 idControl)
        {
            try
            {
                return new NumControlCompraAD().EliminarNumControlCompra(idEmpresa, idLocal, idControl);
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

        public List<NumControlCompraE> ListarNumControlCompra(Int32 idEmpresa, Int32 idLocal)
        {
            try
            {
                return new NumControlCompraAD().ListarNumControlCompra(idEmpresa, idLocal);
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

        public NumControlCompraE ObtenerNumControlCompra(Int32 idEmpresa, Int32 idLocal, Int32 idControl)
        {
            try
            {
                //Cabecera
                NumControlCompraE numControl = new NumControlCompraAD().ObtenerNumControlCompra(idEmpresa, idLocal, idControl);

                //Detalle
                numControl.ListaNumControlCompra = new NumControlCompraDetAD().ListarNumControlCompraDet(idEmpresa, idLocal, idControl);

                return numControl;
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
