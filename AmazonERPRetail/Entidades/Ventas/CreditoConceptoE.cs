using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class CreditoConceptoE
    {
            
        [DataMember]		public Int32 idConcepto { get; set; }
		[DataMember]		public String Descripcion { get; set; }
		[DataMember]		public Boolean flagMoneda { get; set; }
		[DataMember]		public String idMoneda { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }
		
        
    }   
}