using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class RequerimientosAD : DbConection
    {

        public RequerimientosE LlenarEntidad(IDataReader oReader)
        {
            RequerimientosE requerimientos = new RequerimientosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idRequerimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.idRequerimiento = oReader["idRequerimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idRequerimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.tipArticulo = oReader["tipArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numRequeri'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.numRequeri = oReader["numRequeri"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numRequeri"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecRequeri'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.fecRequeri = oReader["fecRequeri"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecRequeri"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPuntoReq'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.idPuntoReq = oReader["idPuntoReq"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPuntoReq"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indIngAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.indIngAlmacen = oReader["indIngAlmacen"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indIngAlmacen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DocumentoRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.DocumentoRef = oReader["DocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DocumentoRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.indEstado = oReader["indEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indEstado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numRequeri'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requerimientos.numRequeri2 = oReader["numRequeri"] == DBNull.Value ? String.Empty : String.IsNullOrWhiteSpace(oReader["numRequeri"].ToString()) ? String.Empty : "RE-" + Convert.ToString(oReader["numRequeri"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requerimientos.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            return  requerimientos;        
        }

        public RequerimientosE InsertarRequerimientos(RequerimientosE requerimientos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRequerimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = requerimientos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = requerimientos.idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = requerimientos.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = requerimientos.MesPeriodo;
					oComando.Parameters.Add("@tipArticulo", SqlDbType.Int).Value = requerimientos.tipArticulo;
					oComando.Parameters.Add("@numRequeri", SqlDbType.VarChar, 8).Value = requerimientos.numRequeri;
					oComando.Parameters.Add("@fecRequeri", SqlDbType.SmallDateTime).Value = requerimientos.fecRequeri;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = requerimientos.idAlmacen;
					oComando.Parameters.Add("@idPuntoReq", SqlDbType.Int).Value = requerimientos.idPuntoReq;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = requerimientos.idCCostos;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 250).Value = requerimientos.Glosa;
					oComando.Parameters.Add("@DocumentoRef", SqlDbType.VarChar, 20).Value = requerimientos.DocumentoRef;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = requerimientos.UsuarioRegistro;

                    oConexion.Open();
                    requerimientos.idRequerimiento = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return requerimientos;
        }
        
        public RequerimientosE ActualizarRequerimientos(RequerimientosE requerimientos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRequerimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRequerimiento", SqlDbType.Int).Value = requerimientos.idRequerimiento;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = requerimientos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = requerimientos.idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = requerimientos.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = requerimientos.MesPeriodo;
					oComando.Parameters.Add("@tipArticulo", SqlDbType.Int).Value = requerimientos.tipArticulo;
					oComando.Parameters.Add("@numRequeri", SqlDbType.VarChar, 8).Value = requerimientos.numRequeri;
					oComando.Parameters.Add("@fecRequeri", SqlDbType.SmallDateTime).Value = requerimientos.fecRequeri;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = requerimientos.idAlmacen;
					oComando.Parameters.Add("@idPuntoReq", SqlDbType.Int).Value = requerimientos.idPuntoReq;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = requerimientos.idCCostos;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 250).Value = requerimientos.Glosa;
					oComando.Parameters.Add("@indIngAlmacen", SqlDbType.Bit).Value = requerimientos.indIngAlmacen;
					oComando.Parameters.Add("@DocumentoRef", SqlDbType.VarChar, 20).Value = requerimientos.DocumentoRef;
					oComando.Parameters.Add("@indEstado", SqlDbType.VarChar, 2).Value = requerimientos.indEstado;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = requerimientos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return requerimientos;
        }        

        public int EliminarRequerimientos(Int32 idRequerimiento)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarRequerimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRequerimiento", SqlDbType.Int).Value = idRequerimiento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<RequerimientosE> ListarRequerimientos(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, Int32 idAlmacen, String idCCostos, String indEstado)
        {
           List<RequerimientosE> listaEntidad = new List<RequerimientosE>();
           RequerimientosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRequerimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = idCCostos;
                    oComando.Parameters.Add("@indEstado", SqlDbType.VarChar, 2).Value = indEstado;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }
        
        public RequerimientosE ObtenerRequerimientos(Int32 idRequerimiento)
        {        
            RequerimientosE requerimientos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerRequerimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRequerimiento", SqlDbType.Int).Value = idRequerimiento;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            requerimientos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return requerimientos;
        }

        public string CorrelativoRequerimiento(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, Int32 idPuntoReq)
        {
            string num = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CorrelativoRequerimiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@idPuntoReq", SqlDbType.Int).Value = idPuntoReq;

                    oConexion.Open();
                    num = String.Format("{0:00000000}", Int32.Parse(oComando.ExecuteScalar().ToString()));
                }
            }

            return num;
        }

    }
}