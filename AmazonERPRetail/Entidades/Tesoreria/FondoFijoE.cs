using System;
using System.Runtime.Serialization;

using Entidades.Maestros;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class FondoFijoE
    {

        public FondoFijoE()
        {
            Persona = new Persona();
        }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public String numFondo { get; set; }

        [DataMember]
		public String desFondo { get; set; }

        [DataMember]
        public String TipoFondo { get; set; }

        [DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

		[DataMember]
		public String numFile { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal MontoAutorizado { get; set; }

		[DataMember]
		public Int32? idPersonaResponsable { get; set; }

        [DataMember]
        public String Tipo { get; set; }

        [DataMember]
        public Int32? idPersonaBanco { get; set; }

        [DataMember]
        public Int32? tipCuenta { get; set; }

        [DataMember]
        public String idMonedaCuenta { get; set; }

        [DataMember]
        public String numCuenta { get; set; }

        [DataMember]
        public String numInterbancaria { get; set; }

        [DataMember]
        public Int32? TipoCuentaLiq { get; set; }

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
        public Persona Persona { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String desResponsable { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String desPersona { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String desBanco { get; set; }

        [DataMember]
        public String nroResponsable { get; set; }

        [DataMember]
        public String desTipoFondo { get; set; }

        [DataMember]
        public String desTipoCuentaLiq { get; set; }

    }   
}