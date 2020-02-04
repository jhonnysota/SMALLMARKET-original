using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class ProvisionesE
    {

        public ProvisionesE()
        {
            ListaPorCCosto = new List<Provisiones_PorCCostoE>();
            ListaPorPartida = new List<Provisiones_PorPartidaE>();
        }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public Int32 idProvision { get; set; }

        [DataMember]
        public Int32? idPersona { get; set; }

        [DataMember]
        public DateTime FechaProvision { get; set; }

        [DataMember]
        public DateTime FechaDocumento { get; set; }

        [DataMember]
        public Int32? NumDiasVen { get; set; }

        [DataMember]
        public DateTime? FechaVencimiento { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String NumSerie { get; set; }

        [DataMember]
        public String NumDocumento { get; set; }

        [DataMember]
        public String idDocumentoRef { get; set; }

        [DataMember]
        public String numSerieRef { get; set; }

        [DataMember]
        public String numDocumentoRef { get; set; }

        [DataMember]
        public DateTime? fecDocumentoRef { get; set; }

        [DataMember]
        public Int32? indAfectacionAlmacen { get; set; }

        [DataMember]
        public Int32? idAlmacen { get; set; }

        [DataMember]
        public Int32? idOperacion { get; set; }

        [DataMember]
        public Int32? idTipoArticulo { get; set; }

        [DataMember]
        public Int32? tipMovimientoAlmacen { get; set; }

        [DataMember]
        public Int32? idDocumentoAlmacen { get; set; }

        [DataMember]
        public String CodMonedaProvision { get; set; }

        [DataMember]
        public Decimal ImpMonedaOrigen { get; set; }

        [DataMember]
        public String EstadoProvision { get; set; } //RE=Registrado PR=Provisionado AN=Anulado LI=Liquidacion RD=Rendición

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }

        [DataMember]
        public String numVoucher { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public Decimal TipCambio { get; set; }

        [DataMember]
        public Boolean IndCalcAuto { get; set; }

        [DataMember]
        public Decimal impTotalBase { get; set; }

        [DataMember]
        public Decimal impImponBase { get; set; }

        [DataMember]
        public Decimal impExonBase { get; set; }

        [DataMember]
        public Decimal impAjusteBase { get; set; }

        [DataMember]
        public Decimal impImpuestoBase { get; set; }

        [DataMember]
        public Decimal impTotalSecun { get; set; }

        [DataMember]
        public Decimal impImponSecun { get; set; }

        [DataMember]
        public Decimal impExonSecun { get; set; }

        [DataMember]
        public Decimal impAjusteSecun { get; set; }

        [DataMember]
        public Decimal impImpuestoSecun { get; set; }

        [DataMember]
        public String NumVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String DesProvision { get; set; }

        [DataMember]
        public Int32? idRecepcion { get; set; }

        [DataMember]
        public Int32? idOrdenCompra { get; set; }

        [DataMember]
        public String NumGuia { get; set; }

        [DataMember]
        public Int32? idPlantilla { get; set; }

        [DataMember]
        public String tipPartidaPresu { get; set; }

        [DataMember]
        public String CodPartidaPresu { get; set; }

        [DataMember]
        public Boolean flagDetraccion { get; set; }

        [DataMember]
        public String retNumero { get; set; }

        [DataMember]
        public DateTime? retFecha { get; set; }

        [DataMember]
        public String TipoDetraccion { get; set; }

        [DataMember]
        public Decimal TasaDetraccion { get; set; }

        [DataMember]
        public Decimal MontoDetraccion { get; set; }

        [DataMember]
        public Decimal MontoDetraccionSoles { get; set; }

        [DataMember]
        public Boolean indPagoDetra { get; set; }

        [DataMember]
        public Int32? idCtaCte { get; set; }

        [DataMember]
        public Int32? idCtaCteItem { get; set; }

        [DataMember]
        public Int32? idCompraFile { get; set; }

        [DataMember]
        public Boolean indHojaCosto { get; set; }

        [DataMember]
        public Int32? idHojaCosto { get; set; }

        [DataMember]
        public Boolean indNoDom { get; set; } 

        [DataMember]
        public String idDocCredFiscal { get; set; }

        [DataMember]
        public Int32? depAduanera { get; set; }

        [DataMember] 
        public String serDocCredFiscal { get; set; }

        [DataMember]
        public String AnioDua { get; set; }

        [DataMember]
        public String numDocCredFiscal { get; set; }

        [DataMember]
        public Decimal RentaBruta { get; set; }

        [DataMember] 
        public Decimal TasaRetencion { get; set; }

        [DataMember]
        public Decimal RentaNeta { get; set; }

        [DataMember]
        public Decimal impRetenido { get; set; }

        [DataMember]
        public String idTasaRenta { get; set; }

        [DataMember]
        public string codCuentaRenta { get; set; }

        [DataMember]
        public Boolean indIgvNoDom { get; set; }

        [DataMember]
        public Decimal IgvNoDom { get; set; }

        [DataMember]
        public Boolean indDistribucion { get; set; }

        [DataMember]
        public String indReparable { get; set; } // N=Normal R=Reparable B=Boletas

        [DataMember]
        public Int32 idConceptoRep { get; set; }

        [DataMember]
        public String desReferenciaRep { get; set; }

        [DataMember]
        public Boolean indReversion { get; set; }

        [DataMember]
        public Int32? idProvisionRev { get; set; }

        [DataMember]
        public Int32? idSistema { get; set; }

        [DataMember]
        public Int32 EsAnticipo { get; set; } //0=Ninguno 1=Anticipo 2=Aplicacion

        [DataMember]
        public Boolean EsLiquidacion { get; set; }

        [DataMember]
        public Boolean indConversion { get; set; }

        [DataMember]
        public Int32? idOrdenConversion { get; set; }

        [DataMember]
        public Boolean EsRendicion { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        // Extensiones 
        [DataMember]
        public List<Provisiones_PorCCostoE> ListaPorCCosto { get; set; }

        [DataMember]
        public List<Provisiones_PorPartidaE> ListaPorPartida { get; set; }

        [DataMember]
        public List<Provisiones_PorCCostoE> ItemsEliminados { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String Ruc { get; set; }

        [DataMember]
        public String DesEstado { get; set; }

        [DataMember]
        public String DesCuenta { get; set; }

        [DataMember]
        public String DesComprobante { get; set; }

        [DataMember]
        public String DesFile { get; set; }

        [DataMember]
        public String desDocumento { get; set; }

        [DataMember]
        public String desPartidaPresu { get; set; }

        [DataMember]
        public Decimal monto { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public Boolean Check { get; set; }

        [DataMember]
        public Int32? idProvisionRevTmp { get; set; }//Para poder comparar los id si han cambiado al guardar la reversión.

        [DataMember]
        public String desCuentaRenta { get; set; }

        [DataMember]
        public String DesidDocumentoRef { get; set; }

        [DataMember]
        public String numOrdenCompra { get; set; }

        [DataMember]
        public String TipoOperacion { get; set; }

        [DataMember]
        public Decimal Redondeo { get; set; }

        [DataMember]
        public String numCuentaDetraccion { get; set; }

        [DataMember]
        public String CodSunat { get; set; }

        [DataMember]
        public DateTime fecOrdenPago { get; set; } //Para la generación de la OP (Detracciones de provisiones)

        [DataMember]
        public Int32 idOrdenPago { get; set; }//Para la generación de la OP (Detracciones de provisiones)

        [DataMember]
        public String codOrdenPago { get; set; }//Para la generación de la OP (Detracciones de provisiones)

        [DataMember]
        public String NombreArchivo { get; set; }//Para la generación de la OP (Detracciones de provisiones)

        [DataMember]
        public String numLiquidacion { get; set; }

        [DataMember]
        public Boolean AfectaOc { get; set; }

        [DataMember]
        public String codOrdenConversion { get; set; }

    }
}