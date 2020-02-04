using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class SolicitudProveedorRendicionE
    {

        public SolicitudProveedorRendicionE()
        {
            Estado = false;
            oListaRendiciones = new List<SolicitudProveedorRendicionDetE>();
        }

        [DataMember]
		public Int32 idRendicion { get; set; }

        [DataMember]
        public String codRendicion { get; set; }

        [DataMember]
		public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
		public Int32 idSolicitud { get; set; }

		[DataMember]
		public DateTime fecOperacion { get; set; }

		[DataMember]
		public String AnioPeriodo { get; set; }

		[DataMember]
		public String MesPeriodo { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

		[DataMember]
		public String numFile { get; set; }

		[DataMember]
		public String numVoucher { get; set; }

		[DataMember]
		public Decimal totSoles { get; set; }

		[DataMember]
		public Decimal totDolares { get; set; }

        [DataMember]
        public Decimal MontoAplicado { get; set; }

        [DataMember]
        public Decimal Diferencia { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public Int32? idCtaCte { get; set; }

        [DataMember]
        public Int32? idCtaCteItem { get; set; }

        [DataMember]
        public String Glosa { get; set; }

        [DataMember]
        public Boolean indDeposito { get; set; }

        [DataMember]
        public Int32? idBancoDepo { get; set; }

        [DataMember]
        public String idDocumentoDepo { get; set; }

        [DataMember]
        public String numSerieDepo { get; set; }

        [DataMember]
        public String numDocumentoDepo { get; set; }

        [DataMember]
        public DateTime? fecDepo { get; set; }

        [DataMember]
        public String idMonedaDepo { get; set; }

        [DataMember]
        public Decimal ImporteDepo { get; set; }

        [DataMember]
        public String AnioDepo { get; set; }

        [DataMember]
        public String MesDepo { get; set; }

        [DataMember]
        public String DiarioDepo { get; set; }

        [DataMember]
        public String FileDepo { get; set; }

        [DataMember]
        public String numVoucherDepo { get; set; }

        [DataMember]
        public String GlosaDepo { get; set; }

        [DataMember]
		public Boolean Estado { get; set; }

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
        public List<SolicitudProveedorRendicionDetE> oListaRendiciones { get; set; }

        [DataMember]
        public List<SolicitudProveedorRendicionDetE> oListaRendicionesDel { get; set; }

        [DataMember]
        public String desEstado { get; set; }

        [DataMember]
        public String idMonedaSol { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public Int32 idProveedor { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String desComprobante { get; set; }

        [DataMember]
        public String desFile { get; set; }

        [DataMember]
        public Decimal impSolicitud { get; set; }

        [DataMember]
        public String codSolicitud { get; set; }

        [DataMember]
        public Decimal SaldoSolicitud { get; set; }

        [DataMember]
        public Int32 Fila { get; set; }

    }
}