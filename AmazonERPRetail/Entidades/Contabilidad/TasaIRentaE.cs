using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class TasaIRentaE
    {
            
        [DataMember]		public String idTasaIRenta { get; set; }
		[DataMember]		public String DesTasaIRenta { get; set; }
		[DataMember]		public Decimal Porcentaje { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }
		
        
    }   
}