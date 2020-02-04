using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorCobrar
{
    [DataContract]
    [Serializable]
    public partial class CobranzasConciliacionE
    {
            
        [DataMember]
		public Int32 numitem { get; set; }

		[DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public DateTime Fecha { get; set; }

		[DataMember]
		public String Glosa { get; set; }

		[DataMember]
		public Decimal Monto { get; set; }

		[DataMember]
		public String Operacion { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public Int32? idPlanilla { get; set; }

		[DataMember]
		public Int32? Recibo { get; set; }

        //Extensiones
        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public Int32? numItemConci { get; set; } //Para la conciliación

    }   
}