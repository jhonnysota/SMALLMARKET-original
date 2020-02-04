using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class LibroConcarE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public String csubdia { get; set; }
		[DataMember]		public String nombre { get; set; }
		[DataMember]		public String idComprobante { get; set; }
		[DataMember]		public String numFile { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }

        //Extensiones        
        [DataMember]
        public String IdComprobanteDes { get; set; }

        [DataMember]
        public String numFileDes { get; set; }


    }   
}