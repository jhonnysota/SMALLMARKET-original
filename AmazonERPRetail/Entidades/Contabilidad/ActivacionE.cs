using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class ActivacionE
    {

        public  ActivacionE()
        {
            ListaActivacionDet = new List<ActivacionDetE>();
        }

        [DataMember]
		public Int32 idActivacion { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

        [DataMember]
        public String codActivacion { get; set; }

        [DataMember]
        public DateTime fecOperacion { get; set; }

        [DataMember]
        public DateTime fecDocumento { get; set; }

        [DataMember]
		public String idCCostos { get; set; }

        [DataMember]
        public Boolean indTicaAuto { get; set; }

        [DataMember]
        public Decimal tipCambio { get; set; }

        [DataMember]
		public String MesIni { get; set; }

		[DataMember]
		public String MesFinal { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

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
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public List<ActivacionDetE> ListaActivacionDet { get; set; }

        [DataMember]
        public String desCCostos { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public PlanCuentasE PlanCuenta { get; set; }
    }   
}