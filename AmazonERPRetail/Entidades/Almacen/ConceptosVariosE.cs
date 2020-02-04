using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class ConceptosVariosE
    {
            
        [DataMember]
		public Int32 idConcepto { get; set; }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
		public Int32 Tipo { get; set; }

		[DataMember]
		public String codConcepto { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

        [DataMember]
		public String numVerPlanCuentas { get; set; }

        [DataMember]
        public Boolean indCuentaAdm { get; set; }

        [DataMember]
		public String codCuentaAdm { get; set; }

        [DataMember]
        public Boolean indCuentaVen { get; set; }

        [DataMember]
        public String codCuentaVen { get; set; }

        [DataMember]
        public Boolean indCuentaPro { get; set; }

        [DataMember]
        public String codCuentaPro { get; set; }

        [DataMember]
        public Boolean indCuentaFin { get; set; }

        [DataMember]
        public String codCuentaFin { get; set; }

        [DataMember]
        public Boolean indConceptoLiqui { get; set; }

        [DataMember]
        public Boolean indDetraccion { get; set; }

        [DataMember]
        public String idTipoDetraccion { get; set; }

        [DataMember]
        public Boolean indRetencion { get; set; }

        [DataMember]
        public Decimal porImpuesto { get; set; }

        [DataMember]
        public Boolean ParaMovi { get; set; }

        [DataMember]
        public Boolean indCuentasMon { get; set; }

        [DataMember]
        public String CtaSoles { get; set; }

        [DataMember]
        public String CtaDolares { get; set; }

        [DataMember]
        public Boolean indTransferencia { get; set; }

        [DataMember]
        public Boolean indContraPartida { get; set; }

        [DataMember]
        public String CtaContraSoles { get; set; }

        [DataMember]
        public String CtaContraDolares { get; set; }

        [DataMember]
        public Boolean indAnticipo { get; set; }

        [DataMember]
        public Boolean indPlanillas { get; set; }

        [DataMember]
        public Boolean indCompras { get; set; }

        [DataMember]
        public Boolean indTesoreria { get; set; }

        [DataMember]
        public Boolean indCobranzas { get; set; }

        [DataMember]
        public String TipoSolicitud { get; set; } //T=Terceros P=Personal R=Proveedor

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
        public String desCuentaAdm { get; set; }

        [DataMember]
        public String desCuentaVen { get; set; }

        [DataMember]
        public String desCuentaPro { get; set; }

        [DataMember]
        public String desCuentaFin { get; set; }

        [DataMember]
        public String indCCAdm { get; set; }

        [DataMember]
        public String indCCVen { get; set; }

        [DataMember]
        public String indCCPro { get; set; }

        [DataMember]
        public String indCCFin { get; set; }

        [DataMember]
        public String indAuxiliar { get; set; }

        #region Para Construir una pequeña tabla

        [DataMember]
        public String Cuentas { get; set; }

        [DataMember]
        public String desCuentas { get; set; }

        [DataMember]
        public String indCentroCosto { get; set; } 

        #endregion

        [DataMember]
        public String NombreEmpresa { get; set; }

        [DataMember]
        public String CtaDesSoles { get; set; }

        [DataMember]
        public String CtaDesDolares { get; set; }

        [DataMember]
        public String CtaDesContraSoles { get; set; }

        [DataMember]
        public String CtaDesContraDolares { get; set; }

        [DataMember]
        public String Nemo { get; set; }

    }   
}