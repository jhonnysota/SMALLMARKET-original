using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class CCostosNumControlDetE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public String idCCostos { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String Serie { get; set; }

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
        public String desCCostos { get; set; }

    }   
}