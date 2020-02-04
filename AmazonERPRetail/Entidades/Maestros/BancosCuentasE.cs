using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class BancosCuentasE
    {

        [DataMember]
        public Int32 idBancosCuentas { get; set; }

        [DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public Int32 tipCuenta { get; set; }

        [DataMember]
		public String numCuenta { get; set; }

        [DataMember]
        public String numCuentaInter { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public String numCheque { get; set; }

		[DataMember]
		public String numChequeIni { get; set; }

		[DataMember]
		public String numChequeFin { get; set; }

		[DataMember]
		public String FormatoCheque { get; set; }

        [DataMember]
        public Boolean indDocumentos { get; set; }

        [DataMember]
		public Boolean indBaja { get; set; }

		[DataMember]
		public DateTime? fecBaja { get; set; }

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
        public String desMoneda { get; set; }

        [DataMember]
        public String desCuenta { get; set; } //Cuenta Contable

        [DataMember]
        public string desTipCuenta { get; set; } //Tipo Cuenta Bancaria

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public string desCuentaBanco { get; set; } //Descripción de la Cuenta Bancaria

        [DataMember]
        public String SolicitaDoc { get; set; }

        [DataMember]
        public String DescripcionCuenta { get; set; }

    }   
}