using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class ProveedorContactoE
    {
            
        [DataMember]		public Int32 idPersona { get; set; }
		[DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idItem { get; set; }
		[DataMember]		public String NroDocumento { get; set; }
		[DataMember]		public String ApePaterno { get; set; }
		[DataMember]		public String ApeMaterno { get; set; }
		[DataMember]		public String Nombres { get; set; }
		[DataMember]		public String Telefono1 { get; set; }
		[DataMember]		public String Telefono2 { get; set; }
		[DataMember]		public String Celular1 { get; set; }
		[DataMember]		public String Celular2 { get; set; }
		[DataMember]		public String Correo1 { get; set; }
		[DataMember]		public String Correo2 { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }


        [DataMember]
        public Int32 Opcion { get; set; }
    }   
}