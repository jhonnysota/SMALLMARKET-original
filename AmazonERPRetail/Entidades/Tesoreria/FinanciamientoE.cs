using System;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class FinanciamientoE
    {
            
        [DataMember]
		public Int32 idFinanciamiento { get; set; }

        [DataMember]
        public String codFinanciamiento { get; set; }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idBanco { get; set; }

		[DataMember]
		public Int32 idLinea { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

		[DataMember]
		public Decimal Importe { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal Garantia { get; set; }

		[DataMember]
		public Decimal Tea { get; set; }

		[DataMember]
		public Int32 Plazo { get; set; }

		[DataMember]
		public Boolean indEstado { get; set; }

		[DataMember]
		public DateTime? fecBaja { get; set; }

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
        public String desBanco { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desLinea { get; set; }

    }   
}