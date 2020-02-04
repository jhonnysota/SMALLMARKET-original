using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class PlanillaBancosE
    {

        public PlanillaBancosE()
        {
            oListaPlanillaBancos = new List<PlanillaBancosDetE>();
        }

        [DataMember]
		public Int32 idPlanillaBanco { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public String Numero { get; set; }

		[DataMember]
		public Int32 idBanco { get; set; }

		[DataMember]
		public String numCuenta { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public DateTime Fecha { get; set; }

		[DataMember]
		public String Producto { get; set; }

		[DataMember]
		public Boolean flagProtesto { get; set; }

		[DataMember]
		public DateTime? fecAbono { get; set; }

		[DataMember]
		public Decimal MontoAbono { get; set; }

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
		public Boolean Generado { get; set; }

		[DataMember]
		public String tipPlanilla { get; set; }

		[DataMember]
		public Int32? idConceptoGasto { get; set; }

        [DataMember]
        public Int32? idConceptoInteres { get; set; }

        [DataMember]
        public Decimal Comision { get; set; }

        [DataMember]
        public Decimal Interes { get; set; }

        [DataMember]
		public String idComprobanteRec { get; set; }

		[DataMember]
		public String numFileRec { get; set; }

		[DataMember]
		public String numVoucherRec { get; set; }

		[DataMember]
		public Boolean GeneradoRec { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public Boolean indEndosar { get; set; }

        [DataMember]
        public Int32? idPersonaEndoso { get; set; }

        [DataMember]
		public String Estado { get; set; } //En Proceso = P  Anulado = A  Cerrado = C

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
        public List<PlanillaBancosDetE> oListaPlanillaBancos { get; set; }

        [DataMember]
        public String desBanco { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desProducto { get; set; }

        [DataMember]
        public String RazonSocialEndoso { get; set; }

        [DataMember]
        public String RucEndoso { get; set; }

        [DataMember]
        public Decimal MontoLetras { get; set; }

        [DataMember]
        public Int32 idPersonaEmpresa { get; set; }

        [DataMember]
        public String RucEmpresa { get; set; }

        [DataMember]
        public String RazonSocialEmpresa { get; set; }

        [DataMember]
        public Int32 idAuxiliar { get; set; }

        [DataMember]
        public String RazonSocialAuxiliar { get; set; }

        [DataMember]
        public String Letra { get; set; }

        [DataMember]
        public DateTime fecVenc { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public Boolean Escoger { get; set; } //Para sacar un check, uso general

    }   
}