using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class TransporteE
    {
        public TransporteE()
        {
            ListaConductores = new List<TransporteConductoresE>();
            ListaVehiculos = new List<TransporteVehiculosE>();
        }

		[DataMember]
		public Int32 idTransporte { get; set; }

		[DataMember]
		public String RazonSocial { get; set; }

		[DataMember]
		public String Direccion { get; set; }

		[DataMember]
		public String Ruc { get; set; }

		[DataMember]
		public String Tipo { get; set; }

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

		// Extensiones
        [DataMember]
        public List<TransporteConductoresE> ListaConductores { get; set; }

        [DataMember]
        public List<TransporteVehiculosE> ListaVehiculos { get; set; }
    }   
}