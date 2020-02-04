using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class conCtaCteItemE
    {
            
        [DataMember]
		public Int32 idCtaCte { get; set; }

		[DataMember]
		public Int32 idCtaCteItem { get; set; }

        [DataMember]
        public String idDocumentoMov { get; set; }

        [DataMember]
        public String SerieMov { get; set; }

        [DataMember]
        public String NumeroMov { get; set; }

		[DataMember]
		public DateTime FechaMovimiento { get; set; }

		[DataMember]
		public String TipoMovimiento { get; set; }

		[DataMember]
		public Decimal Monto { get; set; }

        [DataMember]
        public Decimal TipoCambio { get; set; }

		[DataMember]
		public String indDebeHaber { get; set; }

		[DataMember]
		public Decimal impSoles { get; set; }

        [DataMember]
        public Decimal impDolares { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String numVoucher { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public Boolean Check { get; set; }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public String numVerPlanCuentas{ get; set; }

        [DataMember]
		public String codCuenta{ get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public DateTime fecDocumento { get; set; }

        [DataMember]
        public String idDocumento{ get; set; }

        [DataMember]
		public String serDocumento { get; set; }
		
        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal Tica { get; set; }

        [DataMember]
        public Decimal SaldoSoles { get; set; }

        [DataMember]
        public Decimal SaldoDolares { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desLocal { get; set; }

        [DataMember]
        public DateTime? fecVencimiento { get; set; }

        [DataMember]
        public Boolean AgenteRetenedor { get; set; }

        [DataMember]
        public String idCCostos { get; set; }

        [DataMember]
        public String tipPartidaPresu { get; set; }

        [DataMember]
        public String codPartidaPresu { get; set; }

    }   
}