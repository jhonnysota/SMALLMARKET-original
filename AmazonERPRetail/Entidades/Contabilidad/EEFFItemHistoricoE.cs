using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class EEFFItemHistoricoE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idEEFF { get; set; }
		[DataMember]		public Int32 idEEFFItem { get; set; }
		[DataMember]		public String AnioPeriodo { get; set; }
		[DataMember]		public Decimal? saldo_sol { get; set; }
		[DataMember]		public Decimal? saldo_dol { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }

        //extensiones

        [DataMember]
        public String secItem { get; set; }

        [DataMember]
        public String desItem { get; set; }

        [DataMember]
        public String TipoTabla { get; set; }



    }   
}