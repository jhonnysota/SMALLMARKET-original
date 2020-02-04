using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class HojaCostoE
    {

        public HojaCostoE()
        {
            ListaHojaCostoItem = new List<HojaCostoItemE>();
            ListaGastosImportacion = new List<GastosImportacionE>();
        }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idHojaCosto { get; set; }

		[DataMember]
		public DateTime Fecha { get; set; }

        [DataMember]
        public DateTime FechaIngreso { get; set; }

        [DataMember]
        public Int32 idOrdenCompra { get; set; }

        [DataMember]
		public String numOrdenCompra { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public String Estado { get; set; }

		[DataMember]
		public DateTime? FechaCierreCosto { get; set; }

		[DataMember]
		public String AnioPeriodo { get; set; }

		[DataMember]
		public String MesPeriodo { get; set; }

		[DataMember]
		public String NumVoucher { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

		[DataMember]
		public String NumFile { get; set; }

		[DataMember]
		public String AnioPeriodoCosto { get; set; }

		[DataMember]
		public String MesPeriodoCosto { get; set; }

		[DataMember]
		public String NumVoucherCosto { get; set; }

		[DataMember]
		public String idComprobanteCosto { get; set; }

		[DataMember]
		public String NumFileCosto { get; set; }

		[DataMember]
		public String NumCarperta { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public Int32? tipFormaPago { get; set; }

        [DataMember]
        public String idDocumentoFact { get; set; }

        [DataMember]
		public String FactComercial { get; set; }

        [DataMember]
        public DateTime? fecFacturaComer { get; set; }

		[DataMember]
		public String DUA { get; set; }

        [DataMember]
        public DateTime? fecDua { get; set; }

        [DataMember]
		public String AgAduana { get; set; }

		[DataMember]
		public String Transporte { get; set; }

		[DataMember]
		public DateTime? FechaLlegadaPuerto { get; set; }

		[DataMember]
		public Int32? NroBultos { get; set; }

		[DataMember]
		public String CiadeSeguros { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal? TipoCambio { get; set; }

		[DataMember]
		public String Embarque { get; set; }

		[DataMember]
		public DateTime? FechaLlegadaAduana { get; set; }

		[DataMember]
		public DateTime? FechaLlegadaAlmacen { get; set; }

		[DataMember]
		public String Secuencia { get; set; }

		[DataMember]
		public Int32? Peso { get; set; }

		[DataMember]
		public String Calculo { get; set; }

		[DataMember]
		public String Prorrateo { get; set; }

		[DataMember]
		public Decimal? PorcAdvalorem { get; set; }

		[DataMember]
		public Decimal? PorcIgvCif { get; set; }

		[DataMember]
		public Decimal? PorcIgvAduana { get; set; }

		[DataMember]
		public String Grupo { get; set; }

        [DataMember]
		public Boolean FlagControl { get; set; }

		[DataMember]
		public Decimal? TotalCantidad { get; set; }

		[DataMember]
		public Decimal? TotalPeso { get; set; }

		[DataMember]
		public Decimal? TotalVolumen { get; set; }

		[DataMember]
		public Decimal? TotalFob { get; set; }

		[DataMember]
		public Decimal? TotalFlete { get; set; }

		[DataMember]
		public Decimal? TotalSeguro { get; set; }

		[DataMember]
		public Decimal? TotalSgs { get; set; }

		[DataMember]
		public Decimal? TotalValorCifME { get; set; }

		[DataMember]
		public Decimal? TotalValorCifMN { get; set; }

		[DataMember]
		public Decimal? TotalAdvalorem { get; set; }

		[DataMember]
		public Decimal? TotalGstoAduana { get; set; }

		[DataMember]
		public Decimal? TotalGstoComision { get; set; }

		[DataMember]
		public Decimal? TotalGstoBancario { get; set; }

		[DataMember]
		public Decimal? TotalGstoOtros { get; set; }

		[DataMember]
		public Decimal? TotalCostoImportacion { get; set; }

		[DataMember]
		public Boolean Transferido { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Detalle
        [DataMember]
        public List<HojaCostoItemE> ListaHojaCostoItem { get; set; }

        [DataMember]
        public List<GastosImportacionE> ListaGastosImportacion { get; set; }

        //Extensiones

        [DataMember]
        public String DesPersona { get; set; }

        [DataMember]
        public String DesFormaPago { get; set; }

        [DataMember]
        public String DesGrupo { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

        [DataMember]
        public Decimal Contenido { get; set; }

        [DataMember]
        public String nomUMedidaEnv { get; set; }

        [DataMember]
        public String nomUMedidaPres { get; set; }

        [DataMember]
        public Decimal cantidad { get; set; }

        [DataMember]
        public Decimal FobUnitario { get; set; }

        [DataMember]
        public Decimal CostoUnitarioME { get; set; }

        [DataMember]
        public Decimal Factor { get; set; }

        [DataMember]
        public Decimal ValorFob { get; set; }

        [DataMember]
        public Decimal CostoTotalME { get; set; }

        [DataMember]
        public String DesTransporte { get; set; }

        [DataMember]
        public String NomTipoArticulo { get; set; }

    }   
}