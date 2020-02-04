using System;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public partial class UsuarioAccionE
    {

        [DataMember]  
		public Int32 idPersona { get; set; }  

		[DataMember]  
		public Int32 idAccion { get; set; }

		[DataMember]  
		public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idOpcion { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]  
		public DateTime FechaRegistro { get; set; }

        //Extensiones
        [DataMember]
        public String NombreOpcion { get; set; }

        [DataMember]
        public String NombreGrupo { get; set; }

        [DataMember]
        public String NombreUsuario { get; set; }

        [DataMember]
        public String NombreEmpresa { get; set; }

        [DataMember]
        public Int32 Orden { get; set; }

        [DataMember]
        public Int32 GrupoOpcion { get; set; }

        [DataMember]
        public Boolean ControlTotal { get; set; }

        [DataMember]
        public Boolean CR { get; set; } //Create

        [DataMember]
        public Boolean RE { get; set; } //Read

        [DataMember]
        public Boolean UP { get; set; } //Update

        [DataMember]
        public Boolean DE { get; set; } //Delete

        [DataMember]
        public Boolean TomarOpcion { get; set; } //Opcion para saber si se va a tomar la opcion para darle seguridad

        [DataMember]
        public int ItemsAccion { get; set; }

        [DataMember]
        public Boolean ItemFaltante { get; set; }

    }   
}