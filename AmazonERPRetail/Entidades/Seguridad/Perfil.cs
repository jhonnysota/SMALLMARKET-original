using System;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public class Perfil
    {
        [DataMember]
        public int IdPerfil { get; set; }

        [DataMember]
        public string NombrePerfil { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public string UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaActualizacion { get; set; }

        [DataMember]
        public string UsuarioActualizacion { get; set; }

        #region EXTENDIDAS

        [DataMember]
        public bool CheckPerfil { get; set; }

        #endregion

    }
}
