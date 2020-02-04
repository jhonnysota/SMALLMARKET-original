using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Contabilidad
{
   public class InventarioBalanceCteE21
    {
        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String Periodo { get; set; }

        [DataMember]
        public String codigoBanco { get; set; }

        [DataMember]
        public String num_cuenta { get; set; }

        [DataMember]
        public String codigoMoneda  { get; set; }

        [DataMember]
        public String Estado { get; set; }


    }
}
