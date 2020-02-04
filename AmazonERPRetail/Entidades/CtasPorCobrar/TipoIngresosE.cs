using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Entidades.CtasPorCobrar
{
    [DataContract]
    [Serializable]
    public partial class TipoIngresosE
    {

        public TipoIngresosE()
        {
            ListaIngresosDet = new List<TipoIngresosDetE>();
        }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public String TipoCobro { get; set; }

		[DataMember]
		public String Tipo { get; set; }

		[DataMember]
		public String TipoOperacion { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public String SelCuenta { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
		public String filtroCuenta { get; set; }

        [DataMember]
        public String ctaSoles { get; set; }

        [DataMember]
        public String ctaDolares { get; set; }

        [DataMember]
		public String indCtaProvision { get; set; }

		[DataMember]
		public String codCuentaSoles { get; set; }

		[DataMember]
		public String codCuentaDolares { get; set; }

        [DataMember]
        public Boolean indManipularMontos { get; set; }

        [DataMember]
        public Boolean indManipularMoneda { get; set; }

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
        public List<TipoIngresosDetE> ListaIngresosDet { get; set; }

        [DataMember]
        public List<TipoIngresosDetE> ListaEliminados { get; set; }

        [DataMember]
        public String desCtaProvSoles { get; set; }

        [DataMember]
        public String desCtaProvDolar { get; set; }

        [DataMember]
        public String NombreEmpresa { get; set; }

        [DataMember]
        public String desCtaSoles { get; set; }

        [DataMember]
        public String desCtaDolar { get; set; }

    }   
}