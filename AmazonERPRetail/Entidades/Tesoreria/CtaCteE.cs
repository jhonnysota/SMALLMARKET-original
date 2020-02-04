using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class CtaCteE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idCtaCte { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public String DocReferencia { get; set; }        

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal MontoOrig { get; set; }

        [DataMember]
        public Decimal TipoCambio { get; set; }

        [DataMember]
        public DateTime FechaDocumento { get; set; }

        [DataMember]
        public DateTime? FechaVencimiento { get; set; }

        [DataMember]
        public DateTime FechaCancelacion { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String AnnoVencimiento { get; set; }

        [DataMember]
        public String MesVencimiento { get; set; }

        [DataMember]
        public String SemanaVencimiento { get; set; }

        [DataMember]
        public String tipPartidaPresu { get; set; }

        [DataMember]
        public String codPartidaPresu { get; set; }

        [DataMember]
        public String desGlosa { get; set; }

        [DataMember]
        public DateTime? FechaOperacion { get; set; }

        [DataMember]
        public Boolean EsDetraCab { get; set; }

        [DataMember]
        public Int32 idCtaCteOrigen { get; set; }

        [DataMember]
        public Int32 idSistema { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public Decimal SaldoOperativo { get; set; }

        [DataMember]
        public Decimal SaldoContable { get; set; }
        
        [DataMember]
        public List<CtaCte_DetE> ListaCtaCte { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String desLocal { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String Direccion { get; set; }

        [DataMember]
        public String TipoAC { get; set; }

        [DataMember]
        public Decimal Cargo { get; set; }

        [DataMember]
        public Decimal Abono { get; set; }

        [DataMember]
        public Decimal Saldo { get; set; }

        [DataMember]
        public Int32 DiasMora { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String indDebeHaber { get; set; }

        [DataMember]
        public String idDocumentoMov { get; set; }

        [DataMember]
        public String SerieMov { get; set; }

        [DataMember]
        public String NumeroMov { get; set; }

        [DataMember]
        public DateTime? FechaMovimiento { get; set; }

        [DataMember]
        public Boolean Seleccionar { get; set; }

        [DataMember]
        public String desPartidaPresu { get; set; }

        [DataMember]
        public Decimal CargoD { get; set; }

        [DataMember]
        public Decimal AbonoD { get; set; }

        [DataMember]
        public Decimal SaldoD { get; set; }

        [DataMember]
        public String desDocumento { get; set; }

        [DataMember]
        public Decimal Detraccion { get; set; }

        [DataMember]
        public Decimal Importe { get; set; }

        [DataMember]
        public Boolean AgenteRetenedor { get; set; }

        [DataMember]
        public Boolean EscogerDetra { get; set; }

        [DataMember]
        public Boolean indPagoDetra { get; set; }

        [DataMember]
        public String nroUnico { get; set; }

        [DataMember]
        public String tipDeposito { get; set; }

        [DataMember]
        public String desBanco { get; set; }

        [DataMember]
        public String EstadoDoc { get; set; }

        [DataMember]
        public String Especie { get; set; }

        [DataMember]
        public String Estatus { get; set; }

        [DataMember]
        public String codPedido { get; set; }

        [DataMember]
        public String codOrdenPago { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String indNaturalezaCta { get; set; }

        [DataMember]
        public String indNaturalezaDoc { get; set; }

        [DataMember]
        public Decimal Diferencia { get; set; }

        [DataMember]
        public Int32 idCtaCteItem { get; set; }

        [DataMember]
        public String Motivo { get; set; }

        [DataMember]
        public String desCondicion { get; set; }

        [DataMember]
        public String desFormaPago { get; set; }

        [DataMember]
        public String desMonedaRecibida { get; set; }

        [DataMember]
        public Decimal MontoRecibido { get; set; }

        [DataMember]
        public Boolean TieneDetra { get; set; }

        [DataMember]
        public Decimal MontoDetraFac { get; set; }

        [DataMember]
        public Decimal CobranzaDetra { get; set; } //Para saber si la detracción ha sido cobrado por el módulo de cobranzas

        [DataMember]
        public String CuentaEquivalente { get; set; }

        [DataMember]
        public Decimal SaldoEquivalente { get; set; }

        [DataMember]
        public Decimal ProgPagoDetra { get; set; } //Para saber si la detracción ha sido pagado por el programa de pagos

        [DataMember]
        public String numLetras { get; set; }

        [DataMember]
        public String NroOperacion { get; set; }

        [DataMember]
        public Int32? idPersonaEndoso { get; set; }

        [DataMember]
        public Int32 idConcepto { get; set; }

        [DataMember]
        public String nomVendedor { get; set; }

        [DataMember]
        public Int32 idVendedor { get; set; }

        [DataMember]
        public Int32 idLiquidacionImportacion { get; set; }

    }
}