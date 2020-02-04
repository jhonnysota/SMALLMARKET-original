using System;
using System.Runtime.Serialization;

namespace Infraestructura.Enumerados
{
    [DataContract]
    public enum EnumEsGuia
    { 
        N, //Normal cualquier documento...
        S, //Es un Servicio
        E, //Es una factura de exportación...
        G, //Es una guia
        F  //Factura
    }

    [DataContract]
    public enum EnumEstadoDocumentos
    { 
        C, //Creado en facturas, boletas, guias... Pedidos = cerrado... conCtaCte detalle - Provisiones = Cargo
        E, //Emitido
        B, //Borrado o Anulado
        //T, //En transito
        P, //En Produccion = Produccion - En los Pedidos = Pendientes - En Provisiones (CtaCte) = Pendientes
        F, //Frio (Mercantil) para el pallet en produccion o Facturado en el caso de las Guias...
        G, //Guiado
        A  //Asignado a un pedido conCtaCte detalle - Provisiones = Abono
    }

    [DataContract]
    public enum EnumTipoImpresionGuiaRemision
    {
        [EnumMember]
        VENTA = 189001,
        [EnumMember]
        EXPORTACION = 189002,
        [EnumMember]
        TRASLADO = 189003
    }

    [DataContract]
    [Flags]
    public enum EnumTipoDocumentoVenta
    { 
        [EnumMember]
        FV, //Factura de Venta
        [EnumMember]
        FE,  //Factura de Exportación
        [EnumMember]
        FS,  //Factura de Servicios
        [EnumMember]
        FC,  //Factura de Compras o factura recibida.
        [EnumMember]
        BV,  //Boleta de Ventas
        [EnumMember]
        LT,  //Letras
        [EnumMember]
        OC,  //Orden de Compra
        [EnumMember]
        TK,  //Ticket
        [EnumMember]
        GV, //Guia de Venta
        [EnumMember]
        GT, //Guia de Traslado
        [EnumMember]
        NC, //Nota de Crédito
        [EnumMember]
        NP, //Nota de Crédito Inafecta
        [EnumMember]
        CR, //Nota de Crédito Recibida
        [DataMember]
        ND, //Nota de Débito
        [EnumMember]
        DR, //Nota de Débito Recibida
        [EnumMember]
        NI //Nota de Débito Inafecta
    }

    [DataContract]
    public enum EnumTipoCondicionVenta
    { 
        [EnumMember]
        FacBol = 1,
        [EnumMember]
        NotaCredito = 2,
        [EnumMember]
        NotaDebito = 3
    }

    [DataContract]
    public enum EnumTipoMoneda
    {
        [EnumMember]
        Soles = 1,
        [EnumMember]
        Dolares = 2,
        [EnumMember]
        Euros = 3
    }

    [DataContract]
    public enum EnumEstadoSerie
    {
        C, //En curso
        P, //Pendiente
        F //Finalizado        
    }

    [DataContract]
    [Flags]
    public enum EnumGrupoDocumentos
    {
        F, //Facturas
        B, //Boletas
        G, //Guias de Remisión
        C, //Notas de Crédito
        D, //Notas de Débito
        P, //Pedidos
        T  //Cotización
    }

    [DataContract]
    public enum EnumTipoDocNumControl
    {
        [EnumMember]
        Facturas = 1,
        [EnumMember]
        Boletas = 2,
        [EnumMember]
        GuiaRemision = 3,
        [EnumMember]
        NotaCredito = 4,
        [EnumMember]
        NotaDebito = 5
    }

    [DataContract]
    public enum EnumCanalVenta
    { 
        [EnumMember]
        Nacional = 106001,
        [EnumMember]
        Exportacion = 106002
    }

    [DataContract]
    public enum enumTipoAuxiliar
    {
        [EnumMember]
        PERJU, //Persona Jurídica
        [EnumMember]
        PERCR, //Persona Natural con RUC
        [EnumMember]
        PERSR, //Persona Natural sin RUC
        [EnumMember]
        OTR //Otro tipo de persona(extranjeros)
    }

}
