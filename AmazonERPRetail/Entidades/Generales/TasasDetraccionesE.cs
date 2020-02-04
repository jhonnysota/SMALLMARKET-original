using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public partial class TasasDetraccionesE
    {

        [DataMember]
        public String idTipoDetraccion { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public Decimal BaseAfecta { get; set; }

        [DataMember]
        public Boolean Excluido { get; set; }

        [DataMember]
        public String idTipoOperacion { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public String NombreTemp { get; set; }
        
        [DataMember]
        public List<TasasDetraccionesDetalleE> listaDetraccionesDetalle { get; set; }

        [DataMember]
        public List<TasasDetraccionesDetalleE> ListaDetalleEliminados { get; set; }

    }   
}