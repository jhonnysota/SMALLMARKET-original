using System;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public partial class UsuarioFondoFijoE
    {

        [DataMember]
		public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public Int32 TipoFondo { get; set; }

        [DataMember]
        public Boolean Edicion { get; set; }

        [DataMember]
        public Boolean Visualizar { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
		public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
		public DateTime FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String nomEmpresa { get; set; }

        [DataMember]
        public String nomUsuario { get; set; }

        [DataMember]
        public String desTipoFondo { get; set; }

        [DataMember]
        public Boolean Asignacion { get; set; }

    }   
}