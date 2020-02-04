using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class MovilidadDetE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idMovilidad { get; set; }

		[DataMember]
		public Int32 idItem { get; set; }

		[DataMember]
		public DateTime Fecha { get; set; }

        [DataMember]
        public String idCCostos { get; set; }

        [DataMember]
        public String Desplazamiento { get; set; }

        [DataMember]
		public String MotivoDestino { get; set; }

		[DataMember]
		public Decimal Monto { get; set; }

        [DataMember]
        public Boolean indReparado { get; set; }

        [DataMember]
        public Decimal MontoAceptado { get; set; }

        [DataMember]
        public Decimal MontoReparado { get; set; }

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
        public Int32 Opcion { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String desCCostos { get; set; }

    }   
}