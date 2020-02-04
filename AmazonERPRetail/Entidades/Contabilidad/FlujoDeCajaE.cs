using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Contabilidad
{

    [DataContract]
    [Serializable]
    public partial class FlujoDeCajaE
    {
        [DataMember]
        public String AÑO { get; set; }

        [DataMember]
        public String MES { get; set; }

        [DataMember]
        public String IDENTIFICADOR { get; set; }

        [DataMember]
        public String COD_PARTIDA { get; set; }

        [DataMember]
        public String PARTIDA { get; set; }

        [DataMember]
        public String SUB_PARTIDA { get; set; }

        [DataMember]
        public String SUB_PARTIDA_PRESU { get; set; }

        [DataMember]
        public String MOV { get; set; }

        [DataMember]
        public Decimal IMPORTE { get; set; }

        [DataMember]
        public String CLAVE { get; set; }

        [DataMember]
        public String RANGO { get; set; }

        [DataMember]
        public String COD_PARTIDA_PRES { get; set; }

        [DataMember]
        public String PARTIDA_PRESU { get; set; }

        [DataMember]
        public String LIBRO { get; set; }

        [DataMember]
        public String NFILE { get; set; }

        [DataMember]
        public String NUMERO { get; set; }

        [DataMember]
        public String ITEM { get; set; }

        [DataMember]
        public String CUENTA { get; set; }

        [DataMember]
        public DateTime? FECHA_COMP { get; set; }

        [DataMember]
        public String GLOSA { get; set; }

        [DataMember]
        public String DOCUMENTO { get; set; }

        [DataMember]
        public DateTime? FECHA_EMIS { get; set; }

        [DataMember]
        public Decimal DEBE { get; set; }

        [DataMember]
        public Decimal HABER { get; set; }

    }
}
