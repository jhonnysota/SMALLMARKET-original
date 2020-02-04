using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class ParametrosContaE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Boolean FlagClave { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
		public String VentaS { get; set; }

		[DataMember]
		public String VentaD { get; set; }

		[DataMember]
		public String CompraD { get; set; }

		[DataMember]
		public String CompraS { get; set; }

		[DataMember]
		public String Perdida { get; set; }

		[DataMember]
		public String Ganancia { get; set; }

        [DataMember]
        public Int32 numNivelCCosto { get; set; }

        [DataMember]
		public String Costo { get; set; }

		[DataMember]
		public Boolean indFlag104 { get; set; }

		[DataMember]
		public Boolean indFechaVoucher { get; set; }

		[DataMember]
		public Boolean indDetraccion { get; set; }

        [DataMember]
        public String ctaDetraccion { get; set; }

        [DataMember]
        public String ctaDetraccionDol { get; set; }

        [DataMember]
        public Boolean indDiarioDetra { get; set; }

        [DataMember]
		public String DiarioDetraccion { get; set; }

		[DataMember]
		public String FileDetraccion { get; set; }

        [DataMember]
        public String HonorarioCtaSoles { get; set; }

        [DataMember]
        public String HonorarioCtaDolar { get; set; }

        [DataMember]
        public String DiarioHonorario { get; set; }

        [DataMember]
        public String FileHonorario { get; set; }

        [DataMember]
        public Boolean indCuadrar { get; set; }

        [DataMember]
        public int? idAnulado { get; set; }

        [DataMember]
        public String ctaRenta { get; set; }

        [DataMember]
        public String AnticipoS { get; set; }

        [DataMember]
        public String AnticipoD { get; set; }

        [DataMember]
        public String Transferencia { get; set; }

        [DataMember]
        public String DiarioLetra { get; set; }

        [DataMember]
        public String FileLetra { get; set; }

        [DataMember]
        public String codCtaLetraS { get; set; }

        [DataMember]
        public String codCtaLetraD { get; set; }

        [DataMember]
        public String codCtaLetraRespS { get; set; }

        [DataMember]
        public String codCtaLetraRespD { get; set; }

        [DataMember]
        public String DiarioCierre { get; set; }

        [DataMember]
        public String FileCierreResultado { get; set; }

        [DataMember]
        public String FileCierreBalance { get; set; }

        [DataMember]
        public String DiarioRendicion { get; set; }

        [DataMember]
        public String FileRendicion { get; set; }

        [DataMember]
        public String DiarioLiquiOtros { get; set; }

        [DataMember]
        public String FileLiquiOtros { get; set; }

        [DataMember]
        public Boolean MostrarFechaPrint { get; set; }

        [DataMember]
        public Int32? ReporteConci { get; set; }

        [DataMember]
        public String ctaVinculadaSol { get; set; }

        [DataMember]
        public String ctaVinculadaDol { get; set; }

        [DataMember]
        public Boolean indEliminarVoucher { get; set; }

        [DataMember]
        public Int32 idAuxiliarVarios { get; set; }

        [DataMember]
        public String codCtaLiquiSol { get; set; }

        [DataMember]
        public String codCtaLiquiDol { get; set; }

        [DataMember]
        public String DiarioLiqui { get; set; }

        [DataMember]
        public String FileLiqui { get; set; }

        [DataMember]
        public String DiarioIngresos { get; set; }

        [DataMember]
        public String DiarioEgresos { get; set; }

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
        public Int32 numNivel { get; set; }

        [DataMember]
        public String desVentaS { get; set; }

        [DataMember]
        public String desVentaD { get; set; }

        [DataMember]
        public String desCompraD { get; set; }

        [DataMember]
        public String desCompraS { get; set; }

        [DataMember]
        public String desPerdida { get; set; }

        [DataMember]
        public String desGanancia { get; set; }

        [DataMember]
        public String desCCostos { get; set; }

        [DataMember]
        public String desCtaDetraccion { get; set; }

        [DataMember]
        public String desCtaDetraccionDol { get; set; }

        [DataMember]
        public String desCtaHonorarioSoles { get; set; }

        [DataMember]
        public String desCtaHonorarioDolar { get; set; }

        [DataMember]
        public String desCtaRenta { get; set; }

        [DataMember]
        public String desAnticipoS { get; set; }

        [DataMember]
        public String desAnticipoD { get; set; }

        [DataMember]
        public String desTransferencia { get; set; }

        [DataMember]
        public String desCtaLetraS { get; set; }

        [DataMember]
        public String desCtaLetraD { get; set; }

        [DataMember]
        public String desCtaLetraRespS { get; set; }

        [DataMember]
        public String desCtaLetraRespD { get; set; }

        [DataMember]
        public Int32 ValorReporteConci { get; set; }

        [DataMember]
        public String desCtaVinculadaSol { get; set; }

        [DataMember]
        public String desCtaVinculadaDol { get; set; }

        [DataMember]
        public String desAnulado { get; set; }

        [DataMember]
        public String desVarios { get; set; }

        [DataMember]
        public String desCtaLiquiSol { get; set; }

        [DataMember]
        public String desCtaLiquiDol { get; set; }

    }   
}