using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class MovimientoBancosDetAD : DbConection
    {

        public MovimientoBancosDetE LlenarEntidad(IDataReader oReader)
        {
            MovimientoBancosDetE movimientobancosdet = new MovimientoBancosDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMovBanco'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.idMovBanco = oReader["idMovBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMovBanco"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Importe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.Importe = oReader["Importe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Importe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImporteDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.ImporteDolar = oReader["ImporteDolar"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImporteDolar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TicaAuto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.TicaAuto = oReader["TicaAuto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["TicaAuto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indReparable'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.indReparable = oReader["indReparable"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indReparable"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConceptoRep'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.idConceptoRep = oReader["idConceptoRep"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConceptoRep"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desReferenciaRep'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.desReferenciaRep = oReader["desReferenciaRep"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desReferenciaRep"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.tipPartidaPresu = oReader["tipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.codPartidaPresu = oReader["codPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoviTrans'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.idMoviTrans = oReader["idMoviTrans"] == DBNull.Value ? (int?)null : Convert.ToInt32(oReader["idMoviTrans"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresaTrans'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.idEmpresaTrans = oReader["idEmpresaTrans"] == DBNull.Value ? (int?)null : Convert.ToInt32(oReader["idEmpresaTrans"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBancoTrans'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.idBancoTrans = oReader["idBancoTrans"] == DBNull.Value ? (int?)null : Convert.ToInt32(oReader["idBancoTrans"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaTrans'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.idMonedaTrans = oReader["idMonedaTrans"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaTrans"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaBancariaTrans'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.ctaBancariaTrans = oReader["ctaBancariaTrans"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaBancariaTrans"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VieneApertura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.VieneApertura = oReader["VieneApertura"] == DBNull.Value ? false : Convert.ToBoolean(oReader["VieneApertura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indExceso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.indExceso = oReader["indExceso"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indExceso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientobancosdet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.desBanco = oReader["desBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.desPartidaPresu = oReader["desPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipAccionCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancosdet.TipAccionCtaCte = oReader["TipAccionCtaCte"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipAccionCtaCte"]);

            return  movimientobancosdet;        
        }

        public MovimientoBancosDetE InsertarMovimientoBancosDet(MovimientoBancosDetE movimientobancosdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarMovimientoBancosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = movimientobancosdet.idMovBanco;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = movimientobancosdet.Item;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = movimientobancosdet.idConcepto;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = movimientobancosdet.idPersona;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = movimientobancosdet.idCCostos;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = movimientobancosdet.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = movimientobancosdet.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = movimientobancosdet.numDocumento;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = movimientobancosdet.fecDocumento;
					oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = movimientobancosdet.fecVencimiento;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = movimientobancosdet.idMoneda;
                    oComando.Parameters.Add("@Importe", SqlDbType.Decimal).Value = movimientobancosdet.Importe;
                    oComando.Parameters.Add("@ImporteDolar", SqlDbType.Decimal).Value = movimientobancosdet.ImporteDolar;
                    oComando.Parameters.Add("@TicaAuto", SqlDbType.Bit).Value = movimientobancosdet.TicaAuto;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = movimientobancosdet.tipCambio;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 100).Value = movimientobancosdet.Glosa;
					oComando.Parameters.Add("@indReparable", SqlDbType.Char, 1).Value = movimientobancosdet.indReparable;
					oComando.Parameters.Add("@idConceptoRep", SqlDbType.Int).Value = movimientobancosdet.idConceptoRep;
					oComando.Parameters.Add("@desReferenciaRep", SqlDbType.VarChar, 50).Value = movimientobancosdet.desReferenciaRep;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = movimientobancosdet.tipPartidaPresu;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = movimientobancosdet.codPartidaPresu;
                    oComando.Parameters.Add("@idEmpresaTrans", SqlDbType.Int).Value = movimientobancosdet.idEmpresaTrans;
                    oComando.Parameters.Add("@idBancoTrans", SqlDbType.Int).Value = movimientobancosdet.idBancoTrans;
                    oComando.Parameters.Add("@idMonedaTrans", SqlDbType.VarChar, 2).Value = movimientobancosdet.idMonedaTrans;
                    oComando.Parameters.Add("@ctaBancariaTrans", SqlDbType.VarChar, 20).Value = movimientobancosdet.ctaBancariaTrans;
                    oComando.Parameters.Add("@VieneApertura", SqlDbType.Bit).Value = movimientobancosdet.VieneApertura;
                    oComando.Parameters.Add("@indExceso", SqlDbType.Bit).Value = movimientobancosdet.indExceso;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = movimientobancosdet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return movimientobancosdet;
        }
        
        public MovimientoBancosDetE ActualizarMovimientoBancosDet(MovimientoBancosDetE movimientobancosdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMovimientoBancosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = movimientobancosdet.idMovBanco;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = movimientobancosdet.Item;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = movimientobancosdet.idConcepto;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = movimientobancosdet.idPersona;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = movimientobancosdet.idCCostos;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = movimientobancosdet.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = movimientobancosdet.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = movimientobancosdet.numDocumento;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = movimientobancosdet.fecDocumento;
					oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = movimientobancosdet.fecVencimiento;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = movimientobancosdet.idMoneda;
                    oComando.Parameters.Add("@Importe", SqlDbType.Decimal).Value = movimientobancosdet.Importe;
                    oComando.Parameters.Add("@ImporteDolar", SqlDbType.Decimal).Value = movimientobancosdet.ImporteDolar;
                    oComando.Parameters.Add("@TicaAuto", SqlDbType.Bit).Value = movimientobancosdet.TicaAuto;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = movimientobancosdet.tipCambio;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 100).Value = movimientobancosdet.Glosa;
					oComando.Parameters.Add("@indReparable", SqlDbType.Char, 1).Value = movimientobancosdet.indReparable;
					oComando.Parameters.Add("@idConceptoRep", SqlDbType.Int).Value = movimientobancosdet.idConceptoRep;
					oComando.Parameters.Add("@desReferenciaRep", SqlDbType.VarChar, 50).Value = movimientobancosdet.desReferenciaRep;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = movimientobancosdet.tipPartidaPresu;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = movimientobancosdet.codPartidaPresu;
                    oComando.Parameters.Add("@idEmpresaTrans", SqlDbType.Int).Value = movimientobancosdet.idEmpresaTrans;
                    oComando.Parameters.Add("@idBancoTrans", SqlDbType.Int).Value = movimientobancosdet.idBancoTrans;
                    oComando.Parameters.Add("@idMonedaTrans", SqlDbType.VarChar, 2).Value = movimientobancosdet.idMonedaTrans;
                    oComando.Parameters.Add("@ctaBancariaTrans", SqlDbType.VarChar, 20).Value = movimientobancosdet.ctaBancariaTrans;
                    oComando.Parameters.Add("@VieneApertura", SqlDbType.Bit).Value = movimientobancosdet.VieneApertura;
                    oComando.Parameters.Add("@indExceso", SqlDbType.Bit).Value = movimientobancosdet.indExceso;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = movimientobancosdet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return movimientobancosdet;
        }        

        public Int32 EliminarMovimientoBancosDet(Int32 idMovBanco, Int32 Item)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMovimientoBancosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = idMovBanco;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 EliminarMovBancosDetPorId(Int32 idMovBanco)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMovBancosDetPorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = idMovBanco;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<MovimientoBancosDetE> ListarMovimientoBancosDet(Int32 idMovBanco, Int32 idEmpresa)
        {
           List<MovimientoBancosDetE> listaEntidad = new List<MovimientoBancosDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMovimientoBancosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = idMovBanco;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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
        
        public MovimientoBancosDetE ObtenerMovimientoBancosDet(Int32 idMovBanco, Int32 Item)
        {        
            MovimientoBancosDetE movimientobancosdet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMovimientoBancosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = idMovBanco;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            movimientobancosdet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return movimientobancosdet;
        }

        public Int32 ActualizarIdMovBancosTrans(Int32 idMovBanco, Int32 idMoviTrans, Boolean Borrar = false)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarIdMovBancosTrans", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = idMovBanco;
                    oComando.Parameters.Add("@idMoviTrans", SqlDbType.Int).Value = idMoviTrans;
                    oComando.Parameters.Add("@Borrar", SqlDbType.Bit).Value = Borrar;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public MovimientoBancosDetE MovBancosDetallePorDocumento(Int32 idEmpresa, String idDocumento, String serDocumento, String numDocumento)
        {
            MovimientoBancosDetE movimientobancosdet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MovBancosDetallePorDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            movimientobancosdet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return movimientobancosdet;
        }

        public Int32 ActualizarMovBancosDetCtaCte(Int32 idMovBanco, Int32 Item, Int32? idCtaCte, Int32? idCtaCteItem)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMovBancosDetCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = idMovBanco;
                    oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = idCtaCteItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}