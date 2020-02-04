using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class ArticuloServSunatE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public String CodigoSunat { get; set; }
		[DataMember]		public String Descripcion { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }
		
        
    }   
}