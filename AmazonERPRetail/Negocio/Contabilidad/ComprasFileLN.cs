using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;

namespace Negocio.Contabilidad
{
    public class ComprasFileLN
    {

        public ComprasFileE InsertarComprasFile(ComprasFileE comprasfile)
        {
            try
            {
                return new ComprasFileAD().InsertarComprasFile(comprasfile);
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

        public ComprasFileE ActualizarComprasFile(ComprasFileE comprasfile)
        {
            try
            {
                return new ComprasFileAD().ActualizarComprasFile(comprasfile);
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

        public int EliminarComprasFile(Int32 idCompraFile)
        {
            try
            {
                return new ComprasFileAD().EliminarComprasFile(idCompraFile);
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

        public List<ComprasFileE> ListarComprasFile(Int32 idEmpresa, String MostrarFile = "N")
        {
            try
            {
                List<ComprasFileE> oListaCompraFile = new ComprasFileAD().ListarComprasFile(idEmpresa);

                if (MostrarFile == "S")
                {
                    foreach (ComprasFileE item in oListaCompraFile)
                    {
                        item.FileConta = new ComprobantesFileAD().ObtenerComprobantesFile(idEmpresa, item.idComprobante, item.numFile);
                    }
                }

                return oListaCompraFile;
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

        public ComprasFileE ObtenerComprasFile(Int32 idCompraFile)
        {
            try
            {
                return new ComprasFileAD().ObtenerComprasFile(idCompraFile);
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

        public List<ComprasFileE> ComprasFileEmpresas()
        {
            try
            {
                List<ComprasFileE> ListaFile = new ComprasFileAD().ComprasFileEmpresas();

                if (ListaFile.Count == 0)
                {
                    throw new Exception("No existen datos en otra empresa.");
                }

                return ListaFile;
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

        public List<ComprasFileE> InsertComprasFileOtraEmpresa(Int32 idEmpresa, Int32 idEmpresaNuevo)
        {
            try
            {
                return new ComprasFileAD().InsertComprasFileOtraEmpresa(idEmpresa, idEmpresaNuevo);
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

        public List<ComprasFileE> ListarComprasDiarios(Int32 idEmpresa)
        {
            try
            {
                List<ComprasFileE> ListarDiarios = new ComprasFileAD().ListarComprasDiario(idEmpresa);

                foreach (ComprasFileE item in ListarDiarios)
                {
                    item.oListaFiles = new ComprasFileAD().ListarComprasDiarioFile(idEmpresa, item.idComprobante);
                }

                return ListarDiarios;
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
