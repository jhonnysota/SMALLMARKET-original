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
    public class CanjeGuiasLN //: BaseLN
    {
        public CanjeGuiasE InsertarCanjeGuias(CanjeGuiasE canjeguias)
        {
            try
            {
                return new CanjeGuiasAD().InsertarCanjeGuias(canjeguias);
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

        //public CanjeGuiasE ActualizarCanjeGuias(CanjeGuiasE canjeguias)
        //{
        //    try
        //    {
        //        return new CanjeGuiasAD().ActualizarCanjeGuias(canjeguias);
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

        public Int32 EliminarCanjeGuias(Int32 idEmpresa, Int32 idLocal, String idDocumentoFact, String numSerieFact, String numDocumentoFact, String idDocumentoGuia, String numSerieGuia, String numDocumentoGuia)
        {
            try
            {
                return new CanjeGuiasAD().EliminarCanjeGuias(idEmpresa, idLocal, idDocumentoFact, numSerieFact, numDocumentoFact, idDocumentoGuia, numSerieGuia, numDocumentoGuia);
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

        //public List<CanjeGuiasE> ListarCanjeGuias()
        //{
        //    try
        //    {
        //        return new CanjeGuiasAD().ListarCanjeGuias();
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

        public List<CanjeGuiasE> ObtenerCanjeGuias(Int32 idEmpresa, Int32 idLocal, String idDocumentoFact, String numSerieFact, String numDocumentoFact)
        {
            try
            {
                return new CanjeGuiasAD().ObtenerCanjeGuias(idEmpresa, idLocal, idDocumentoFact, numSerieFact, numDocumentoFact);
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
