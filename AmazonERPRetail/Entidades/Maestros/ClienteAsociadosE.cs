using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class ClienteAsociadosE
    {
            
        [DataMember]		public Int32 idPersona { get; set; }
		[DataMember]		public Int32 IdEmpresa { get; set; }
		[DataMember]		public Int32 IdAsociado { get; set; }
		[DataMember]		public String RazonSocial { get; set; }
		[DataMember]		public String RUC { get; set; }
		[DataMember]		public String Direccion { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime FechaModificacion { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }
        
    }   
}