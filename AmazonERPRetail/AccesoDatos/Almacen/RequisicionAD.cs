using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class RequisicionAD : DbConection
    {

        public RequisicionE LlenarEntidad(IDataReader oReader)
        {
            RequisicionE requisicion = new RequisicionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idRequisicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.idRequisicion = oReader["idRequisicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idRequisicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocalAtencion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.idLocalAtencion = oReader["idLocalAtencion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocalAtencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numRequisicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.numRequisicion = oReader["numRequisicion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numRequisicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipRequisicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.tipRequisicion = oReader["tipRequisicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipRequisicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.tipCompra = oReader["tipCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaSolicitud'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.FechaSolicitud = oReader["FechaSolicitud"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaSolicitud"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impCostoEstimado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.impCostoEstimado = oReader["impCostoEstimado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impCostoEstimado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Justificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.Justificacion = oReader["Justificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Justificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Observacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.Observacion = oReader["Observacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Observacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRequerida'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.FechaRequerida = oReader["FechaRequerida"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRequerida"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.tipEstado = oReader["tipEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipEstado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipEstadoOC'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.tipEstadoOC = oReader["tipEstadoOC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipEstadoOC"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipEstadoAtencion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.tipEstadoAtencion = oReader["tipEstadoAtencion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipEstadoAtencion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numLicitacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.numLicitacion = oReader["numLicitacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numLicitacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indLicitacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.indLicitacion = oReader["indLicitacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indLicitacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacenEntrega'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.idAlmacenEntrega = oReader["idAlmacenEntrega"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacenEntrega"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesTipRequisicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.DesTipRequisicion = oReader["DesTipRequisicion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesTipRequisicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesTipModalCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.DesTipModalCompra = oReader["DesTipModalCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesTipModalCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.DesMoneda = oReader["DesMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoCCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.tipoCCosto = oReader["tipoCCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipoCCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.DesLocal = oReader["DesLocal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesLocalAtencion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.DesLocalAtencion = oReader["DesLocalAtencion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesLocalAtencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SiglaSucursal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.SiglaSucursal = oReader["SiglaSucursal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SiglaSucursal"]);
            
            return  requisicion;        
        }

        public RequisicionE InsertarRequisicion(RequisicionE requisicion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRequisicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = requisicion.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = requisicion.idLocal;
                    oComando.Parameters.Add("@idLocalAtencion", SqlDbType.Int).Value = requisicion.idLocalAtencion;
                    oComando.Parameters.Add("@numRequisicion", SqlDbType.VarChar, 7).Value = requisicion.numRequisicion;
                    oComando.Parameters.Add("@tipRequisicion", SqlDbType.Int).Value = requisicion.tipRequisicion;
                    oComando.Parameters.Add("@tipCompra", SqlDbType.Char, 1).Value = requisicion.tipCompra;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = requisicion.idCCostos;
					oComando.Parameters.Add("@FechaSolicitud", SqlDbType.DateTime).Value = requisicion.FechaSolicitud;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = requisicion.idMoneda;
                    oComando.Parameters.Add("@impCostoEstimado", SqlDbType.Decimal).Value = requisicion.impCostoEstimado;
                    oComando.Parameters.Add("@Justificacion", SqlDbType.VarChar, 1250).Value = requisicion.Justificacion;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = requisicion.Observacion;
					oComando.Parameters.Add("@FechaRequerida", SqlDbType.DateTime).Value = requisicion.FechaRequerida;
					oComando.Parameters.Add("@tipEstado", SqlDbType.VarChar, 2).Value = requisicion.tipEstado;
					oComando.Parameters.Add("@tipEstadoOC", SqlDbType.VarChar, 2).Value = requisicion.tipEstadoOC;
					oComando.Parameters.Add("@tipEstadoAtencion", SqlDbType.VarChar, 2).Value = requisicion.tipEstadoAtencion;
					oComando.Parameters.Add("@numLicitacion", SqlDbType.VarChar, 20).Value = requisicion.numLicitacion;
					oComando.Parameters.Add("@indLicitacion", SqlDbType.Char, 1).Value = requisicion.indLicitacion;
                    oComando.Parameters.Add("@idAlmacenEntrega", SqlDbType.Int).Value = requisicion.idAlmacenEntrega;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = requisicion.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = requisicion.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = requisicion.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = requisicion.FechaModificacion;

                    oConexion.Open();
                    requisicion.idRequisicion = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return requisicion;
        }
        
        public RequisicionE ActualizarRequisicion(RequisicionE requisicion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRequisicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = requisicion.idEmpresa;
					oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = requisicion.idRequisicion;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = requisicion.idLocal;
                    oComando.Parameters.Add("@idLocalAtencion", SqlDbType.Int).Value = requisicion.idLocalAtencion;
                    oComando.Parameters.Add("@numRequisicion", SqlDbType.VarChar, 7).Value = requisicion.numRequisicion;
                    oComando.Parameters.Add("@tipRequisicion", SqlDbType.Int).Value = requisicion.tipRequisicion;
                    oComando.Parameters.Add("@tipCompra", SqlDbType.Char, 1).Value = requisicion.tipCompra;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = requisicion.idCCostos;
					oComando.Parameters.Add("@FechaSolicitud", SqlDbType.DateTime).Value = requisicion.FechaSolicitud;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = requisicion.idMoneda;
                    oComando.Parameters.Add("@impCostoEstimado", SqlDbType.Decimal).Value = requisicion.impCostoEstimado;
                    oComando.Parameters.Add("@Justificacion", SqlDbType.VarChar, 1250).Value = requisicion.Justificacion;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = requisicion.Observacion;
					oComando.Parameters.Add("@FechaRequerida", SqlDbType.DateTime).Value = requisicion.FechaRequerida;
					oComando.Parameters.Add("@tipEstado", SqlDbType.VarChar, 2).Value = requisicion.tipEstado;
					oComando.Parameters.Add("@tipEstadoOC", SqlDbType.VarChar, 2).Value = requisicion.tipEstadoOC;
					oComando.Parameters.Add("@tipEstadoAtencion", SqlDbType.VarChar, 2).Value = requisicion.tipEstadoAtencion;
					oComando.Parameters.Add("@numLicitacion", SqlDbType.VarChar, 20).Value = requisicion.numLicitacion;
					oComando.Parameters.Add("@indLicitacion", SqlDbType.Char, 1).Value = requisicion.indLicitacion;
                    oComando.Parameters.Add("@idAlmacenEntrega", SqlDbType.Int).Value = requisicion.idAlmacenEntrega;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = requisicion.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = requisicion.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = requisicion.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = requisicion.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return requisicion;
        }        

        public int EliminarRequisicion(Int32 idEmpresa, Int32 idRequisicion)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarRequisicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = idRequisicion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<RequisicionE> ListarRequisicion(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin)
        {
           List<RequisicionE> listaEntidad = new List<RequisicionE>();
           RequisicionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRequisicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;

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

        public List<RequisicionE> ListarRequisicionAprobacion(Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String tipEstado)
        {
            List<RequisicionE> listaEntidad = new List<RequisicionE>();
            RequisicionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRequisicionAprobacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@tipEstado", SqlDbType.VarChar, 2).Value = tipEstado;

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

        public RequisicionE ObtenerRequisicion(Int32 idEmpresa, Int32 idRequisicion)
        {        
            RequisicionE requisicion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerRequisicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = idRequisicion;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            requisicion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return requisicion;
        }

        public RequisicionE ActivarRequisicion(RequisicionE requisicion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActivarRequisicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = requisicion.idEmpresa;
                    oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = requisicion.idRequisicion;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = requisicion.idLocal;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return requisicion;
        }

        public List<RequisicionE> ListarRequisicionPendientes(Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String Filtro)
        {
            List<RequisicionE> listaEntidad = new List<RequisicionE>();
            RequisicionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRequisicionPendientes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@Filtro", SqlDbType.VarChar, 100).Value = Filtro;

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

        public Int32 GenerarNroRequisicion(Int32 idEmpresa, Int32 idLocal, DateTime FechaSolicitud)
        {
            Int32 NroOC = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNroRequisicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@FechaSolicitud", SqlDbType.SmallDateTime).Value = FechaSolicitud;

                    oConexion.Open();
                    NroOC = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return NroOC;
        }

    }
}