using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class VentasE
    {
        [DataMember]
        public String Campo1 { get; set; }

        [DataMember]
        public String Campo2 { get; set; }

        [DataMember]
        public String Campo3 { get; set; }

        [DataMember]
        public String Campo4 { get; set; }

        [DataMember]
        public String Campo5 { get; set; }

        [DataMember]
        public String Campo6 { get; set; }

        [DataMember]
        public String Campo7 { get; set; }

        [DataMember]
        public String Campo8 { get; set; }

        [DataMember]
        public String Campo9 { get; set; }

        [DataMember]
        public String Campo10 { get; set; }


    }
}
