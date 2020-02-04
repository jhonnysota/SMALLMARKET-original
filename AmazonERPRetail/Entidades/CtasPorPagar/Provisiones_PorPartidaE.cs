using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public class Provisiones_PorPartidaE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idProvision { get; set; }

		[DataMember]
		public Int32 idItem { get; set; }

		[DataMember]
		public String numVerPartida { get; set; }

		[DataMember]
		public String TipPartidaPresu { get; set; }

		[DataMember]
		public String CodPartidaPresu { get; set; }

		[DataMember]
		public String CodMonedaProvision { get; set; }

		[DataMember]
		public Decimal Monto { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public String DesPartidaPresu { get; set; }

        [DataMember]
        public int Opcion { get; set; }
        
    }   
}