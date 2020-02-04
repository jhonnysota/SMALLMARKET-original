using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class ReporteEEFFItemE
    {

        [DataMember]
        public Int32 idEEFFItem { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }
        
        [DataMember]
        public String secItem { get; set; }

		[DataMember]
        public String desItem { get; set; }

        [DataMember]
        public String desCCostos { get; set; }

		[DataMember]
        public String TipoTabla { get; set; }

        [DataMember]
        public String TipoCaracteristica { get; set; }

        [DataMember]
        public decimal? saldo_sol { get; set; }

        [DataMember]
        public decimal? saldo_dol { get; set; }

        [DataMember]
        public Int32 fila { get; set; }

        [DataMember]
        public Int32 columna { get; set; }

        [DataMember]
        public String sSaldoSoles { get; set; } //Para los Ratios

        [DataMember]
        public String sSaldoDolares { get; set; } //Para los Ratios -- s de String

        [DataMember]
        public String TipoReporte { get; set; } //Para los Ratios -- s de String

        [DataMember]
        public Int32 Grupo { get; set; } //Para los Ratios

        [DataMember]
        public String GrupoTotalSol { get; set; } //Para los Ratios

        [DataMember]
        public String GrupoTotalDol { get; set; } //Para los Ratios

        [DataMember]
        public String IniFin { get; set; } //Para los Ratios

        [DataMember]
        public String Anio1 { get; set; } //Para los Ratios - Reporte

        [DataMember]
        public String Anio2 { get; set; } //Para los Ratios - Reporte

        [DataMember]
        public String Analisis1V { get; set; } //Para los Ratios - Reporte

        [DataMember]
        public String Analisis2V { get; set; } //Para los Ratios - Reporte

        [DataMember]
        public String AnalisisH { get; set; } //Para los Ratios - Reporte

    }   
}