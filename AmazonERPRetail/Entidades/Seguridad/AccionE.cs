using System;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public class AccionE
    {

        public AccionE()
        {
            Nombre = String.Empty;
            Descripcion = String.Empty;
        }

        [DataMember]
        public Int32 IdAccion { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

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
        public Int32 Indice { get; set; } //Para el CRUD

    }
}