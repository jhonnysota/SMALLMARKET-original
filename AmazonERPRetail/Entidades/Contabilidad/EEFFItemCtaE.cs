using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class EEFFItemCtaE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idEEFF { get; set; }
		[DataMember]		public Int32 idEEFFItem { get; set; }
		[DataMember]		public Int32 idEEFFItemCta { get; set; }		[DataMember]		public String CodPlaCta { get; set; }
		[DataMember]		public String NumPlaCta { get; set; }
		[DataMember]		public String TipoCondicion { get; set; }
		[DataMember]		public String TipoNivel { get; set; }		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String DesNivel { get; set; }

        [DataMember]
        public Decimal totDebeSoles { get; set; }

        [DataMember]
        public Decimal totHaberSoles { get; set; }

        [DataMember]
        public Decimal totDebeDolares { get; set; }

        [DataMember]
        public Decimal totHaberDolares { get; set; }

        [DataMember]
        public Decimal SaldoActualSoles { get; set; }

        [DataMember]
        public Decimal SaldoActualDolares { get; set; }

        [DataMember]
        public Boolean Check { get; set; }

    }   
}