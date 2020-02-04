using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class LoteAD : DbConection
    {

        public LoteE LlenarEntidad(IDataReader oReader)
        {
            LoteE lote = new LoteE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.tipMovimiento = oReader["tipMovimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.idDocumentoAlmacen = oReader["idDocumentoAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idDocumentoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indfecProceso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.indfecProceso = oReader["indfecProceso"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indfecProceso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecProceso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.fecProceso = oReader["fecProceso"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecProceso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.indPersona = oReader["indPersona"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.LoteProveedor = oReader["LoteProveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPaisOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.idPaisOrigen = oReader["idPaisOrigen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPaisOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPaisProcedencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.idPaisProcedencia = oReader["idPaisProcedencia"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPaisProcedencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Batch'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.Batch = oReader["Batch"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Batch"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorcentajeGerminacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.PorcentajeGerminacion = oReader["PorcentajeGerminacion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorcentajeGerminacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecPrueba'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.fecPrueba = oReader["fecPrueba"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecPrueba"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.PesoUnitario = oReader["PesoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PesoUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomComercial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.nomComercial = oReader["nomComercial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomComercial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codColor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.codColor = oReader["codColor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codColor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='HibOp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.HibOp = oReader["HibOp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["HibOp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Otros'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.Otros = oReader["Otros"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Otros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CaCm'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.CaCm = oReader["CaCm"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CaCm"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Patron'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.Patron = oReader["Patron"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Patron"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Observacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.Observacion = oReader["Observacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Observacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EntregadoPor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.EntregadoPor = oReader["EntregadoPor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EntregadoPor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.ruc = oReader["ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.LoteAlmacen = oReader["LoteAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPaisOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.DesPaisOrigen = oReader["DesPaisOrigen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPaisOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPaisProcedencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.DesPaisProcedencia = oReader["DesPaisProcedencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPaisProcedencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesColor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.DesColor = oReader["DesColor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesColor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SiglaLoteAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                lote.SiglaLoteAlmacen = oReader["SiglaLoteAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SiglaLoteAlmacen"]);

            return lote;
        }

        public LoteE InsertarLote(LoteE lote)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = lote.idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = lote.tipMovimiento;
                    oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = lote.idDocumentoAlmacen;
                    oComando.Parameters.Add("@indfecProceso", SqlDbType.Bit).Value = lote.indfecProceso;
                    oComando.Parameters.Add("@fecProceso", SqlDbType.SmallDateTime).Value = lote.fecProceso;
                    oComando.Parameters.Add("@indPersona", SqlDbType.Bit).Value = lote.indPersona;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = lote.idPersona;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 40).Value = lote.Lote;
                    oComando.Parameters.Add("@LoteProveedor", SqlDbType.VarChar, 40).Value = lote.LoteProveedor;
                    oComando.Parameters.Add("@LoteAlmacen", SqlDbType.VarChar, 6).Value = lote.LoteAlmacen;
                    oComando.Parameters.Add("@idPaisOrigen", SqlDbType.Int).Value = lote.idPaisOrigen;
                    oComando.Parameters.Add("@idPaisProcedencia", SqlDbType.Int).Value = lote.idPaisProcedencia;
                    oComando.Parameters.Add("@Batch", SqlDbType.VarChar, 40).Value = lote.Batch;
                    oComando.Parameters.Add("@PorcentajeGerminacion", SqlDbType.Decimal).Value = lote.PorcentajeGerminacion;
                    oComando.Parameters.Add("@fecPrueba", SqlDbType.SmallDateTime).Value = lote.fecPrueba;
                    oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = lote.PesoUnitario;
                    oComando.Parameters.Add("@nomComercial", SqlDbType.VarChar, 20).Value = lote.nomComercial;
                    oComando.Parameters.Add("@codColor", SqlDbType.Int).Value = lote.codColor;
                    oComando.Parameters.Add("@HibOp", SqlDbType.VarChar, 20).Value = lote.HibOp;
                    oComando.Parameters.Add("@Otros", SqlDbType.VarChar, 100).Value = lote.Otros;
                    oComando.Parameters.Add("@CaCm", SqlDbType.VarChar, 100).Value = lote.CaCm;
                    oComando.Parameters.Add("@Patron", SqlDbType.VarChar, 100).Value = lote.Patron;
                    oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 100).Value = lote.Observacion;
                    oComando.Parameters.Add("@EntregadoPor", SqlDbType.VarChar, 100).Value = lote.EntregadoPor;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 40).Value = lote.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return lote;
        }

        public LoteE ActualizarLote(LoteE lote)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = lote.idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = lote.tipMovimiento;
                    oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = lote.idDocumentoAlmacen;
                    oComando.Parameters.Add("@indfecProceso", SqlDbType.Bit).Value = lote.indfecProceso;
                    oComando.Parameters.Add("@fecProceso", SqlDbType.SmallDateTime).Value = lote.fecProceso;
                    oComando.Parameters.Add("@indPersona", SqlDbType.Bit).Value = lote.indPersona;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = lote.idPersona;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 40).Value = lote.Lote;
                    oComando.Parameters.Add("@LoteProveedor", SqlDbType.VarChar, 40).Value = lote.LoteProveedor;
                    oComando.Parameters.Add("@LoteAlmacen", SqlDbType.VarChar, 6).Value = lote.LoteAlmacen;
                    oComando.Parameters.Add("@idPaisOrigen", SqlDbType.Int).Value = lote.idPaisOrigen;
                    oComando.Parameters.Add("@idPaisProcedencia", SqlDbType.Int).Value = lote.idPaisProcedencia;
                    oComando.Parameters.Add("@Batch", SqlDbType.VarChar, 40).Value = lote.Batch;
                    oComando.Parameters.Add("@PorcentajeGerminacion", SqlDbType.Decimal).Value = lote.PorcentajeGerminacion;
                    oComando.Parameters.Add("@fecPrueba", SqlDbType.SmallDateTime).Value = lote.fecPrueba;
                    oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = lote.PesoUnitario;
                    oComando.Parameters.Add("@nomComercial", SqlDbType.VarChar, 20).Value = lote.nomComercial;
                    oComando.Parameters.Add("@codColor", SqlDbType.Int).Value = lote.codColor;
                    oComando.Parameters.Add("@HibOp", SqlDbType.VarChar, 20).Value = lote.HibOp;
                    oComando.Parameters.Add("@Otros", SqlDbType.VarChar, 100).Value = lote.Otros;
                    oComando.Parameters.Add("@CaCm", SqlDbType.VarChar, 100).Value = lote.CaCm;
                    oComando.Parameters.Add("@Patron", SqlDbType.VarChar, 100).Value = lote.Patron;
                    oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 100).Value = lote.Observacion;
                    oComando.Parameters.Add("@EntregadoPor", SqlDbType.VarChar, 100).Value = lote.EntregadoPor;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 40).Value = lote.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return lote;
        }

        public int EliminarLote(Int32 idEmpresa, String Lote)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 40).Value = Lote;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<LoteE> ListarLote()
        {
            List<LoteE> listaEntidad = new List<LoteE>();
            LoteE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLote", oConexion))
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
            }

            return listaEntidad;
        }

        public LoteE ObtenerLote(Int32 idEmpresa, String Lote, Int32 idAlmacen)
        {
            LoteE lote = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 40).Value = Lote;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            lote = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return lote;
        }

        public LoteE ObtenerPorLote( String Lote, Int32 idAlmacen)
        {
            LoteE lote = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPorLoteYAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 40).Value = Lote;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            lote = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return lote;
        }

        public String ObtenerMaxLoteAlmacen(Int32 idEmpresa)
        {
            String lote = "";

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMaxLoteAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oConexion.Open();

                    lote = Convert.ToString(oComando.ExecuteScalar());
                }
            }

            return lote;
        }

        public String ObtenerMaxLoteAlmacenInterno(Int32 idEmpresa)
        {
            String lote = "";

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMaxLoteAlmacenInterno", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oConexion.Open();

                    lote = Convert.ToString(oComando.ExecuteScalar());
                }
            }

            return lote;
        }

        public LoteE BuscarLoteExistente(Int32 idEmpresa, String Lote)
        {
            LoteE lote = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BuscarLoteExistente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 40).Value = Lote;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            lote = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return lote;
        }

        public Int32 ActualizarDocAlmacenLote(Int32 idEmpresa, String Lote, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarDocAlmacenLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 40).Value = Lote;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 40).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public int EliminarLotesKardexXLS(Int32 idEmpresa, String Lote)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLotesKardexXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 40).Value = Lote;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}