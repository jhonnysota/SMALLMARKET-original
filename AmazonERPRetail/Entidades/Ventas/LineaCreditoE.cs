using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class LineaCreditoE
    {
            
        [DataMember]		public Int32 idPersona { get; set; }
		[DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 item { get; set; }
		[DataMember]		public Int32? idConcepto { get; set; }
		[DataMember]		public DateTime? Inicio { get; set; }
		[DataMember]		public DateTime? Fin { get; set; }
		[DataMember]		public Decimal? Valor { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }
		
        
    }   
}