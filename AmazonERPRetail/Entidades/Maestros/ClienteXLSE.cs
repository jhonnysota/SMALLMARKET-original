using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class ClienteXLSE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 TipoPersona { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String ApePaterno { get; set; }

        [DataMember]
        public String ApeMaterno { get; set; }

        [DataMember]
        public String Nombres { get; set; }

        [DataMember]
        public Int32 TipoDocumento { get; set; }

        [DataMember]
        public String NroDocumento { get; set; }

        [DataMember]
        public String DireccionCompleta { get; set; }

        [DataMember]
        public Int32 idPais { get; set; }

        [DataMember]
        public Int32 idCanalVenta { get; set; }

        [DataMember]
        public Int32 Linea { get; set; }


    }
}
