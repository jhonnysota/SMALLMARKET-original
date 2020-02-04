using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class VoucherItemE
    {

        public VoucherItemE()
        {
            PlanCuenta = new PlanCuentasE();
        }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

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
        public String numItem { get; set; }

        [DataMember]
        public Int32? idPersona { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal tipCambio { get; set; }

        [DataMember]
        public String indCambio { get; set; }

        [DataMember]
        public String idCCostos { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String desGlosa { get; set; }

        [DataMember]
        public DateTime? fecDocumento { get; set; }

        [DataMember]
        public DateTime? fecVencimiento { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String serDocumento { get; set; }

        [DataMember]
        public String numDocumento { get; set; }
   
        [DataMember]
        public DateTime? fecDocumentoRef { get; set; }

        [DataMember]
        public String idDocumentoRef { get; set; }

        [DataMember]
        public String serDocumentoRef { get; set; }

        [DataMember]
        public String numDocumentoRef { get; set; }

        [DataMember]
        public String indDebeHaber { get; set; }

        [DataMember]
        public Decimal impSoles { get; set; }

        [DataMember]
        public Decimal impDolares { get; set; }

        [DataMember]
        public String indAutomatica { get; set; }

        [DataMember]
        public String CorrelativoAjuste { get; set; }

        [DataMember]
        public String codFteFin { get; set; }

        [DataMember]
        public String codProgramaCred { get; set; }

        [DataMember]
        public String indMovimientoAnterior { get; set; }

        [DataMember]
        public String tipPartidaPresu { get; set; }

        [DataMember]
        public String codPartidaPresu { get; set; }

        [DataMember]
        public String desPartidaPresu { get; set; }

        [DataMember]
        public String numDocumentoPresu { get; set; }

        [DataMember]
        public Int32? codColumnaCoven { get; set; }

        [DataMember]
        public Int32? depAduanera { get; set; }

        [DataMember]
        public String nroDua { get; set; }

        [DataMember]
        public String AnioDua { get; set; }

        [DataMember]
        public String flagDetraccion { get; set; }

        [DataMember]
        public String numDetraccion { get; set; }

        [DataMember]
        public DateTime? fecDetraccion { get; set; }

        [DataMember]
        public String tipDetraccion { get; set; }

        [DataMember]
        public Decimal? TasaDetraccion { get; set; }

        [DataMember]
        public Decimal? MontoDetraccion { get; set; }

        [DataMember]
        public Boolean indPagoDetra { get; set; }

        [DataMember]
        public String indReparable { get; set; }

        [DataMember]
        public Int32? idConceptoRep { get; set; }

        [DataMember]
        public String desReferenciaRep { get; set; }

        [DataMember]
        public String idAlmacen { get; set; }

        [DataMember]
        public String tipMovimientoAlmacen { get; set; }

        [DataMember]
        public String numDocumentoAlmacen { get; set; }

        [DataMember]
        public String numItemAlmacen { get; set; }

        [DataMember]
        public String CajaSucursal { get; set; }

        [DataMember]
        public String indCompra { get; set; }

        [DataMember]
        public String indConciliado { get; set; }

        [DataMember]
        public DateTime? fecRecepcion { get; set; }

        [DataMember]
        public Int32? codMedioPago { get; set; }

        [DataMember]
        public Int32? idCampana { get; set; }

        [DataMember]
        public Int32? idConceptoGasto { get; set; }

        [DataMember]
        public String idAccion { get; set; }

        [DataMember]
        public Int32? idCtaCte { get; set; }

        [DataMember]
        public Int32? idCtaCteItem { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        //OTROS CAMPOS...
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public PlanCuentasE PlanCuenta { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String Ruc { get; set; }

        [DataMember]
        public String NombreColumna { get; set; }

        [DataMember]
        public String indCuentaGastos { get; set; }

        [DataMember]
        public String codCuentaDestino { get; set; }

        [DataMember]
        public String codCuentaTransferencia { get; set; }

        [DataMember]
        public String desCCostos { get; set; }

        [DataMember]
        public String desComprobante { get; set; }

        [DataMember]
        public String desFile { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String GlosaGeneral { get; set; }

        [DataMember]
        public String desMedioPago { get; set; }
        
        [DataMember]
        public Decimal Importe { get; set; }

        [DataMember]
        public String desDocumento { get; set; }

        [DataMember]
        public String desConcepto { get; set; }

        [DataMember]
        public String desCampana { get; set; }

        [DataMember]
        public Decimal impDebe { get; set; }

        [DataMember]
        public Decimal impHaber { get; set; }

        [DataMember]
        public Decimal impDebeDolares { get; set; }

        [DataMember]
        public Decimal impHaberDolares { get; set; }

        [DataMember]
        public Decimal SaldoAnterior { get; set; }

        [DataMember]
        public Int32 idEEFFItem { get; set; }

        [DataMember]
        public String indCtaCte { get; set; }

        [DataMember]
        public DateTime? fecOperacion { get; set; }

        [DataMember]
        public String idPersonaCad { get; set; }

        [DataMember]
        public Decimal MontoDetraEntero { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public String CuentaOrigen { get; set; }

        [DataMember]
        public String desCuentaOrigen { get; set; }

        [DataMember]
        public Decimal salAntSoles { get; set; }

        [DataMember]
        public Decimal salAntDolares { get; set; }

        [DataMember]
        public Decimal salActSoles { get; set; }

        [DataMember]
        public Decimal salActDolares { get; set; }

        [DataMember]
        public Decimal salAntSoles104 { get; set; }

        [DataMember]
        public Decimal salAntDolares104 { get; set; }

        [DataMember]
        public String RazonSocialEmisor { get; set; }

        [DataMember]
        public String DesPersona { get; set; }

        [DataMember]
        public Boolean indConciliadoBool { get; set; }

        [DataMember]
        public Decimal monto { get; set; }

        [DataMember]
        public String sistema { get; set; }

        [DataMember]
        public Boolean EsAutomatico { get; set; }

        [DataMember]
        public String Campo3 { get; set; }

        [DataMember]
        public String CodPlanCuenta { get; set; }

        [DataMember]
        public String TD { get; set; }

        [DataMember]
        public String codSunat { get; set; }

        [DataMember]
        public String DebeSoles { get; set; }

        [DataMember]
        public String HaberSoles { get; set; }

        [DataMember]
        public String DebeDolares { get; set; }

        [DataMember]
        public String HaberDolares { get; set; }

        [DataMember]
        public String nomBanco { get; set; }

        [DataMember]
        public String indSolicitaCentroCosto { get; set; }

    }   
}