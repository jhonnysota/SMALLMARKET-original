using System;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public class UsuarioPreferenciasE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idPreferencias { get; set; }
		[DataMember]		public String NombreFormulario { get; set; }
		[DataMember]		public String Campo { get; set; }
		[DataMember]		public String Valor { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		
        
    }   
}