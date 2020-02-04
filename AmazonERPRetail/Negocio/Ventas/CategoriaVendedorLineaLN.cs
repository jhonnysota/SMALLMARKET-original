using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using AccesoDatos;
using Infraestructura;
using Entidades.Ventas;
//using Negocio.Base;

namespace Negocio.Maestros
{
    public class CategoriaVendedorLineaLN //: BaseLN
    {
        public CategoriaVendedorLineaE InsertarCategoriaVendedorLinea(CategoriaVendedorLineaE categorialinea)
        {
            try
            {
                return new CategoriaVendedorLineaAD().InsertarCategoriaVendedorLinea(categorialinea);
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

        public CategoriaVendedorLineaE ActualizarCategoriaVendedorLinea(CategoriaVendedorLineaE categorialinea)
        {
            try
            {
                return new CategoriaVendedorLineaAD().ActualizarCategoriaVendedorLinea(categorialinea);
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

        public int EliminarCategoriaVendedorLinea(Int32 idEmpresa, Int32 idCategoria, string idLinea)
        {
            try
            {
                return new CategoriaVendedorLineaAD().EliminarCategoriaVendedorLinea(idEmpresa, idCategoria, idLinea);
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

        public List<CategoriaVendedorLineaE> ListarCategoriaVendedorLinea(Int32 idEmpresa, Int32 idCategoria)
        {
            try
            {
                return new CategoriaVendedorLineaAD().ListarCategoriaVendedorLinea(idEmpresa, idCategoria);
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

        public CategoriaVendedorLineaE ObtenerCategoriaVendedorLinea(Int32 idEmpresa, Int32 idCategoria, Int32 idLinea)
        {
            try
            {
                return new CategoriaVendedorLineaAD().ObtenerCategoriaVendedorLinea(idEmpresa, idCategoria, idLinea);
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
