using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorCobrar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorCobrar
{
    public class CobranzasConciliacionAD : DbConection
    {

        public CobranzasConciliacionE LlenarEntidad(IDataReader oReader)
        {
            CobranzasConciliacionE cobranzasconciliacion = new CobranzasConciliacionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numitem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasconciliacion.numitem = oReader["numitem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numitem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasconciliacion.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasconciliacion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasconciliacion.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasconciliacion.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasconciliacion.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Operacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasconciliacion.Operacion = oReader["Operacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Operacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasconciliacion.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlanilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasconciliacion.idPlanilla = oReader["idPlanilla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPlanilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Recibo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasconciliacion.Recibo = oReader["Recibo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Recibo"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasconciliacion.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            return  cobranzasconciliacion;        
        }

        public CobranzasConciliacionE InsertarCobranzasConciliacion(CobranzasConciliacionE cobranzasconciliacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCobranzasConciliacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = cobranzasconciliacion.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cobranzasconciliacion.idEmpresa;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = cobranzasconciliacion.Fecha;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 100).Value = cobranzasconciliacion.Glosa;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = cobranzasconciliacion.Monto;
					oComando.Parameters.Add("@Operacion", SqlDbType.VarChar, 20).Value = cobranzasconciliacion.Operacion;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = cobranzasconciliacion.codCuenta;
					//oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = cobranzasconciliacion.idPlanilla;
					//oComando.Parameters.Add("@Recibo", SqlDbType.Int).Value = cobranzasconciliacion.Recibo;

                    oConexion.Open();
                    cobranzasconciliacion.numitem = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return cobranzasconciliacion;
        }
        
        public CobranzasConciliacionE ActualizarCobranzasConciliacion(CobranzasConciliacionE cobranzasconciliacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCobranzasConciliacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@numitem", SqlDbType.Int).Value = cobranzasconciliacion.numitem;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = cobranzasconciliacion.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cobranzasconciliacion.idEmpresa;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = cobranzasconciliacion.Fecha;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 100).Value = cobranzasconciliacion.Glosa;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = cobranzasconciliacion.Monto;
					oComando.Parameters.Add("@Operacion", SqlDbType.VarChar, 20).Value = cobranzasconciliacion.Operacion;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = cobranzasconciliacion.codCuenta;
					oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = cobranzasconciliacion.idPlanilla;
					oComando.Parameters.Add("@Recibo", SqlDbType.Int).Value = cobranzasconciliacion.Recibo;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return cobranzasconciliacion;
        }        

        public int EliminarCobranzasConciliacion(Int32 idPersona, Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String codCuenta)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCobranzasConciliacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar).Value = codCuenta;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<CobranzasConciliacionE> ListarCobranzasConciliacion(Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String codCuenta)
        {
            List<CobranzasConciliacionE> listaEntidad = new List<CobranzasConciliacionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCobranzasConciliacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar).Value = codCuenta;

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
        
        public CobranzasConciliacionE ObtenerCobranzasConciliacion(Int32 numitem)
        {        
            CobranzasConciliacionE cobranzasconciliacion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCobranzasConciliacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@numitem", SqlDbType.Int).Value = numitem;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            cobranzasconciliacion = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return cobranzasconciliacion;
        }

    }
}