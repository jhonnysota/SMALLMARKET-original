using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Infraestructura.Enumerados
{
    [DataContract]
    public enum EnumParTabla
    {
        [EnumMember]
        TipoDocumento = 101000,
        [EnumMember]
        TipoPersona = 102000,
        [EnumMember]
        TipoSituacion = 103000,
        [EnumMember]
        TipoCliente = 104000,
        [EnumMember]
        TipoComprobantePago = 105000,
        [EnumMember]
        TipoMercado = 106000,
        [EnumMember]
        TipoDireccion = 107000,
        [EnumMember]
        TipoVia = 108000,
        [EnumMember]
        TipoZona = 109000,
        [EnumMember]
        TipoOrdenPedido = 110000,
        [EnumMember]
        TipoDestinoVenta = 191000,
        [EnumMember]
        TipoMoneda = 111000,
        [EnumMember]
        TipoFormaEntrega = 112000,
        [EnumMember]
        TipoPrioridad = 113000,
        [EnumMember]
        TipoOrigen = 114000,
        [EnumMember]
        TipoUnidadMedida = 116000,
        [EnumMember]
        TipoUso = 118000,
        [EnumMember]
        TipoOrden = 120000,
        [EnumMember]
        TipoVencimiento = 122000,
        [EnumMember]
        TipoArticulo = 124000,
        [EnumMember]
        TipoSituacionMuestra = 126000,
        [EnumMember]
        TipoConceptoNotaCredito = 130000,
        [EnumMember]
        TipoAlmacen = 132000,
        //[EnumMember]
        //ClaseAlmacen = 134000,
        [EnumMember]
        TipoAplicacion = 136000,
        [EnumMember]
        TipoVehiculo = 137000,
        [EnumMember]
        TipoMarca = 138000,
        [EnumMember]
        TipoModelo = 139000,
        [EnumMember]
        Correlativo = 140000,
        [EnumMember]
        TipoLicencia = 141000,
        [EnumMember]
        TipoCaracteristica = 142000,
        [EnumMember]
        TipoFormaPago = 143000,
        [EnumMember]
        EnumTipoObservacion = 144000,
        [EnumMember]
        TipoSituacionOrdenPedido = 145000,
        [EnumMember]
        TipoSituacionFormulario = 146000,
        [EnumMember]
        TipoSituacionSolProdProceso = 148000,
        [EnumMember]
        TipoSituacionSolProdInsumo = 149000,
        [EnumMember]
        TipoSolicitudProduccion = 147000,
        [EnumMember]
        TipoPrefinito = 150000,
        [EnumMember]
        TipoDespacho = 157000,
        [EnumMember]
        TipoSubAlmacen = 162000,
        [EnumMember]
        MotivoTraslado = 161000,
        [EnumMember]
        SituacionGuiaRemision = 164000,
        [EnumMember]
        TipoMovimientoAlmacen = 169000,
        [EnumMember]
        TipoRequerimientoInsumo = 170000,
        [EnumMember]
        TipoSituacionReqInsumo = 171000,
        [EnumMember]
        TipoSituacionReqInsumoitem = 172000,
        //[EnumMember]
        //ModalidadOrdenCompra = 173000,
        [EnumMember]
        SituacionOrdenCompra = 175000,
        [EnumMember]
        TipoDia = 178000,
        [EnumMember]
        TipoCuentaPorPagar = 179000,
        [EnumMember]
        EstadoCuentasPagar = 181000,
        [EnumMember]
        TipoAplicacionNC = 183000,
        [EnumMember]
        SituacionMovAlmacen = 184000,
        [EnumMember]
        TipoOrdenMantenimiento = 185000,
        [EnumMember]
        SituacionOrdenMantenimiento = 187000,
        [EnumMember]
        TipoImpresionFactura = 188000,
        [EnumMember]
        TipoImpresionGuiaRemision = 189000,
        [EnumMember]
        SituacionDespacho = 158000,
        [EnumMember]
        SituacionAlbaran = 166000,
        [EnumMember]
        SituacionCajaVenta = 193000,
        [EnumMember]
        TipoVenta = 195000,
        [EnumMember]
        TipoFacturacion = 196000,
        [EnumMember]
        SituacionComprobantePago = 168000,
        [EnumMember]
        TipoDiaSemana = 194000,
        [EnumMember]
        TipoMovimientoPlanilla = 197000,
        [EnumMember]
        TipoValorPlanilla = 198000,
        [EnumMember]
        TipoTributoPlanilla = 199000,
        [EnumMember]
        SituacionCanjeLetra = 201000,
        [EnumMember]
        TipoEntidad = 202000,
        [EnumMember]
        TipoCuenta = 228000,
        [EnumMember]
        TipoNaturaleza = 229000,
        [EnumMember]
        TipoCargo = 203000,
        [EnumMember]
        TipoTrabajadorSunat = 204000,
        [EnumMember]
        Nacionalidad = 206000,
        [EnumMember]
        EstadoCivil = 207000,
        [EnumMember]
        PaisEmisorDocumento = 208000,
        [EnumMember]
        CodigoLargaDistancia = 209000,
        [EnumMember]
        CategoriaOcupacional = 210000,
        [EnumMember]
        NivelEducativo = 211000,
        [EnumMember]
        Pago = 212000,
        [EnumMember]
        RegimenPensionario = 213000,
        [EnumMember]
        Sexo = 214000,
        [EnumMember]
        AporteArtista = 215000,
        [EnumMember]
        VidaSeguroAccidente = 216000,
        [EnumMember]
        RegimenLaboral = 217000,
        [EnumMember]
        SituacionEspecial = 218000,
        [EnumMember]
        ConvenioTributario = 219000,
        [EnumMember]
        PeriodicidadRemunerativa = 220000,
        [EnumMember]
        RegimenSalud = 221000,
        [EnumMember]
        MotivoCese = 222000,
        [EnumMember]
        SituacionTrabajador = 223000,
        [EnumMember]
        ModalidadFormativa = 224000,
        [EnumMember]
        SctrSalud = 225000,
        [EnumMember]
        SctrPension = 226000,
        [EnumMember]
        Contrato = 227000,
        [EnumMember]
        TipoSeleccion = 230000,
        [EnumMember]
        SituacionPlanoProduccion = 231000,
        [EnumMember]
        TipoCuentaBancaria = 232000,
        [EnumMember]
        TipoGeneracionBoleta = 233000,
        [EnumMember]
        TipoCalculoBoleta = 234000,
        [EnumMember]
        TipoResumenPlanilla = 235000,
        [EnumMember]
        TipoMarcacionMasiva = 236000,
        [EnumMember]
        CaracteristicaInsumo = 237000,
        [EnumMember]
        TipoCredito = 238000,
        [EnumMember]
        TipoPiel = 239000,
        [EnumMember]
        TipoSituacionGeneral = 240000,
        [EnumMember]
        TipoRetencion = 241000,
        [EnumMember]
        TipoDevolucionSalida = 242000,
        [EnumMember]
        SerieTalla = 243000,
        [EnumMember]
        SituacionMovCheque = 244000,
        [EnumMember]
        TipoEgresoTesoreria = 245000,
        [EnumMember]
        TipoPagoTesoreria = 246000,
        [EnumMember]
        SituacionCajaChica = 247000,
        [EnumMember]
        TipoEgresoCajaChica = 248000,
        [EnumMember]
        SituacionLiquidacion = 249000,
        [EnumMember]
        SituacionMovBanco = 250000,
        [EnumMember]
        SituacionMovAsignaDocumento = 251000,
        [EnumMember]
        TipoNaturalezaCompra = 252000,
        [EnumMember]
        TipoConfiguracionContable = 253000,
        [EnumMember]
        TipoBeneficio = 254000,
        [EnumMember]
        TipoOrigenEmisionComprobante = 255000,
        [EnumMember]
        TipoSalidaCajaVenta = 256000,
        [EnumMember]
        TipoPlanilla = 257000,
        [EnumMember]
        TipoLibroContable = 258000,
        [EnumMember]
        TipoDescuentoPorApertura = 259000,
        [EnumMember]
        TipoAgrupacionParTabla = 260000,
        [EnumMember]
        TipoRelacionPersona = 261000,
        [EnumMember]
        TipoSituacionValeEmision = 262000,
        [EnumMember]
        TipoOrigenGuia = 264000,
        [EnumMember]
        TipoServicio = 265000,
        [EnumMember]
        SituacionArticulosValeEmision = 266000,
        [EnumMember]
        TipoMovimientoBeneficio = 267000,
        [EnumMember]
        SituacionPrestamo = 269000,
        [EnumMember]

        #region Contabilidad

        TipoDiario = 270000,
        [EnumMember]
        ClaseFile = 271000,
        [EnumMember]
        TipoDetraccion = 272000,
        [EnumMember]
        TipoBalanceContable = 275000,
        [EnumMember]
        TipoAjusteDiferencia = 274000, //Ajuste de Cambio Ganancia o perdida...
        [EnumMember]
        ConceptosCoVen = 273000, //Tipos Conceptos compras/ventas
        [EnumMember]
        TipoBaseImponibles = 276000,
        [EnumMember]
        TipoIgv = 277000,
        [EnumMember]
        TipoTotal = 278000,
        [EnumMember]
        TipoCajaChica = 288000,
        [EnumMember]
        CuentasDiferenciaCambio = 289000,

        #endregion

        [EnumMember]
        CondicionLocal = 281000,        
        [EnumMember]
        TipoContribuyente = 282000,
        [EnumMember]
        TipoProveedor = 283000,
        [EnumMember]
        RegimenEmpresa = 284000,
        [EnumMember]
        CategoriaEmpresa = 285000,

        #region Para los pedidos
        
        [EnumMember]
        CalibreArticuloPed = 290000,
        [EnumMember]
        CategoriaArticuloPed = 292000,
        [EnumMember]
        TipoPrecioPed = 301000,

        #endregion

        [EnumMember]
        TemperaturaPaises = 304000,

        #region Para exportacion

        [EnumMember]
        Calibre = 290000,
        [EnumMember]
        Categoria = 292000,
        [EnumMember]
        Color = 293000,

        #endregion

        [EnumMember]
        MedioPago = 306000,

        [EnumMember]
        TipoOrdenCompra = 120000,

        [EnumMember]
        OrigenOrdenCompra = 186000,

        [EnumMember]
        ModalidadOrdenCompra = 144000,

        [EnumMember]
        CanalVenta = 106000,

        #region Para Planilla

        [EnumMember]
        AreaTrabajador = 313000,

        [EnumMember]
        AreaCategoriaTrabajador = 328000,

        [EnumMember]
        FormaPagoTrabajador = 212000,

        [EnumMember]
        TipoCtaBancoTrabajador = 232000,

        [EnumMember]
        TipoTrabajador = 204000,

        [EnumMember]
        SituacionEspecialTrabajador = 218000,

        [EnumMember]
        RegimenLaboralTrabajador = 217000,

        [EnumMember]
        RegimenPensionarioTrabajador = 213000,

        [EnumMember]
        SituaciondeTrabajador = 223000,

        [EnumMember]
        RegimenSaludTrabajador = 221000,

        [EnumMember]
        SctrSaludTrabajador = 225000,

        [EnumMember]
        SctrPensionTrabajador = 226000,

        [EnumMember]
        EmpresaAseguradora = 334000,

        [EnumMember]
        SedeTrabajador = 335000,

        [EnumMember]
        TipoViaTrabajador = 108000,

        [EnumMember]
        TipoZonaTrabajador = 109000,

        [EnumMember]
        EstadoCivilTrabajador = 207000,

        [EnumMember]
        NivelEducativoTrabajador = 211000

        #endregion

    }

    [DataContract]
    public enum EnumTipoEgreso
    {
        [EnumMember]
        SALIDAPORDEPOSITO = 256001,

        [EnumMember]
        SALIDAPOREMERGENCIA = 256002,

        [EnumMember]
        SALIDAPORNOTACREDITO = 256003
    }

    [DataContract]
    public enum EnumTipoDeTraccion
    {
        [EnumMember]
        N = 272001,
        [EnumMember]
        L = 272002,
        [EnumMember]
        V = 272003
    }

    [DataContract]
    public enum EnumTipoVenta
    {
        [EnumMember]
        PedidoCliente = 195001,
        [EnumMember]
        SinPedido = 195002,
        [EnumMember]
        Anticipos = 195003,
        [EnumMember]
        Diferida = 195004,
        [EnumMember]
        Insumos = 195005,
        [EnumMember]
        ActivoFijo = 195006,
        [EnumMember]
        Sobrantes = 195007,
        [EnumMember]
        Vale = 195008
    }

    [DataContract]
    public enum EnumSituacionCanjeLetra
    {
        [EnumMember]
        Pendiente = 201001,
        [EnumMember]
        Registrado = 201002,
        [EnumMember]
        Anulado = 201003
    }

    [DataContract]
    public enum EnumSituacionLetraCambio
    {
        [EnumMember]
        Pendiente = 200001,
        [EnumMember]
        Aprobado = 200002,
        [EnumMember]
        Cancelado = 200003,
        [EnumMember]
        Anulado = 200004
    }

    [DataContract]
    public enum EnumTipoFacturacion
    {
        [EnumMember]
        Mercaderia = 196001,
        [EnumMember]
        SinEntrega = 196002,
        [EnumMember]
        OtrasVentas = 196003,
        [EnumMember]
        PorVale = 196004
    }

    [DataContract]
    public enum EnumTipoImpresionFactura
    {
        [EnumMember]
        Regular = 188001,
        [EnumMember]
        Exportacion = 188002,
        [EnumMember]
        Agrupado = 188003
    }

    [DataContract]
    public enum EnumSituacionCajaVenta
    {
        [EnumMember]
        Registrado = 193001,
        [EnumMember]
        Abierto = 193002,
        [EnumMember]
        Cerrado = 193003,
        [EnumMember]
        Aqueada = 193004
    }

    [DataContract]
    public enum EnumTipoDestinoVenta
    {
        [EnumMember]
        Exterior = 191001,
        [EnumMember]
        Local = 191002
    }

    [DataContract]
    public enum EnumEstadoCuentasPagar
    {
        [EnumMember]
        NoGenerado = 181001,
        [EnumMember]
        Emitido = 181002,
        [EnumMember]
        Contabilizado = 181003,
        [EnumMember]
        Anulado = 181004
    }

    [DataContract]
    public enum EnumTipoCuentaPorPagar
    {
        [EnumMember]
        CompraAlExterior = 179001,
        [EnumMember]
        CompraLocal = 179002,
        [EnumMember]
        ReciboPorHonorario = 179003
    }

    [DataContract]
    public enum enumTipoPersona
    {
        [EnumMember]
        Juridica = 102001,
        [EnumMember]
        Natural_Ruc = 102002,
        [EnumMember]
        Natural_Sin_Ruc = 102003,
        [EnumMember]
        Otros = 102004
    }

    [DataContract]
    public enum EnumTipoDocumento
    {
        [EnumMember]
        Dni = 101001,
        [EnumMember]
        CarnetExtranjeria = 101002,
        [EnumMember]
        Cedula = 101003,
        [EnumMember]
        Ruc = 101004,
        [EnumMember]
        Otros = 101005,
        [EnumMember]
        Pasaporte = 101006,
    }

    [DataContract]
    public enum EnumTipoSituacion
    {
        [EnumMember]
        Abierto = 103001,
        [EnumMember]
        Cerrado = 103002,
        [EnumMember]
        Anulado = 103003

    }

    [DataContract]
    public enum EnumTipoSituacionCuentaPorPagar
    {
        [EnumMember]
        NoGenerado = 181001,
        [EnumMember]
        Emitido = 181002,
        [EnumMember]
        Contabilizado = 181003,
        [EnumMember]
        Anulado = 181004
    }

    [DataContract]
    public enum EnumTipoProveedor
    {
        [EnumMember]
        Nacional = 106001,
        [EnumMember]
        Importado = 106002
    }

    [DataContract]
    public enum EnumTipoSituacionMuestra
    {
        [EnumMember]
        Registrado = 126001,
        [EnumMember]
        Pendiente = 126002,
        [EnumMember]
        AprobadoJV = 126003,
        [EnumMember]
        AprobadoJD = 126004
    }

    [DataContract]
    public enum EnumTipoUso
    {
        [EnumMember]
        Muestra = 118001,
        [EnumMember]
        Mercaderia = 118002,
        [EnumMember]
        Servicio = 118003,
        [EnumMember]
        Anticipo = 118004
    }

    [DataContract]
    public enum EnumTipoOrigen
    {
        [EnumMember]
        Propio = 114001,
        [EnumMember]
        Consignatario = 114002,
        [EnumMember]
        Concesionario = 114003,
        [EnumMember]
        Servicio = 114004

    }

    //[DataContract]
    //public enum EnumTipoUnidadMedida
    //{
    //    [EnumMember]
    //    Pies2 = 116001,
    //    [EnumMember]
    //    Centimetros = 116002,
    //    [EnumMember]
    //    Kilogramos = 116003,
    //    [EnumMember]
    //    Litro = 116004,
    //    [EnumMember]
    //    Pulgadas = 116005,
    //    [EnumMember]
    //    MetrosCuadrados = 116006,
    //    [EnumMember]
    //    Unidades = 116007,
    //    [EnumMember]
    //    Unidad = 116008,
    //    [EnumMember]
    //    Par = 116009,
    //    [EnumMember]
    //    Decimal = 116010,
    //}

    [DataContract]
    public enum EnumTipoVencimiento
    {
        [EnumMember]
        DIAS_PARTIR_FACTURA_30 = 122001,
        [EnumMember]
        DIAS_PARTIR_FACTURA_60 = 122002,
        [EnumMember]
        DIAS_PARTIR_FACTURA_90 = 122003
    }

    [DataContract]
    public enum EnumTipoArticulo
    {
        [EnumMember]
        Insumo = 124001,
        [EnumMember]
        ProductoFinal = 124002,
        [EnumMember]
        ActivoFijo = 124003,
        [EnumMember]
        Horma = 124004,
        [EnumMember]
        TarjetaProduccion = 124005,
        [EnumMember]
        Servicio = 124006
    }

    [DataContract]
    public enum EnumTipoImagen
    {
        [EnumMember]
        Diseno = 132001,
        [EnumMember]
        Numerado = 132002,
    }

    [DataContract]
    public enum EnumTipoDireccion
    {
        [EnumMember]
        Principal = 107001,
    }

    [DataContract]
    public enum EnumTipoObservacion
    {
        [EnumMember]
        ObservacionDiseno = 144001,
        [EnumMember]
        ObservacionProduccion = 144002
    }

    [DataContract]
    public enum EnumTipoPrioridad
    {
        [EnumMember]
        Urgente = 113001,
        [EnumMember]
        Regular = 113002,
        [EnumMember]
        Baja = 113003

    }

    [DataContract]
    public enum EnumSituacionOrdenPedido_Mant_Devo
    {

        [EnumMember]
        Pendiente = 145001,
        [EnumMember]
        Procesado = 145002,
        [EnumMember]
        Aprobado = 145003,
        [EnumMember]
        EnProduccion = 145004,
        [EnumMember]
        EnTransito = 145005,
        [EnumMember]
        Anulada = 145006,
        [EnumMember]
        Recibido = 145007,
        [EnumMember]
        Rechazados = 145008,
             [EnumMember]
        Cerrada = 145009


    }

    [DataContract]
    public enum EnumTipoOrden
    {
        [EnumMember]
        OrdenPedido = 120001,
        [EnumMember]
        OrdenCompra = 120002

    }

    [DataContract]
    public enum EnumTipoOrdenPedido
    {
        [EnumMember]
        Produccion = 110001,
        [EnumMember]
        Disponible = 110002,

    }

    [DataContract]
    public enum EnumTipoOrdenMantenimiento
    {
        [EnumMember]
        OrdenGenerica = 185001,
        [EnumMember]
        OrdenMantenimiento = 185002,
        [EnumMember]
        OrdenDevolucion = 185003

    }

    [DataContract]
    public enum EnumSituacionOrdenMantenimiento
    {
        [EnumMember]
        Pendiente = 187001,
        [EnumMember]
        Registrado = 187002,
        [EnumMember]
        Procesado = 187003,
        [EnumMember]
        Anulado = 187004,
        [EnumMember]
        Cerrado = 187005

    }

    [DataContract]
    public enum EnumTipoSolicitudProduccion
    {
        [EnumMember]
        Muestra = 147001,
        [EnumMember]
        OrdenPedido = 147002,
        [EnumMember]
        OrdenMantenimiento = 147003
    }

    [DataContract]
    public enum EnumSituacionProceso
    {
        //Cuando se Genera la tarjeta de Produccion
        [EnumMember]
        Registrado = 148001,
        //Cuando  la primera tarjeta pasa a un Plano de produccion
        [EnumMember]
        EnProceso = 148002,
        //Cuando todas las tarjetas ya fueron finalizadas
        [EnumMember]
        Cerrado = 148003,
        //Cuando se anula la solicitud produccion
        [EnumMember]
        Anulado = 148004,
        //Cuando se Genera la Solicitud Produccion
        [EnumMember]
        Pendiente = 148006
    }

    [DataContract]
    public enum EnumSituacionInsumo
    {
        [EnumMember]
        Pendiente = 149001,
        [EnumMember]
        Parcial = 149002,
        [EnumMember]
        Atendido = 149003
    }

    [DataContract]
    public enum EnumSituacionTarjetaProceso
    {
        [EnumMember]
        Pendiente = 151001,
        [EnumMember]
        Registrado = 151002,
        [EnumMember]
        EnProceso = 151003,
        [EnumMember]
        Cerrado = 151004,
        [EnumMember]
        Anulado = 151005,
        [EnumMember]
        Despachada = 151006
    }

    [DataContract]
    public enum EnumSituacionTarjetaInsumo
    {
        [EnumMember]
        Pendiente = 152001,
        [EnumMember]
        Atendido = 152002
    }

    [DataContract]
    public enum EnumTipoActividad
    {
        //es cuando la actividad se realiza dentro de la empresa
        [EnumMember]
        Interna = 153001,
        //cuando la actividad se realiza fuera de la empresa
        [EnumMember]
        Externa = 153002
    }

    [DataContract]
    public enum EnumTipoOrigenActividadProductiva
    {
        //cuando la actividad sigue un conducto regular.
        [EnumMember]
        Regular = 154001,
        //cuando se hace una actividad extra
        [EnumMember]
        Adicional = 154002
    }

    [DataContract]
    public enum EnumTipoPagoActividadProductiva
    {
        //El pago lo asume la empresa
        [EnumMember]
        PagoEmpresa = 155001,
        //el pago lo asumen el trabajador
        [EnumMember]
        PagoTrabajador = 155002
    }

    [DataContract]
    public enum EnumSituacionActividadProductiva
    {
        [EnumMember]
        Registrado = 156001,
        [EnumMember]
        Pendiente = 156002,
        [EnumMember]
        aprobado = 156003
    }

    [DataContract]
    public enum EnumTipoDespacho
    {
        [EnumMember]
        PorOrdenPedido = 157001,
        [EnumMember]
        PorOrdenMantenimiento = 157002
    }

    [DataContract]
    public enum EnumSituacionDespacho
    {
        //cuando se crea
        [EnumMember]
        Pendiente = 158001,
        //en el despacho cuando esta todo, en el despachoitem cuando se asigna a la guia de remision
        [EnumMember]
        Atendida = 158002,
        [EnumMember]
        Anulada = 158003
    }

    [DataContract]
    public enum EnumSituacionTPSerie
    {
        //Por default Cuando se genera la serie
        [EnumMember]
        Pendiente = 159001,
        //Cuando Se asigna al Despacho
        [EnumMember]
        Asignado = 159002,
        //cuando se genera la Guia de Remision
        [EnumMember]
        Procesado = 159003
    }

    [DataContract]
    public enum EnumSituacionSolicitudProduccionItemEntrega
    {
        [EnumMember]
        Pendiente = 160001,
        [EnumMember]
        Atendido = 160002
    }

    [DataContract]
    public enum EnumTipoSubAlmacen
    {
        [EnumMember]
        DISPONIBLE = 162001,
        [EnumMember]
        EXTERNO = 162002,
        [EnumMember]
        EXHIBICION = 162003,
        [EnumMember]
        PRESTAMO = 162004,
        [EnumMember]
        CLIENTE = 162005,
        [EnumMember]
        SEPARACIONCLIENTE = 162006,
        [EnumMember]
        //
        MNTGENERICO = 162007,
        [EnumMember]
        PRODUCCION = 162008,
        [EnumMember]
        //
        SEPARACIONINSUMO = 162009,
        [EnumMember]
        SEPARACIONDESPACHO = 162010
    }

    [DataContract]
    public enum EnumSituacionGuiaRemision
    {
        [EnumMember]
        Pendiente = 164001,
        [EnumMember]
        Recibida = 164002,
        [EnumMember]
        Facturada = 164003,
        [EnumMember]
        Anulada = 164004
    }

    [DataContract]
    public enum EnumSituacionAlbaran
    {
        [EnumMember]
        Pendiente = 166001,
        [EnumMember]
        Registrado = 166002,
        [EnumMember]
        Procesado = 166003,
        [EnumMember]
        Anulada = 166004
    }

    [DataContract]
    public enum EnumSituacionMovVenta
    {
        [EnumMember]
        Registrado = 168001,
        [EnumMember]
        Cancelado = 168002,
        [EnumMember]
        Anulado = 168003,
        [EnumMember]
        Aplicado = 168004,
        [EnumMember]
        Proceso = 168005
    }

    [DataContract]
    public enum EnumTipoComprobante
    {
        [EnumMember]
        Factura = 105001,
        [EnumMember]
        Boleta = 105002,
        [EnumMember]
        NotaCredito = 105003,
        [EnumMember]
        LetraCambio = 105004,
        [EnumMember]
        ReciboPorHonorarios = 105005,
        [EnumMember]
        Ticket = 105006,
        [EnumMember]
        Otros = 105007,
        [EnumMember]
        SERVICIOS = 105008,
        [EnumMember]
        VALE = 105009,
        [EnumMember]
        PREFACTURA = 105010
    }

    [DataContract]
    public enum EnumTipoFormaPago
    {
        [EnumMember]
        Efectivo = 143001,
        [EnumMember]
        TarjetaMastercard = 143002,
        [EnumMember]
        TarjetaVisa = 143003,
        [EnumMember]
        TarjetaOtra = 143004,
        [EnumMember]
        NotaCredito = 143005,
        [EnumMember]
        Credito = 143006,
        [EnumMember]
        Cheque = 143007,
        [EnumMember]
        DepositoCuenta = 143008,
        [EnumMember]
        TrasferenciaCuenta = 143009,
        [EnumMember]
        TransferenciaGratuita = 143010,
        [EnumMember]
        LetraCambio = 143011,
        [EnumMember]
        Vuelto = 143012
    }

    [DataContract]
    public enum EnumTipoRequerimientoInsumo
    {
        [EnumMember]
        Reposicion = 170001,
        [EnumMember]
        Produccion = 170002
    }

    [DataContract]
    public enum EnumTipoCorrelativo
    {
        [EnumMember]
        Rango = 140001,
        [EnumMember]
        Boleta = 140002,
        [EnumMember]
        Factura = 140003,
        [EnumMember]
        GuiaRemision = 140004,
        [EnumMember]
        IngresoCompraLocal = 140005,
        [EnumMember]
        NotaCredito = 140006,
        [EnumMember]
        CuentasPorCobrar = 140007,
        [EnumMember]
        CalzadoDama = 140008,
        [EnumMember]
        CalzadoCaballero = 140000,
        [EnumMember]
        CarteraDama = 140000,

        [EnumMember]
        PRESTAMOCLIENTE = 140009,
        [EnumMember]
        DEVOLUCIONPROVEEDOR = 140010
    }

    [DataContract]
    public enum EnumModalidadOrdenCompra
    {
        [EnumMember]
        Compra = 173001,
        [EnumMember]
        Consignacion = 173002,
        [EnumMember]
        Concesion = 173003
    }

    [DataContract]
    public enum EnumTipoMovimientoAlmacen
    {
        [EnumMember]
        IngresoCompraLocal = 169001,
        [EnumMember]
        IngresoCompraExterior = 169002,
        [EnumMember]
        IngresoDevolucionCliente = 169003,
        [EnumMember]
        IngresoPorTransformacion = 169004,
        [EnumMember]
        IngresoPorProduccion = 169005,
        [EnumMember]
        IngresoPorConsignacion = 169006,
        [EnumMember]
        IngresoPorConcesion = 169007,
        [EnumMember]
        IngresoRegularizacionInventario = 169008,
        [EnumMember]
        TransfIngresoMntoDeTerceros = 169009,
        [EnumMember]
        TransfIngresoMntoHaciaTerceros = 169010,
        [EnumMember]
        TransfEntreSubAlmacenes = 169011,
        [EnumMember]
        TransfSalidaMntoDeTerceros = 169012,
        [EnumMember]
        TransfSalidaMntoHaciaTerceros = 169013,
        [EnumMember]
        TransfSalidaPorPrestamoRecibido = 169014,
        [EnumMember]
        TransfIngresoPorPrestamoRecibido = 169015,
        [EnumMember]
        TransfSalidaPorPrestamoEntregado = 169016,
        [EnumMember]
        TransfIngresoPorPrestamoEntregado = 169017,
        [EnumMember]
        TransfSalidaEntreAlmacenesInternos = 169018,
        [EnumMember]
        TransfIngresoEntreAlmacenesInternos = 169019,
        [EnumMember]
        TransfIngresoMnntoGenerico = 169020,
        [EnumMember]
        TransfSalidaMnntoGenerico = 169021,
        [EnumMember]
        SalidaPorVenta = 169022,
        [EnumMember]
        SalidaInsumosProduccion = 169023,
        [EnumMember]
        SalidaPorTransformacion = 169024,
        [EnumMember]
        SalidaRegularizacionInventario = 169025,
        [EnumMember]
        SalidaPorMerma = 169026,
        [EnumMember]
        SalidaPorObsolescencia = 169027,
        [EnumMember]
        SalidaPorDevolucionAProveedor = 169028,
        [EnumMember]
        SalidaPorDevolucionAConsignatario = 169029,
        [EnumMember]
        SalidaPorDevolucionAConcesionario = 169030
    }

    [DataContract]
    public enum EnumTipoSituacionReqInsumo
    {
        [EnumMember]
        REGISTRADO = 171001,
        [EnumMember]
        ATENDIDO = 171002,
        [EnumMember]
        ANULADO = 171003
    }

    [DataContract]
    public enum EnumTipoSituacionReqInsumoitem
    {
        [EnumMember]
        PENDIENTE = 172001,
        [EnumMember]
        PARCIAL = 172002,
        [EnumMember]
        ATENDIDO = 173003,
        [EnumMember]
        ANULADO = 173004
    }

    [DataContract]
    public enum EnumSituacionOrdenCompra
    {
        [EnumMember]
        PENDIENTE = 175001,
        [EnumMember]
        EMITIDO = 175002,
        [EnumMember]
        ATENDIDO = 175003,
        [EnumMember]
        ANULADO = 175004
    }

    [DataContract]
    public enum EnumTipoDia
    {
        [EnumMember]
        LABORABLE = 178001,
        [EnumMember]
        NOLABORABLE = 178002,
        [EnumMember]
        FERIADO = 178003,
    }

    [DataContract]
    public enum EnumTipoConceptoNotaCredito
    {
        [EnumMember]
        DevolucionMercaderia = 130001,
        [EnumMember]
        RebajaPosteriorEmision = 130002,
        [EnumMember]
        AnulacionComprobante = 130003
    }

    [DataContract]
    public enum EnumTipoAplicacionNC
    {
        [EnumMember]
        PorMontoTotal = 183001,
        [EnumMember]
        Poritems = 183002
    }

    [DataContract]
    public enum EnumSituacionMovAlmacen
    {
        [EnumMember]
        Pendiente = 184001,
        [EnumMember]
        Registrado = 184002,
        [EnumMember]
        Anulado = 184003
    }

    [DataContract]
    public enum EnumSituacionMovVentaCobro
    {
        [EnumMember]
        Registrado = 205001,
        [EnumMember]
        Anulado = 205002
    }

    [DataContract]
    public enum EnumTipoEntidad
    {
        [EnumMember]
        Empleado = 202001,
        [EnumMember]
        Trabajador = 202002,
        [EnumMember]
        Proveedor = 202003,
        [EnumMember]
        Bancos = 202004,
        [EnumMember]
        Local = 202005,
        [EnumMember]
        Area = 202006
    }

    [DataContract]
    public enum EnumTipoCuenta
    {
        [EnumMember]
        Activo = 228001,
        [EnumMember]
        Pasivo = 228002,
        [EnumMember]
        Resultado = 228003,
        [EnumMember]
        Naturaleza = 228004,
        [EnumMember]
        Orden = 228005
    }

    [DataContract]
    public enum EnumTipoNaturaleza
    {
        [EnumMember]
        Debe = 229001,
        [EnumMember]
        Haber = 229002
    }

    [DataContract]
    public enum EnumTipoSeleccion
    {
        [EnumMember]
        SoloSeleccionados = 230001,
        [EnumMember]
        NoSeleccionados = 230002,
        [EnumMember]
        Todos = 230003
    }

    [DataContract]
    public enum EnumSituacionPlanoProduccion
    {
        [EnumMember]
        Pendiente = 231001,
        [EnumMember]
        EnProceso = 231002,
        [EnumMember]
        Terminado = 231003
    }

    [DataContract]
    public enum EnumTipoSituacionTrabajador
    {
        [EnumMember]
        ACTIVO_SUBSIDIADO = 223001,
        [EnumMember]
        BAJA = 223002,
        [EnumMember]
        SUSPENSION_PERFECTA = 223003,
        [EnumMember]
        PENDIENTE_LIQUIDAR = 223004,
        //[EnumMember]
        //SUSPENSION_PERFECTA_EPS = 223005,
        //[EnumMember]
        //SUSPENSION_PERFECTA = 223006,
        //[EnumMember]
        //PENDIENTE_LIQUIDAR_EPS = 223007,
        //[EnumMember]
        //PENDIENTE_LIQUIDAR = 223008

    }

    [DataContract]
    public enum EnumTipoGeneracionBoleta
    {
        [EnumMember]
        Manual = 233001,
        [EnumMember]
        Automatico = 233002
    }

    [DataContract]
    public enum EnumTipoMovimientoPlanilla
    {
        [EnumMember]
        Ingreso = 197001,
        [EnumMember]
        Egreso = 197002,
        [EnumMember]
        Patronal = 197003,
        [EnumMember]
        Provision = 197004,
    }

    [DataContract]
    public enum EnumTipoCalculoBoleta
    {
        [EnumMember]
        Monto = 234001,
        [EnumMember]
        Porcentaje = 234002,
    }

    [DataContract]
    public enum EnumCaracteristicaInsumo
    {
        [EnumMember]
        Piel1 = 237001,
        [EnumMember]
        Piel2 = 237002,
    }

    [DataContract]
    public enum EnumTipoFalta
    {
        [EnumMember]
        AsistenciaRegular = 9999,
    }

    [DataContract]
    public enum EnumCategoriaOcupacional
    {
        [EnumMember]
        Ejecutivo = 210001,
        [EnumMember]
        Obrero = 210002,
        [EnumMember]
        Empleado = 210003,
    }

    [DataContract]
    public enum EnumTipoResumenPlanilla
    {
        [EnumMember]
        Mensual = 235001,
        [EnumMember]
        Quincenal = 235002,
        [EnumMember]
        Semanal = 235003,
    }

    [DataContract]
    public enum EnumTipoCredito
    {
        [EnumMember]
        Prestamo = 238001,
    }

    [DataContract]
    public enum EnumTipoSituacionGeneral
    {
        [EnumMember]
        Registrado = 240001,
        [EnumMember]
        Anulado = 240002,
        [EnumMember]
        Pendiente = 240003
    }

    [DataContract]
    public enum EnumTipoRegimenSalud
    {
        [EnumMember]
        ESSALUDREGULAR = 221001,
        [EnumMember]
        ESSALUDREGULARYEPSYSERVPROPIOS = 221002,
        [EnumMember]
        ESSALUDTRABAJADORESPESQUEROS = 221003,
        [EnumMember]
        ESSALUDTRABAJADORESPESQUEROSYEPS = 221004,
        [EnumMember]
        ESSALUDAGRARIOACUICOLA = 221005,
        [EnumMember]
        ESSALUDPENSIONISTAS = 221006,
        [EnumMember]
        SANIDADDEFFAAYPOLICIALES = 221007,
        [EnumMember]
        SISMICROEMPRESA = 221008,
    }

    [DataContract]
    public enum EnumSituacionMovCheque
    {
        [EnumMember]
        Emitido = 244001,
        [EnumMember]
        Atendido = 244002,
        [EnumMember]
        Anulado = 244003,
    }

    [DataContract]
    public enum EnumTipoPagoTesoreria
    {
        [EnumMember]
        Efectivo = 246001,
        [EnumMember]
        Cheque = 246002,
        [EnumMember]
        Transferencia = 246003,
        [EnumMember]
        CanjeDocumentos = 246004,
    }

    [DataContract]
    public enum EnumTipoEgresoTesoreria
    {
        [EnumMember]
        PagoProveedores = 245001,
        [EnumMember]
        EntregaRendir = 245002,
        [EnumMember]
        CajaChica = 245003,
        [EnumMember]
        Personal = 245004,
        [EnumMember]
        Varios = 245005,
    }

    [DataContract]
    public enum EnumSituacionCajaChica
    {
        [EnumMember]
        Pendiente = 247001,
        [EnumMember]
        Abierto = 247002,
        [EnumMember]
        Cerrado = 247003,
        [EnumMember]
        Liquidado = 247004,
    }

    [DataContract]
    public enum EnumTipoEgresoCajaChica
    {
        [EnumMember]
        Gasto = 248001,
        [EnumMember]
        SalidaProvisional = 248002,
    }

    public enum EnumSituacionLiquidacion
    {
        [EnumMember]
        Pendiente = 249001,
        [EnumMember]
        Provisionado = 249002,
        [EnumMember]
        Anulado = 249003
    }

    [DataContract]
    public enum EnumSituacionMovBanco
    {
        [EnumMember]
        Registrado = 250001,
        [EnumMember]
        Conciliado = 250002,
        [EnumMember]
        Anulado = 250003,
    }

    [DataContract]
    public enum EnumSituacionMovAsignaDocumento
    {
        [EnumMember]
        Registrado = 251001,
        [EnumMember]
        Anulado = 251002,
    }

    [DataContract]
    public enum EnumPerfil
    {
        [EnumMember]
        Jefe_Tienda = 1,
        Vendedor = 2
    }

    [DataContract]
    public enum EnumTipoNaturalezaCompra
    {
        [EnumMember]
        Disponible = 252001,
        [EnumMember]
        Hechura = 252002,
    }

    [DataContract]
    public enum EnumTipoAgrupacionParTabla
    {
        [EnumMember]
        FacturacionCajaVenta = 260001,
        [EnumMember]
        FormaPagoCajaVenta = 260002,
        [EnumMember]
        ComprobanteCajaChica = 260003,
        [EnumMember]
        FormaPagoVale = 260004,
        [EnumMember]
        GrupoPrestamo = 260005,
        [EnumMember]
        GrupoBusquedaMovimiento = 260006
    }

    [DataContract]
    public enum EnumTipoRelacionPersona
    {
        [EnumMember]
        No_Relacionado = 261001,
        [EnumMember]
        Relacionado = 261002
    }

    [DataContract]
    public enum TipoSituacionValeEmision
    {
        [EnumMember]
        Pendiente = 262001,
        [EnumMember]
        Facturado = 262002,
        [EnumMember]
        Anulado = 262003,
        [EnumMember]
        Cerrado = 262004,
        [EnumMember]
        Procesado = 262005,
        [EnumMember]
        PagadoPorCliente = 262006
    }

    [DataContract]
    public enum EnumTipoOrigenGuia
    {
        [EnumMember]
        Regulares = 264001,
        [EnumMember]
        Masivos = 264002,
        [EnumMember]
        Servicios = 264003,
    }

    [DataContract]
    public enum EnumTipoServicio
    {
        [EnumMember]
        Transporte = 265001,
        [EnumMember]
        Comisiones = 265002,
        [EnumMember]
        Otros = 265003,
    }

    [DataContract]
    public enum EnumSituacionPrestamo
    {
        [EnumMember]
        PENDIENTE = 269001,
        [EnumMember]
        REGISTRADO = 269002,
        [EnumMember]
        DEVUELTO = 269003,
        [EnumMember]
        ATENDIDO = 269004
    }

    [DataContract]
    public enum EnumTipoCliente
    {
        [EnumMember]
        Broker = 104001,
        [EnumMember]
        Potencial = 104002,
        [EnumMember]
        ImportadorDirecto = 104003,
        [DataMember]
        ClientesInternos = 104004,
        [DataMember]
        CanalDistribuidor = 104005,
        [DataMember]
        AlmacenPortuario = 104006
    }

    [DataContract]
    public enum EnumTipoOrigenEmisionComprobante
    {
        [EnumMember]
        PREIMPRESO = 255001,
        [EnumMember]
        TICKET = 255002
    }

    [DataContract]
    public enum SituacionArticulosValeEmision
    {
        [EnumMember]
        PENDIENTE = 266001,
        [EnumMember]
        ATENDIDO = 266002,
        [EnumMember]
        ANULADO = 266003,
    }

    [DataContract]
    public enum EnumTipoMovimientoBeneficio
    {
        [EnumMember]
        ASIGNADO = 267001,
        [EnumMember]
        DESASIGNADO = 267002
    }

    [DataContract]
    public enum EnumTipoRubroCompra
    {
        //[EnumMember]
        ////ASIGNADO = 267001,
        ////[EnumMember]
        ////DESASIGNADO = 267002
    }    

    [DataContract]
    public enum EnumValorTipoMoneda
    {
        [EnumMember]
        SOLES = 01,
        [EnumMember]
        DOLARES = 02,
        [EnumMember]
        EUROS = 03
    }

    public enum ValorCadenaTipoComprobantePago
    {
        [EnumMember]
        FACTURA = 01,
        [EnumMember]
        BOLETA = 02,
        [EnumMember]
        NOTACREDITO = 03,
        [EnumMember]
        TICKET = 04
    }

    [DataContract]
    public enum EnumCalibres
    {
        [EnumMember]
        L = 290001,
        [EnumMember]
        M = 290002,
        [EnumMember]
        XL = 290003,
        [EnumMember]
        J = 290004
    }
    //[DataContract]
    //public enum EnumTipoAjuste
    //{ 
    //    [EnumMember]
    //    CCTA = 289001,
    //    [EnumMember]
    //    CDTO = 289002,
    //    [EnumMember]
    //    CTA = 289003
    //}

}
