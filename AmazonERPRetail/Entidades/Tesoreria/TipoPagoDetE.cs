using System;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class TipoPagoDetE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public String codTipoPago { get; set; }

		[DataMember]
		public Int32 idConcepto { get; set; }

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
        public String codConcepto { get; set; }

        [DataMember]
        public String desConcepto { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

    }   
}