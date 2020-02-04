using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class Provisiones_PorPartidaAD : DbConection
    {
        
        public Provisiones_PorPartidaE LlenarEntidad(IDataReader oReader)
        {
            Provisiones_PorPartidaE provisiones_porpartida = new Provisiones_PorPartidaE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porpartida.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porpartida.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProvision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porpartida.idProvision = oReader["idProvision"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idProvision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porpartida.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPartida'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porpartida.numVerPartida = oReader["numVerPartida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPartida"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipPartidaPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porpartida.TipPartidaPresu = oReader["TipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipPartidaPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodPartidaPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porpartida.CodPartidaPresu = oReader["CodPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porpartida.DesPartidaPresu = oReader["DesPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPartidaPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodMonedaProvision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porpartida.CodMonedaProvision = oReader["CodMonedaProvision"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodMonedaProvision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porpartida.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porpartida.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porpartida.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porpartida.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porpartida.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  provisiones_porpartida;        
        }

        public Provisiones_PorPartidaE InsertarProvisiones_PorPartida(Provisiones_PorPartidaE provisiones_porpartida)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarProvisiones_PorPartida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = provisiones_porpartida.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = provisiones_porpartida.idLocal;
					oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = provisiones_porpartida.idProvision;
					oComando.Parameters.Add("@numVerPartida", SqlDbType.VarChar, 3).Value = provisiones_porpartida.numVerPartida;
					oComando.Parameters.Add("@TipPartidaPresu", SqlDbType.VarChar, 2).Value = provisiones_porpartida.TipPartidaPresu;
					oComando.Parameters.Add("@CodPartidaPresu", SqlDbType.VarChar, 20).Value = provisiones_porpartida.CodPartidaPresu;
					oComando.Parameters.Add("@CodMonedaProvision", SqlDbType.VarChar, 2).Value = provisiones_porpartida.CodMonedaProvision;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = provisiones_porpartida.Monto;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = provisiones_porpartida.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = provisiones_porpartida.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = provisiones_porpartida.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.DateTime).Value = provisiones_porpartida.FechaModificacion;

                    oConexion.Open();
                    provisiones_porpartida.idItem = Convert.ToInt32(oComando.ExecuteScalar());
                    oConexion.Close();
                }
            }

            return provisiones_porpartida;
        }
        
        public Provisiones_PorPartidaE ActualizarProvisiones_PorPartida(Provisiones_PorPartidaE provisiones_porpartida)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarProvisiones_PorPartida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = provisiones_porpartida.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = provisiones_porpartida.idLocal;
					oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = provisiones_porpartida.idProvision;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = provisiones_porpartida.idItem;
					oComando.Parameters.Add("@numVerPartida", SqlDbType.VarChar, 3).Value = provisiones_porpartida.numVerPartida;
					oComando.Parameters.Add("@TipPartidaPresu", SqlDbType.VarChar, 2).Value = provisiones_porpartida.TipPartidaPresu;
					oComando.Parameters.Add("@CodPartidaPresu", SqlDbType.VarChar, 20).Value = provisiones_porpartida.CodPartidaPresu;
					oComando.Parameters.Add("@CodMonedaProvision", SqlDbType.VarChar, 2).Value = provisiones_porpartida.CodMonedaProvision;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = provisiones_porpartida.Monto;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = provisiones_porpartida.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = provisiones_porpartida.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = provisiones_porpartida.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.DateTime).Value = provisiones_porpartida.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return provisiones_porpartida;
        }        

        public int EliminarProvisiones_PorPartida(Int32 idEmpresa, Int32 idLocal, Int32 idProvision)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarProvisiones_PorPartida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<Provisiones_PorPartidaE> ListarProvisiones_PorPartida()
        {
           List<Provisiones_PorPartidaE> listaEntidad = new List<Provisiones_PorPartidaE>();
           Provisiones_PorPartidaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProvisiones_PorPartida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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

                oConexion.Close();
            }

            return listaEntidad;
        }
        
        public Provisiones_PorPartidaE ObtenerProvisiones_PorPartida(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, Int32 idItem)
        {        
            Provisiones_PorPartidaE provisiones_porpartida = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerProvisiones_PorPartida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            provisiones_porpartida = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return provisiones_porpartida;
        }


        public List<Provisiones_PorPartidaE> RecuperarProvisiones_PorPartidaPorId(Int32 idEmpresa, Int32 idLocal, Int32 idProvision)
        {
            List<Provisiones_PorPartidaE> listaEntidad = new List<Provisiones_PorPartidaE>();
            Provisiones_PorPartidaE Entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarProvisiones_PorPartidaPorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Entidad = LlenarEntidad(oReader);
                            listaEntidad.Add(Entidad);
                        }
                    }
                }

                oConexion.Close();
            }

            return listaEntidad;
        }




    }
}