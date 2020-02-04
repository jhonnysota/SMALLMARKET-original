using System;
using System.Collections.Generic;
using System.ServiceModel;

using Entidades.Maestros;
using Infraestructura.Enumerados;

namespace ContratoWCF
{

    [ServiceContract]
    public interface IMaestros
    {
        [OperationContract]
        DateTime RecuperarFechaServidor();

        #region Entidad Empresa JOSE SALAZAR

        [OperationContract]
        List<Empresa> ListarEmpresa(String parametro);

        [OperationContract]
        List<Empresa> ListarEmpresaPorEstado(String parametro, Boolean Estado1, Boolean Estado2);

        [OperationContract]
        List<Empresa> ListarEmpresaPorUsuario(Int32 IdPersona);

        [OperationContract]
        Empresa RecuperarEmpresaPorID(Int32 idEmpresa);

        [OperationContract]
        Empresa GrabarEmpresa(Empresa empresa, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        Empresa RecuperarEmpresaPorRUC(String ruc);

        #endregion

        #region Entidad UbigeoE JOSE SALAZAR

        [OperationContract]
        UbigeoE ActualizarUbigeo(UbigeoE ubigeo);

        [OperationContract]
        UbigeoE InsertarUbigeo(UbigeoE ubigeo);

        [OperationContract]
        UbigeoE ObtenerUbigeo(String idUbigeo);

        [OperationContract]
        UbigeoE ObtenerubigeosunatPorDepProDis(String Departamento, String Provincia, String Distrito);

        [OperationContract]
        List<UbigeoE> ListarDepartamentos(); /////////////////

        [OperationContract]
        List<UbigeoE> ListarProvincias(String Departamento); //////////////////////

        [OperationContract]
        List<UbigeoE> ListarDistritos(String Departamento, String Provincia); ///////////////////////

        [OperationContract]
        UbigeoE RecuperarUbigeoPorId(String idUbigeo);

        [OperationContract]
        Int32 AnularUbigeo(String idUbigeo, String UsuarioModificacion);

        //Faltan Implementar
        [OperationContract]
        List<UbigeoE> ListarUbigeo(Int32 idPais, Boolean Activo, Boolean Inactivo);

        #endregion

        #region Entidad Persona JOSE SALAZAR

        [OperationContract]
        Persona InsertarPersona(Persona persona);

        [OperationContract]
        Persona ActualizarPersona(Persona persona);

        [OperationContract]
        Persona RecuperarPersonaPorID(Int32 idPersona, Int32 idEmpresa = 0, String conAvales = "N");

        [OperationContract]
        Persona RecuperarPersonaPorNroDocumento(String nroDocumento);

        [OperationContract]
        Persona RecuperarPersonaPorRUC(Int32 tipoDocumento, String ruc);

        [OperationContract]
        Persona RecuperarPersonaPorDNI(String DNI);

        [OperationContract]
        Persona ValidaNroDocumentoExistente(Int32 tipoDocumento, String nroDocumento, Int32 IdPersona);

        [OperationContract]
        Persona ValidaRUCExistente(String RUC);

        [OperationContract]
        List<Persona> ListarPersonaPorFiltro(Int32 idEmpresa, String Tipo, String Filtro);

        [OperationContract]
        List<Persona> ListarCorreosTrabajador();

        [OperationContract]
        List<Persona> BusquedaPersonaPorTipo(String Tipo, Int32 idEmpresa, String RazonSocial, String nroDocumento, Boolean EsReferente = false);

        [OperationContract]
        Persona ObtenerPersonaPorNroRuc(String Ruc, Int32 idEmpresa = 0);

        [OperationContract]
        List<Persona> ListarCarteraClientesPorFiltro(Int32 idEmpresa, String Tipo, String Filtro, Int32 idVendedor);

        [OperationContract]
        List<Persona> ListarPersonasPorTipPer(Int32 idEmpresa, String Tipo, String Filtro, String TipoPersona);

        [OperationContract]
        Int32 GrabarPersonaMasivo(List<ClienteXLSE> oListaAuxiliares, String Tipo, String Usuario);

        #endregion

        #region Entidad Proveedor JOSE SALAZAR

        [OperationContract]
        ProveedorE GrabarProveedor(ProveedorE proveedor, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        Int32 ActualizarEstadoProveedor(Int32 idPersona, Boolean estado, Int32 idEmpresa, String usuarioModificacion, DateTime fechaModificacion);

        [OperationContract]
        List<ProveedorE> ListarProveedorPorParametro(Int32 idEmpresa, String RazonSocial, String NroDocumento, Int32? TipoPersona, String indBaja);

        [OperationContract]
        ProveedorE RecuperarProveedorPorID(Int32 idPersona, Int32 idEmpresa, String BuscarOtros = "S", Boolean indBaja = false);

        [OperationContract]
        ProveedorE InsertarProveedor(ProveedorE proveedor);

        [OperationContract]
        Int32 EliminarProveedor(Int32 idEmpresa, Int32 idPersona);

        [OperationContract]
        List<ProveedorE> BuscarProveedor(Int32 idEmpresa, String RazonSocial, String NroDocumento, Int32 TipoProveedor);

        #endregion

        #region ICliente Members JOSE SALAZAR

        [OperationContract]
        ClienteE GrabarCliente(ClienteE Cliente, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        ClienteE InsertarCliente(ClienteE cliente);

        [OperationContract]
        ClienteE ActualizarCliente(ClienteE cliente);

        [OperationContract]
        List<ClienteE> BuscarClientes(Int32 idEmpresa, String RazonSocial, String NroDocumento, Int32 TipoCliente);

        [OperationContract]
        Int32 AnularCliente(Int32 idPersona, Int32 idEmpresa, Boolean indBaja, String UsuarioModificacion);

        [OperationContract]
        Int32 EliminarCliente(Int32 idEmpresa, Int32 idPersona);

        [OperationContract]
        ClienteE RecuperarClientePorId(Int32 idPersona, Int32 idEmpresa, String BuscarOtros = "S");

        [OperationContract]
        List<ClienteE> ListarClientePorParametro(Int32 idEmpresa, String RazonSocial, String NroDocumento, Boolean activo, Boolean inactivo);

        #endregion

        #region Local Members JOSE SALAZAR

        [OperationContract]
        LocalE InsertarLocal(LocalE local);

        [OperationContract]
        LocalE ActualizarLocal(LocalE local);

        [OperationContract]
        Int32 RecuperarMaxIdLocal(Int32 IdEmpresa);

        [OperationContract]
        List<LocalE> ListarLocal(String value, Boolean activo, Boolean inactivo, Int32 idEmpresa);

        [OperationContract]
        List<LocalE> ListarLocalTodos(String value, Boolean activo, Boolean inactivo);

        [OperationContract]
        List<LocalE> ListarLocalPorUsuario(Int32 IdPersona);

        [OperationContract]
        List<LocalE> ListarLocalPorEmpresa(Int32 idEmpresa, Boolean incluirLogico, Boolean incluirTodos);

        [OperationContract]
        Int32 AnularLocalPorCodigo(Int32 IdLocal, Int32 IdEmpresa);

        [OperationContract]
        LocalE RecuperarLocalPorCodigo(Int32 IdLocal, Int32 IdEmpresa);

        #endregion

        #region IArea Members JOSE SALAZAR

        [OperationContract]
        Area InsertarArea(Area areas);

        [OperationContract]
        Area ActualizarArea(Area areas);

        [OperationContract]
        List<Area> ListarTodasAreas(Int32 idEmpresa, Int32 idLocal);

        [OperationContract]
        Area GrabarAreas(Area Areas, EnumOpcionGrabar Opcion);

        [OperationContract]
        List<Area> BuscarAreaDescripcion(Int32 idEmpresa, Int32 idLocal, String descripcion);

        [OperationContract]
        List<Area> ListarAreaPorUsuario(Int32 idPersona);

        [OperationContract]
        List<Area> ListarTodasAreasPorUsuario(Int32 idEmpresa, Int32 idLocal, Int32 idPersona);

        #endregion

        #region ICentroCostos JOSE SALAZAR

        [OperationContract]
        CCostosE InsertarCCostos(CCostosE ccostos);

        [OperationContract]
        CCostosE ActualizarCCostos(CCostosE ccostos);

        [OperationContract]
        List<CCostosE> ListarCCostosPorNivel(Int32 idEmpresa, Int32? numNivel);

        [OperationContract]
        List<CCostosE> ListarCCostosPorSistema(Int32 idEmpresa, Int32 idSistema);

        [OperationContract]
        Int32 AnularCCostos(Int32 idEmpresa, String idCCostos);

        [OperationContract]
        CCostosE ObtenerCCostos(Int32 idEmpresa, String idCCostos);

        [OperationContract]
        String ObtenerIdCosto(Int32 idEmpresa, String desCCostos);

        [OperationContract]
        Int32 MaxNivelCCostos(Int32 idEmpresa);

        [OperationContract]
        List<CCostosE> ListarCCostosPorTipoCCosto(Int32 idEmpresa, Int32 idSistema, Int32 tipoCCosto);

        #endregion

        #region IDocumentos Members JOSE SALAZAR

        [OperationContract]
        DocumentosE InsertarDocumentos(DocumentosE documentos);

        [OperationContract]
        DocumentosE ActualizarDocumentos(DocumentosE documentos);

        [OperationContract]
        DocumentosE GrabarImpuestosDocumentos(DocumentosE documentos, EnumOpcionGrabar OpcionGrabacion);

        [OperationContract]
        Int32 AnularActivarDocumento(String idDocumento, Boolean indBaja);

        [OperationContract]
        DocumentosE ObtenerDocumentos(String idDocumento);

        [OperationContract]
        List<DocumentosE> ListarDocumentosGeneral();

        [OperationContract]
        List<DocumentosE> ListadoDeDocumentos(Boolean Activo, Boolean Inactivo);

        #endregion

        #region IArticuloServ Members JOSE SALAZAR

        [OperationContract]
        ArticuloServE GrabarArticuloServ(ArticuloServE articulo, EnumOpcionGrabar Opcion);

        [OperationContract]
        ArticuloServE InsertarArticuloServ(ArticuloServE articuloserv);

        [OperationContract]
        ArticuloServE ActualizarArticuloServ(ArticuloServE articuloserv);

        [OperationContract]
        List<ArticuloServE> ListarArticuloServ(Int32 idEmpresa, Int32 idTipoArticulo, String codCategoria, string nomArticulo, Boolean Incluir);

        [OperationContract]
        List<ArticuloServE> ListarArticuloServDetalle(Int32 idEmpresa, Int32 idTipoArticulo, Int32 idTipo, String codCategoria, Boolean Incluir);

        [OperationContract]
        List<ArticuloServE> ListarArticulosBusqueda(Int32 idEmpresa, Int32 idTipoArticulo, String Filtro);

        [OperationContract]
        Int32 EliminarArticuloServ(Int32 idEmpresa, Int32 idArticulo);

        [OperationContract]
        ArticuloServE ObtenerArticuloServ(Int32 idEmpresa, Int32 idArticulo);

        [OperationContract]
        ArticuloServE ObteneridArticuloPorCodArticulo(Int32 idEmpresa, String CodArticulo);

        [OperationContract]
        List<ArticuloServE> BuscarArticuloDescripcion(Int32 idEmpresa, String descripcion);

        [OperationContract]
        List<ArticuloServE> ArticuloReporteExportacion(Int32 idEmpresa, Int32 tipoArticulo);

        [OperationContract]
        List<ArticuloServE> ListarArticuloServReporte(Int32 idEmpresa, Int32 idTipoArticulo);

        [OperationContract]
        Int32 AnularArticuloServ(Int32 idEmpresa, Int32 idArticulo);

        [OperationContract]
        Int32 CorrelativoArticulo(Int32 idEmpresa, String codCategoria);

        [OperationContract]
        ArticuloServE ObtenerArticuloPorCodBarra(Int32 idEmpresa, String CodBarra);

        [OperationContract]
        ArticuloServE ObtenerImagenArticulo(ArticuloServE Articulo);

        [OperationContract]
        ArticuloServE BorrarImagenArticulo(ArticuloServE Articulo);

        [OperationContract]
        ArticuloServE BorrarImagenArticuloLocal(ArticuloServE Articulo);

        [OperationContract]
        List<ArticuloServE> ListarArticulosPorFiltro(Int32 idEmpresa, Int32 idTipoArticulo, String codArticulo, String nomArticulo);

        [OperationContract]
        List<ArticuloServE> ListarArticulosPorFiltroArticuloYLote(Int32 idEmpresa, Int32 idTipoArticulo, String codArticulo, String nomArticulo, String Lote);

        [OperationContract]
        List<ArticuloServE> ListarArticulosPV(Int32 idEmpresa, String Nemo, Int32 idListaPrecio);

        [OperationContract]
        List<ArticuloServE> ListarCodBarrasArticuloServ(List<ArticuloServE> oListaArticulo);

        [OperationContract]
        List<ArticuloServE> ArticulosPorListaPrecio(Int32 idEmpresa, Int32 idTipoArticulo, String codArticulo, String nomArticulo, Int32 idListaPrecio);

        [OperationContract]
        List<ArticuloServE> ArticulosPorListaPrecioStock(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, String Anio, String Mes, String codArticulo, String nomArticulo, Int32 idListaPrecio, Boolean conLote);

        [OperationContract]
        List<ArticuloServE> ArticulosPorArticuloCodArticulo(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, Int32 idArticulo, String codArticulo);

        [OperationContract]
        List<ArticuloServE> ArticulosPorListaPrecioStock2(Int32 idEmpresa, String Anio, String Mes, Int32 idListaPrecio, string nomArticulo, int idAlmacen);

        [OperationContract]
        List<ArticuloServE> ArticulosListaPrecioStockPa(Int32 idEmpresa, String Anio, String Mes, Int32 idListaPrecio, string PrincipioActivo, int idAlmacen);

        /******************* CALZADO *******************/
        [OperationContract]
        ArticuloServE GrabarArticuloCalzado(ArticuloServE articulo, EnumOpcionGrabar Opcion); //JOSE SALAZAR

        [OperationContract]
        ArticuloServE ObtenerArticuloCalzado(Int32 idEmpresa, Int32 idArticulo); //JOSE SALAZAR

        [OperationContract]
        List<ArticuloServE> ListarArticuloCalzado(Int32 idEmpresa, Int32 idTipoArticulo, String codCategoria, Boolean Incluir); //JOSE SALAZAR

        [OperationContract]
        List<ArticuloServE> ListarArtiCalzadoBusqueda(Int32 idEmpresa, Int32 idTipoArticulo, String Filtro, Int32 codMarca, Int32 codModelo);

        [OperationContract]
        List<ArticuloServE> ListarArtiCalzadoBusqueda2(Int32 idEmpresa, Int32 idTipoArticulo, String Filtro, Int32 codMarca, Int32 codModelo);

        [OperationContract]
        ArticuloServE ObtenerArticuloPorCodArticulo(Int32 idEmpresa, String CodArticulo);

        #endregion

        #region IArticuloDetalle JOSE SALAZAR

        [OperationContract]
        ArticuloDetalleE InsertarArticuloDetalle(ArticuloDetalleE articulodetalle);

        [OperationContract]
        ArticuloDetalleE ActualizarArticuloDetalle(ArticuloDetalleE articulodetalle);

        [OperationContract]
        Int32 EliminarArticuloDetalle(Int32 idEmpresa, Int32 idArticulo, Int32 idCaracteristica);

        [OperationContract]
        List<ArticuloDetalleE> ListarArticuloDetalle(Int32 idArticulo);

        [OperationContract]
        ArticuloDetalleE ObtenerArticuloDetalle(Int32 idEmpresa, Int32 idArticulo, Int32 idCaracteristica);

        #endregion 

        #region IOpeLogistico Members JOSE SALAZAR

        [OperationContract]
        OpeLogisticoE GrabarOpeLogistico(OpeLogisticoE OpeLogistico, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        OpeLogisticoE InsertarOpeLogistico(OpeLogisticoE opelogistico);

        [OperationContract]
        OpeLogisticoE ActualizarOpeLogistico(OpeLogisticoE opelogistico);

        //[OperationContract]
        //Int32 EliminarOpeLogistico(Int32 idPersona, Int32 idEmpresa);

        [OperationContract]
        List<OpeLogisticoE> ListarOpeLogistico();

        [OperationContract]
        OpeLogisticoE ObtenerOpeLogistico(Int32 idPersona, Int32 idEmpresa);

        [OperationContract]
        List<OpeLogisticoE> ListarOpeLogPorParametro(Int32 idEmpresa, String RazonSocial, String NroDocumento, Boolean activo, Boolean inactivo);

        [OperationContract]
        OpeLogisticoE RecuperarOpeLogPorId(Int32 idPersona, Int32 idEmpresa);

        #endregion

        #region IPartida_Presupuestaria Members JOSE SALAZAR

        [OperationContract]
        PartidaPresupuestariaE InsertarPartidaPresupuestaria(PartidaPresupuestariaE partidapresupuestaria);

        [OperationContract]
        PartidaPresupuestariaE ActualizarPartidaPresupuestaria(PartidaPresupuestariaE partidapresupuestaria);

        [OperationContract]
        Int32 EliminarPartidaPresupuestaria(Int32 idEmpresa, String tipPartidaPresu, String codPartidaPresu);

        [OperationContract]
        List<PartidaPresupuestariaE> ListarPartidaPresupuestaria();

        [OperationContract]
        PartidaPresupuestariaE ListarPartidaPresupuestariaPorCodigo(Int32 idEmpresa, String codPartidaPresu);

        [OperationContract]
        PartidaPresupuestariaE ObtenerPartidaPresupuestaria(Int32 idEmpresa, String tipPartidaPresu, String codPartidaPresu);

        [OperationContract]
        List<PartidaPresupuestariaE> ListarPartidaPresupuestariaPorTipo(Int32 idEmpresa, String tipPartidaPresu, String desPartidaPresu, Int32 numNivel);

        [OperationContract]
        Int32 ObtenerNivelPartida(Int32 idEmpresa); //JOSE SALAZAR

        [OperationContract] ///JOSE SALAZAR
        Int32 EliminarPartidaPresupuestariaTodo(Int32 idEmpresa, String tipPartidaPresu, String codPartidaPresuSup);

        #endregion         

        #region IBancos Members JOSE SALAZAR

        [OperationContract]
        BancosE GrabarBanco(BancosE oBanco, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        BancosE InsertarBancos(BancosE bancos);

        [OperationContract]
        BancosE ActualizarBancos(BancosE bancos);

        [OperationContract]
        Int32 EliminarBancos(Int32 idPersona, Int32 idEmpresa);

        [OperationContract]
        List<BancosE> ListarBancos(Int32 idEmpresa);

        [OperationContract]
        BancosE ObtenerBancos(Int32 idPersona, Int32 idEmpresa);

        [OperationContract]
        BancosE RecuperarBancoPorId(Int32 idPersona, Int32 idEmpresa, String BuscarOtros = "S");

        [OperationContract]
        BancosE RecuperarBancoPorRUC(Int32 idEmpresa,String Ruc);

        #endregion

        #region IBancosCuentas Members JOSE SALAZAR

        [OperationContract]
        BancosCuentasE InsertarBancosCuentas(BancosCuentasE bancoscuentas);

        [OperationContract]
        BancosCuentasE ActualizarBancosCuentas(BancosCuentasE bancoscuentas);

        [OperationContract]
        Int32 EliminarBancosCuentas(Int32 idPersona, Int32 idEmpresa, Int32 IdBancosCuentas);

        [OperationContract]
        List<BancosCuentasE> ListarBancosCuentas(Int32 idEmpresa, Int32 idPersona);

        [OperationContract]
        BancosCuentasE ObtenerBancosCuentas(Int32 idPersona, Int32 idEmpresa, String numCuenta);

        [OperationContract]
        BancosCuentasE ObtenerBancosPorNroCuenta(Int32 idEmpresa, String numCuenta);

        [OperationContract]
        BancosCuentasE ObtenerBancosPorCodCuenta(Int32 idEmpresa, String codCuenta);

        [OperationContract]
        List<BancosCuentasE> ListarCuentasPorBancos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String idMoneda);

        [OperationContract]
        List<BancosCuentasE> ListarCuentasParaDoc(Int32 idEmpresa);

        [OperationContract]
        List<BancosCuentasE> BancosCuentasPorMoneda(Int32 idPersona, Int32 idEmpresa, String idMoneda);

        [OperationContract]
        List<BancosCuentasE> BancosCuentasPorEmpresa(Int32 idPersona, Int32 idEmpresa);

        #endregion

        #region IArticuloCat JOSE SALAZAR

        [OperationContract]
        ArticuloCatE GrabarArticuloCat(ArticuloCatE articulo, EnumOpcionGrabar Opcion);

        [OperationContract]
        List<ArticuloCatE> ListarArticuloCatArbol(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel,string filtro);

        [OperationContract]
        List<ArticuloCatE> ListarArticuloCategoria(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel, string filtro);


        [OperationContract]
        List<ArticuloCatE> ListarCategoriasPorTipoArticulo(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel);

        [OperationContract]
        List<ArticuloCatE> ListarCategPorTipoArtiCategSup(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel, string CodCategoriaSup);

        [OperationContract]
        List<ArticuloCatE> ListarCategoriasPorUltNivel(Int32 idEmpresa, Int32 idTipoArticulo);

        [OperationContract]
        Int32 EliminarArticuloCat(Int32 idEmpresa, Int32 idTipoArticulo, String CodCategoria);

        #endregion

        #region IArticuloEstruc JOSE SALAZAR

        [OperationContract]
        ArticuloEstrucE GrabarArticuloEstruc(ArticuloEstrucE articulo, EnumOpcionGrabar Opcion, ArticuloEstrucE ArticuloEstrucAnte = null);

        [OperationContract]
        Int32 EliminarArticulosEstruc(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel);

        [OperationContract]
        List<ArticuloEstrucE> ListarArticuloEstruc(Int32 idEmpresa, Int32 idTipoArticulo);

        #endregion

        #region IVendedores Members JOSE SALAZAR

        [OperationContract]
        VendedoresE GrabarVendedor(VendedoresE Vendedores, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        VendedoresE InsertarVendedores(VendedoresE vendedores);

        [OperationContract]
        VendedoresE ActualizarVendedores(VendedoresE vendedores);

        [OperationContract]
        Int32 EliminarVendedores(Int32 idPersona, Int32 idEmpresa);

        [OperationContract]
        List<VendedoresE> ListarVendedores(Int32 idEmpresa, String parambusqueda, Boolean indEstado);

        [OperationContract]
        List<VendedoresE> BusquedaVendedores(Int32 idEmpresa);

        [OperationContract]
        VendedoresE RecuperarVendedorPorId(Int32 idPersona, Int32 idEmpresa);

        [OperationContract]
        VendedoresE RecuperarIDPersonaPorVendedor(Int32 idPersona, Int32 idEmpresa);

        [OperationContract]
        Int32 DarBajaVendedores(Int32 idPersona, Int32 idEmpresa, String UsuarioModificacion);

        #endregion

        #region IVendedoresCartera Members JOSE SALAZAR

        [OperationContract]
        VendedoresCarteraE InsertarVendedoresCartera(VendedoresCarteraE vendedorescartera);

        [OperationContract]
        VendedoresCarteraE ActualizarVendedoresCartera(VendedoresCarteraE vendedorescartera);

        [OperationContract]
        int EliminarVendedoresCartera(Int32 idEmpresa, Int32 idVendedor, Int32 idCliente);

        [OperationContract]
        List<VendedoresCarteraE> ListarVendedoresCartera(Int32 idEmpresa, Int32 idVendedor);

        [OperationContract]
        VendedoresCarteraE ObtenerVendedoresCartera(Int32 idEmpresa, Int32 idVendedor, Int32 idCliente);

        [OperationContract]
        VendedoresCarteraE ObtenerCarteraPorIdCliente(Int32 idEmpresa, Int32 idCliente);

        #endregion 

        #region ITrabajador JOSE SALAZAR

        //[OperationContract]
        //TrabajadorE GrabarTrabajador(TrabajadorE Trabajador, EnumOpcionGrabar OpcionGrabar);

        //[OperationContract]
        //TrabajadorE InsertarTrabajador(TrabajadorE trabajador);

        //[OperationContract]
        //TrabajadorE ActualizarTrabajador(TrabajadorE trabajador);

        //[OperationContract]
        //Int32 EliminarTrabajador(Int32 idPersona, Int32 idEmpresa);

        //[OperationContract]
        //List<TrabajadorE> ListarTrabajador(Int32 idEmpresa, string nroDocumento, string RazonSocial);

        //[OperationContract]
        //List<TrabajadorE> ListarTrabajadorPorDocumentos(Int32 idEmpresa, Int32 idLocal, String NroDocumento, String ApePaterno, String ApeMaterno, String Nombres, Int32 IdPersona);

        //[OperationContract]
        //List<TrabajadorE> BuscarTrabajador(Int32 idEmpresa);

        //[OperationContract]
        //TrabajadorE ObtenerTrabajador(Int32 idPersona, Int32 idEmpresa);

        //[OperationContract]
        //TrabajadorE RecuperarIDPersonaPorTrabajador(Int32 idPersona, Int32 idEmpresa);

        //[OperationContract] //JOSE SALAZAR
        //List<TrabajadorE> ListarTrabajadorPorFiltro(Int32 idEmpresa, String Tipo, String Filtro);

        //[OperationContract]
        //List<TrabajadorE> ListarTrabajadorPorPlanilla(Int32 idEmpresa, Int32 idLocal, String codAnno, String codMes, String codPeriodo, String idPlanilla);

        //[OperationContract]
        //List<TrabajadorE> ListarTrabajadorPorLocalPlanilla(Int32 idEmpresa, List<LocalTduE> Local, String codAnno, String codMes, String codPeriodo, String idPlanilla);

        //[OperationContract]
        //List<TrabajadorE> ListarTrabajadorPorPlanillaPorParam(Int32 idEmpresa, Int32 idLocal, String codAnno, String codMes, String codPeriodo, String idPlanilla, String NroDocumento, String ApePaterno, String ApeMaterno, String Nombres);

        //[OperationContract]
        //TrabajadorE ObtenerImagenTrabajador(TrabajadorE trabajador);

        //[OperationContract]
        //TrabajadorE BorrarImagenTrabajador(TrabajadorE trabajador);

        //[OperationContract]
        //TrabajadorE BorrarImagenTrabajadorLocal(TrabajadorE trabajador);

        //[OperationContract]
        //List<TrabajadorE> ListarTrabajadorPorAnioMes(Int32 idEmpresa, String Tipo, String Filtro, String Anio, String Mes);

        //[OperationContract]
        //List<TrabajadorE> ReportePlanillaNetoPago(Int32 idEmpresa, String Periodo, String Anio, String Mes, String idPlanilla, String TipoPlanilla, String idMoneda, Int32 idFormaPago, Decimal Tica, Int32 idBanco, String Formato);

        //[OperationContract]
        //String GenerarOpNetoPago(Int32 idEmpresa, Int32 idLocal, String idPlanilla, String Anio, String Mes, String Periodo, DateTime FechaDeposito, String idMoneda, Int32 idBanco, List<TrabajadorE> ListarTrabajadores, String Usuario, PeriodoPlanillaOpE planillaOpE = null);

        #endregion

        #region IEstablecimientos JOSE SALAZAR

        [OperationContract]
        EstablecimientosE InsertarEstablecimientos(EstablecimientosE establecimientos);

        [OperationContract]
        EstablecimientosE ActualizarEstablecimientos(EstablecimientosE establecimientos);

        [OperationContract]
        Int32 EliminarEstablecimientos(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento);

        [OperationContract]
        List<EstablecimientosE> ListarEstablecimientos(Int32 idEmpresa, Int32 idLocal);

        [OperationContract]
        EstablecimientosE ObtenerEstablecimientos(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento);

        [OperationContract]
        EstablecimientosE ObtenerEstablecimientosPorDescripcionEstablecimiento(String Descripcion);

        [OperationContract] 
        Int32 DarBajaEstablecimiento(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento, String UsuarioModificacion);

        [OperationContract]
        List<EstablecimientosE> ListarEstablecimientosZonas(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento);

        #endregion        

        #region IPersonaDireccion Members JOSE SALAZAR

        [OperationContract]
        PersonaDireccionE InsertarPersonaDireccion(PersonaDireccionE personadireccion);

        [OperationContract]
        PersonaDireccionE ActualizarPersonaDireccion(PersonaDireccionE personadireccion);

        [OperationContract]
        int EliminarPersonaDireccion(Int32 IdPersona, Int32 IdDireccion);

        [OperationContract]
        List<PersonaDireccionE> ListarPersonaDireccion(Int32 IdPersona);

        [OperationContract]
        PersonaDireccionE ObtenerPersonaDireccion(Int32 IdPersona, Int32 IdDireccion);

        #endregion

        #region IClienteAsociados Members JOSE SALAZAR

        [OperationContract]
        ClienteAsociadosE InsertarClienteAsociados(ClienteAsociadosE clienteasociados);

        [OperationContract]
        ClienteAsociadosE ActualizarClienteAsociados(ClienteAsociadosE clienteasociados);

        [OperationContract]
        int EliminarClienteAsociados(Int32 idPersona, Int32 IdEmpresa, Int32 IdAsociado);

        [OperationContract]
        List<ClienteAsociadosE> ListarClienteAsociados(Int32 IdEmpresa, Int32 idPersona);

        [OperationContract]
        ClienteAsociadosE ObtenerClienteAsociados(Int32 idPersona, Int32 IdEmpresa, Int32 IdAsociado);

        #endregion 

        #region IEmpresaImagenes Members JOSE SALAZAR

        [OperationContract]
        EmpresaImagenesE InsertarEmpresaImagenes(EmpresaImagenesE empresaimagenes);

        [OperationContract]
        EmpresaImagenesE ActualizarEmpresaImagenes(EmpresaImagenesE empresaimagenes);

        [OperationContract]
        Int32 EliminarEmpresaImagenes(Int32 idImagen, Int32 idEmpresa);

        [OperationContract]
        List<EmpresaImagenesE> ListarEmpresaImagenes(Int32 idEmpresa);

        [OperationContract]
        EmpresaImagenesE ObtenerEmpresaConImagenes(Int32 idImagen, Int32 idEmpresa);

        [OperationContract]
        EmpresaImagenesE ObtenerEmpresaSinImagenes(Int32 idImagen, Int32 idEmpresa);

        #endregion

        #region IClienteAval Members JOSE SALAZAR

        [OperationContract]
        ClienteAvalE InsertarClienteAval(ClienteAvalE clienteaval);

        [OperationContract]
        ClienteAvalE ActualizarClienteAval(ClienteAvalE clienteaval);

        [OperationContract]
        int EliminarClienteAval(Int32 idEmpresa, Int32 idPersona);

        [OperationContract]
        List<ClienteAvalE> ListarClienteAval(Int32 idEmpresa, Int32 idPersona);

        [OperationContract]
        ClienteAvalE ObtenerClienteAval(Int32 idEmpresa, Int32 idPersona, Int32 idAval);

        #endregion

        #region IProveedorContacto Members JOSE SALAZAR

        [OperationContract]
        ProveedorContactoE InsertarProveedorContacto(ProveedorContactoE proveedorcontacto);

        [OperationContract]
        ProveedorContactoE ActualizarProveedorContacto(ProveedorContactoE proveedorcontacto);

        [OperationContract]
        int EliminarProveedorContacto(Int32 idPersona, Int32 idEmpresa, Int32 idItem);

        [OperationContract]
        List<ProveedorContactoE> ListarProveedorContacto(Int32 idEmpresa, Int32 idPersona);

        [OperationContract]
        ProveedorContactoE ObtenerProveedorContacto(Int32 idPersona, Int32 idEmpresa, Int32 idItem);

        #endregion

        #region ICostosClasificacion Members JOSE SALAZAR

        [OperationContract]
        CostosClasificacionE GrabarClasifica(CostosClasificacionE clasificacion, EnumOpcionGrabar Opcion);

        [OperationContract]
        CostosClasificacionE InsertarClasificacion(CostosClasificacionE clasificacion);

        [OperationContract]
        CostosClasificacionE ActualizarClasificacion(CostosClasificacionE clasificacion);

        [OperationContract]
        int EliminarClasificacion(Int32 idEmpresa, String CodClasificacion);

        [OperationContract]
        List<CostosClasificacionE> ListarClasificacion(Int32 idEmpresa);

        [OperationContract]
        List<CostosClasificacionE> ListarClasificacionCat(Int32 idEmpresa, Int32 numNivel);

        [OperationContract]
        CostosClasificacionE ObtenerClasificacion(Int32 idEmpresa, String CodClasificacion);

        #endregion

        #region ICostosEstruc Members JOSE SALAZAR

        [OperationContract]
        CostosEstrucE GrabarCostosEstruc(CostosEstrucE estruc, EnumOpcionGrabar Opcion, CostosEstrucE CostoEstruc = null);

        [OperationContract]
        CostosEstrucE InsertarEstruc(CostosEstrucE estruc);

        [OperationContract]
        CostosEstrucE ActualizarEstruc(CostosEstrucE estruc);

        [OperationContract]
        int EliminarEstruc(Int32 idEmpresa, Int32 numNivel);

        [OperationContract]
        List<CostosEstrucE> ListarEstruc();

        [OperationContract]
        CostosEstrucE ObtenerEstruc(Int32 idEmpresa, Int32 numNivel);

        #endregion

        #region ICostosMovimientos Members JOSE SALAZAR


        [OperationContract]
        CostosMovimientosE GrabarCostosMovimientos(CostosMovimientosE CostosMov, EnumOpcionGrabar Opcion);

        [OperationContract]
        CostosMovimientosE InsertarCostosMovimientos(CostosMovimientosE costosmovimientos);

        [OperationContract]
        CostosMovimientosE ActualizarCostosMovimientos(CostosMovimientosE costosmovimientos);

        [OperationContract]
        int EliminarCostosMovimientos(Int32 idEmpresa, String CodClasificacion, Int32 idElemento, String Anio);

        [OperationContract]
        List<CostosMovimientosE> ListarCostosMovimientos(Int32 idEmpresa, Int32 idElemento, String Anio);

        [OperationContract]
        CostosMovimientosE ObtenerCostosMovimientos(Int32 idEmpresa, String CodClasificacion, Int32 idElemento, String Anio);

        #endregion

        #region ICostosMovimientosItem Members JOSE SALAZAR

        [OperationContract]
        CostosMovimientosItemE InsertarCostosMovimientosItem(CostosMovimientosItemE costosmovimientositem);

        [OperationContract]
        CostosMovimientosItemE ActualizarCostosMovimientosItem(CostosMovimientosItemE costosmovimientositem);

        [OperationContract]
        int EliminarCostosMovimientosItem(Int32 idEmpresa, Int32 idElemento, String CodClasificacion, String Mes, String Anio);

        [OperationContract]
        List<CostosMovimientosItemE> ListarCostosMovimientosItem(Int32 idEmpresa, Int32 idElemento, String CodClasificacion);

        [OperationContract]
        CostosMovimientosItemE ObtenerCostosMovimientosItem(Int32 idEmpresa, Int32 idElemento, String CodClasificacion, String Mes, String Anio);

        #endregion

        #region IRegistro de Articulos JOSE SALAZAR

        [OperationContract]
        Int32 ProcesarArticuloServXLS(List<ArticuloServXLSE> oLista);

        [OperationContract]
        Int32 ErroresArticuloServXLSE();

        [OperationContract]
        Int32 IntegrarArticuloServXLSE();

        #endregion

        #region IProveedorCuenta Members JOSE SALAZAR

        [OperationContract]
        ProveedorCuentaE InsertarProveedorCuenta(ProveedorCuentaE proveedorcuenta);

        [OperationContract]
        ProveedorCuentaE ActualizarProveedorCuenta(ProveedorCuentaE proveedorcuenta);

        [OperationContract]
        int AnularProveedorCuenta(Int32 idPersona, Int32 idEmpresa, Int32 idItem, Boolean indBaja);

        [OperationContract]
        List<ProveedorCuentaE> ListarProveedorCuenta(Int32 idEmpresa, Int32 idPersona, Boolean indBaja);

        [OperationContract]
        ProveedorCuentaE ObtenerProveedorCuenta(Int32 idPersona, Int32 idEmpresa, Int32 idItem);

        [OperationContract]
        List<ProveedorCuentaE> BancosPorProv(Int32 idPersona, Int32 idEmpresa);

        [OperationContract]
        List<ProveedorCuentaE> TipoCuentaProv(Int32 idPersona, Int32 idEmpresa, Int32 idPersonaBanco);

        [OperationContract]
        List<ProveedorCuentaE> CuentasBancosProv(Int32 idPersona, Int32 idEmpresa, Int32 idPersonaBanco, Int32 tipCuenta);

        [OperationContract]
        ProveedorCuentaE ObtenerProvCtaDefecto(Int32 idPersona, Int32 idEmpresa, String idMoneda);

        #endregion

        #region ICCostosNumControlDet Members JOSE SALAZAR

        [OperationContract]
        CCostosNumControlDetE InsertarCCostosNumControlDet(CCostosNumControlDetE ccostosnumcontroldet);

        [OperationContract]
        int EliminarCCostosNumControlDet(Int32 idEmpresa, String idCCostos, String idDocumento, String Serie);

        [OperationContract]
        List<CCostosNumControlDetE> ListarCCostosNumControlDet(Int32 idEmpresa, String idCCostos);

        [OperationContract]
        CCostosNumControlDetE ObtenerCCostosNumControlDet(Int32 idEmpresa, String idCCostos, String idDocumento, String Serie);

        [OperationContract]
        CCostosNumControlDetE CCostosNumControlPorSerie(Int32 idEmpresa, String idDocumento, String Serie);

        [OperationContract]
        List<CCostosNumControlDetE> CCostosNumControlPorCC(Int32 idEmpresa, String idCCostos);

        #endregion

        #region IEmisionDocumentoCCostos Members JOSE SALAZAR

        [OperationContract]
        EmisionDocumentoCCostosE InsertarEmisionDocumentoCCostos(EmisionDocumentoCCostosE emisiondocumentoccostos);

        [OperationContract]
        EmisionDocumentoCCostosE ActualizarEmisionDocumentoCCostos(EmisionDocumentoCCostosE emisiondocumentoccostos);

        [OperationContract]
        int EliminarEmisionDocumentoCCostos(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        List<EmisionDocumentoCCostosE> ListarEmisionDocumentoCCostos(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        EmisionDocumentoCCostosE ObtenerEmisionDocumentoCCostos(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String idCCostos);

        #endregion

        #region IClienteXLS Members JOSE SALAZAR

        [OperationContract]
        Int32 InsertarClienteXLS(List<ClienteXLSE> oListaCliente);

        [OperationContract]
        Int32 ErroresClienteXLS(List<ClienteXLSE> oListaErrores);

        [OperationContract]
        Int32 IntegrarClienteXLS(List<ClienteXLSE> oListaAuxiliares, String Tipo, String Usuario);

        [OperationContract]
        Int32 EliminarClienteXLS(List<ClienteXLSE> oListaPorEliminar);

        #endregion

        #region IImportacionComprasXLS Members JOSE SALAZAR

        [OperationContract]
        Int32 InsertarComprasXLS(List<ImportacionComprasXLSE> oListaCompras);

        [OperationContract]
        Int32 IntegrarImportacionCompras(List<ImportacionComprasXLSE> oListaImportacionCompras, String Usuario);

        #endregion

        #region IImpresionBarras Members JOSE SALAZAR

        [OperationContract]
        ImpresionBarrasE InsertarImpresionBarras(ImpresionBarrasE impresionbarras);

        [OperationContract]
        ImpresionBarrasE ActualizarImpresionBarras(ImpresionBarrasE impresionbarras);

        [OperationContract]
        int EliminarImpresionBarras(Int32 idImpresion);

        [OperationContract]
        List<ImpresionBarrasE> ListarImpresionBarras(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        ImpresionBarrasE ObtenerImpresionBarras(Int32 idImpresion);

        #endregion

        #region IImpresionBarrasDet Members JOSE SALAZAR

        [OperationContract]
        ImpresionBarrasDetE InsertarImpresionBarrasDet(ImpresionBarrasDetE impresionbarrasdet);

        [OperationContract]
        ImpresionBarrasDetE ActualizarImpresionBarrasDet(ImpresionBarrasDetE impresionbarrasdet);

        [OperationContract]
        int EliminarImpresionBarrasDet(Int32 idImpresion, Int32 idArticulo);

        [OperationContract]
        List<ImpresionBarrasDetE> ListarImpresionBarrasDet(Int32 idImpresion);

        [OperationContract]
        ImpresionBarrasDetE ObtenerImpresionBarrasDet(Int32 idImpresion, Int32 idArticulo);

        #endregion

        #region IImpresionBarrasDetDet Members JOSE SALAZAR

        [OperationContract]
        ImpresionBarrasDetDetE InsertarImpresionBarrasDetDet(ImpresionBarrasDetDetE impresionbarrasdetdet);

        [OperationContract]
        ImpresionBarrasDetDetE ActualizarImpresionBarrasDetDet(ImpresionBarrasDetDetE impresionbarrasdetdet);

        [OperationContract]
        int EliminarImpresionBarrasDetDet(Int32 idImpresion, Int32 idArticulo, Int32 Item);

        [OperationContract]
        List<ImpresionBarrasDetDetE> ListarImpresionBarrasDetDet(Int32 idImpresion, Int32 idArticulo);

        [OperationContract]
        ImpresionBarrasDetDetE ObtenerImpresionBarrasDetDet(Int32 idImpresion, Int32 idArticulo, Int32 Item);

        [OperationContract]
        List<ImpresionBarrasDetDetE> ListarImpresionCodigoBarras(Int32 idImpresion);

        [OperationContract]
        ImpresionBarrasDetDetE ObtenerImpresionDetDetPorBarras(Int32 idEmpresa, String codBarras);

        #endregion

        #region IAfectacionIgv Members JOSE SALAZAR

        [OperationContract]
        AfectacionIgvE InsertarAfectacionIgv(AfectacionIgvE afectacionigv);

        [OperationContract]
        AfectacionIgvE ActualizarAfectacionIgv(AfectacionIgvE afectacionigv);

        [OperationContract]
        int EliminarAfectacionIgv(Int32 idEmpresa, Int32 idAfectacion, Boolean indEstado, String UsuarioAnula);

        [OperationContract]
        List<AfectacionIgvE> ListarAfectacionIgv(Int32 idEmpresa);

        [OperationContract]
        AfectacionIgvE ObtenerAfectacionIgv(Int32 idEmpresa, Int32 idAfectacion);

        [OperationContract]
        List<AfectacionIgvE> ListarAfectacionIgvActivos(Int32 idEmpresa);

        #endregion

        #region IArticuloServSunat Members JOSE SALAZAR

        [OperationContract]
        ArticuloServSunatE InsertarArticuloServSunat(ArticuloServSunatE articuloservsunat);

        [OperationContract]
        ArticuloServSunatE ActualizarArticuloServSunat(ArticuloServSunatE articuloservsunat);

        [OperationContract]
        int EliminarArticuloServSunat(Int32 idEmpresa, String CodigoSunat);

        [OperationContract]
        List<ArticuloServSunatE> ListarArticuloServSunat(Int32 idEmpresa);

        [OperationContract]
        ArticuloServSunatE ObtenerArticuloServSunat(Int32 idEmpresa, String CodigoSunat);

        #endregion

        #region IArticuloKit Members JOSE SALAZAR

        [OperationContract]
        ArticuloKitE InsertarArticuloKit(ArticuloKitE articulokit);

        [OperationContract]
        ArticuloKitE ActualizarArticuloKit(ArticuloKitE articulokit);

        [OperationContract]
        int EliminarArticuloKit(Int32 idEmpresa, Int32 idArticulo, Int32 idArticuloComponente);

        [OperationContract]
        List<ArticuloKitE> ListarArticuloKit(Int32 idArticulo);

        [OperationContract]
        ArticuloKitE ObtenerArticuloKit(Int32 idEmpresa, Int32 idArticulo, Int32 idArticuloComponente);

        #endregion

    }
}
