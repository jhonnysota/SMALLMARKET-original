using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public class Plantilla_Concepto_itemE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idPlantilla { get; set; }

		[DataMember]
		public Int32 idItem { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public String indDebeHaber { get; set; }

        [DataMember]
        public Int32 codColumnaCoven { get; set; }

        [DataMember]
        public String DesColumna { get; set; }

        [DataMember]
        public String DesCuenta { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? fechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? fechaModificacion { get; set; }

        [DataMember]
        public int Opcion { get; set; }
        
    }   
}