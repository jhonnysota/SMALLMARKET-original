using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class CuentasMigracionE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }
        
        [DataMember]
        public String tipo { get; set; }
        
        [DataMember]
        public String cuentadestino { get; set; }

        [DataMember]
        public String cuentaorigen { get; set; }

        [DataMember]
        public String ccosto { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        //Extensiones
        [DataMember]
        public String nombredestino { get; set; }

        [DataMember]
        public String nombreorigen { get; set; }

        [DataMember]
        public String nombreccosto { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String empresa { get; set; }

        [DataMember]
        public String ejer { get; set; }
    }
}
