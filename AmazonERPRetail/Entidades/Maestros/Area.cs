using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class Area
    {
        [DataMember]  
		public int idArea { get; set; }

        [DataMember]
        public int idEmpresa { get; set; }

        [DataMember]
        public int idLocal { get; set; }

		[DataMember]
		public string descripcion { get; set; }

		[DataMember]  
		public int? estado { get; set; }

        [DataMember]
        public string UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

		[DataMember]  
		public string UsuarioModificacion { get; set; }
  
		[DataMember]  
		public DateTime FechaModificacion { get; set; }

        #region Otros

        [DataMember]
        public string DesEstado { get; set; }

        #endregion

    }
}