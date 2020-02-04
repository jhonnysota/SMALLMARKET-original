using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ArticuloServAD : DbConection
    {

        public ArticuloServE LlenarEntidad(IDataReader oReader)
        {
            ArticuloServE articuloserv = new ArticuloServE();
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);
	
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloserv.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticuloLargo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloserv.nomArticuloLargo = oReader["nomArticuloLargo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticuloLargo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomCorto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloserv.nomCorto = oReader["nomCorto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomCorto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codBarra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloserv.codBarra = oReader["codBarra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codBarra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codUniMedAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codUniMedAlmacen = oReader["codUniMedAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codUniMedAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUniMedEnvase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.idUniMedEnvase = oReader["idUniMedEnvase"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUniMedEnvase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTipoMedPresentacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codTipoMedPresentacion = oReader["codTipoMedPresentacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codTipoMedPresentacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codUniMedPresentacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codUniMedPresentacion = oReader["codUniMedPresentacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codUniMedPresentacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Contenido = oReader["Contenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Contenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Capacidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Capacidad = oReader["Capacidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Capacidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PesoUnitario = oReader["PesoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PesoUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCategoria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codCategoria = oReader["codCategoria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCategoria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indLineaVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.indLineaVenta = oReader["indLineaVenta"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indLineaVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codLineaVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codLineaVenta = oReader["codLineaVenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codLineaVenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagActivo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloserv.flagActivo = oReader["flagActivo"] == DBNull.Value ? true : Convert.ToBoolean(oReader["flagActivo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecCese'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloserv.fecCese = oReader["fecCese"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecCese"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Combinar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Combinar = oReader["Combinar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Combinar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreReal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.NombreReal = oReader["NombreReal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreReal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreImagen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.NombreImagen = oReader["NombreImagen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreImagen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Extension'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Extension = oReader["Extension"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Extension"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codModelo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codModelo = oReader["codModelo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codModelo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codMarca'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codMarca = oReader["codMarca"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codMarca"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.indDetraccion = oReader["indDetraccion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.tipDetraccion = oReader["tipDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCodSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.indCodSunat = oReader["indCodSunat"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCodSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodigoSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.CodigoSunat = oReader["CodigoSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodigoSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indReceta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.indReceta = oReader["indReceta"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indReceta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloserv.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloserv.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloserv.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloserv.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //EXTENSIONES
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre_Categoria_Principal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Nombre_Categoria_Principal = oReader["Nombre_Categoria_Principal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre_Categoria_Principal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomUMedida = oReader["nomUMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedida"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCategoria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desCategoria = oReader["desCategoria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCategoria"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLinea'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desLinea = oReader["desLinea"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLinea"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desTipoArticulo = oReader["desTipoArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomUMedidaPres = oReader["nomUMedidaPres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaAdm'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codCuentaAdm = oReader["codCuentaAdm"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaAdm"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaVta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codCuentaVta = oReader["codCuentaVta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaVta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaPro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codCuentaPro = oReader["codCuentaPro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaPro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SKU'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.SKU = oReader["SKU"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SKU"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaEnv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomUMedidaEnv = oReader["nomUMedidaEnv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaEnv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nemo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Nemo = oReader["Nemo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nemo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Barras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Barras = oReader["Barras"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Barras"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DescripcionGeneral'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.DescripcionGeneral = oReader["DescripcionGeneral"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DescripcionGeneral"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desModelo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desModelo = oReader["desModelo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desModelo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMarca'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desMarca = oReader["desMarca"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMarca"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomTipoUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomTipoUMedida = oReader["nomTipoUMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomTipoUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomTipoUMedidaEnv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomTipoUMedidaEnv = oReader["nomTipoUMedidaEnv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomTipoUMedidaEnv"]);


            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticuloComponente'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codModelo = oReader["idArticuloComponente"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticuloComponente"]);

            return articuloserv;        
        }

        public ArticuloServE LlenarListaPrecioVenta(IDataReader oReader)
        {
            ArticuloServE articuloserv = new ArticuloServE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticuloLargo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomArticuloLargo = oReader["nomArticuloLargo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticuloLargo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomCorto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomCorto = oReader["nomCorto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomCorto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codBarra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codBarra = oReader["codBarra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codBarra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codUniMedAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codUniMedAlmacen = oReader["codUniMedAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codUniMedAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUniMedEnvase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.idUniMedEnvase = oReader["idUniMedEnvase"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUniMedEnvase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTipoMedPresentacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codTipoMedPresentacion = oReader["codTipoMedPresentacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codTipoMedPresentacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codUniMedPresentacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codUniMedPresentacion = oReader["codUniMedPresentacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codUniMedPresentacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Contenido = oReader["Contenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Contenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Capacidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Capacidad = oReader["Capacidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Capacidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioBruto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PrecioBruto = oReader["PrecioBruto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioBruto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorDscto1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PorDscto1 = oReader["PorDscto1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorDscto1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorDscto2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PorDscto2 = oReader["PorDscto2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorDscto2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorDscto3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PorDscto3 = oReader["PorDscto3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorDscto3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDscto1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.MontoDscto1 = oReader["MontoDscto1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDscto1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDscto2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.MontoDscto2 = oReader["MontoDscto2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDscto2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDscto3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.MontoDscto3 = oReader["MontoDscto3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDscto3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioValorVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PrecioValorVenta = oReader["PrecioValorVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioValorVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flgisc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.flgisc = oReader["flgisc"] == DBNull.Value ? false : Convert.ToBoolean(oReader["flgisc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoImpSelectivo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.TipoImpSelectivo = oReader["TipoImpSelectivo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoImpSelectivo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porisc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.porisc = oReader["porisc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porisc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='isc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.isc = oReader["isc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["isc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flgigv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.flgigv = oReader["flgigv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["flgigv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porigv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.porigv = oReader["porigv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porigv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='igv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.igv = oReader["igv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["igv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PrecioVenta = oReader["PrecioVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioVentaConte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PrecioVentaConte = oReader["PrecioVentaConte"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioVentaConte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioBrutoConte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PrecioBrutoConte = oReader["PrecioBrutoConte"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioBrutoConte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='conLote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.conLote = oReader["conLote"] == DBNull.Value ? false : Convert.ToBoolean(oReader["conLote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idListaPrecio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.idListaPrecio = oReader["idListaPrecio"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idListaPrecio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Stock'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Stock = oReader["Stock"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Stock"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='StockDetalle'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.StockDetalle = oReader["StockDetalle"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["StockDetalle"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.LoteProveedor = oReader["LoteProveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.indDetraccion = oReader["indDetraccion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.tipDetraccion = oReader["tipDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codMarca'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codMarca = oReader["codMarca"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codMarca"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PrecioD = oReader["PrecioD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorDsctoD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PorDsctoD = oReader["PorDsctoD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorDsctoD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDsctoD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.MontoDsctoD = oReader["MontoDsctoD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDsctoD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioValorVentaD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PrecioValorVentaD = oReader["PrecioValorVentaD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioValorVentaD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FlgIgvD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.FlgIgvD = oReader["FlgIgvD"] == DBNull.Value ? false : Convert.ToBoolean(oReader["FlgIgvD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorIgvD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PorIgvD = oReader["PorIgvD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorIgvD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.IgvD = oReader["IgvD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioVentaD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.PrecioVentaD = oReader["PrecioVentaD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioVentaD"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomUMedida = oReader["nomUMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaEnv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomUMedidaEnv = oReader["nomUMedidaEnv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaEnv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomUMedidaPres = oReader["nomUMedidaPres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMarca'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desMarca = oReader["desMarca"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMarca"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomTipoUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomTipoUMedida = oReader["nomTipoUMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomTipoUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomTipoUMedidaEnv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomTipoUMedidaEnv = oReader["nomTipoUMedidaEnv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomTipoUMedidaEnv"]);

            return articuloserv;
        }

        public ArticuloServE InsertarArticuloServ(ArticuloServE articuloserv)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarArticuloServ", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articuloserv.idEmpresa;
                    oComando.Parameters.Add("@codArticulo", SqlDbType.VarChar, 20).Value = articuloserv.codArticulo;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 100).Value = articuloserv.nomArticulo;
                    oComando.Parameters.Add("@nomArticuloLargo", SqlDbType.VarChar, 500).Value = articuloserv.nomArticuloLargo;
                    oComando.Parameters.Add("@nomCorto", SqlDbType.VarChar, 20).Value = articuloserv.nomCorto;
                    oComando.Parameters.Add("@codBarra", SqlDbType.VarChar, 20).Value = articuloserv.codBarra;
                    oComando.Parameters.Add("@codUniMedAlmacen", SqlDbType.Int).Value = articuloserv.codUniMedAlmacen;
                    oComando.Parameters.Add("@idUniMedEnvase", SqlDbType.Int).Value = articuloserv.idUniMedEnvase;
                    oComando.Parameters.Add("@codUniMedPresentacion", SqlDbType.Int).Value = articuloserv.codUniMedPresentacion;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = articuloserv.idTipoArticulo;
                    oComando.Parameters.Add("@codCategoria", SqlDbType.VarChar, 20).Value = articuloserv.codCategoria;
                    oComando.Parameters.Add("@Contenido", SqlDbType.Decimal).Value = articuloserv.Contenido;
                    oComando.Parameters.Add("@Capacidad", SqlDbType.Decimal).Value = articuloserv.Capacidad;
                    oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = articuloserv.PesoUnitario;
                    oComando.Parameters.Add("@indLineaVenta", SqlDbType.Bit).Value = articuloserv.indLineaVenta;
                    oComando.Parameters.Add("@codLineaVenta", SqlDbType.VarChar, 2).Value = articuloserv.codLineaVenta;
                    oComando.Parameters.Add("@Combinar", SqlDbType.Bit).Value = articuloserv.Combinar;
                    oComando.Parameters.Add("@NombreReal", SqlDbType.VarChar, 100).Value = articuloserv.NombreReal;
                    oComando.Parameters.Add("@NombreImagen", SqlDbType.VarChar, 100).Value = articuloserv.NombreImagen;
                    oComando.Parameters.Add("@Extension", SqlDbType.VarChar, 5).Value = articuloserv.Extension;
                    oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = articuloserv.indDetraccion;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = articuloserv.tipDetraccion;
                    oComando.Parameters.Add("@codModelo", SqlDbType.Int).Value = articuloserv.codModelo;
                    oComando.Parameters.Add("@codMarca", SqlDbType.Int).Value = articuloserv.codMarca;
                    oComando.Parameters.Add("@indCodSunat", SqlDbType.Bit).Value = articuloserv.indCodSunat;
                    oComando.Parameters.Add("@CodigoSunat", SqlDbType.VarChar, 10).Value = articuloserv.CodigoSunat;
                    oComando.Parameters.Add("@indReceta", SqlDbType.Bit).Value = articuloserv.indReceta;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = articuloserv.UsuarioRegistro;

                    oConexion.Open();
                    articuloserv.idArticulo = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return articuloserv;
        }

        public ArticuloServE ActualizarArticuloServ(ArticuloServE articuloserv)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarArticuloServ", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articuloserv.idEmpresa;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = articuloserv.idArticulo;
                    oComando.Parameters.Add("@codArticulo", SqlDbType.VarChar, 20).Value = articuloserv.codArticulo;
					oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 100).Value = articuloserv.nomArticulo;
					oComando.Parameters.Add("@nomArticuloLargo", SqlDbType.VarChar, 500).Value = articuloserv.nomArticuloLargo;
					oComando.Parameters.Add("@nomCorto", SqlDbType.VarChar, 20).Value = articuloserv.nomCorto;
					oComando.Parameters.Add("@codBarra", SqlDbType.VarChar, 20).Value = articuloserv.codBarra;
					oComando.Parameters.Add("@codUniMedAlmacen", SqlDbType.Int).Value = articuloserv.codUniMedAlmacen;
                    oComando.Parameters.Add("@idUniMedEnvase", SqlDbType.Int).Value = articuloserv.idUniMedEnvase;
                    oComando.Parameters.Add("@codUniMedPresentacion", SqlDbType.Int).Value = articuloserv.codUniMedPresentacion;
                    oComando.Parameters.Add("@Contenido", SqlDbType.Decimal).Value = articuloserv.Contenido;
                    oComando.Parameters.Add("@Capacidad", SqlDbType.Decimal).Value = articuloserv.Capacidad;
                    oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = articuloserv.PesoUnitario;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = articuloserv.idTipoArticulo;
                    oComando.Parameters.Add("@codCategoria", SqlDbType.VarChar, 20).Value = articuloserv.codCategoria;
                    oComando.Parameters.Add("@indLineaVenta", SqlDbType.Bit).Value = articuloserv.indLineaVenta;
                    oComando.Parameters.Add("@codLineaVenta", SqlDbType.VarChar, 2).Value = articuloserv.codLineaVenta;
                    oComando.Parameters.Add("@Combinar", SqlDbType.Bit).Value = articuloserv.Combinar;
                    oComando.Parameters.Add("@NombreReal", SqlDbType.VarChar, 100).Value = articuloserv.NombreReal;
                    oComando.Parameters.Add("@NombreImagen", SqlDbType.VarChar, 100).Value = articuloserv.NombreImagen;
                    oComando.Parameters.Add("@Extension", SqlDbType.VarChar, 5).Value = articuloserv.Extension;
                    oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = articuloserv.indDetraccion;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = articuloserv.tipDetraccion;
                    oComando.Parameters.Add("@codModelo", SqlDbType.Int).Value = articuloserv.codModelo;
                    oComando.Parameters.Add("@codMarca", SqlDbType.Int).Value = articuloserv.codMarca;
                    oComando.Parameters.Add("@indCodSunat", SqlDbType.Bit).Value = articuloserv.indCodSunat;
                    oComando.Parameters.Add("@CodigoSunat", SqlDbType.VarChar, 10).Value = articuloserv.CodigoSunat;
                    oComando.Parameters.Add("@indReceta", SqlDbType.Bit).Value = articuloserv.indReceta;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = articuloserv.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articuloserv;
        }        

        public Int32 EliminarArticuloServ(Int32 idEmpresa, Int32 idArticulo)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarArticuloServ", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ArticuloServE> ListarArticuloServ(Int32 idEmpresa, Int32 idTipoArticulo, string codCategoria, string nomArticulo, Boolean Incluir)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloServ", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@codCategoria", SqlDbType.VarChar, 20).Value = codCategoria;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 50).Value = nomArticulo;
                    oComando.Parameters.Add("@Incluir", SqlDbType.Bit).Value = Incluir;

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

        public List<ArticuloServE> ListarArticulosBusqueda(Int32 idEmpresa, Int32 idTipoArticulo, String Filtro)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticulosBusqueda", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@Filtro", SqlDbType.VarChar, 100).Value = Filtro;

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

        public ArticuloServE ObtenerArticuloServ(Int32 idEmpresa, Int32 idArticulo)
        {        
            ArticuloServE articuloserv = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerArticuloServ", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            articuloserv = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return articuloserv;        
        }

        public List<ArticuloServE> BuscarArticuloDescripcion(Int32 idEmpresa, String descripcion)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloPorDescripcion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@descripcion", SqlDbType.VarChar, 100).Value = descripcion;

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

        public List<ArticuloServE> ArticuloReporteExportacion(Int32 idEmpresa, Int32 tipoArticulo)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteArticulos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipoArticulo", SqlDbType.Int).Value = tipoArticulo;

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

        public List<ArticuloServE> ListarArticuloServDetalle(Int32 idEmpresa, Int32 idTipoArticulo, Int32 idTipo, String codCategoria, Boolean Incluir)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloServDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@idTipo", SqlDbType.Int).Value = idTipo;
                    oComando.Parameters.Add("@codCategoria", SqlDbType.VarChar,20).Value = codCategoria;
                    oComando.Parameters.Add("@Incluir", SqlDbType.Bit).Value = Incluir;

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

        public List<ArticuloServE> ListarArticuloServReporte(Int32 idEmpresa, Int32 idTipoArticulo)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloServReporte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;

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

        public Int32 AnularArticuloServ(Int32 idEmpresa, Int32 idArticulo)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularArticuloServ", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 CorrelativoArticulo(Int32 idEmpresa, String codCategoria)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CorrelativoArticulo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@codCategoria", SqlDbType.VarChar, 20).Value = codCategoria;

                    oConexion.Open();
                    resp = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return resp;
        }

        public ArticuloServE ObtenerArticuloPorCodBarra(Int32 idEmpresa, String CodBarra)
        {
            ArticuloServE articuloserv = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerArticuloPorCodBarra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@CodBarra", SqlDbType.VarChar, 100).Value = CodBarra;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            articuloserv = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return articuloserv;
        }

        public ArticuloServE ObteneridArticuloPorCodArticulo(Int32 idEmpresa, String CodArticulo)
        {
            ArticuloServE articuloserv = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObteneridArticuloPorCodArticulo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@CodArticulo", SqlDbType.VarChar, 20).Value = CodArticulo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            articuloserv = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return articuloserv;
        }

        public List<ArticuloServE> ListarArticulosPorFiltro(Int32 idEmpresa, Int32 idTipoArticulo, String codArticulo, String nomArticulo)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();
            ArticuloServE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticulosPorFiltro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@codArticulo", SqlDbType.VarChar, 100).Value = codArticulo;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 100).Value = nomArticulo;

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

        public List<ArticuloServE> ListarArticulosPorFiltroArticuloYLote(Int32 idEmpresa, Int32 idTipoArticulo, String codArticulo, String nomArticulo,String Lote)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();
            ArticuloServE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticulosPorFiltroArticuloYLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@codArticulo", SqlDbType.VarChar, 100).Value = codArticulo;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 100).Value = nomArticulo;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 40).Value = Lote;

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

        public List<ArticuloServE> ListarArticulosPV(Int32 idEmpresa, String Nemo, Int32 idListaPrecio)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticulosPV", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Nemo", SqlDbType.VarChar, 20).Value = Nemo;
                    oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = idListaPrecio;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarListaPrecioVenta(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public String ObtenerCodigoBarras(Int32 idEmpresa, Int32 idArticulo)
        {
            String Barritas = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCodigoBarras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if(oReader.Read())
                        {
                            Barritas = oReader["Barras"].ToString();
                        }
                    }
                }
            }

            return Barritas;
        }

        public List<ArticuloServE> ArticulosPorListaPrecio(Int32 idEmpresa, Int32 idTipoArticulo, String codArticulo, String nomArticulo, Int32 idListaPrecio)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ArticulosPorListaPrecio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@codArticulo", SqlDbType.VarChar, 20).Value = codArticulo;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 100).Value = nomArticulo;
                    oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = idListaPrecio;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarListaPrecioVenta(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public ArticuloServE UnidMedidasArticulos(Int32 idEmpresa, Int32 idArticulo)
        {
            ArticuloServE articuloserv = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_UnidMedidasArticulos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            articuloserv = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return articuloserv;
        }

        public ArticuloServE ArticuloPorNombreCorto(Int32 idEmpresa, String nomCorto)
        {
            ArticuloServE articuloserv = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ArticuloPorNombreCorto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@nomCorto", SqlDbType.VarChar, 20).Value = nomCorto;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            articuloserv = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return articuloserv;
        }

        public List<ArticuloServE> ArticulosPorListaPrecioStock(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, String Anio, String Mes, String codArticulo, String nomArticulo, Int32 idListaPrecio, Boolean conLote)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ArticulosPorListaPrecioStock", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@codArticulo", SqlDbType.VarChar, 20).Value = codArticulo;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 100).Value = nomArticulo;
                    oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = idListaPrecio;
                    oComando.Parameters.Add("@conLote", SqlDbType.Int).Value = conLote;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarListaPrecioVenta(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<ArticuloServE> ArticulosPorArticuloCodArticulo(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, Int32 idArticulo, String codArticulo)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ArticulosPorArticuloCodArticulo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    oComando.Parameters.Add("@codArticulo", SqlDbType.VarChar, 20).Value = codArticulo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarListaPrecioVenta(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<ArticuloServE> ArticulosPorListaPrecioStock2(Int32 idEmpresa, String Anio, String Mes, Int32 idListaPrecio, string nomArticulo, int idAlmacen)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ArticulosPorListaPrecioStock2", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = idListaPrecio;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 50).Value = nomArticulo;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarListaPrecioVenta(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<ArticuloServE> ArticulosListaPrecioStockPa(Int32 idEmpresa, String Anio, String Mes, Int32 idListaPrecio, string PrincipioActivo, int idAlmacen)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ArticulosListaPrecioStockPa", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = idListaPrecio;
                    oComando.Parameters.Add("@PrincipioActivo", SqlDbType.VarChar, 100).Value = PrincipioActivo;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarListaPrecioVenta(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        /******************************************************************************** CALZADOS **************************************************************************************************/
        public ArticuloServE LlenarEntidadCalzado(IDataReader oReader)
        {
            ArticuloServE articuloserv = new ArticuloServE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticuloLargo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomArticuloLargo = oReader["nomArticuloLargo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticuloLargo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomCorto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomCorto = oReader["nomCorto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomCorto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codBarra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codBarra = oReader["codBarra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codBarra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codUniMedAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codUniMedAlmacen = oReader["codUniMedAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codUniMedAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCategoria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codCategoria = oReader["codCategoria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCategoria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagActivo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.flagActivo = oReader["flagActivo"] == DBNull.Value ? true : Convert.ToBoolean(oReader["flagActivo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecCese'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.fecCese = oReader["fecCese"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecCese"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Combinar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Combinar = oReader["Combinar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Combinar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreReal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.NombreReal = oReader["NombreReal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreReal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreImagen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.NombreImagen = oReader["NombreImagen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreImagen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Extension'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Extension = oReader["Extension"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Extension"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codColor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codColor = oReader["codColor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codColor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codMaterial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codMaterial = oReader["codMaterial"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codMaterial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCapellada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codCapellada = oReader["codCapellada"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codCapellada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTaco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codTaco = oReader["codTaco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codTaco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codEstilo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codEstilo = oReader["codEstilo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codEstilo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codForro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codForro = oReader["codForro"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codForro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPlanta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codPlanta = oReader["codPlanta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codPlanta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codEstacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codEstacion = oReader["codEstacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codEstacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Horma'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Horma = oReader["Horma"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Horma"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MedAncho'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.MedAncho = oReader["MedAncho"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MedAncho"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MedLargo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.MedLargo = oReader["MedLargo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MedLargo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AltPlataforma'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.AltPlataforma = oReader["AltPlataforma"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["AltPlataforma"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Compartimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Compartimiento = oReader["Compartimiento"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Compartimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BolInterno'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.BolInterno = oReader["BolInterno"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BolInterno"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BolExterno'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.BolExterno = oReader["BolExterno"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BolExterno"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCuero'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.indCuero = oReader["indCuero"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCuero"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codSerie = oReader["codSerie"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codModelo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codModelo = oReader["codModelo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codModelo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codMarca'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codMarca = oReader["codMarca"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codMarca"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SKU'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.SKU = oReader["SKU"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SKU"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //EXTENSIONES
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.nomUMedida = oReader["nomUMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCategoria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desCategoria = oReader["desCategoria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCategoria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desTipoArticulo = oReader["desTipoArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaAdm'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codCuentaAdm = oReader["codCuentaAdm"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaAdm"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaVta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codCuentaVta = oReader["codCuentaVta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaVta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaPro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.codCuentaPro = oReader["codCuentaPro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaPro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nemo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Nemo = oReader["Nemo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nemo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Barras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Barras = oReader["Barras"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Barras"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desColor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desColor = oReader["desColor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desColor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMaterial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desMaterial = oReader["desMaterial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMaterial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCapellada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desCapellada = oReader["desCapellada"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCapellada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTaco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desTaco = oReader["desTaco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTaco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstilo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desEstilo = oReader["desEstilo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstilo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desForro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desForro = oReader["desForro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desForro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPlanta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desPlanta = oReader["desPlanta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPlanta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desEstacion = oReader["desEstacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desSerie = oReader["desSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desModelo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desModelo = oReader["desModelo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desModelo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMarca'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.desMarca = oReader["desMarca"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMarca"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloserv.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

            return articuloserv;
        }

        public ArticuloServE InsertarArticuloCalzado(ArticuloServE articuloserv)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarArticuloCalzado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articuloserv.idEmpresa;
                    oComando.Parameters.Add("@codArticulo", SqlDbType.VarChar, 20).Value = articuloserv.codArticulo;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 100).Value = articuloserv.nomArticulo;
                    oComando.Parameters.Add("@nomArticuloLargo", SqlDbType.VarChar, 500).Value = articuloserv.nomArticuloLargo;
                    oComando.Parameters.Add("@nomCorto", SqlDbType.VarChar, 20).Value = articuloserv.nomCorto;
                    oComando.Parameters.Add("@codBarra", SqlDbType.VarChar, 20).Value = articuloserv.codBarra;
                    oComando.Parameters.Add("@codUniMedAlmacen", SqlDbType.Int).Value = articuloserv.codUniMedAlmacen;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = articuloserv.idTipoArticulo;
                    oComando.Parameters.Add("@codCategoria", SqlDbType.VarChar, 20).Value = articuloserv.codCategoria;
                    oComando.Parameters.Add("@Combinar", SqlDbType.Bit).Value = articuloserv.Combinar;
                    oComando.Parameters.Add("@NombreReal", SqlDbType.VarChar, 100).Value = articuloserv.NombreReal;
                    oComando.Parameters.Add("@NombreImagen", SqlDbType.VarChar, 100).Value = articuloserv.NombreImagen;
                    oComando.Parameters.Add("@Extension", SqlDbType.VarChar, 5).Value = articuloserv.Extension;
                    oComando.Parameters.Add("@codColor", SqlDbType.Int).Value = articuloserv.codColor;
                    oComando.Parameters.Add("@codMaterial", SqlDbType.Int).Value = articuloserv.codMaterial;
                    oComando.Parameters.Add("@codCapellada", SqlDbType.Int).Value = articuloserv.codCapellada;
                    oComando.Parameters.Add("@codTaco", SqlDbType.Int).Value = articuloserv.codTaco;
                    oComando.Parameters.Add("@codEstilo", SqlDbType.Int).Value = articuloserv.codEstilo;
                    oComando.Parameters.Add("@codForro", SqlDbType.Int).Value = articuloserv.codForro;
                    oComando.Parameters.Add("@codPlanta", SqlDbType.Int).Value = articuloserv.codPlanta;
                    oComando.Parameters.Add("@codEstacion", SqlDbType.Int).Value = articuloserv.codEstacion;
                    oComando.Parameters.Add("@Horma", SqlDbType.VarChar, 2).Value = articuloserv.Horma;
                    oComando.Parameters.Add("@MedAncho", SqlDbType.Decimal).Value = articuloserv.MedAncho;
                    oComando.Parameters.Add("@MedLargo", SqlDbType.Decimal).Value = articuloserv.MedLargo;
                    oComando.Parameters.Add("@AltPlataforma", SqlDbType.Decimal).Value = articuloserv.AltPlataforma;
                    oComando.Parameters.Add("@Compartimiento", SqlDbType.Decimal).Value = articuloserv.Compartimiento;
                    oComando.Parameters.Add("@BolInterno", SqlDbType.Decimal).Value = articuloserv.BolInterno;
                    oComando.Parameters.Add("@BolExterno", SqlDbType.Decimal).Value = articuloserv.BolExterno;
                    oComando.Parameters.Add("@indCuero", SqlDbType.Bit).Value = articuloserv.indCuero;
                    oComando.Parameters.Add("@codSerie", SqlDbType.Int).Value = articuloserv.codSerie;
                    oComando.Parameters.Add("@codModelo", SqlDbType.Int).Value = articuloserv.codModelo;
                    oComando.Parameters.Add("@codMarca", SqlDbType.Int).Value = articuloserv.codMarca;
                    oComando.Parameters.Add("@SKU", SqlDbType.VarChar, 500).Value = articuloserv.SKU;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = articuloserv.UsuarioRegistro;

                    oConexion.Open();
                    articuloserv.idArticulo = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return articuloserv;
        }

        public ArticuloServE ActualizarArticuloCalzado(ArticuloServE articuloserv)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarArticuloCalzado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articuloserv.idEmpresa;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = articuloserv.idArticulo;
                    oComando.Parameters.Add("@codArticulo", SqlDbType.VarChar, 20).Value = articuloserv.codArticulo;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 100).Value = articuloserv.nomArticulo;
                    oComando.Parameters.Add("@nomArticuloLargo", SqlDbType.VarChar, 500).Value = articuloserv.nomArticuloLargo;
                    oComando.Parameters.Add("@nomCorto", SqlDbType.VarChar, 20).Value = articuloserv.nomCorto;
                    oComando.Parameters.Add("@codBarra", SqlDbType.VarChar, 20).Value = articuloserv.codBarra;
                    oComando.Parameters.Add("@codUniMedAlmacen", SqlDbType.Int).Value = articuloserv.codUniMedAlmacen;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = articuloserv.idTipoArticulo;
                    oComando.Parameters.Add("@codCategoria", SqlDbType.VarChar, 20).Value = articuloserv.codCategoria;
                    oComando.Parameters.Add("@Combinar", SqlDbType.Bit).Value = articuloserv.Combinar;
                    oComando.Parameters.Add("@NombreReal", SqlDbType.VarChar, 100).Value = articuloserv.NombreReal;
                    oComando.Parameters.Add("@NombreImagen", SqlDbType.VarChar, 100).Value = articuloserv.NombreImagen;
                    oComando.Parameters.Add("@Extension", SqlDbType.VarChar, 5).Value = articuloserv.Extension;
                    oComando.Parameters.Add("@codColor", SqlDbType.Int).Value = articuloserv.codColor;
                    oComando.Parameters.Add("@codMaterial", SqlDbType.Int).Value = articuloserv.codMaterial;
                    oComando.Parameters.Add("@codCapellada", SqlDbType.Int).Value = articuloserv.codCapellada;
                    oComando.Parameters.Add("@codTaco", SqlDbType.Int).Value = articuloserv.codTaco;
                    oComando.Parameters.Add("@codEstilo", SqlDbType.Int).Value = articuloserv.codEstilo;
                    oComando.Parameters.Add("@codForro", SqlDbType.Int).Value = articuloserv.codForro;
                    oComando.Parameters.Add("@codPlanta", SqlDbType.Int).Value = articuloserv.codPlanta;
                    oComando.Parameters.Add("@codEstacion", SqlDbType.Int).Value = articuloserv.codEstacion;
                    oComando.Parameters.Add("@Horma", SqlDbType.VarChar, 2).Value = articuloserv.Horma;
                    oComando.Parameters.Add("@MedAncho", SqlDbType.Decimal).Value = articuloserv.MedAncho;
                    oComando.Parameters.Add("@MedLargo", SqlDbType.Decimal).Value = articuloserv.MedLargo;
                    oComando.Parameters.Add("@AltPlataforma", SqlDbType.Decimal).Value = articuloserv.AltPlataforma;
                    oComando.Parameters.Add("@Compartimiento", SqlDbType.Decimal).Value = articuloserv.Compartimiento;
                    oComando.Parameters.Add("@BolInterno", SqlDbType.Decimal).Value = articuloserv.BolInterno;
                    oComando.Parameters.Add("@BolExterno", SqlDbType.Decimal).Value = articuloserv.BolExterno;
                    oComando.Parameters.Add("@indCuero", SqlDbType.Bit).Value = articuloserv.indCuero;
                    oComando.Parameters.Add("@codSerie", SqlDbType.Int).Value = articuloserv.codSerie;
                    oComando.Parameters.Add("@codModelo", SqlDbType.Int).Value = articuloserv.codModelo;
                    oComando.Parameters.Add("@codMarca", SqlDbType.Int).Value = articuloserv.codMarca;
                    oComando.Parameters.Add("@SKU", SqlDbType.VarChar, 500).Value = articuloserv.SKU;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = articuloserv.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articuloserv;
        }

        public ArticuloServE ObtenerArticuloCalzado(Int32 idEmpresa, Int32 idArticulo)
        {
            ArticuloServE articuloserv = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerArticuloCalzado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            articuloserv = LlenarEntidadCalzado(oReader);
                        }
                    }
                }
            }

            return articuloserv;
        }

        public List<ArticuloServE> ListarArticuloCalzado(Int32 idEmpresa, Int32 idTipoArticulo, String codCategoria, Boolean Incluir)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();
            ArticuloServE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloCalzado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@codCategoria", SqlDbType.VarChar, 20).Value = codCategoria;
                    oComando.Parameters.Add("@Incluir", SqlDbType.Bit).Value = Incluir;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidadCalzado(oReader);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<ArticuloServE> ListarArtiCalzadoBusqueda(Int32 idEmpresa, Int32 idTipoArticulo, String Filtro, Int32 codMarca, Int32 codModelo)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArtiCalzadoBusqueda", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@Filtro", SqlDbType.VarChar, 100).Value = Filtro;
                    oComando.Parameters.Add("@codMarca", SqlDbType.Int).Value = codMarca;
                    oComando.Parameters.Add("@codModelo", SqlDbType.Int).Value = codModelo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidadCalzado(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<ArticuloServE> ListarArtiCalzadoBusqueda2(Int32 idEmpresa, Int32 idTipoArticulo, String Filtro, Int32 codMarca, Int32 codModelo)
        {
            List<ArticuloServE> listaEntidad = new List<ArticuloServE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArtiCalzadoBusqueda2", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@Filtro", SqlDbType.VarChar, 100).Value = Filtro;
                    oComando.Parameters.Add("@codMarca", SqlDbType.Int).Value = codMarca;
                    oComando.Parameters.Add("@codModelo", SqlDbType.Int).Value = codModelo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidadCalzado(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public ArticuloServE ObtenerArticuloPorCodArticulo(Int32 idEmpresa, String CodArticulo)
        {
            ArticuloServE articuloserv = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerArticuloPorCodArticulo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@CodArticulo", SqlDbType.VarChar, 20).Value = CodArticulo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            articuloserv = LlenarEntidadCalzado(oReader);
                        }
                    }
                }
            }

            return articuloserv;
        }

        /*****************************************************************************************************************************************************/

    }
}