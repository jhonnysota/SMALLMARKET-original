using System;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public class UsuarioPlanillaE
    {
            
        [DataMember]		public Int32 idPersona { get; set; }
		[DataMember]		public String idPlanillas { get; set; }
		[DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public Boolean VerRemun { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

    }   
}