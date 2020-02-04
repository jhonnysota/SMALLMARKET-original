using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Generales;
using AccesoDatos.Generales;
using Infraestructura.Enumerados;

namespace Negocio.Generales
{
    public class ImpuestosLN
    {
        public ImpuestosE InsertarImpuestos(ImpuestosE impuestos)
        {
            try
            {
                return new ImpuestosAD().InsertarImpuestos(impuestos);
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

        public ImpuestosE ActualizarImpuestos(ImpuestosE impuestos)
        {
            try
            {
                return new ImpuestosAD().ActualizarImpuestos(impuestos);
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

        public ImpuestosE GrabarImpuestosControl(ImpuestosE impuestos, EnumOpcionGrabar OpcionGrabacion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabacion)
                    {
                        case EnumOpcionGrabar.Insertar:

                            impuestos = new ImpuestosAD().InsertarImpuestos(impuestos);

                            if (impuestos.listaImpuestosPeriodo != null && impuestos.listaImpuestosPeriodo.Count > 0)
                            {
                                foreach (ImpuestosPeriodoE item in impuestos.listaImpuestosPeriodo)
                                {
                                    item.idImpuesto= impuestos.idImpuesto;
                                    new ImpuestosPeriodoAD().InsertarImpuestosPeriodo(item);
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            impuestos = new ImpuestosAD().ActualizarImpuestos(impuestos);
                            Int32 resp = new ImpuestosPeriodoAD().EliminarImpuestosPeriodo(impuestos.idImpuesto);
                            
                            if (impuestos.listaImpuestosPeriodo != null && impuestos.listaImpuestosPeriodo.Count > 0)
                            {
                                foreach (ImpuestosPeriodoE item in impuestos.listaImpuestosPeriodo)
                                {
                                    item.idImpuesto = impuestos.idImpuesto;
                                    new ImpuestosPeriodoAD().InsertarImpuestosPeriodo(item);
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return impuestos;
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

        public ImpuestosE ObtenerImpuestosCompleto(Int32 idImpuesto)
        {
            try
            {
                //Cabecera
                ImpuestosE ImpuestosCtr = new ImpuestosAD().ObtenerImpuestos(idImpuesto);

                //Detalle
                ImpuestosCtr.listaImpuestosPeriodo = new ImpuestosPeriodoAD().ListarImpuestosPeriodoPorIdImpuesto(idImpuesto);

                return ImpuestosCtr;
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

        public Int32 EliminarImpuestos(Int32 idImpuesto)
        {
            try
            {
                return new ImpuestosAD().EliminarImpuestos(idImpuesto);
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

        public List<ImpuestosE> ListarImpuestos()
        {
            try
            {
                return new ImpuestosAD().ListarImpuestos();
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

        public ImpuestosE ObtenerImpuestos(Int32 idImpuesto)
        {
            try
            {
                return new ImpuestosAD().ObtenerImpuestos(idImpuesto);
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
