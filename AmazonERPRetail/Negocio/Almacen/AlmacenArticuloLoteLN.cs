using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;

using Entidades.Almacen;
using AccesoDatos.Almacen;

namespace Negocio.Almacen
{
    public class AlmacenArticuloLoteLN 
    {

        public AlmacenArticuloLoteE InsertarAlmacenArticuloLote(AlmacenArticuloLoteE almacenarticulolote)
        {
            try
            {
                return new AlmacenArticuloLoteAD().InsertarAlmacenArticuloLote(almacenarticulolote);
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

        public AlmacenArticuloLoteE ActualizarAlmacenArticuloLote(AlmacenArticuloLoteE almacenarticulolote)
        {
            try
            {
                return new AlmacenArticuloLoteAD().ActualizarAlmacenArticuloLote(almacenarticulolote);
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

        public int EliminarAlmacenArticuloLote(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen, Int32 idArticulo, String Lote)
        {
            try
            {
                return new AlmacenArticuloLoteAD().EliminarAlmacenArticuloLote(idEmpresa, AnioPeriodo, MesPeriodo, idAlmacen, idArticulo, Lote);
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

        public List<AlmacenArticuloLoteE> ListarAlmacenArticuloLote(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen, Int32 idArticulo)
        {
            try
            {
                return new AlmacenArticuloLoteAD().ListarAlmacenArticuloLote(idEmpresa, AnioPeriodo, MesPeriodo, idAlmacen, idArticulo);
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

        public AlmacenArticuloLoteE ObtenerAlmacenArticuloLote(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen, Int32 idArticulo, String Lote)
        {
            try
            {
                return new AlmacenArticuloLoteAD().ObtenerAlmacenArticuloLote(idEmpresa, AnioPeriodo, MesPeriodo, idAlmacen, idArticulo, Lote);
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

        public List<AlmacenArticuloLoteE> ListarReporteStockSLPorTipoArticulo(Int32 idEmpresa, Int32 TipoArticulo, String Anio, String Mes, Int32 indCorte, string fechaHasta)
        {
            try
            {
                return new AlmacenArticuloLoteAD().ListarReporteStockSLPorTipoArticulo(idEmpresa, TipoArticulo, Anio, Mes, indCorte, fechaHasta);
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

        public List<AlmacenArticuloLoteE> AlmacenArticuloVsSaldos(Int32 idEmpresa, String Anio, String Mes)
        {
            try
            {
                List<AlmacenArticuloLoteE> oListaDevuelta = new AlmacenArticuloLoteAD().AlmacenArticuloVsSaldos(idEmpresa, Anio, Mes);

                //Lista agrupado por Documento de Almacén
                if (oListaDevuelta.Count > 0)
                {
                    List<AlmacenArticuloLoteE> oListaAgrupada = oListaDevuelta.GroupBy(x => x.codCuentaDestino).Select(p => p.First()).ToList();

                    foreach (AlmacenArticuloLoteE item in oListaAgrupada)
                    {
                        Decimal Soles = oListaDevuelta.Where(x => x.codCuentaDestino == item.codCuentaDestino).Sum(s => Decimal.Round(s.TotalSoles, 2, MidpointRounding.AwayFromZero));
                        Decimal Dolares = oListaDevuelta.Where(x => x.codCuentaDestino == item.codCuentaDestino).Sum(s => Decimal.Round(s.TotalDolar, 2, MidpointRounding.AwayFromZero));

                        AlmacenArticuloLoteE ItemArticulo = new AlmacenArticuloLoteE()
                        {
                            idAlmacen = 1000,
                            desAlmacen = String.Empty,
                            codCuentaDestino = item.codCuentaDestino,
                            desCtaDestino = "TOTAL " + item.codCuentaDestino,
                            TotalSoles = Soles,
                            TotalDolar = Dolares
                        };

                        oListaDevuelta.Add(ItemArticulo);
                    }

                    oListaDevuelta = (from x in oListaDevuelta orderby x.codCuentaDestino, x.idAlmacen select x).ToList();
                }

                return oListaDevuelta;
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
