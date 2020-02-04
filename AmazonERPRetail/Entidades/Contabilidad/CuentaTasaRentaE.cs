using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class CuentaTasaRentaE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String idTasaRenta { get; set; }

		//Extensiones
        [DataMember]
        public String desTasaRenta { get; set; }

        [DataMember]
        public Decimal TasaRenta { get; set; }

    }   
}