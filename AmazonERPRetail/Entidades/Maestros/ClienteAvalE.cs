using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class ClienteAvalE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public Int32 idAval { get; set; }

		[DataMember]
		public Int32? TipoDocumento { get; set; }

		[DataMember]
		public String nroDocumento { get; set; }

		[DataMember]
		public String RazonSocial { get; set; }

		[DataMember]
		public String Direccion { get; set; }

		[DataMember]
		public String Telefonos { get; set; }

		[DataMember]
		public String Email { get; set; }

        [DataMember]
        public Boolean EsPrincipal { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public Int16 Opcion { get; set; }
        
    }   
}