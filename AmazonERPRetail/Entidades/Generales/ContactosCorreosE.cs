using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public partial class ContactosCorreosE
    {

        [DataMember]
        public Int32 idGrupo { get; set; }

        [DataMember]
		public Int32 idCorreo { get; set; }

		[DataMember]
		public String Correo { get; set; }

		[DataMember]
		public String Nombres { get; set; }

        [DataMember]
        public Boolean CorreoDefecto { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public int Correlativo { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

    }   
}