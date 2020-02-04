using System;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public partial class UsuarioPuntoRequeE
    {
            
        [DataMember]
		public Int32 idUsuario { get; set; }

		[DataMember]
		public Int32 idPuntoReq { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime FechaModificacion { get; set; }

		//Extensiones
        [DataMember]
        public String desPuntoReq { get; set; }
        
    }   
}