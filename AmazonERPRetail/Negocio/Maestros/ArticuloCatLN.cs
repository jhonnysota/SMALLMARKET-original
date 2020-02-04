using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Maestros;
using Infraestructura.Enumerados;

namespace Negocio.Maestros
{
    public class ArticuloCatLN
    {

        public ArticuloCatE GrabarArticuloCat(ArticuloCatE categoria, EnumOpcionGrabar Opcion)
        {
            try
            {
                if (Opcion == EnumOpcionGrabar.Insertar)
                {
                    return new ArticuloCatAD().InsertarArticuloCat(categoria);
                }
                else
                {
                    return new ArticuloCatAD().ActualizarArticuloCat(categoria);
                }
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

        public List<ArticuloCatE> ListarArticuloCatArbol(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel,string filtro)
        {
            try
            {
                return new ArticuloCatAD().ListarArticuloCatArbol(idEmpresa, idTipoArticulo, numNivel,filtro);
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
        public List<ArticuloCatE> ListarArticuloCategoria(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel, string filtro)
        {
            try
            {
                return new ArticuloCatAD().ListarArticuloCategoria(idEmpresa, idTipoArticulo, numNivel, filtro);
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


        public List<ArticuloCatE> ListarCategoriasPorTipoArticulo(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel)
        {
            try
            {
                return new ArticuloCatAD().ListarCategoriasPorTipoArticulo(idEmpresa, idTipoArticulo, numNivel);
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

        public List<ArticuloCatE> ListarCategPorTipoArtiCategSup(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel, string CodCategoriaSup)
        {
            try
            {
                return new ArticuloCatAD().ListarCategPorTipoArtiCategSup(idEmpresa, idTipoArticulo, numNivel, CodCategoriaSup);
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

        public List<ArticuloCatE> ListarCategoriasPorUltNivel(Int32 idEmpresa, Int32 idTipoArticulo)
        {
            try
            {
                return new ArticuloCatAD().ListarCategoriasPorUltNivel(idEmpresa, idTipoArticulo);
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

        public Int32 EliminarArticuloCat(Int32 idEmpresa, Int32 idTipoArticulo, String CodCategoria)
        {
            try
            {
                return new ArticuloCatAD().EliminarArticuloCat(idEmpresa, idTipoArticulo, CodCategoria);
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
