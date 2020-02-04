using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Maestros;

namespace Negocio.Maestros
{
    public class ProveedorCuentaLN 
    {
        public ProveedorCuentaE InsertarProveedorCuenta(ProveedorCuentaE proveedorcuenta)
        {
            try
            {
                return new ProveedorCuentaAD().InsertarProveedorCuenta(proveedorcuenta);
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

        public ProveedorCuentaE ActualizarProveedorCuenta(ProveedorCuentaE proveedorcuenta)
        {
            try
            {
                return new ProveedorCuentaAD().ActualizarProveedorCuenta(proveedorcuenta);
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

        public int AnularProveedorCuenta(Int32 idPersona, Int32 idEmpresa, Int32 idItem, Boolean indBaja)
        {
            try
            {
                return new ProveedorCuentaAD().AnularProveedorCuenta(idPersona, idEmpresa, idItem, indBaja);
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

        public List<ProveedorCuentaE> ListarProveedorCuenta(Int32 idEmpresa, Int32 idPersona, Boolean indBaja)
        {
            try
            {
                return new ProveedorCuentaAD().ListarProveedorCuenta(idEmpresa, idPersona, indBaja);
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

        public ProveedorCuentaE ObtenerProveedorCuenta(Int32 idPersona, Int32 idEmpresa, Int32 idItem)
        {
            try
            {
                return new ProveedorCuentaAD().ObtenerProveedorCuenta(idPersona, idEmpresa, idItem);
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

        public List<ProveedorCuentaE> BancosPorProv(Int32 idPersona, Int32 idEmpresa)
        {
            try
            {
                return new ProveedorCuentaAD().BancosPorProv(idEmpresa, idPersona);
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

        public List<ProveedorCuentaE> TipoCuentaProv(Int32 idPersona, Int32 idEmpresa, Int32 idPersonaBanco)
        {
            try
            {
                return new ProveedorCuentaAD().TipoCuentaProv(idEmpresa, idPersona, idPersonaBanco);
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

        public List<ProveedorCuentaE> CuentasBancosProv(Int32 idPersona, Int32 idEmpresa, Int32 idPersonaBanco, Int32 tipCuenta)
        {
            try
            {
                return new ProveedorCuentaAD().CuentasBancosProv(idEmpresa, idPersona, idPersonaBanco, tipCuenta);
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

        public ProveedorCuentaE ObtenerProvCtaDefecto(Int32 idPersona, Int32 idEmpresa, String idMoneda)
        {
            try
            {
                return new ProveedorCuentaAD().ObtenerProvCtaDefecto(idPersona, idEmpresa, idMoneda);
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
