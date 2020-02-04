using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Maestros;
using Infraestructura.Enumerados;

namespace Negocio.Maestros
{
    public class ArticuloEstrucLN
    {

        public ArticuloEstrucE GrabarArticuloEstruc(ArticuloEstrucE articulo, EnumOpcionGrabar Opcion, ArticuloEstrucE ArticuloEstrucAnte = null)
        {
            try
            {
                if (Opcion == EnumOpcionGrabar.Insertar)
                {
                    return new ArticuloEstrucAD().InsertarArticuloEstruc(articulo);
                }
                else
                {
                    if (ArticuloEstrucAnte != null)
                    {
                        new ArticuloEstrucAD().EliminarArticuloEstruc(ArticuloEstrucAnte.idEmpresa, ArticuloEstrucAnte.idTipoArticulo, ArticuloEstrucAnte.numNivel);
                    }

                    return new ArticuloEstrucAD().InsertarArticuloEstruc(articulo);
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

        public List<ArticuloEstrucE> ListarArticuloEstruc(Int32 idEmpresa, Int32 idTipoArticulo)
        {
            try
            {
                return new ArticuloEstrucAD().ListarArticuloEstruc(idEmpresa,idTipoArticulo);
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

        public Int32 EliminarArticuloEstruc(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel)
        {
            try
            {
                return new ArticuloEstrucAD().EliminarArticuloEstruc(idEmpresa, idTipoArticulo, numNivel);
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
