using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class ProveedorCuentaE
    {
            
        [DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idItem { get; set; }

		[DataMember]
		public Int32? idPersonaBanco { get; set; }

		[DataMember]
		public Int32? tipCuenta { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public String numCuenta { get; set; }

		[DataMember]
		public String numInterbancaria { get; set; }

        [DataMember]
        public Boolean BancoPorDefecto { get; set; }

        [DataMember]
        public String CuentaPorDefecto { get; set; }

        [DataMember]
        public Boolean indBaja { get; set; }

        [DataMember]
        public DateTime? fecBaja { get; set; }

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
        public Int32 Opcion { get; set; }

        [DataMember]
        public String desBanco { get; set; }

        [DataMember]
        public String desTipoCuenta { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String CuentaBanco { get; set; }

    }
}