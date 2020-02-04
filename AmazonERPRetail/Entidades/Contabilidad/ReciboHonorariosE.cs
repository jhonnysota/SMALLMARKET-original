using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class ReciboHonorariosE
    {

        public ReciboHonorariosE()
        {
            oListaRecibos = new List<ReciboHonorariosDetE>();
        }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
		public Int32 idReciboHonorarios { get; set; }

		[DataMember]
		public String AnioPeriodo { get; set; }

		[DataMember]
		public String MesPeriodo { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public Decimal impRecibo { get; set; }

		[DataMember]
		public Decimal impCuartaCat { get; set; }

		[DataMember]
		public Decimal impIES { get; set; }

        [DataMember]
        public Boolean EsCancelado { get; set; }

        [DataMember]
        public Boolean indEstado { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime FechaModificacion { get; set; }

		//Extensiones
        [DataMember]
        public List<ReciboHonorariosDetE> oListaRecibos { get; set; }

        [DataMember]
		public String RUC { get; set; }

        [DataMember]
		public String NroDocumento { get; set; }

        [DataMember]
		public String TipoDocumento { get; set; }

        [DataMember]
		public String desDocumento { get; set; }

        [DataMember]
		public String RazonSocial { get; set; }

        [DataMember]
        public String NomPersona { get; set; }

        [DataMember]
        public String desEstado { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String serDocumento { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public String AnioDet { get; set; }

        [DataMember]
        public String MesDet { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String numVoucher { get; set; }

    }   
}