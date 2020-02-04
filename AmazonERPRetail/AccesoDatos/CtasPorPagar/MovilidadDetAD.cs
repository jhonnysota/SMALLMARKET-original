using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class MovilidadDetAD : DbConection
    {
        
        public MovilidadDetE LlenarEntidad(IDataReader oReader)
        {
            MovilidadDetE movilidaddet = new MovilidadDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidaddet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidaddet.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMovilidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidaddet.idMovilidad = oReader["idMovilidad"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMovilidad"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidaddet.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidaddet.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidaddet.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Desplazamiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidaddet.Desplazamiento = oReader["Desplazamiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Desplazamiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MotivoDestino'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidaddet.MotivoDestino = oReader["MotivoDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MotivoDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidaddet.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoAceptado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidaddet.MontoAceptado = oReader["MontoAceptado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoAceptado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoReparado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidaddet.MontoReparado = oReader["MontoReparado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoReparado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidaddet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidaddet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidaddet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidaddet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidaddet.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidaddet.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidaddet.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidaddet.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            return  movilidaddet;        
        }

        public MovilidadDetE InsertarMovilidadDet(MovilidadDetE movilidaddet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarMovilidadDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = movilidaddet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = movilidaddet.idLocal;
					oComando.Parameters.Add("@idMovilidad", SqlDbType.Int).Value = movilidaddet.idMovilidad;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = movilidaddet.Fecha.Date;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = movilidaddet.idCCostos;
                    oComando.Parameters.Add("@Desplazamiento", SqlDbType.VarChar, 200).Value = movilidaddet.Desplazamiento;
                    oComando.Parameters.Add("@MotivoDestino", SqlDbType.VarChar, 500).Value = movilidaddet.MotivoDestino;
                    oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = movilidaddet.Monto;
                    oComando.Parameters.Add("@indReparado", SqlDbType.Bit).Value = movilidaddet.indReparado;
                    oComando.Parameters.Add("@MontoAceptado", SqlDbType.Decimal).Value = movilidaddet.MontoAceptado;
                    oComando.Parameters.Add("@MontoReparado", SqlDbType.Decimal).Value = movilidaddet.MontoReparado;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = movilidaddet.UsuarioRegistro;

                    oConexion.Open();
                    movilidaddet.idItem = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return movilidaddet;
        }
        
        public MovilidadDetE ActualizarMovilidadDet(MovilidadDetE movilidaddet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMovilidadDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = movilidaddet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = movilidaddet.idLocal;
					oComando.Parameters.Add("@idMovilidad", SqlDbType.Int).Value = movilidaddet.idMovilidad;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = movilidaddet.idItem;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = movilidaddet.Fecha.Date;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = movilidaddet.idCCostos;
                    oComando.Parameters.Add("@Desplazamiento", SqlDbType.VarChar, 200).Value = movilidaddet.Desplazamiento;
                    oComando.Parameters.Add("@MotivoDestino", SqlDbType.VarChar, 500).Value = movilidaddet.MotivoDestino;
                    oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = movilidaddet.Monto;
                    oComando.Parameters.Add("@indReparado", SqlDbType.Bit).Value = movilidaddet.indReparado;
                    oComando.Parameters.Add("@MontoAceptado", SqlDbType.Decimal).Value = movilidaddet.MontoAceptado;
                    oComando.Parameters.Add("@MontoReparado", SqlDbType.Decimal).Value = movilidaddet.MontoReparado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = movilidaddet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return movilidaddet;
        }        

        public int EliminarMovilidadDet(Int32 idEmpresa, Int32 idLocal, Int32 idMovilidad, Int32 idItem)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMovilidadDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idMovilidad", SqlDbType.Int).Value = idMovilidad;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<MovilidadDetE> ListarMovilidadDet(Int32 idEmpresa, Int32 idLocal, Int32 idMovilidad)
        {
           List<MovilidadDetE> listaEntidad = new List<MovilidadDetE>();
           MovilidadDetE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMovilidadDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idMovilidad", SqlDbType.Int).Value = idMovilidad;

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
        
        public MovilidadDetE ObtenerMovilidadDet(Int32 idEmpresa, Int32 idLocal, Int32 idMovilidad, Int32 idItem)
        {        
            MovilidadDetE movilidaddet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMovilidadDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idMovilidad", SqlDbType.Int).Value = idMovilidad;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            movilidaddet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return movilidaddet;
        }

        public List<MovilidadDetE> MovilidadDetReporte(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin)
        {
            List<MovilidadDetE> listaEntidad = new List<MovilidadDetE>();
            MovilidadDetE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MovilidadDetReporte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni.Date;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin.Date;

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

    }
}