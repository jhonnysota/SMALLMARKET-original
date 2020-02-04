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
    public partial class PlanContableXLSE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public String Cuenta { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public Int32 Nivel { get; set; }

        [DataMember]
        public String Mon { get; set; }

        [DataMember]
        public String DH { get; set; }

        [DataMember]
        public String AjusCambio { get; set; }

        [DataMember]
        public Int32 TipoAjus { get; set; }

        [DataMember]
        public String CtaGanan { get; set; }

        [DataMember]
        public String CtaPerd { get; set; }

        [DataMember]
        public String CambioCom { get; set; }

        [DataMember]
        public String IndGasto { get; set; }

        [DataMember]
        public String CtaDest { get; set; }

        [DataMember]
        public String CtaTransf { get; set; }

        [DataMember]
        public String IndCierre { get; set; }

        [DataMember]
        public String CtaCierre { get; set; }

        [DataMember]
        public String CtaCte { get; set; }

        [DataMember]
        public String ConAux { get; set; }

        [DataMember]
        public String ConDoc { get; set; }

        [DataMember]
        public String ConCC { get; set; }

        [DataMember]
        public Int32 Balance { get; set; }

        [DataMember]
        public Int32 ColCV { get; set; }

        [DataMember]
        public String UltNodo { get; set; }

        [DataMember]
        public Int32 Linea { get; set; }
    }
}
