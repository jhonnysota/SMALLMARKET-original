using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public partial class UsuarioRol
    {
         [DataMember]  
		public int IdPersona { get; set; }  

		[DataMember]  
		public int IdRol { get; set; }  

		[DataMember]  
		public int IdEmpresa { get; set; }  

		[DataMember]  
		public bool Estado { get; set; }  

		[DataMember]  
		public DateTime FechaRegistro { get; set; }  

		[DataMember]  
		public string UsuarioRegistro { get; set; }  

		[DataMember]  
		public DateTime FechaActualizacion { get; set; }  

		[DataMember]  
		public string UsuarioActualizacion { get; set; }  
		
    }
}