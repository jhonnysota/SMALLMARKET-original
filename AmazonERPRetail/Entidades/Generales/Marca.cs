using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public partial class Marca
    {
        [DataMember]
        public int idMarca { get; set; }

        [DataMember]
        public int idSistema { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string nombreCorto { get; set; }

        [DataMember]
        public string UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public string UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

        #region Extension
        
        [DataMember]
        public int IdVendedor { get; set; }

        #endregion

    }
}