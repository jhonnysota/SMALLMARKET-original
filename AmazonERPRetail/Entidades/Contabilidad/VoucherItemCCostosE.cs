using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class VoucherItemCCostosE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public String AnioPeriodo { get; set; }

		[DataMember]
		public String MesPeriodo { get; set; }

		[DataMember]
		public String numVoucher { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

		[DataMember]
		public String numFile { get; set; }

		[DataMember]
		public String numItem { get; set; }

		[DataMember]
		public String idCCostos { get; set; }

		[DataMember]
		public Decimal? ImporteOriginal { get; set; }

		[DataMember]
		public Decimal? Porcentaje { get; set; }

		[DataMember]
		public Decimal? ImportePorcentaje { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

		//ext
        [DataMember]
        public String desCCostos { get; set; }

        [DataMember]
        public String TipoCC { get; set; }
        
    }   
}