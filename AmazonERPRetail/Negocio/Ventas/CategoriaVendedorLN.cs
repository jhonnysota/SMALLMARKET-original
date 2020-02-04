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
using AccesoDatos.Ventas;
//using Negocio.Base;

namespace Negocio.Maestros
{
    public class CategoriaVendedorLN //: BaseLN
    {

        public int GrabarCategoriaVendedor(CategoriaVendedorE categoria)
        {
            try
            {
                if(categoria.idCategoria==0)
                {
                    categoria.idCategoria = (new CategoriaVendedorAD().InsertarCategoriaVendedor(categoria) ).idCategoria;
                }
                else
                {
                    new CategoriaVendedorAD().ActualizarCategoriaVendedor(categoria);
                }

                List<CategoriaVendedorLineaE> ListarSQL = new CategoriaVendedorLineaAD().ListarCategoriaVendedorLinea(categoria.idEmpresa, categoria.idCategoria);
                List<CategoriaVendedorLineaE> ListaFRM = categoria.oListaDetalle;

                foreach(CategoriaVendedorLineaE itemSQL in ListarSQL)
                {
                    Boolean oExiste = true;

                    foreach (CategoriaVendedorLineaE itemFRM in ListaFRM)
                    {
                        if (itemSQL.idLinea == itemFRM.idLinea)
                        {
                            new CategoriaVendedorLineaAD().ActualizarCategoriaVendedorLinea(itemFRM);

                            oExiste = false;
                        }
                    }

                    if (oExiste)
                        new CategoriaVendedorLineaAD().EliminarCategoriaVendedorLinea(itemSQL.idEmpresa, itemSQL.idCategoria, itemSQL.idLinea);
                }

                

                foreach (CategoriaVendedorLineaE itemFRM in ListaFRM)
                {
                    Boolean oExiste = true;

                    foreach (CategoriaVendedorLineaE itemSQL in ListarSQL)
                    {
                        if (itemSQL.idLinea == itemFRM.idLinea)
                            oExiste = false;
                    }

                    if (oExiste)
                        new CategoriaVendedorLineaAD().InsertarCategoriaVendedorLinea(itemFRM);
                }

                return 0;
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

        public CategoriaVendedorE InsertarCategoriaVendedor(CategoriaVendedorE categoria)
        {
            try
            {
                return new CategoriaVendedorAD().InsertarCategoriaVendedor(categoria);
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

        public CategoriaVendedorE ActualizarCategoriaVendedor(CategoriaVendedorE categoria)
        {
            try
            {
                return new CategoriaVendedorAD().ActualizarCategoriaVendedor(categoria);
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

        public int EliminarCategoriaVendedor(Int32 idEmpresa, Int32 idCategoria)
        {
            try
            {
                return new CategoriaVendedorAD().EliminarCategoriaVendedor(idEmpresa, idCategoria);
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

        public List<CategoriaVendedorE> ListarCategoriaVendedor(string paramBusquedad)
        {
            try
            {
                return new CategoriaVendedorAD().ListarCategoriaVendedor(paramBusquedad);
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

        public CategoriaVendedorE ObtenerCategoriaVendedor(Int32 idEmpresa, int idCategoria, string codCategoria)
        {
            try
            {
                return new CategoriaVendedorAD().ObtenerCategoriaVendedor(idEmpresa, idCategoria, codCategoria);
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
