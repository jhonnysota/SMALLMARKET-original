using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Almacen;
using AccesoDatos.Almacen;

namespace Negocio.Almacen
{
    public class OperacionLN
    {

        public OperacionE InsertarOperacion(OperacionE operacion)
        {
            try
            {
                return new OperacionAD().InsertarOperacion(operacion);
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

        public OperacionE ActualizarOperacion(OperacionE operacion)
        {
            try
            {
                return new OperacionAD().ActualizarOperacion(operacion);
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

        public int EliminarOperacion(Int32 idEmpresa, Int32 idOperacion, Int32 tipAlmacen, Int32 idTipoDocumento)
        {
            try
            {
                return new OperacionAD().EliminarOperacion(idEmpresa,idOperacion, tipAlmacen, idTipoDocumento);
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
        
        public List<OperacionE> ListarOperacion(Int32 idEmpresa)
        {
            try
            {
                List<OperacionE> Lista = new OperacionAD().ListarOperacion(idEmpresa);

                foreach (OperacionE item in Lista)
                {
                    item.desTemporal = item.desOperacion + "  |  " + item.tipMovimiento.ToString() + " | " + item.desTipMovimiento + "  |  " + item.tipAlmacen.ToString() + " | " + item.desTipAlmacen;
                }

                return Lista;
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

        public List<OperacionE> ListarEmpresaOperacion(Int32 idEmpresa, Int32 TipAlmacen)
        {
            try
            {
                return new OperacionAD().ListarEmpresaOperacion(idEmpresa, TipAlmacen);
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

        public List<OperacionE> ListarOperacionPorTipoArticulo(Int32 tipAlmacen, Int32 idEmpresa, Int32 tipMovimiento)
        {
            try
            {
                return new OperacionAD().ListarOperacionPorTipoArticulo(tipAlmacen, idEmpresa, tipMovimiento);
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

        public List<OperacionE> ListarOperacionporTipoMovimiento(String pStr_filtro, Int32 idEmpresa, Int32 tipMovimiento)
        {
            try
            {
                return new OperacionAD().ListarOperacionporTipoMovimiento(pStr_filtro, idEmpresa,tipMovimiento);
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

        public OperacionE ObtenerOperacion(Int32 pi_idEmpresa, Int32 pi_idOperacion)
        {
            try
            {
                return new OperacionAD().ObtenerOperacion(pi_idEmpresa, pi_idOperacion);
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

        public Int32 InsertarOperacionesMasiva(List<OperacionE> ListaOpe)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    foreach (OperacionE item in ListaOpe)
                    {
                        new OperacionAD().InsertarOperacion(item);
                        resp++;
                    }

                    oTrans.Complete();
                }

                return resp;
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
