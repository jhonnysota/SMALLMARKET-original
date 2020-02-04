using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{

    [DataContract]
    [Serializable]
    public class ConsistenciaVoucherE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
        public String numVoucher { get; set; }

		[DataMember]
        public String numItem { get; set; }

		[DataMember]
		public String MesPeriodo { get; set; }

		[DataMember]
		public String AnioPeriodo { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }


        [DataMember]
        public Decimal D_imp_Soles { get; set; }

        [DataMember]
        public Decimal H_imp_Soles { get; set; }

        [DataMember]
        public Decimal D_imp_Dolares { get; set; }

        [DataMember]
        public Decimal H_imp_Dolares { get; set; }



		[DataMember]
		public String idMoneda { get; set; }

        [DataMember]
        public DateTime? fecOperacion { get; set; }

        [DataMember]
        public DateTime? fecDocumento { get; set; }

		[DataMember]
		public String Glosita { get; set; }

		[DataMember]
		public String GlosaGeneral { get; set; }

        [DataMember]
        public String codCuentaDestino { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public Decimal Diferencia { get; set; }

        //[DataMember]
        //public String UsuarioRegistro { get; set; }

        //[DataMember]
        //public DateTime? FechaRegistro { get; set; }

        //[DataMember]
        //public String UsuarioModificacion { get; set; }

        //[DataMember]
        //public DateTime? FechaModificacion { get; set; }

		
        
    }   
}