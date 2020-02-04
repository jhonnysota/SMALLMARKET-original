using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class TransporteVehiculosE
    {
		[DataMember]
		public Int32 idTransporte { get; set; }

        [DataMember]
        public Int32 idVehiculo { get; set; }

		[DataMember]
		public String numPlaca { get; set; }

		[DataMember]
		public String numInscripcion { get; set; }

		[DataMember]
		public String desVehicular { get; set; }

		[DataMember]
		public String Marca { get; set; }

		[DataMember]
		public Decimal? Capacidad { get; set; }

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