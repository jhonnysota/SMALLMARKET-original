using System;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public partial class UsuarioCCostosE
    {
            
        [DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public String idCCostos { get; set; }

		[DataMember]
		public DateTime FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public String desCCostos { get; set; }
        
    }   
}