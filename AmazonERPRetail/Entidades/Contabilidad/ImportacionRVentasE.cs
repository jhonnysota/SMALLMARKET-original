using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class ImportacionRVentasE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idEstablecimiento { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }

        [DataMember]
        public String Libro { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public Int32 Item { get; set; }

        [DataMember]
		public String T { get; set; }

		[DataMember]
		public String VOU { get; set; }

        [DataMember]
        public String DebeHaber { get; set; }

        [DataMember]
		public DateTime Fecha { get; set; }

		[DataMember]
		public String Cuenta { get; set; }

		[DataMember]
		public Decimal Debe { get; set; }

		[DataMember]
		public Decimal Haber { get; set; }

		[DataMember]
		public String Moneda { get; set; }

		[DataMember]
		public Decimal TC { get; set; }

		[DataMember]
		public String Doc { get; set; }

		[DataMember]
		public String Numero { get; set; }

		[DataMember]
		public DateTime FechaD { get; set; }

		[DataMember]
		public DateTime? FechaV { get; set; }

		[DataMember]
		public String Codigo { get; set; }

		[DataMember]
		public String CC { get; set; }

		[DataMember]
		public String FE { get; set; }

		[DataMember]
		public String PRE { get; set; }

		[DataMember]
		public String MPago { get; set; }

		[DataMember]
		public String Glosa { get; set; }

		[DataMember]
		public String RNumero { get; set; }

		[DataMember]
		public String RTdoc { get; set; }

		[DataMember]
		public DateTime? RFecha { get; set; }

		[DataMember]
		public String SNumero { get; set; }

		[DataMember]
		public DateTime? SFecha { get; set; }

		[DataMember]
		public String TL { get; set; }

		[DataMember]
		public Decimal BaseImponible { get; set; }

		[DataMember]
		public Decimal BaseNoImponible { get; set; }

		[DataMember]
		public Decimal IgvB { get; set; }

		[DataMember]
		public Decimal BaseImponibleExportacion { get; set; }

		[DataMember]
		public Decimal IGV { get; set; }

		[DataMember]
		public Decimal IgvOtros { get; set; }

		[DataMember]
		public Decimal BaseImponilbleC { get; set; }

		[DataMember]
		public Decimal IgvC { get; set; }

		[DataMember]
		public Decimal ISC { get; set; }

		[DataMember]
		public String RUC { get; set; }

		[DataMember]
		public String Tipo { get; set; }

		[DataMember]
		public String Rs { get; set; }

		[DataMember]
		public String Ape1 { get; set; }

		[DataMember]
		public String Ape2 { get; set; }

		[DataMember]
		public String Nombre { get; set; }

		[DataMember]
		public String TDoci { get; set; }

		[DataMember]
		public String RNumdes { get; set; }

		[DataMember]
		public String RCodTasa { get; set; }

		[DataMember]
		public String RIndRet { get; set; }

		[DataMember]
		public Decimal RMonto { get; set; }

		[DataMember]
		public Decimal RIgv { get; set; }

        [DataMember]
        public String NombreArchivo { get; set; }

    }   
}