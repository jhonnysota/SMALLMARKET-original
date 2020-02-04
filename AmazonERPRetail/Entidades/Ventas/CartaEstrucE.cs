using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class CartaEstrucE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idTipoArticulo { get; set; }
		[DataMember]		public Int32 numNivel { get; set; }
		[DataMember]		public String desNivel { get; set; }
		[DataMember]		public Int32 numLongitud { get; set; }
		[DataMember]		public String indUltimoNivel { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? fechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? fechaModificacion { get; set; }
		
        
    }   
}