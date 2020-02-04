using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class NumControlCompraDetAD : DbConection
    {
        
        public NumControlCompraDetE LlenarEntidad(IDataReader oReader)
        {
            NumControlCompraDetE numcontrolcompradet = new NumControlCompraDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idControl'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.idControl = oReader["idControl"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idControl"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.item = oReader["item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Serie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.Serie = oReader["Serie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Serie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantDigSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.cantDigSerie = oReader["cantDigSerie"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["cantDigSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numInicial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.numInicial = oReader["numInicial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numInicial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFinal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.numFinal = oReader["numFinal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFinal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCorrelativo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.numCorrelativo = oReader["numCorrelativo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCorrelativo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantDigNumero'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.cantDigNumero = oReader["cantDigNumero"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["cantDigNumero"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompradet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  numcontrolcompradet;        
        }

        public NumControlCompraDetE InsertarNumControlCompraDet(NumControlCompraDetE numcontrolcompradet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarNumControlCompraDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = numcontrolcompradet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = numcontrolcompradet.idLocal;
					oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = numcontrolcompradet.idControl;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = numcontrolcompradet.idDocumento;
					oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = numcontrolcompradet.Serie;
					oComando.Parameters.Add("@cantDigSerie", SqlDbType.TinyInt).Value = numcontrolcompradet.cantDigSerie;
					oComando.Parameters.Add("@numInicial", SqlDbType.VarChar, 20).Value = numcontrolcompradet.numInicial;
					oComando.Parameters.Add("@numFinal", SqlDbType.VarChar, 20).Value = numcontrolcompradet.numFinal;
					oComando.Parameters.Add("@numCorrelativo", SqlDbType.VarChar, 20).Value = numcontrolcompradet.numCorrelativo;
					oComando.Parameters.Add("@cantDigNumero", SqlDbType.TinyInt).Value = numcontrolcompradet.cantDigNumero;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = numcontrolcompradet.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = numcontrolcompradet.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = numcontrolcompradet.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = numcontrolcompradet.FechaModificacion;

                    oConexion.Open();
                    numcontrolcompradet.item = Convert.ToInt32(oComando.ExecuteScalar());
                    oConexion.Close();
                }
            }

            return numcontrolcompradet;
        }
        
        public NumControlCompraDetE ActualizarNumControlCompraDet(NumControlCompraDetE numcontrolcompradet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarNumControlCompraDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = numcontrolcompradet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = numcontrolcompradet.idLocal;
					oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = numcontrolcompradet.idControl;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = numcontrolcompradet.item;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = numcontrolcompradet.idDocumento;
					oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = numcontrolcompradet.Serie;
					oComando.Parameters.Add("@cantDigSerie", SqlDbType.TinyInt).Value = numcontrolcompradet.cantDigSerie;
					oComando.Parameters.Add("@numInicial", SqlDbType.VarChar, 20).Value = numcontrolcompradet.numInicial;
					oComando.Parameters.Add("@numFinal", SqlDbType.VarChar, 20).Value = numcontrolcompradet.numFinal;
					oComando.Parameters.Add("@numCorrelativo", SqlDbType.VarChar, 20).Value = numcontrolcompradet.numCorrelativo;
					oComando.Parameters.Add("@cantDigNumero", SqlDbType.TinyInt).Value = numcontrolcompradet.cantDigNumero;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = numcontrolcompradet.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = numcontrolcompradet.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = numcontrolcompradet.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = numcontrolcompradet.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return numcontrolcompradet;
        }        

        public int EliminarNumControlCompraDet(Int32 idEmpresa, Int32 idLocal, Int32 idControl, Int32 item)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarNumControlCompraDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = idControl;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<NumControlCompraDetE> ListarNumControlCompraDet(Int32 idEmpresa, Int32 idLocal, Int32 idControl)
        {
           List<NumControlCompraDetE> listaEntidad = new List<NumControlCompraDetE>();
           NumControlCompraDetE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarNumControlCompraDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = idControl;

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
        
        public NumControlCompraDetE ObtenerNumControlCompraDet(Int32 idEmpresa, Int32 idLocal, Int32 idControl, Int32 item)
        {        
            NumControlCompraDetE numcontrolcompradet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerNumControlCompraDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = idControl;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            numcontrolcompradet = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return numcontrolcompradet;
        }

        public List<NumControlCompraDetE> ListarNumControlDocSerie(Int32 idEmpresa, Int32 idLocal, String idDocumento)
        {
            List<NumControlCompraDetE> listaEntidad = new List<NumControlCompraDetE>();
            NumControlCompraDetE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarNumControlDocSerie", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;

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

        public NumControlCompraDetE ObtenerNumControlPorSerie(Int32 idEmpresa, Int32 idLocal, Int32 item)
        {
            NumControlCompraDetE numcontrolcompradet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerNumControlPorSerie", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            numcontrolcompradet = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return numcontrolcompradet;
        }


        public NumControlCompraDetE ObtenerNumControlPorSerieDoc(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie)
        {
            NumControlCompraDetE numcontrolcompradet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerNumControlPorSerieDoc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = Serie;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            numcontrolcompradet = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return numcontrolcompradet;
        }


    }
}