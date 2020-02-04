using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public partial class ContactosCorreosGrupoE
    {

        public ContactosCorreosGrupoE()
        {
            ListaCorreos = new List<ContactosCorreosE>();
        }

        [DataMember]
        public Int32 idGrupo { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public Int32 idUsuario { get; set; }

        [DataMember]
        public Boolean GrupoDefecto { get; set; }

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
        public List<ContactosCorreosE> ListaCorreos { get; set; }

        [DataMember]
        public List<ContactosCorreosE> ListaCorreosEliminados { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

    }   
}