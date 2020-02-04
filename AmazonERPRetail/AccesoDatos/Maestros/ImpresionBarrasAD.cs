using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ImpresionBarrasAD : DbConection
    {

        public ImpresionBarrasE LlenarEntidad(IDataReader oReader)
        {
            ImpresionBarrasE impresionbarras = new ImpresionBarrasE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idImpresion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarras.idImpresion = oReader["idImpresion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idImpresion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarras.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarras.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaImpresion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarras.FechaImpresion = oReader["FechaImpresion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaImpresion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Observacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarras.Observacion = oReader["Observacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Observacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPedido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarras.idPedido = oReader["idPedido"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPedido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarras.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarras.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModficacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarras.UsuarioModficacion = oReader["UsuarioModficacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModficacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarras.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPedido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarras.codPedido = oReader["codPedido"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPedido"]);

            return  impresionbarras;        
        }

        public ImpresionBarrasE InsertarImpresionBarras(ImpresionBarrasE impresionbarras)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarImpresionBarras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = impresionbarras.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = impresionbarras.idLocal;
					oComando.Parameters.Add("@FechaImpresion", SqlDbType.SmallDateTime).Value = impresionbarras.FechaImpresion;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 150).Value = impresionbarras.Observacion;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = impresionbarras.idPedido;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = impresionbarras.UsuarioRegistro;

                    oConexion.Open();
                    impresionbarras.idImpresion = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return impresionbarras;
        }
        
        public ImpresionBarrasE ActualizarImpresionBarras(ImpresionBarrasE impresionbarras)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarImpresionBarras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresion", SqlDbType.Int).Value = impresionbarras.idImpresion;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = impresionbarras.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = impresionbarras.idLocal;
					oComando.Parameters.Add("@FechaImpresion", SqlDbType.SmallDateTime).Value = impresionbarras.FechaImpresion;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 150).Value = impresionbarras.Observacion;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = impresionbarras.idPedido;
                    oComando.Parameters.Add("@UsuarioModficacion", SqlDbType.VarChar, 20).Value = impresionbarras.UsuarioModficacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return impresionbarras;
        }        

        public int EliminarImpresionBarras(Int32 idImpresion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarImpresionBarras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresion", SqlDbType.Int).Value = idImpresion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ImpresionBarrasE> ListarImpresionBarras(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin)
        {
            List<ImpresionBarrasE> listaEntidad = new List<ImpresionBarrasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarImpresionBarras", oConexion))
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
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }
        
        public ImpresionBarrasE ObtenerImpresionBarras(Int32 idImpresion)
        {        
            ImpresionBarrasE impresionbarras = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerImpresionBarras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresion", SqlDbType.Int).Value = idImpresion;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            impresionbarras = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return impresionbarras;
        }

        public ImpresionBarrasE ImpresionBarrasPorIdPedido(Int32 idEmpresa, Int32 idLocal, Int32 idPedido)
        {
            ImpresionBarrasE impresionbarras = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ImpresionBarrasPorIdPedido", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            impresionbarras = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return impresionbarras;
        }

    }
}