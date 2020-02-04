using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class PlanillaBancosDetE
    {
            
        [DataMember]
		public Int32 idPlanillaBanco { get; set; }

		[DataMember]
		public String Letra { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public DateTime Fecha { get; set; }

		[DataMember]
		public DateTime fecVenc { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal Monto { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public String Plaza { get; set; }

        [DataMember]
        public String nroUnico { get; set; }

        [DataMember]
        public Int32? idCtaCte12 { get; set; }

        [DataMember]
        public Int32? idCtaCteItem12 { get; set; }

        [DataMember]
        public Int32? idCtaCte { get; set; }

        [DataMember]
        public Int32? idCtaCteItem { get; set; }

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
        public String desMoneda { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String tipCanje { get; set; } //Viene de canje de Letras

        [DataMember]
        public String codCanje { get; set; } //Viene de canje de Letras

    }
}