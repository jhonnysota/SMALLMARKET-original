using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public class HojaCostoAlmacenE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idLocal { get; set; }
		[DataMember]		public Int32 idHojaCosto { get; set; }
		[DataMember]		public Int32 tipMovimiento { get; set; }
		[DataMember]		public Int32 idDocumentoAlmacen { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime FechaModificacion { get; set; }
        
    }   
}