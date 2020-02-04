using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class CostosEstrucE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 numNivel { get; set; }
		[DataMember]		public String desNivel { get; set; }
		[DataMember]		public Int32 numLongitud { get; set; }
		[DataMember]		public String indUltimoNivel { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }
		
        
    }   
}