using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class MovimientoBancosE
    {

        public MovimientoBancosE()
        {
            oListaMovimientos = new List<MovimientoBancosDetE>();
        }

        [DataMember]
		public Int32 idMovBanco { get; set; }

		[DataMember]
		public String codMovBanco { get; set; }

		[DataMember]
		public Int32 tipMovimiento { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idBanco { get; set; }

		[DataMember]
		public String ctaBancaria { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public DateTime fecMovimiento { get; set; }

        [DataMember]
        public Boolean TicaAuto { get; set; }

        [DataMember]
		public Decimal tipCambio { get; set; }

		[DataMember]
		public String Glosa { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String serDocumento { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public DateTime? fecDocumento { get; set; }

        [DataMember]
        public DateTime? fecVencimiento { get; set; }

        [DataMember]
        public Int32 idMedioPago { get; set; }

        [DataMember]
        public Decimal TotalImporte { get; set; }

        [DataMember]
        public Decimal TotalImporteDol { get; set; }

        [DataMember]
        public String GiradoA { get; set; }

        [DataMember]
        public Decimal MontoTransS { get; set; }

        [DataMember]
        public Decimal MontoTransD { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

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
        public Boolean indDevolucion { get; set; }

        [DataMember]
        public String indEstado { get; set; } //CR=Creado PR=Provisionado AN=Anulado PT=Transferencia Provisionada

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
        public List<MovimientoBancosDetE> oListaMovimientos { get; set; }

        [DataMember]
        public String desBanco { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desTipoMovimiento { get; set; }

        [DataMember]
        public Int32 idMoviTrans { get; set; }

        [DataMember]
        public String codMoviTrans { get; set; }

        [DataMember]
        public Int32 idEmpresaTrans { get; set; }

        [DataMember]
        public String EmpresaTrans { get; set; }

        [DataMember]
        public Boolean CampoCheck { get; set; }

        [DataMember]
        public String RucEmpresa { get; set; }

    }   
}