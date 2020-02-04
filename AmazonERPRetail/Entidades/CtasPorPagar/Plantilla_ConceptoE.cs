using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class Plantilla_ConceptoE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idPlantilla { get; set; }

		[DataMember]
		public String DesPlantilla { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

		[DataMember]
		public String numFile { get; set; }

        [DataMember]
        public String CodMoneda { get; set; }

		[DataMember]
		public String TipoPlantilla { get; set; }

        [DataMember]
        public String DesComprobante { get; set; }

        [DataMember]
        public String DesnumFile { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? fechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? fechaModificacion { get; set; }

        [DataMember]
        public List<Plantilla_Concepto_itemE> ListaPlantillaItem { get; set; }

        [DataMember]
        public int Opcion { get; set; }
		
    }   
}