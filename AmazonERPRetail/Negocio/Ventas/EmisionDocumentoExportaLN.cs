using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Ventas;
using Infraestructura;
//using Negocio.Base;

namespace Negocio.Maestros
{
    public class EmisionDocumentoExportaLN //: BaseLN
    {
        #region IEmisionDocumentoExporta Members

        public EmisionDocumentoExportaE InsertarEmisionDocumentoExporta(EmisionDocumentoExportaE emisiondocumentoexporta)
        {
            try
            {
                return new EmisionDocumentoExportaAD().InsertarEmisionDocumentoExporta(emisiondocumentoexporta);
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

        //public EmisionDocumentoExportaE ActualizarEmisionDocumentoExporta(EmisionDocumentoExportaE emisiondocumentoexporta)
        //{
        //    try
        //    {
        //        return new EmisionDocumentoExportaAD().ActualizarEmisionDocumentoExporta(emisiondocumentoexporta);
        //    }
        //    catch (SqlException ex)
        //    {
        //        SqlError err = ex.Errors[0];
        //        StringBuilder mensaje = new StringBuilder();

        //        switch (err.Number)
        //        {                    
        //            default:
        //                mensaje.Append("Mensaje: " + err.Message + "\n");
        //                mensaje.Append("N° Linea: " + err.LineNumber + "\n");
        //                mensaje.Append("Origen: " + err.Source + "\n");
        //                mensaje.Append("Procedimiento: " + err.Procedure + "\n");
        //                mensaje.Append("N° Error: " + err.Number);
        //                break;
        //        }

        //        throw new Exception(mensaje.ToString());
        //    }
        //}

        //public List<EmisionDocumentoExportaE> ListarEmisionDocumentoExporta()
        //{
        //    try
        //    {
        //        return new EmisionDocumentoExportaAD().ListarEmisionDocumentoExporta();
        //    }
        //    catch (SqlException ex)
        //    {
        //        SqlError err = ex.Errors[0];
        //        StringBuilder mensaje = new StringBuilder();

        //        switch (err.Number)
        //        {                    
        //            default:
        //                mensaje.Append("Mensaje: " + err.Message + "\n");
        //                mensaje.Append("N° Linea: " + err.LineNumber + "\n");
        //                mensaje.Append("Origen: " + err.Source + "\n");
        //                mensaje.Append("Procedimiento: " + err.Procedure + "\n");
        //                mensaje.Append("N° Error: " + err.Number);
        //                break;
        //        }

        //        throw new Exception(mensaje.ToString());
        //    }
        //}

        public Int32 EliminarEmisionDocumentoExporta(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String Item)
        {
            try
            {
                return new EmisionDocumentoExportaAD().EliminarEmisionDocumentoExporta(idEmpresa, idLocal, idDocumento, numSerie, numDocumento, Item);
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

        public List<EmisionDocumentoExportaE> ObtenerEmisionDocumentoExporta(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            try
            {
                return new EmisionDocumentoExportaAD().ObtenerEmisionDocumentoExporta(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
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

        #endregion
    }
}
