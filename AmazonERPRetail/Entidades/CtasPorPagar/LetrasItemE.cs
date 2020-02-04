using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class LetrasItemE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idCanje { get; set; }

		[DataMember]
		public Int32 idItemLetra { get; set; }

		[DataMember]
		public String numLetra { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public DateTime FechaEmision { get; set; }

		[DataMember]
		public DateTime? FechaVencimiento { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal MontoLetra { get; set; }

        [DataMember]
        public Decimal MontoSoles { get; set; }

        [DataMember]
        public Decimal MontoDolares { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public Int32 idCtaCte { get; set; }

        [DataMember]
        public Int32 idCtaCteItem { get; set; }

        [DataMember]
        public String Estado { get; set; }        

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

    }   
}