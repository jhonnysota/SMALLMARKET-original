using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class CanjeE
    {

        public CanjeE()
        {
            ListaCanjeDctoItem = new List<CanjeDctoItemE>();
            ListaLetrasItem = new List<LetrasItemE>();
        }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idCanje { get; set; }

		[DataMember]
		public String numCanje { get; set; }

		[DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public Decimal TipoCambio { get; set; }

		[DataMember]
		public String idMonedaCanje { get; set; }

		[DataMember]
		public Decimal MontoCanje { get; set; }

		[DataMember]
		public DateTime FechaCanje { get; set; }

		[DataMember]
		public Int32 numLetras { get; set; }

		[DataMember]
		public String tipCanje { get; set; }

		[DataMember]
		public String Estado { get; set; }

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
		public Boolean indRetencion { get; set; }

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
        public List<CanjeDctoItemE> ListaCanjeDctoItem { get; set; }

        [DataMember]
        public List<LetrasItemE> ListaLetrasItem { get; set; }

        [DataMember]
        public List<CanjeDctoItemE> ListaDocsEliminados { get; set; }

        [DataMember]
        public List<LetrasItemE> ListaLetrasEliminados { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desEstado { get; set; }

    }
}