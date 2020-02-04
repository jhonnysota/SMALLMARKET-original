using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class TransporteConductoresE
    {
		[DataMember]
		public Int32 idTransporte { get; set; }

		[DataMember]
		public Int32 idConductor { get; set; }

		[DataMember]
		public String Licencia { get; set; }

		[DataMember]
		public String Nombres { get; set; }

		[DataMember]
		public String nomResumido { get; set; }

		[DataMember]
		public Boolean indEstado { get; set; }

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

    }   
}