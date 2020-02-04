using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class AnticiposAD : DbConection
    {

        public AnticiposE LlenarEntidad(IDataReader oReader)
        {
            AnticiposE anticipos = new AnticiposE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocAnticipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.idDocAnticipo = oReader["idDocAnticipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocAnticipo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerieAnticipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.numSerieAnticipo = oReader["numSerieAnticipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerieAnticipo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocAnticipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.numDocAnticipo = oReader["numDocAnticipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocAnticipo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocFactura'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.idDocFactura = oReader["idDocFactura"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocFactura"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerieFactura'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.numSerieFactura = oReader["numSerieFactura"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerieFactura"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocFactura'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.numDocFactura = oReader["numDocFactura"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocFactura"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SubTotalAnticipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.SubTotalAnticipo = oReader["SubTotalAnticipo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SubTotalAnticipo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvAnticipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.IgvAnticipo = oReader["IgvAnticipo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvAnticipo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalAnticipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.TotalAnticipo = oReader["TotalAnticipo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalAnticipo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SubTotalSaldo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.SubTotalSaldo = oReader["SubTotalSaldo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SubTotalSaldo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvSaldo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.IgvSaldo = oReader["IgvSaldo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvSaldo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalSaldo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.TotalSaldo = oReader["TotalSaldo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalSaldo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Aplicado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				anticipos.Aplicado = oReader["Aplicado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Aplicado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.Tipo = oReader["Tipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Tipo"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEmision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.fecEmision = oReader["fecEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecEmision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Banco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.Banco = oReader["Banco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Banco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Debe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.Debe = oReader["Debe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Debe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Haber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.Haber = oReader["Haber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Haber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.indEstado = oReader["indEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalSaldo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.TotalSaldoTmp = oReader["TotalSaldo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalSaldo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Orden'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                anticipos.Orden = oReader["Orden"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Orden"]);

            return  anticipos;        
        }

        public AnticiposE InsertarAnticipos(AnticiposE anticipos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarAnticipos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = anticipos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = anticipos.idLocal;
					oComando.Parameters.Add("@idDocAnticipo", SqlDbType.VarChar, 2).Value = anticipos.idDocAnticipo;
					oComando.Parameters.Add("@numSerieAnticipo", SqlDbType.VarChar, 10).Value = anticipos.numSerieAnticipo;
					oComando.Parameters.Add("@numDocAnticipo", SqlDbType.VarChar, 10).Value = anticipos.numDocAnticipo;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = anticipos.idPersona;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = anticipos.idMoneda;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = anticipos.idArticulo;
					oComando.Parameters.Add("@idDocFactura", SqlDbType.VarChar, 2).Value = anticipos.idDocFactura;
					oComando.Parameters.Add("@numSerieFactura", SqlDbType.VarChar, 10).Value = anticipos.numSerieFactura;
					oComando.Parameters.Add("@numDocFactura", SqlDbType.VarChar, 10).Value = anticipos.numDocFactura;
					oComando.Parameters.Add("@SubTotalAnticipo", SqlDbType.Decimal).Value = anticipos.SubTotalAnticipo;
					oComando.Parameters.Add("@IgvAnticipo", SqlDbType.Decimal).Value = anticipos.IgvAnticipo;
					oComando.Parameters.Add("@TotalAnticipo", SqlDbType.Decimal).Value = anticipos.TotalAnticipo;
					oComando.Parameters.Add("@SubTotalSaldo", SqlDbType.Decimal).Value = anticipos.SubTotalSaldo;
					oComando.Parameters.Add("@IgvSaldo", SqlDbType.Decimal).Value = anticipos.IgvSaldo;
					oComando.Parameters.Add("@TotalSaldo", SqlDbType.Decimal).Value = anticipos.TotalSaldo;
					oComando.Parameters.Add("@Aplicado", SqlDbType.Bit).Value = anticipos.Aplicado;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = anticipos.Tipo;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return anticipos;
        }
        
        public AnticiposE ActualizarAnticipos(AnticiposE anticipos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarAnticipos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = anticipos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = anticipos.idLocal;
					oComando.Parameters.Add("@idDocAnticipo", SqlDbType.VarChar, 2).Value = anticipos.idDocAnticipo;
					oComando.Parameters.Add("@numSerieAnticipo", SqlDbType.VarChar, 10).Value = anticipos.numSerieAnticipo;
					oComando.Parameters.Add("@numDocAnticipo", SqlDbType.VarChar, 10).Value = anticipos.numDocAnticipo;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = anticipos.idPersona;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = anticipos.idMoneda;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = anticipos.idArticulo;
					oComando.Parameters.Add("@idDocFactura", SqlDbType.VarChar, 2).Value = anticipos.idDocFactura;
					oComando.Parameters.Add("@numSerieFactura", SqlDbType.VarChar, 10).Value = anticipos.numSerieFactura;
					oComando.Parameters.Add("@numDocFactura", SqlDbType.VarChar, 10).Value = anticipos.numDocFactura;
					//oComando.Parameters.Add("@SubTotalAnticipo", SqlDbType.Decimal).Value = anticipos.SubTotalAnticipo;
					//oComando.Parameters.Add("@IgvAnticipo", SqlDbType.Decimal).Value = anticipos.IgvAnticipo;
					//oComando.Parameters.Add("@TotalAnticipo", SqlDbType.Decimal).Value = anticipos.TotalAnticipo;
					oComando.Parameters.Add("@SubTotalSaldo", SqlDbType.Decimal).Value = anticipos.SubTotalSaldo;
					oComando.Parameters.Add("@IgvSaldo", SqlDbType.Decimal).Value = anticipos.IgvSaldo;
					oComando.Parameters.Add("@TotalSaldo", SqlDbType.Decimal).Value = anticipos.TotalSaldo;
					oComando.Parameters.Add("@Aplicado", SqlDbType.Bit).Value = anticipos.Aplicado;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = anticipos.Tipo;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return anticipos;
        }        

        public int EliminarAnticipos(Int32 idEmpresa, Int32 idLocal, String idDocAnticipo, String numSerieAnticipo, String numDocAnticipo, Int32 idPersona)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarAnticipos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idDocAnticipo", SqlDbType.VarChar, 2).Value = idDocAnticipo;
					oComando.Parameters.Add("@numSerieAnticipo", SqlDbType.VarChar, 10).Value = numSerieAnticipo;
					oComando.Parameters.Add("@numDocAnticipo", SqlDbType.VarChar, 10).Value = numDocAnticipo;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public int EliminarAnticiposDet(Int32 idEmpresa, Int32 idLocal, String idDocAnticipo, String numSerieAnticipo, String numDocAnticipo, Int32 idPersona, String idDocFactura, String numSerieFactura, String numDocFactura)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarAnticiposDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocAnticipo", SqlDbType.VarChar, 2).Value = idDocAnticipo;
                    oComando.Parameters.Add("@numSerieAnticipo", SqlDbType.VarChar, 10).Value = numSerieAnticipo;
                    oComando.Parameters.Add("@numDocAnticipo", SqlDbType.VarChar, 10).Value = numDocAnticipo;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idDocFactura", SqlDbType.VarChar, 2).Value = idDocFactura;
                    oComando.Parameters.Add("@numSerieFactura", SqlDbType.VarChar, 10).Value = numSerieFactura;
                    oComando.Parameters.Add("@numDocFactura", SqlDbType.VarChar, 10).Value = numDocFactura;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<AnticiposE> ListarAnticipos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            List<AnticiposE> listaEntidad = new List<AnticiposE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAnticipos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

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
        
        public AnticiposE ObtenerAnticipos(Int32 idEmpresa, Int32 idLocal, String idDocAnticipo, String numSerieAnticipo, String numDocAnticipo, Int32 idPersona)
        {        
            AnticiposE anticipos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAnticipos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idDocAnticipo", SqlDbType.VarChar, 2).Value = idDocAnticipo;
					oComando.Parameters.Add("@numSerieAnticipo", SqlDbType.VarChar, 10).Value = numSerieAnticipo;
					oComando.Parameters.Add("@numDocAnticipo", SqlDbType.VarChar, 10).Value = numDocAnticipo;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            anticipos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return anticipos;
        }

        public List<AnticiposE> AnticiposPorFactura(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String idDocFactura, String numSerieFactura, String numDocFactura)
        {
            List<AnticiposE> listaEntidad = new List<AnticiposE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnticiposPorFactura", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idDocFactura", SqlDbType.VarChar, 2).Value = idDocFactura;
                    oComando.Parameters.Add("@numSerieFactura", SqlDbType.VarChar, 10).Value = numSerieFactura;
                    oComando.Parameters.Add("@numDocFactura", SqlDbType.VarChar, 10).Value = numDocFactura;

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

        public List<AnticiposE> ReporteAnticipos(Int32 idEmpresa, DateTime Desde, DateTime Hasta, String idMoneda, Int32 idPersona, Boolean PorAplicar, Boolean Aplicado)
        {
            List<AnticiposE> listaEntidad = new List<AnticiposE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteAnticipos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Desde", SqlDbType.SmallDateTime).Value = Desde;
                    oComando.Parameters.Add("@Hasta", SqlDbType.SmallDateTime).Value = Hasta;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@PorAplicar", SqlDbType.Bit).Value = PorAplicar;
                    oComando.Parameters.Add("@Aplicado", SqlDbType.Bit).Value = Aplicado;

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

        public List<AnticiposE> AnticiposPorDocAnticipo(Int32 idEmpresa, Int32 idLocal, String idDocAnticipo, String numSerieAnticipo, String numDocAnticipo)
        {
            List<AnticiposE> listaEntidad = new List<AnticiposE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnticiposPorDocAnticipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocAnticipo", SqlDbType.VarChar, 2).Value = idDocAnticipo;
                    oComando.Parameters.Add("@numSerieAnticipo", SqlDbType.VarChar, 10).Value = numSerieAnticipo;
                    oComando.Parameters.Add("@numDocAnticipo", SqlDbType.VarChar, 10).Value = numDocAnticipo;

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