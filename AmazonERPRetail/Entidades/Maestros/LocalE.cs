using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class LocalE
    {
        public LocalE()
        {
            Nombre = "";
            NombreCorto = "";
            Direccion = "";
            Telefonos = "";
            IdEmpresa = 0;
        }

        [DataMember]
        public Int32 IdEmpresa { get; set; }  

        [DataMember]
		public Int32 IdLocal { get; set; }

		[DataMember]
		public String Nombre { get; set; }

        [DataMember]
        public Boolean EsPrincipal { get; set; }

		[DataMember]  
		public Boolean EsAlmacen { get; set; }  

		[DataMember]
        public Boolean EsTienda { get; set; }  

		[DataMember]  
		public String NombreCorto { get; set; }  

		[DataMember]
		public String Direccion { get; set; }

        [DataMember]
        public String Telefonos { get; set; } 

        [DataMember]
		public String email { get; set; }
        
        [DataMember]
        public Int32? idCondicion { get; set; }

        [DataMember]
        public String idUbigeo { get; set; }

        [DataMember]
        public string Siglas { get; set; }

        [DataMember]
        public Boolean Estado { get; set; }
	
		[DataMember]  
		public DateTime FechaRegistro { get; set; }  

		[DataMember]  
		public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

		[DataMember]  
		public String UsuarioModificacion { get; set; }       

		#region EXTENSIONES

		[DataMember]
		public String NombreEmpresa { get; set; }

        [DataMember]
        public String Departamento { get; set; }

        [DataMember]
        public String Provincia { get; set; }

        [DataMember]
        public String Distrito { get; set; }

		#endregion

    }
}