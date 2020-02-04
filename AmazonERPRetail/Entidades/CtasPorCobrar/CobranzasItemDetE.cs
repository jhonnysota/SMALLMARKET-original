using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorCobrar
{
    [DataContract]
    [Serializable]
    public partial class CobranzasItemDetE
    {

        [DataMember]
        public Int32 item { get; set; }

        [DataMember]
		public Int32 idPlanilla { get; set; }

		[DataMember]
		public Int32 Recibo { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String numSerie { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public DateTime? fecEmision { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal? Monto { get; set; }

		[DataMember]
		public String idMonedaReci { get; set; }

		[DataMember]
		public Decimal? MontoReci { get; set; }

		[DataMember]
		public Decimal? tipCambioReci { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

        [DataMember]
        public DateTime? fecVencimiento { get; set; }

        [DataMember]
        public Int32? idCtaCte { get; set; }

        [DataMember]
        public Int32? idCtaCteItem { get; set; }

        [DataMember]
        public Int32? idCtaCte45 { get; set; }

        [DataMember]
        public Int32? idCtaCteItem45 { get; set; }

        [DataMember]
        public Int32? LetraEndosadaA { get; set; }

        [DataMember]
        public Boolean indTercero { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Extension
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String Moneda { get; set; }

        [DataMember]
        public String MonedaReci { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String Ruc { get; set; }

        [DataMember]
        public Boolean indEndosar { get; set; }

        [DataMember]
        public String RazonSocialEndose { get; set; }

        [DataMember]
        public String codPlanilla { get; set; }

        [DataMember]
        public String NroOperacion { get; set; }

        [DataMember]
        public Boolean EstadoDoc { get; set; } //Campo de CobranzasE

    }   
}