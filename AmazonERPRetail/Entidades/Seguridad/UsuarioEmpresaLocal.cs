using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public partial class UsuarioEmpresaLocal
    {

        [DataMember]  
		public Int32 IdPersona { get; set; }  

		[DataMember]  
		public Int32 IdEmpresa { get; set; }  

		[DataMember]  
		public Int32 IdLocal { get; set; }  

		[DataMember]  
		public DateTime? FechaRegistro { get; set; }  

		[DataMember]  
		public String UsuarioRegistro { get; set; }  

		[DataMember]  
		public DateTime? FechaActualizacion { get; set; }  

		[DataMember]  
		public String UsuarioActualizacion { get; set; }

        #region Extensiones

        [DataMember]
        public List<UsuarioEmpresaLocalPerfil> ListaUsuarioEmpresaLocalPerfil { get; set; }

        [DataMember]
        public String NombreLocal { get; set; }

        [DataMember]
        public String NombreEmpresa { get; set; }

        [DataMember]
        public String NombreUsuario { get; set; }

        #endregion
    }

    

}