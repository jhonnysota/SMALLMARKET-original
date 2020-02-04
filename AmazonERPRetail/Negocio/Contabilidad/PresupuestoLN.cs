using AccesoDatos.Contabilidad;
using Entidades.Contabilidad;
using Infraestructura.Enumerados;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio.Contabilidad
{
    public class PresupuestoLN
    {
        public PresupuestoE InsertarPresupuesto(PresupuestoE Presupuesto)
        {
            try
            {
                return new PresupuestoAD().InsertarPresupuesto(Presupuesto);
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

        public PresupuestoE ActualizarPresupuesto(PresupuestoE Presupuesto)
        {
            try
            {
                return new PresupuestoAD().ActualizarPresupuesto(Presupuesto);
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

        public int EliminarPresupuesto(Int32 idEmpresa, Int32 idPresupuesto )
        {
            try
            {
             

                //Cabecera
                int Presupuesto = new PresupuestoAD().EliminarPresupuesto(idEmpresa, idPresupuesto);


                return Presupuesto;
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

        public List<PresupuestoE> ListarPresupuesto(Int32 idEmpresa)
        {
            try
            {
                return new PresupuestoAD().ListarPresupuesto(idEmpresa);
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

        public PresupuestoE ObtenerPresupuesto(Int32 idEmpresa, Int32 idPresupuesto)
        {
            try
            {
                return new PresupuestoAD().ObtenerPresupuesto(idEmpresa, idPresupuesto);
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

        public PresupuestoE GrabarPresupuesto(PresupuestoE Presupuesto, EnumOpcionGrabar OpcionGrabacion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabacion)
                    {
                        case EnumOpcionGrabar.Insertar:

                            Presupuesto = new PresupuestoAD().InsertarPresupuesto(Presupuesto);

                            if (Presupuesto.ListaPresupuestoDet != null && Presupuesto.ListaPresupuestoDet.Count > 0)
                            {
                                foreach (PresupuestoDetE item in Presupuesto.ListaPresupuestoDet)
                                {
                                    item.idEmpresa = Presupuesto.idEmpresa;
                                    item.idPresupuesto = Presupuesto.idPresupuesto;

                                    new PresupuestoDetAD().InsertarPresupuestoDet(item);                                
                                }                           

                            }                           

                          

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            Presupuesto = new PresupuestoAD().ActualizarPresupuesto(Presupuesto);

                            if (Presupuesto.ListaPresupuestoDet != null && Presupuesto.ListaPresupuestoDet.Count > 0)
                            {
                                foreach (PresupuestoDetE item in Presupuesto.ListaPresupuestoDet)
                                {
                                    item.idEmpresa = Presupuesto.idEmpresa;
                                    item.idPresupuesto = Presupuesto.idPresupuesto;

                                    switch (item.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new PresupuestoDetAD().InsertarPresupuestoDet(item);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new PresupuestoDetAD().ActualizarPresupuestoDet(item);

                                            break;
                                        case (int)EnumOpcionGrabar.Eliminar:
                                            new PresupuestoDetAD().EliminarPresupuestoDet(item.idEmpresa, item.idPresupuesto, item.idPresupuestoItem);
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

                return Presupuesto;
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

        public PresupuestoE ObtenerPresupuestoCompleto(Int32 idEmpresa, Int32 idPresupuesto)
        {
            try
            {
                //Cabecera
                PresupuestoE Presupuesto = new PresupuestoAD().ObtenerPresupuesto(idEmpresa, idPresupuesto);

                //Detalle
                Presupuesto.ListaPresupuestoDet = new PresupuestoDetAD().ListarPresupuestoDet(idEmpresa, idPresupuesto);

                return Presupuesto;
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
