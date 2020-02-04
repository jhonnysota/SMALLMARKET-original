using System;
using System.Runtime.Serialization;

using Entidades.Almacen;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class ReciboHonorariosDetE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
		public Int32 idReciboHonorarios { get; set; }

        [DataMember]
        public Int32 idReciboHonorariosDet { get; set; }
        
        [DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String serDocumento { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

        [DataMember]
        public DateTime FechaOperacion { get; set; }

        [DataMember]
		public DateTime FechaRecibo { get; set; }

        [DataMember]
        public Decimal TipoCambio { get; set; }

        [DataMember]
		public Decimal impRecibo { get; set; }

		[DataMember]
		public Decimal impFlete { get; set; }

		[DataMember]
		public Decimal impRetencion { get; set; }

		[DataMember]
		public DateTime FechaPago { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public String numVerPlanCuenta { get; set; }

        [DataMember]
		public String codCuenta { get; set; }

        [DataMember]
        public Int32? idConcepto { get; set; }

        [DataMember]
		public String CuentaGastos { get; set; }

		[DataMember]
		public String idCCostos { get; set; }

		[DataMember]
		public String codFormula { get; set; }

        [DataMember]
        public Boolean indCuartaCat { get; set; }

        [DataMember]
        public Decimal porRetencion { get; set; }

        [DataMember]
        public Decimal impCuartaCat { get; set; }

        [DataMember]
        public Int32? idCtaCte { get; set; }

        [DataMember]
        public Int32? idCtaCteItem { get; set; }

        [DataMember]
        public Boolean indVoucher { get; set; }

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
        public String Glosa { get; set; }

        [DataMember]
        public Boolean indHojaCosto { get; set; }

        [DataMember]
        public Int32? idHojaCosto { get; set; }

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
        public ConceptosVariosE oConcepto { get; set; }

        [DataMember]
        public String desDocumento { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String NomGasto { get; set; }

        [DataMember]
        public String NomCosto { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String codConcepto { get; set; }

        [DataMember]
        public String nomConcepto { get; set; }

    }
}