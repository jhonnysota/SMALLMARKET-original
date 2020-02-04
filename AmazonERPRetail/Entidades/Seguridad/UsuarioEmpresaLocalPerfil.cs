using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public partial  class UsuarioEmpresaLocalPerfil
    {
        [DataMember]
        public int IdPersona { get; set; }

        [DataMember]
        public int IdEmpresa { get; set; }

        [DataMember]
        public int IdLocal { get; set; }

        [DataMember]
        public int IdPerfil { get; set; }

        #region EXTENDIDAS

        [DataMember]
        public string NombreCompletoPersona { get; set; }

        [DataMember]
        public string NombrePerfil { get; set; }

        [DataMember]
        public bool Estado { get; set; }

        [DataMember]
        public decimal MontoPar { get; set; }

        [DataMember]
        public decimal MontoPorcentaje { get; set; }

        #endregion
    }
}
