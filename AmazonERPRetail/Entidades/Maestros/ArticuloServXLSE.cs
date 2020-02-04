using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class ArticuloServXLSE
    {

        [DataMember]
        public Int32 Linea { get; set; }

        [DataMember]
        public String TipoArticulo { get; set; }

        [DataMember]
        public String Categoria { get; set; }

        [DataMember]
        public String CodigoArticulo { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String NombreLargo { get; set; }

        [DataMember]
        public String NombreCorto { get; set; }

        [DataMember]
        public String CodBarra { get; set; }

        [DataMember]
        public String TipoMedAlmacen { get; set; }

        [DataMember]
        public String UniMedAlmacen { get; set; }

        [DataMember]
        public String TipoMedEnv { get; set; }

        [DataMember]
        public String UniMedEnv { get; set; }

        [DataMember]
        public String TipoMedPres { get; set; }

        [DataMember]
        public String UniMedPres { get; set; }

        [DataMember]
        public Decimal Contenido { get; set; }

        [DataMember]
        public Decimal PesoUnitario { get; set; }

        [DataMember]
        public Decimal Capacidad { get; set; }

    }
}
