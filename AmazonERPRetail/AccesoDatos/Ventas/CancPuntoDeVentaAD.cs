using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class CancPuntoDeVentaAD : DbConection
    {

        public CancPuntoDeVentaE LlenarEntidad(IDataReader oReader)
        {
            CancPuntoDeVentaE ptv = new CancPuntoDeVentaE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ptv.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ptv.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ptv.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ptv.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ptv.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ptv.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ptv.totTotal = oReader["totTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMedioPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ptv.idMedioPago = oReader["idMedioPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMedioPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ptv.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaRecibida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ptv.idMonedaRecibida = oReader["idMonedaRecibida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaRecibida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoRecibido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ptv.MontoRecibido = oReader["MontoRecibido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoRecibido"]);


            return ptv;
        }

        public List<CancPuntoDeVentaE> ListarCancPuntoDeVenta(Int32 idEmpresa , DateTime Fecha , String PuntoVenta)
        {
            List<CancPuntoDeVentaE> listaEntidad = new List<CancPuntoDeVentaE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteCancelacionPuntoVenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    oComando.Parameters.Add("@PuntoVenta", SqlDbType.VarChar,2).Value = PuntoVenta;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

    }
}
