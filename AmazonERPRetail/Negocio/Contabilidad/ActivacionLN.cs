using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura.Enumerados;

namespace Negocio.Contabilidad
{
    public class ActivacionLN
    {

        public ActivacionE GrabarActivacion(ActivacionE activacion, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    Int32 Corre = 1;

                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Insertar:

                            String Codi = new ActivacionAD().GenerarNumActivacion(activacion.idEmpresa);
                            activacion.codActivacion = Codi;
                            //Insertando la activacion
                            activacion = new ActivacionAD().InsertarActivacion(activacion);

                            //Detalle de las activaciones
                            if (activacion.ListaActivacionDet != null)
                            {
                                foreach (ActivacionDetE oitem in activacion.ListaActivacionDet)
                                {
                                    oitem.idActivacion = activacion.idActivacion;
                                    oitem.Item = Corre;
                                    new ActivacionDetAD().InsertarActivacionDet(oitem);
                                    Corre++;
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizando la activacion
                            new ActivacionAD().ActualizarActivacion(activacion);

                            //Detalle de las activaciones
                            if (activacion.ListaActivacionDet != null)
                            {
                                new ActivacionDetAD().EliminarActivacionDet(activacion.idActivacion);

                                foreach (ActivacionDetE oitem in activacion.ListaActivacionDet)
                                {
                                    oitem.idActivacion = activacion.idActivacion;
                                    oitem.Item = Corre;
                                    new ActivacionDetAD().InsertarActivacionDet(oitem);
                                    Corre++;
                                }
                            }

                            break;
                        
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return activacion;
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

        public ActivacionE InsertarActivacion(ActivacionE activacion)
        {
            try
            {
                return new ActivacionAD().InsertarActivacion(activacion);
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

        public ActivacionE ActualizarActivacion(ActivacionE activacion)
        {
            try
            {
                return new ActivacionAD().ActualizarActivacion(activacion);
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

        public int EliminarActivacion(Int32 idActivacion)
        {
            try
            {
                return new ActivacionAD().EliminarActivacion(idActivacion);
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

        public List<ActivacionE> ListarActivacion(Int32 idEmpresa)
        {
            try
            {
                return new ActivacionAD().ListarActivacion(idEmpresa);
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

        public ActivacionE ObtenerActivacion(Int32 idActivacion)
        {
            try
            {
                return new ActivacionAD().ObtenerActivacion(idActivacion);
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

        public ActivacionE RecuperarActivacionCompleta(Int32 idActivacion, Int32 idEmpresa)
        {
            try
            {
                ActivacionE oActivacion = new ActivacionAD().ObtenerActivacion(idActivacion);
                oActivacion.ListaActivacionDet = new ActivacionDetAD().ListarActivacionDet(idActivacion, idEmpresa);

                return oActivacion;
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

        public ActivacionE GenerarVoucherCapitalizacion(Int32 idActivacion, Int32 idEmpresa, Int32 idLocal, String Usuario)
        {
            try
            {
                return new ActivacionAD().GenerarVoucherCapitalizacion(idActivacion, idEmpresa, idLocal, Usuario);
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
