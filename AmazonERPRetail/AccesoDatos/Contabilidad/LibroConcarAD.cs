using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class LibroConcarAD : DbConection
    {
        
        public LibroConcarE LlenarEntidad(IDataReader oReader)
        {
            LibroConcarE libroconcar = new LibroConcarE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				libroconcar.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='csubdia'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				libroconcar.csubdia = oReader["csubdia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["csubdia"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombre'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				libroconcar.nombre = oReader["nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nombre"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				libroconcar.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				libroconcar.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				libroconcar.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				libroconcar.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				libroconcar.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				libroconcar.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdComprobanteDes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                libroconcar.IdComprobanteDes = oReader["IdComprobanteDes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["IdComprobanteDes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFileDes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                libroconcar.numFileDes = oReader["numFileDes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFileDes"]);

            return  libroconcar;        
        }

        public LibroConcarE Insertarlibroconcar(LibroConcarE libroconcar)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Insertarlibroconcar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = libroconcar.idEmpresa;
					oComando.Parameters.Add("@csubdia", SqlDbType.VarChar, 10).Value = libroconcar.csubdia;
					oComando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = libroconcar.nombre;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = libroconcar.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = libroconcar.numFile;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = libroconcar.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = libroconcar.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = libroconcar.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = libroconcar.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return libroconcar;
        }
        
        public LibroConcarE Actualizarlibroconcar(LibroConcarE libroconcar)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Actualizarlibroconcar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = libroconcar.idEmpresa;
					oComando.Parameters.Add("@csubdia", SqlDbType.VarChar, 10).Value = libroconcar.csubdia;
					oComando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = libroconcar.nombre;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = libroconcar.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = libroconcar.numFile;
					//oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = libroconcar.UsuarioRegistro;
					//oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = libroconcar.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = libroconcar.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return libroconcar;
        }        

        public int Eliminarlibroconcar(Int32 idEmpresa, String csubdia)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Eliminarlibroconcar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@csubdia", SqlDbType.VarChar, 10).Value = csubdia;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<LibroConcarE> Listarlibroconcar(Int32 idEmpresa)
        {
           List<LibroConcarE> listaEntidad = new List<LibroConcarE>();
           LibroConcarE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Listarlibroconcar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
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
        
        public LibroConcarE Obtenerlibroconcar(Int32 idEmpresa, String csubdia)
        {        
            LibroConcarE libroconcar = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Obtenerlibroconcar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@csubdia", SqlDbType.VarChar, 10).Value = csubdia;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            libroconcar = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return libroconcar;
        }

    }
}