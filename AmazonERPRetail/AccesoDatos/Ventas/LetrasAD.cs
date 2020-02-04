using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class LetrasAD : DbConection
    {

        public LetrasE LlenarEntidad(IDataReader oReader)
        {
            LetrasE letras = new LetrasE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.tipCanje = oReader["tipCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.codCanje = oReader["codCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Numero'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.Numero = oReader["Numero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Numero"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Corre'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.Corre = oReader["Corre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Corre"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaVenc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.FechaVenc = oReader["FechaVenc"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaVenc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoOrigen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.MontoOrigen = oReader["MontoOrigen"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoOrigen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoRefe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.MontoRefe = oReader["MontoRefe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoRefe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GiradoA'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.GiradoA = oReader["GiradoA"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["GiradoA"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Direccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.Direccion = oReader["Direccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Direccion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Plaza'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.Plaza = oReader["Plaza"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Plaza"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Doi'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.Doi = oReader["Doi"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Doi"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Telefono'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.Telefono = oReader["Telefono"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Telefono"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Aval'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.Aval = oReader["Aval"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Aval"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DoiAval'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.DoiAval = oReader["DoiAval"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DoiAval"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TelefAval'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.TelefAval = oReader["TelefAval"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TelefAval"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DireccionAval'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.DireccionAval = oReader["DireccionAval"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DireccionAval"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Representante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.Representante = oReader["Representante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Representante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Observacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.Observacion = oReader["Observacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Observacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlanillaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.idPlanillaBanco = oReader["idPlanillaBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPlanillaBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.idVendedor = oReader["idVendedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipCondicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.idTipCondicion = oReader["idTipCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipCondicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCondicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.idCondicion = oReader["idCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCondicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letras.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Numero'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.Letra = oReader["Numero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Numero"]) + "-" + Convert.ToString(oReader["Corre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecProceso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.fecProceso = oReader["fecProceso"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecProceso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPlazaGirador'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.desPlazaGirador = oReader["desPlazaGirador"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPlazaGirador"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPlazaGiradoA'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.desPlazaGiradoA = oReader["desPlazaGiradoA"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPlazaGiradoA"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPlanillaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.codPlanillaBanco = oReader["codPlanillaBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPlanillaBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoPlanillaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letras.EstadoPlanillaBanco = oReader["EstadoPlanillaBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EstadoPlanillaBanco"]);

            return  letras;        
        }

        public LetrasE InsertarLetras(LetrasE letras)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLetras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = letras.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = letras.idLocal;
					oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = letras.tipCanje;
					oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = letras.codCanje;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = letras.Numero;
					oComando.Parameters.Add("@Corre", SqlDbType.Char, 2).Value = letras.Corre;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = letras.Fecha;
					oComando.Parameters.Add("@FechaVenc", SqlDbType.SmallDateTime).Value = letras.FechaVenc;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = letras.idMoneda;
					oComando.Parameters.Add("@MontoOrigen", SqlDbType.Decimal).Value = letras.MontoOrigen;
					oComando.Parameters.Add("@MontoRefe", SqlDbType.Decimal).Value = letras.MontoRefe;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = letras.idPersona;
					oComando.Parameters.Add("@GiradoA", SqlDbType.VarChar, 100).Value = letras.GiradoA;
					oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 100).Value = letras.Direccion;
					oComando.Parameters.Add("@Plaza", SqlDbType.VarChar, 2).Value = letras.Plaza;
					oComando.Parameters.Add("@Doi", SqlDbType.VarChar, 20).Value = letras.Doi;
					oComando.Parameters.Add("@Telefono", SqlDbType.VarChar, 15).Value = letras.Telefono;
					oComando.Parameters.Add("@Aval", SqlDbType.VarChar, 100).Value = letras.Aval;
					oComando.Parameters.Add("@DoiAval", SqlDbType.VarChar, 20).Value = letras.DoiAval;
					oComando.Parameters.Add("@TelefAval", SqlDbType.VarChar, 15).Value = letras.TelefAval;
					oComando.Parameters.Add("@DireccionAval", SqlDbType.VarChar, 100).Value = letras.DireccionAval;
					oComando.Parameters.Add("@Representante", SqlDbType.VarChar, 50).Value = letras.Representante;
					oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = letras.tipCambio;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 200).Value = letras.Observacion;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = letras.idVendedor;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = letras.idTipCondicion;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.Int).Value = letras.idCondicion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = letras.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return letras;
        }
        
        public LetrasE ActualizarLetras(LetrasE letras)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLetras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = letras.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = letras.idLocal;
					oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = letras.tipCanje;
					oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = letras.codCanje;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = letras.Numero;
					oComando.Parameters.Add("@Corre", SqlDbType.Char, 2).Value = letras.Corre;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = letras.Fecha;
					oComando.Parameters.Add("@FechaVenc", SqlDbType.SmallDateTime).Value = letras.FechaVenc;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = letras.idMoneda;
					oComando.Parameters.Add("@MontoOrigen", SqlDbType.Decimal).Value = letras.MontoOrigen;
					oComando.Parameters.Add("@MontoRefe", SqlDbType.Decimal).Value = letras.MontoRefe;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = letras.idPersona;
					oComando.Parameters.Add("@GiradoA", SqlDbType.VarChar, 100).Value = letras.GiradoA;
					oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 100).Value = letras.Direccion;
					oComando.Parameters.Add("@Plaza", SqlDbType.VarChar, 2).Value = letras.Plaza;
					oComando.Parameters.Add("@Doi", SqlDbType.VarChar, 20).Value = letras.Doi;
					oComando.Parameters.Add("@Telefono", SqlDbType.VarChar, 15).Value = letras.Telefono;
					oComando.Parameters.Add("@Aval", SqlDbType.VarChar, 100).Value = letras.Aval;
					oComando.Parameters.Add("@DoiAval", SqlDbType.VarChar, 20).Value = letras.DoiAval;
					oComando.Parameters.Add("@TelefAval", SqlDbType.VarChar, 15).Value = letras.TelefAval;
					oComando.Parameters.Add("@DireccionAval", SqlDbType.VarChar, 100).Value = letras.DireccionAval;
					oComando.Parameters.Add("@Representante", SqlDbType.VarChar, 50).Value = letras.Representante;
					oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = letras.tipCambio;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 200).Value = letras.Observacion;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = letras.idVendedor;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = letras.idTipCondicion;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.Int).Value = letras.idCondicion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = letras.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return letras;
        }

        public Int32 EliminarLetras(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLetras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = Numero;
                    oComando.Parameters.Add("@Corre", SqlDbType.Char, 2).Value = Corre;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<LetrasE> ListarLetras(Int32 idEmpresa, Int32 idLocal, String tipCanje, Int32 idPersona, String Estado, String TipoFecha, DateTime fecIni, DateTime fecFinal)
        {
            List<LetrasE> listaEntidad = new List<LetrasE>();
            LetrasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLetras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;
                    oComando.Parameters.Add("@TipoFecha", SqlDbType.Char, 1).Value = TipoFecha;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFinal", SqlDbType.SmallDateTime).Value = fecFinal;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);

                            if (!String.IsNullOrEmpty(entidad.Estado))
                            {
                                switch (entidad.Estado)
                                {
                                    case "P":
                                        entidad.desEstado = "Por Aceptar";
                                        break;
                                    case "A":
                                        entidad.desEstado = "Aceptado";
                                        break;
                                    case "B":
                                        entidad.desEstado = "Anulado";
                                        break;
                                    default:
                                        break;
                                }
                            }

                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }
        
        public LetrasE ObtenerLetras(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre)
        {        
            LetrasE letras = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLetras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
					oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = Numero;
					oComando.Parameters.Add("@Corre", SqlDbType.Char, 2).Value = Corre;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            letras = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return letras;
        }

        public List<LetrasE> ListarLetrasPorCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {
            List<LetrasE> listaEntidad = new List<LetrasE>();
            LetrasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLetrasPorCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);

                            if (!String.IsNullOrEmpty(entidad.Estado))
                            {
                                //P=Por Aceptar A=Aceptada
                                switch (entidad.Estado)
                                {
                                    case "P":
                                        entidad.desEstado = "Por Aceptar";
                                        break;
                                    case "A":
                                        entidad.desEstado = "Aceptado";
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (entidad.idMoneda == "01")
                            {
                                entidad.MontoSoles = entidad.MontoOrigen;
                                entidad.MontoDolares = entidad.MontoRefe;
                            }
                            else
                            {
                                entidad.MontoDolares = entidad.MontoOrigen;
                                entidad.MontoSoles = entidad.MontoRefe;
                            }

                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public String GenerarNumeroLetra(Int32 idEmpresa, Int32 idLocal)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNumeroLetra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = oReader["Numero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Numero"]);
                        }
                    }
                }
            }

            return Codigo;
        }

        public LetrasE RecuperarLetrasPorNumero(Int32 idEmpresa, Int32 idLocal, String Numero)
        {
            LetrasE letras = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarLetrasPorNumero", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = Numero;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            letras = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return letras;
        }

        public Int32 ActualizarEstadoDeLetra(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre, Int32? idCtaCte, Int32? idCtaCteItem, String Estado, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEstadoDeLetra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = Numero;
                    oComando.Parameters.Add("@Corre", SqlDbType.Char, 2).Value = Corre;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = idCtaCteItem;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarIdPlanillaBancoLetra(Int32 idEmpresa, Int32 idLocal, String Numero, String Corre, Int32 idPersona, Int32? idPlanillaBanco, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarIdPlanillaBancoLetra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = Numero;
                    oComando.Parameters.Add("@Corre", SqlDbType.Char, 2).Value = Corre;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idPlanillaBanco", SqlDbType.Int).Value = idPlanillaBanco;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public LetrasE ActualizarLetrasTica(LetrasE letras)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLetrasTica", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = letras.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = letras.idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = letras.tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = letras.codCanje;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = letras.Numero;
                    oComando.Parameters.Add("@Corre", SqlDbType.Char, 2).Value = letras.Corre;
                    oComando.Parameters.Add("@MontoRefe", SqlDbType.Decimal).Value = letras.MontoRefe;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = letras.tipCambio;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = letras.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return letras;
        }

        public LetrasE ObtenerLetrasPorAuxiliar(Int32 idEmpresa, Int32 idLocal, String tipCanje, String Numero, String Corre, Int32 idPersona)
        {
            LetrasE letras = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLetrasPorAuxiliar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = Numero;
                    oComando.Parameters.Add("@Corre", SqlDbType.Char, 2).Value = Corre;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int ).Value = idPersona;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            letras = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return letras;
        }

    }
}