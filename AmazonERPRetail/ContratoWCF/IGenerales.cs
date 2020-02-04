using System;
using System.Collections.Generic;
using System.ServiceModel;

using Entidades.Generales;
using Infraestructura.Enumerados;

namespace ContratoWCF
{
    [ServiceContract]
    public interface IGenerales
    {

        #region Entidad ParTabla

        [OperationContract]
        Int32 InsertarParTabla(ParTabla partabla);

        [OperationContract]
        Int32 ActualizarParTabla(ParTabla partabla);

        [OperationContract]
        List<ParTabla> ListarParTablaCabecera(String parametro);

        [OperationContract]
        List<ParTabla> ListarParTabla(String parametro, Boolean activo, Boolean inactivo);

        [OperationContract]
        List<ParTabla> ListarParTablaPorGrupo(Int32 grupo, String parametro);

        [OperationContract]
        Int32 AnularParTabla(Int32 idPartabla);

        [OperationContract]
        ParTabla RecuperarParTablaPorId(Int32 idPartabla);

        [OperationContract]
        Int32 RecuperarMaxIdParTablaPorGrupo(Int32 grupo);

        [OperationContract]
        String RecuperarNombreGrupoParTabla(Int32 IdParTabla);

        [OperationContract]
        Int32 RecuperarMaxGrupoPartabla();

        [OperationContract]
        Dictionary<EnumParTabla, List<ParTabla>> ListarParTablaPorListaGrupo(List<EnumParTabla> listaGrupo);

        [OperationContract]
        List<ParTabla> RecuperarParTablaPorEnumerado(EnumParTabla enumParTabla, Boolean todos);

        [OperationContract]
        Dictionary<EnumParTabla, List<ParTabla>> RecuperarParTablaPorGrupoEnumeradoOpcionVacio(Dictionary<EnumParTabla, Boolean> listaEnumParTabla);

        [OperationContract]
        List<ParTabla> ListarParTablaxGrupoXestado(Int32 grupo, Boolean activo, Boolean inactivo);

        [OperationContract]
        List<ParTabla> ListarParTablaCorrelativo();

        [OperationContract]
        List<ParTabla> ListarParTablaEnlace(Int32 ValorCadena);

        [OperationContract]
        List<ParTabla> ListarParTablaTemperaturas(Int32 grupo);

        [OperationContract]
        List<ParTabla> ListarParTablaPorNemo(String NemoTecnico);

        [OperationContract]
        Int32 ObtenerIdCalibre(String NemoTecnico);

        [OperationContract]
        Int32 ObtenerIdCategoria(String Nombre);

        [OperationContract]
        Int32 ObtenerIdColor(String Descripcion);

        [OperationContract]
        ParTabla ParTablaPorNemo(String NemoTecnico);

        [OperationContract]
        List<ParTabla> ListarParTablaPorValorCadena(String ValorCadena);

        [OperationContract]
        List<ParTabla> ListarParTablaPorValorEntero(Int32 ValorEntero);

        #endregion  

        #region Entidad Parametro JOSE SALAZAR

        [OperationContract]
        ParametroE GrabarParametro(ParametroE parametro);

        [OperationContract]
        Int32 EliminarParametro(Int32 IdEmpresa, Int32 IdParametro, Int32 idUsuario);

        [OperationContract]
        List<ParametroE> ListarParametro();

        [OperationContract]
        ParametroE ObtenerParametro(Int32 IdEmpresa, Int32 IdParametro, Int32 idUsuario);

        [OperationContract]
        List<ParametroE> ListarParametroPorUsuario(Int32 IdEmpresa, Int32 idUsuario);
        
        [OperationContract]
        Int32 ActualizarEstadoParametro(Int32 idEmpresa, Int32 idParametro, Boolean estado, String usuarioModificacion, DateTime fechaModificacion);

        #endregion

        #region IMarca Members JOSE SALAZAR

        [OperationContract]
        Marca InsertarMarca(Marca marca);

        [OperationContract]
        Marca ActualizarMarca(Marca marca);

        [OperationContract]
        Marca GrabarMarcas(Marca marcas, EnumOpcionGrabar opcion);

        [OperationContract]
        List<Marca> ListarMarca(Int32 codSistema);

        [OperationContract]
        List<Marca> ListarMarcaBusqueda();

        [OperationContract]
        void BorrarMarca(Int32 idMarca, Int32 codSistema);

        [OperationContract]
        List<Marca> BuscarMarcaPorDescripcion(Int32 codSistema, String nombre);

        [OperationContract]
        Int32 ObtenerIdmarcas(String nombre);

        #endregion

        #region ITipoCambio Members JOSE SALAZAR

        [OperationContract]
        TipoCambioE InsertarTipoCambio(TipoCambioE tipocambio);

        [OperationContract]
        TipoCambioE ActualizarTipoCambio(TipoCambioE tipocambio);

        [OperationContract]
        List<TipoCambioE> ListarTipoCambioPorFechas(String idMoneda, string fecIni, string fecFin);

        [OperationContract]
        TipoCambioE ObtenerTipoCambioPorDia(String idMoneda, string fecCambio);

        [OperationContract]
        void GrabarTipoCambioPorDia(TipoCambioE tipocambio);

        [OperationContract]
        void GrabarTipoCambioMasivo(List<TipoCambioE> oListaTipoCambio);

        #endregion      

        #region IMonedas Members JOSE SALAZAR

        [OperationContract]
        MonedasE InsertarMonedas(MonedasE monedas);

        [OperationContract]
        MonedasE ActualizarMonedas(MonedasE monedas);

        [OperationContract]
        MonedasE GrabarMoneda(MonedasE monedas, EnumOpcionGrabar Opcion);

        [OperationContract]
        List<MonedasE> ListarMonedas();

        //[OperationContract]
        //Int32 AnularMonedasPorCodigo(String idMoneda);

        //[OperationContract]
        //MonedasE RecuperarMonedasPorCodigo(String idMoneda);

        #endregion        

        #region Sistemas JOSE SALAZAR

        [OperationContract]
        List<SistemasE> ListarSistemas();

        #endregion

        #region IUMedida Members JOSE SALAZAR

        [OperationContract]
        UMedidaE InsertarUMedida(UMedidaE umedida);

        [OperationContract]
        UMedidaE ActualizarUMedida(UMedidaE umedida);

        [OperationContract]
        Int32 EliminarUMedida(Int32 idUMedida);

        [OperationContract]
        List<UMedidaE> ListarUMedida(string NomUMedida);

        [OperationContract]
        UMedidaE ObtenerUMedida(Int32 idUMedida);

        #endregion       

        #region IPaises Members JOSE SALAZAR

        [OperationContract]
        PaisesE InsertarPaises(PaisesE paises);

        [OperationContract]
        PaisesE ActualizarPaises(PaisesE paises);

        //[OperationContract]
        //Int32 EliminarPaises(Int32 idPais);

        [OperationContract]
        List<PaisesE> ListarPaises();

        [OperationContract]
        List<PaisesE> ListarPaisesPuerto();

        [OperationContract]
        PaisesE ObtenerPaises(Int32 idPais);

        [OperationContract]
        List<PaisesE> ListarPaisesTemperatura();

        [OperationContract]
        List<PaisesE> ListarPaisesPuertos();

        #endregion

        #region ITasasDetracciones Members JOSE SALAZAR

        [OperationContract]
        TasasDetraccionesE GrabarTasasDetracciones(TasasDetraccionesE tasasdetra, EnumOpcionGrabar OpcionGrabacion);

        [OperationContract]
        TasasDetraccionesE InsertarTasasDetracciones(TasasDetraccionesE tasasdetracciones);

        [OperationContract]
        TasasDetraccionesE ActualizarTasasDetracciones(TasasDetraccionesE tasasdetracciones);

        [OperationContract]
        Int32 EliminarTasasDetracciones(String idtipo_detraccion);

        [OperationContract]
        List<TasasDetraccionesE> ListarTasasDetracciones();

        [OperationContract]
        TasasDetraccionesE ObtenerTasasDetracciones(String idtipo_detraccion);

        [OperationContract]
        TasasDetraccionesE ObtenerTasasDetraccionesCompleto(String idTipoDetraccion);

        [OperationContract]
        List<TasasDetraccionesE> ListarDetraccionesCabActivas(); //JOSE SALAZAR

        #endregion

        #region ITasasDetraccionesDetalle Members JOSE SALAZAR

        [OperationContract]
        TasasDetraccionesDetalleE InsertarTasasDetraccionesDetalle(TasasDetraccionesDetalleE tasasdetraccionesdetalle);

        [OperationContract]
        TasasDetraccionesDetalleE ActualizarTasasDetraccionesDetalle(TasasDetraccionesDetalleE tasasdetraccionesdetalle);

        [OperationContract]
        int EliminarTasasDetraccionesDetalle(String idTipoDetraccion, Int32 item);

        [OperationContract]
        List<TasasDetraccionesDetalleE> ListarTasasDetraccionesDetalle(String idTipoDetraccion);

        [OperationContract]
        TasasDetraccionesDetalleE ObtenerTasasDetraccionesDetalle(String idTipoDetraccion, Int32 item);

        [OperationContract]
        List<TasasDetraccionesDetalleE> ListarDetraccionesDetActivas(DateTime fecDetraccion, String idTipoDetraccion = "%"); //JOSE SALAZAR

        #endregion 

        #region IImpuestos Members JOSE SALAZAR

        [OperationContract]
        ImpuestosE InsertarImpuestos(ImpuestosE impuestos);

        [OperationContract]
        ImpuestosE GrabarImpuestosControl(ImpuestosE impuestos, EnumOpcionGrabar OpcionGrabacion);

        [OperationContract]
        ImpuestosE ActualizarImpuestos(ImpuestosE impuestos);

        [OperationContract]
        Int32 EliminarImpuestos(Int32 idImpuesto);

        [OperationContract]
        List<ImpuestosE> ListarImpuestos();

        [OperationContract]
        ImpuestosE ObtenerImpuestos(Int32 idImpuesto);

        [OperationContract]
        ImpuestosE ObtenerImpuestosCompleto(Int32 idImpuesto);

        #endregion

        #region IImpuestosPeriodo Members JOSE SALAZAR

        [OperationContract]
        ImpuestosPeriodoE InsertarImpuestosPeriodo(ImpuestosPeriodoE impuestosperiodo);

        [OperationContract]
        ImpuestosPeriodoE ActualizarImpuestosPeriodo(ImpuestosPeriodoE impuestosperiodo);

        [OperationContract]
        Int32 EliminarImpuestosPeriodo(Int32 idImpuesto);

        [OperationContract]
        List<ImpuestosPeriodoE> ListarImpuestosPeriodo();

        [OperationContract]
        ImpuestosPeriodoE ObtenerImpuestosPeriodo(Int32 idImpuesto, Int32 Item);

        [OperationContract]
        ImpuestosPeriodoE ObtenerPorcentajeImpuesto(Int32 idImpuesto, DateTime Fecha);

        [OperationContract]
        List<ImpuestosPeriodoE> ListarPorcentajeImpuesto(DateTime Fecha);

        #endregion

        #region IImpuestosDocumentos Members

        [OperationContract]
        ImpuestosDocumentosE InsertarImpuestosDocumentos(ImpuestosDocumentosE impuestosdocumentos);

        [OperationContract]
        ImpuestosDocumentosE ActualizarImpuestosDocumentos(ImpuestosDocumentosE impuestosdocumentos);

        [OperationContract]
        Int32 EliminarImpuestosDocumentos(String idDocumento, Int32 idImpuesto);

        [OperationContract]
        List<ImpuestosDocumentosE> ListarImpuestosDocumentos();

        [OperationContract]
        ImpuestosDocumentosE ObtenerImpuestosDocumentos(String idDocumento, Int32 idImpuesto);

        [OperationContract]
        List<ImpuestosDocumentosE> ListarImpuestosPorIdDocumento(String idDocumento);

        #endregion

        #region IImportarCompras Members HENRY

        
        [OperationContract]
        Int32 ImportarCompras(String codEmpresa, String codSucursal, String codLibro, DateTime fecDesde, DateTime fecHasta, Int32 idEmpresa);


        #endregion

        #region IContactosCorreosGrupo Members JOSE SALAZAR

        [OperationContract]
        ContactosCorreosGrupoE GrabarCorreoGrupo(ContactosCorreosGrupoE Grupo, EnumOpcionGrabar OpcionGrabacion);

        [OperationContract]
        ContactosCorreosGrupoE InsertarContactosCorreosGrupo(ContactosCorreosGrupoE contactoscorreosgrupo);

        [OperationContract]
        ContactosCorreosGrupoE ActualizarContactosCorreosGrupo(ContactosCorreosGrupoE contactoscorreosgrupo);

        [OperationContract]
        int EliminarContactosCorreosGrupo(Int32 idGrupo);

        [OperationContract]
        List<ContactosCorreosGrupoE> ListarContactosCorreosGrupo(Int32 idUsuario);

        [OperationContract]
        ContactosCorreosGrupoE ObtenerContactosCorreosGrupo(Int32 idGrupo);

        [OperationContract]
        Int32 RevisarCorreosGrupoPorDefecto(Int32 idGrupo, Int32 idUsuario);

        #endregion

        #region IContactosCorreos Members JOSE SALAZAR

        [OperationContract]
        ContactosCorreosE InsertarContactosCorreos(ContactosCorreosE contactoscorreos);

        [OperationContract]
        ContactosCorreosE ActualizarContactosCorreos(ContactosCorreosE contactoscorreos);

        [OperationContract]
        int EliminarContactosCorreos(Int32 idGrupo, Int32 idCorreo);

        [OperationContract]
        List<ContactosCorreosE> ListarContactosCorreos();

        [OperationContract]
        ContactosCorreosE ObtenerContactosCorreos(Int32 idCorreo);

        [OperationContract]
        List<ContactosCorreosE> ListarCorreosBusqueda();

        [OperationContract]
        List<ContactosCorreosE> ListarCorreosPorDefecto(Int32 idUsuario);

        [OperationContract]
        List<ContactosCorreosE> ListarContactosCorreosPorGrupo(Int32 idGrupo);

        #endregion

        #region IUsuarioImpresoras Members JOSE SALAZAR

        [OperationContract]
        UsuarioImpresorasE GrabarUsuarioImpresoras(UsuarioImpresorasE usuarioimpresoras, EnumOpcionGrabar opcionGrabar);

        [OperationContract]
        UsuarioImpresorasE InsertarUsuarioImpresoras(UsuarioImpresorasE usuarioimpresoras);

        [OperationContract]
        UsuarioImpresorasE ActualizarUsuarioImpresoras(UsuarioImpresorasE usuarioimpresoras);

        [OperationContract]
        int EliminarUsuarioImpresoras(Int32 idImpresora, Int32 idPersona);

        [OperationContract]
        List<UsuarioImpresorasE> ListarUsuarioImpresoras(Int32 idPersona);

        [OperationContract]
        UsuarioImpresorasE ObtenerUsuarioImpresoras(Int32 idImpresora, Int32 idPersona, String ConDetalle = "N");

        [OperationContract]
        List<UsuarioImpresorasE> ListarUsuarioImpresorasBarras(Int32 idPersona);

        #endregion

        #region IUsuarioImpresorasDet Members JOSE SALAZAR

        [OperationContract]
        UsuarioImpresorasDetE InsertarUsuarioImpresorasDet(UsuarioImpresorasDetE usuarioimpresorasdet);

        [OperationContract]
        UsuarioImpresorasDetE ActualizarUsuarioImpresorasDet(UsuarioImpresorasDetE usuarioimpresorasdet);

        [OperationContract]
        int EliminarUsuarioImpresorasDet(Int32 idImpresora, Int32 Item);

        [OperationContract]
        List<UsuarioImpresorasDetE> ListarUsuarioImpresorasDet(Int32 idImpresora);

        [OperationContract]
        UsuarioImpresorasDetE ObtenerUsuarioImpresorasDet(Int32 idImpresora, Int32 Item);

        #endregion

        #region IEstructuraXLS Members JOSE SALAZAR

        [OperationContract]
        EstructuraXLSE InsertarEstructuraXLS(EstructuraXLSE estructuraxls);

        [OperationContract]
        EstructuraXLSE ActualizarEstructuraXLS(EstructuraXLSE estructuraxls);

        [OperationContract]
        int EliminarEstructuraXLS(Int32 Item);

        [OperationContract]
        List<EstructuraXLSE> ListarEstructuraXLS(Int32 idEmpresa);

        [OperationContract]
        EstructuraXLSE ObtenerEstructuraXLS(Int32 idEmpresa, Int32 Tipo);

        [OperationContract]
        List<EstructuraXLSE> NombreColumnasTabla(String NombreTabla);

        #endregion

        #region IControlDetracciones Members JOSE SALAZAR

        [OperationContract]
        ControlDetraccionesE InsertarControlDetracciones(ControlDetraccionesE controldetracciones);

        [OperationContract]
        Int32 ActualizarControlDetracciones(List<ControlDetraccionesE> controldetracciones);

        [OperationContract]
        int EliminarControlDetracciones(Int32 idControl);

        [OperationContract]
        List<ControlDetraccionesE> ListarControlDetracciones(Int32 idEmpresa);

        [OperationContract]
        List<ControlDetraccionesE> ObtenerControlDetraccionesPorOp(Int32 idOrdenPago);

        [OperationContract]
        int EliminarControlDetraccionesPorOp(Int32 idOrdenPago);

        #endregion

    }
}
