using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.CtasPorCobrar;
using AccesoDatos.CtasPorCobrar;
using Infraestructura.Enumerados;

namespace Negocio.CtasPorCobrar
{
    public class TipoIngresosLN 
    {

        public TipoIngresosE GrabarTipoIngresos(TipoIngresosE tipoingresos, EnumOpcionGrabar Opcion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (Opcion == EnumOpcionGrabar.Insertar)
                    {
                        tipoingresos = new TipoIngresosAD().InsertarTipoIngresos(tipoingresos);

                        if (tipoingresos.ListaIngresosDet != null)
                        {
                            foreach (TipoIngresosDetE item in tipoingresos.ListaIngresosDet)
                            {
                                item.TipoCobro = tipoingresos.TipoCobro;
                                new TipoIngresosDetAD().InsertarTipoIngresosDet(item);
                            }
                        }
                    }
                    else
                    {
                        //Actualizando la cabecera...
                        tipoingresos = new TipoIngresosAD().ActualizarTipoIngresos(tipoingresos);

                        //verificando si hay registros eliminados
                        if (tipoingresos.ListaEliminados != null)
                        {
                            foreach (TipoIngresosDetE item in tipoingresos.ListaEliminados)
                            {
                                new TipoIngresosDetAD().EliminarTipoIngresosDet(item.idEmpresa, item.TipoCobro, item.TipoPlanilla);
                            }
                        }

                        //Actualizando el detalle
                        if (tipoingresos.ListaIngresosDet != null)
                        {
                            foreach (TipoIngresosDetE item in tipoingresos.ListaIngresosDet)
                            {
                                item.TipoCobro = tipoingresos.TipoCobro;

                                switch (item.Opcion)
                                {
                                    case (Int32)EnumOpcionGrabar.Insertar:
                                        new TipoIngresosDetAD().InsertarTipoIngresosDet(item);
                                        break;
                                    case (Int32)EnumOpcionGrabar.Actualizar:
                                        new TipoIngresosDetAD().ActualizarTipoIngresosDet(item);
                                        break;
                                    default:
                                        break;
                                }
                                
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return tipoingresos;
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

        public TipoIngresosE InsertarTipoIngresos(TipoIngresosE tipoingresos)
        {
            try
            {
                return new TipoIngresosAD().InsertarTipoIngresos(tipoingresos);
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

        public TipoIngresosE ActualizarTipoIngresos(TipoIngresosE tipoingresos)
        {
            try
            {
                return new TipoIngresosAD().ActualizarTipoIngresos(tipoingresos);
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

        public int EliminarTipoIngresos(Int32 idEmpresa, String TipoCobro)
        {
            try
            {
                return new TipoIngresosAD().EliminarTipoIngresos(idEmpresa, TipoCobro);
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

        public List<TipoIngresosE> ListarTipoIngresos(Int32 idEmpresa)
        {
            try
            {
                return new TipoIngresosAD().ListarTipoIngresos(idEmpresa);
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

        public TipoIngresosE ObtenerTipoIngresos(Int32 idEmpresa, String TipoCobro, String ConDetalle = "N")
        {
            try
            {
                TipoIngresosE TipoIngreso = new TipoIngresosAD().ObtenerTipoIngresos(idEmpresa, TipoCobro);

                if (TipoIngreso != null && ConDetalle == "S")
                {
                    TipoIngreso.ListaIngresosDet = new TipoIngresosDetAD().ListarTipoIngresosDet(idEmpresa, TipoCobro);
                }

                return TipoIngreso;
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

        public Int32 CopiarTipoIngresos(Int32 idEmpresaDe, Int32 idEmpresaA, String UsuarioRegistro)
        {
            try
            {
                return new TipoIngresosAD().CopiarTipoIngresos(idEmpresaDe, idEmpresaA, UsuarioRegistro);
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

        public List<TipoIngresosE> ListarEmpresaTipIng(Int32 idEmpresa)
        {
            try
            {
                return new TipoIngresosAD().ListarEmpresaTipIng(idEmpresa);
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

        public List<TipoIngresosE> TipoIngresosCombos(Int32 idEmpresa)
        {
            try
            {
                return new TipoIngresosAD().TipoIngresosCombos(idEmpresa);
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
