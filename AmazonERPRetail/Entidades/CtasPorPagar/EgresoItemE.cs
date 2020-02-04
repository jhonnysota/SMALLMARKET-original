using System;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class EgresoItemE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idNumEgreso { get; set; }

		[DataMember]
		public Int32 NumItem { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public String serDocumento { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public String indDebeHaber { get; set; }

		[DataMember]
		public Decimal? impMontoPago { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public Decimal? impPagoBase { get; set; }

		[DataMember]
		public Decimal? impPagoSecun { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public String tipEstado { get; set; }

		[DataMember]
		public Decimal? tipCambio { get; set; }

		[DataMember]
		public String idSistema { get; set; }

		[DataMember]
		public DateTime? fecDocumento { get; set; }

		[DataMember]
		public DateTime? fecVencimiento { get; set; }

		[DataMember]
		public String desGlosa { get; set; }

        [DataMember]
        public Int32 idCtaCte { get; set; }

        [DataMember]
        public Int32 idCtaCteItem { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

    }   
}