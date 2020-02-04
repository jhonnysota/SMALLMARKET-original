using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Entidades.CtasPorPagar;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class AnticipoCtaCteE
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

        [DataMember]
        public Decimal SaldoOperativo { get; set; }

        [DataMember]
        public Decimal SaldoContable { get; set; }

        //Extensiones
        [DataMember]
        public List<CtaCte_DetE> ListaCtaCte { get; set; }

        [DataMember]
        public Provisiones_PorCCostoE oProvisionDet { get; set; }

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
        public String desCuenta { get; set; }

        [DataMember]
        public Decimal Apertura { get; set; }

        [DataMember]
        public Decimal Provision { get; set; }

        [DataMember]
        public Decimal Importacion { get; set; }

        [DataMember]
        public Decimal Compras { get; set; }

        [DataMember]
        public Decimal Canje { get; set; }

        [DataMember]
        public Decimal Pagos { get; set; }

        [DataMember]
        public Decimal Compensa { get; set; }

        [DataMember]
        public Decimal Retencion { get; set; }

        [DataMember]
        public Decimal Detraccion { get; set; }

        [DataMember]
        public Decimal Otros { get; set; }

        [DataMember]
        public Decimal Importe { get; set; }

        [DataMember]
        public Decimal Compras_Soles { get; set; }

        [DataMember]
        public Decimal ImportePartida { get; set; }

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
        public String Banco { get; set; }

        [DataMember]
        public String NroUnico { get; set; }

        [DataMember]
        public String DesPartida { get; set; }

        [DataMember]
        public Int32 idProvisionOrigen { get; set; }

    }
}
