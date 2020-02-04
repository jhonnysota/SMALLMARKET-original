using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class ProcesoValorizaciondeAlmacenE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idAlmacen { get; set; }

        [DataMember]
        public Int32 idArticulo { get; set; }

        [DataMember]
        public String AnioInicio { get; set; }

        [DataMember]
        public String MesInicio { get; set; }

        [DataMember]
        public String AnioFin { get; set; }

        [DataMember]
        public String MesFin { get; set; }

    }
}
