using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.CtasPorCobrar
{
    [DataContract]
    [Serializable]
    public partial class CobranzasE
    {

        public CobranzasE()
        {
            oListaCobranzas = new List<CobranzasItemE>();
        }

        [DataMember]
        public Int32 idPlanilla { get; set; }

        [DataMember]
        public Int32 TipoPlanilla { get; set; }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

        [DataMember]
        public String codPlanilla { get; set; }

		[DataMember]
		public DateTime Fecha { get; set; }

		[DataMember]
		public Decimal MontoSoles { get; set; }

		[DataMember]
		public Decimal MontoDolares { get; set; }

		[DataMember]
		public String Observaciones { get; set; }

		[DataMember]
		public Boolean EstadoDoc { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

		[DataMember]
		public String numFile { get; set; }

		[DataMember]
		public String AnioPeriodo { get; set; }

		[DataMember]
		public String MesPeriodo { get; set; }

		[DataMember]
		public String numVoucher { get; set; }

        [DataMember]
        public Boolean VieneFact { get; set; }

        [DataMember]
        public Int32? idBanco { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

		//Extensiones
        [DataMember]
        public List<CobranzasItemE> oListaCobranzas { get; set; }

        //Extensiones
        [DataMember]
        public List<CobranzasItemE> oListaItemsEliminados { get; set; }

        [DataMember]
        public String desEstado { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numCheque { get; set; }

        [DataMember]
        public Decimal TipCambio { get; set; }

        [DataMember]
        public String desCtaDetino { get; set; }

        [DataMember]
        public String ToolTipText { get; set; }
        
    }   
}