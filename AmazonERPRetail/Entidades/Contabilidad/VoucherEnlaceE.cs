using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class VoucherEnlaceE
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
		public Int32 idEmpresaD { get; set; }

		[DataMember]
		public Int32 idLocalD { get; set; }

		[DataMember]
		public String AnioPeriodoD { get; set; }

		[DataMember]
		public String MesPeriodoD { get; set; }

		[DataMember]
		public String numVoucherD { get; set; }

		[DataMember]
		public String idComprobanteD { get; set; }

		[DataMember]
		public String numFileD { get; set; }

    }   
}