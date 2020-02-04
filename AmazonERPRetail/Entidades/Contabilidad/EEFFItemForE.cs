using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class EEFFItemForE
    {
            
        [DataMember]		public Int32 idEMPRESA { get; set; }
		[DataMember]		public Int32 idEEFF { get; set; }
		[DataMember]		public Int32 idEEFFItem { get; set; }
		[DataMember]		public Int32 idEEFFItemFor { get; set; }		[DataMember]		public String secItem { get; set; }
		[DataMember]		public String TipoOperador { get; set; }

        [DataMember]
        public String desItem { get; set; }		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }
		
        
    }   
}