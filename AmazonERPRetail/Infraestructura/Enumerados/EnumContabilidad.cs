using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Infraestructura.Enumerados
{
    [DataContract]
    public enum EnumReporteContable
    {
        [EnumMember]
        ESTADOS_FINANCIEROSXNATURALEZA = 275007,
        [EnumMember]
        ESTADOS_FINANCIEROSXFUNCION = 275006,
        [EnumMember]
        AMBOS_ESTADOS_FINANCIEROS = 275005,
        [EnumMember]
        CUENTAS_DE_CIERRE = 275004,
        [EnumMember]
        INGRESOS_GASTOS = 275003,
        [EnumMember]
        CUENTAS_ORDEN = 275002,
        [EnumMember]
        ACTIVO_PASIVO_PATRIMONIO = 275001
    }

    [DataContract]
    public enum EnumAjustesDiferencia
    {
        [EnumMember]
        CCTA = 274001, //Por Cuenta Codigo - Auxiliar
        [EnumMember]
        CDTO = 274002, //Por Cuenta Codigo - Auxiliar - Documento
        [EnumMember]
        CTA = 274003 //Por Saldo Cuenta
    }

    [DataContract]
    public enum EnumTipoConceptosCompraVentas
    {
        [EnumMember]
        ImpuestoRenta = 273007,
        [EnumMember]
        ImpuestoExtraordinarioSolidaridad = 273006,
        [EnumMember]
        TotalGeneral = 273005,
        [EnumMember]
        OtrosImpuestos = 273004,
        [EnumMember]
        ImpuestoSelecttivoConsumo = 273003,
        [EnumMember]
        ImpuestoGeneralVentas = 273002,
        [EnumMember]
        BaseImponible = 273001,
    }
    
    [DataContract]
    public enum EnumTipoBaseImponibles
    {
        [EnumMember]
        BaseImponible = 276001,
        [EnumMember]
        BaseImponibleInafecta = 276002,
        [EnumMember]
        BaseGravadaYnoGravada = 276003,
        [EnumMember]
        BaseExportacion = 276006
    }

    [DataContract]
    public enum EnumTipoIgv
    {
        [EnumMember]
        ImpuestoGeneralVentas = 277001,
        [EnumMember]
        IgvGravadoYnoGrabado = 277002,
        [EnumMember]
        IgvSinDerecho = 277003
    }

    [DataContract]
    public enum EnumTipoTotal
    {
        [EnumMember]
        Total = 278001
    }

    [DataContract]
    public enum EnumTipoDiario
    {
        [EnumMember]
        DiarioContable = 270001
    }

    [DataContract]
    [Flags]
    public enum EnumReparable
    { 
        N,
        R,
        B
    }

    [DataContract]
    public enum enumLibro
    { 
        [DataMember]
        Apertura = 01,
        [DataMember]
        RegistroVentas = 02,
        [DataMember]
        RegistroCompras = 03,
        [DataMember]
        CajaIngreso = 04,
        [DataMember]
        CajaEgreso = 05
    }

    [DataContract]
    [Flags]
    public enum EnumAccionCtaCte
    {
        A, //Provision
        M, //Movimiento
        Z //Sin Accion
    }

    [DataContract]
    public enum EnumMedioPago
    { 
        [DataMember]
        MasterDolar = 22,
        [DataMember]
        MasterSoles = 23,
        [DataMember]
        AmexDolar = 27,
        [DataMember]
        AmexSoles = 24,
        [DataMember]
        DinerDolar = 28,
        [DataMember]
        DinerSoles = 25,
        [DataMember]
        VisaDolar = 29,
        [DataMember]
        VisaSoles = 26,
        [DataMember]
        Soles = 30,
        [DataMember]
        Euro = 31,
        [DataMember]
        Dolar = 32
    }

}
