using System;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class AperturaCtaCteE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idRegistro { get; set; }

		[DataMember]
		public DateTime? FechaOperacion { get; set; }

		[DataMember]
		public String numVerPlanCuenta { get; set; }

		[DataMember]
		public String CodCuenta { get; set; }

		[DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public String Glosa { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String Serie { get; set; }

		[DataMember]
		public String Numero { get; set; }

		[DataMember]
		public DateTime? FechaEmision { get; set; }

		[DataMember]
		public Decimal? TipoCambio { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal? importe { get; set; }

		[DataMember]
		public String indDebeHaber { get; set; }

        [DataMember]
        public String tipPartidaPresu { get; set; }

        [DataMember]
        public String codPartidaPresu { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }
        
    }   
}