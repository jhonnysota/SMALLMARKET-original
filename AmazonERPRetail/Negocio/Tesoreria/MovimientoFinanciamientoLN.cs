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
    public class MovimientoFinanciamientoLN
    {

        public MovimientoFinanciamientoE GrabarMovimientoFinanciamiento(MovimientoFinanciamientoE movimientofinanciamiento, EnumOpcionGrabar Opcion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (Opcion == EnumOpcionGrabar.Insertar)
                    {
                        String codMovimiento = new MovimientoFinanciamientoAD().GenerarNumMovFinanciamiento(movimientofinanciamiento.idEmpresa);
                        movimientofinanciamiento.codMovimiento = codMovimiento;
                        movimientofinanciamiento = new MovimientoFinanciamientoAD().InsertarMovimientoFinanciamiento(movimientofinanciamiento);

                        if (movimientofinanciamiento.oListaMovimientos != null)
                        {
                            foreach (MovimientoFinanciamientoDetE item in movimientofinanciamiento.oListaMovimientos)
                            {
                                item.idMovimiento = movimientofinanciamiento.idMovimiento;
                                new MovimientoFinanciamientoDetAD().InsertarMovimientoFinanciamientoDet(item);
                            }
                        }
                    }
                    else
                    {
                        movimientofinanciamiento = new MovimientoFinanciamientoAD().ActualizarMovimientoFinanciamiento(movimientofinanciamiento);

                        if (movimientofinanciamiento.oListaMovimientos != null)
                        {
                            new MovimientoFinanciamientoDetAD().EliminarMovFinanDetPorId(movimientofinanciamiento.idMovimiento);

                            foreach (MovimientoFinanciamientoDetE item in movimientofinanciamiento.oListaMovimientos)
                            {
                                item.idMovimiento = movimientofinanciamiento.idMovimiento;
                                new MovimientoFinanciamientoDetAD().InsertarMovimientoFinanciamientoDet(item);
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return movimientofinanciamiento;
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

        public MovimientoFinanciamientoE InsertarMovimientoFinanciamiento(MovimientoFinanciamientoE movimientofinanciamiento)
        {
            try
            {
                return new MovimientoFinanciamientoAD().InsertarMovimientoFinanciamiento(movimientofinanciamiento);
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

        public MovimientoFinanciamientoE ActualizarMovimientoFinanciamiento(MovimientoFinanciamientoE movimientofinanciamiento)
        {
            try
            {
                return new MovimientoFinanciamientoAD().ActualizarMovimientoFinanciamiento(movimientofinanciamiento);
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

        public int EliminarMovimientoFinanciamiento(Int32 idMovimiento)
        {
            try
            {
                return new MovimientoFinanciamientoAD().EliminarMovimientoFinanciamiento(idMovimiento);
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

        public List<MovimientoFinanciamientoE> ListarMovimientoFinanciamiento(Int32 idEmpresa, Int32 idLinea, Int32 idBanco, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                return new MovimientoFinanciamientoAD().ListarMovimientoFinanciamiento(idEmpresa, idLinea, idBanco, fecIni, fecFin);
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

        public MovimientoFinanciamientoE ObtenerMovimientoFinanciamiento(Int32 idMovimiento)
        {
            try
            {
                return new MovimientoFinanciamientoAD().ObtenerMovimientoFinanciamiento(idMovimiento);
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

        public MovimientoFinanciamientoE ObtenerMovFinanciamientoCompleto(Int32 idMovimiento)
        {
            try
            {
                MovimientoFinanciamientoE oMovimiento = new MovimientoFinanciamientoAD().ObtenerMovimientoFinanciamiento(idMovimiento);

                if (oMovimiento != null)
                {
                    oMovimiento.oListaMovimientos = new MovimientoFinanciamientoDetAD().ListarMovimientoFinanciamientoDet(idMovimiento);
                }

                return oMovimiento;
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

        public List<MovimientoFinanciamientoE> ListarMovFinCuentasBan(Int32 idPersona, Int32 idEmpresa, String idMoneda)
        {
            try
            {
                return new MovimientoFinanciamientoAD().ListarMovFinCuentasBan(idPersona, idEmpresa, idMoneda);
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
