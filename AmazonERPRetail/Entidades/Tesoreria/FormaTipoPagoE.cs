using System;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class FormaTipoPagoE
    {

        [DataMember]
        public String codTipoPago { get; set; }

        [DataMember]
		public String codFormaPago { get; set; }

        [DataMember]
        public Int32 idConcepto { get; set; }

        [DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String desFormaPago { get; set; }

        [DataMember]
        public String desTipoPago { get; set; }

        [DataMember]
        public String desConcepto { get; set; }

        [DataMember]
        public String codConcepto { get; set; }

    }   
}