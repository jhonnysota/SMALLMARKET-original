using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class CanjeDctoItemE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idCanje { get; set; }

		[DataMember]
		public Int32 idItemDcmto { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String serDocumento { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public DateTime? FechaDocumento { get; set; }

		[DataMember]
		public DateTime? FechaVencimiento { get; set; }

		[DataMember]
		public String idMonedaOrigen { get; set; }

		[DataMember]
		public Decimal MontoOrigen { get; set; }

		[DataMember]
		public Decimal TipoCambio { get; set; }

		[DataMember]
		public String indDebeHaber { get; set; }

        [DataMember]
		public Decimal PorRetencion { get; set; }

		[DataMember]
		public Decimal MontoReteSoles { get; set; }

		[DataMember]
		public Decimal MontoReteDolares { get; set; }

        [DataMember]
        public Decimal MontoSoles { get; set; }

        [DataMember]
        public Decimal MontoDolares { get; set; }

        [DataMember]
        public Int32 idCtaCte { get; set; }

        [DataMember]
        public Int32 idCtaCteItem { get; set; }

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
        public Int32 Opcion { get; set; }

        [DataMember]
        public String Documento { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

    }   
}