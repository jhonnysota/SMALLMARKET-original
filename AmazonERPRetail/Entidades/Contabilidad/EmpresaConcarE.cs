using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class EmpresaConcarE
    {
        [DataMember]
        public String CodEmpresa { get; set; }

        [DataMember]
        public String NomEmpresa { get; set; }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        //Extension 
        [DataMember]
        public String EmpresaDescripcion { get; set; }

    }
}
