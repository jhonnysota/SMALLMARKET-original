using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public partial class TasasDetraccionesDetalleE
    {
            
        [DataMember]









        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public Boolean Excluido { get; set; }

        [DataMember]
        public String NombreTemp { get; set; }

        [DataMember]
        public Decimal BaseAfecta { get; set; }

    }   
}