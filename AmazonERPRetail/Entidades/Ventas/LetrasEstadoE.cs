using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class LetrasEstadoE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public String tipCanje { get; set; }

		[DataMember]
		public String codCanje { get; set; }

		[DataMember]
		public String Numero { get; set; }

		[DataMember]
		public String Corre { get; set; }

		[DataMember]
		public Int32 item { get; set; }

		[DataMember]
		public DateTime Fecha { get; set; }

		[DataMember]
		public String Estado { get; set; } //Aceptada en Cartera=E, Cobranza Libre=L, Descuentos=D, Protestada=P

        [DataMember]
		public Int32? idBanco { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public String numUnico { get; set; }

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
        public String desEstado { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

    }   
}