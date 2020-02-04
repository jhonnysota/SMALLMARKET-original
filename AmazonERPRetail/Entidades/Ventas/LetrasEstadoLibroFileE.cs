using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class LetrasEstadoLibroFileE
    {
            
        [DataMember]
		public String Estado { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

		[DataMember]
		public String numFile { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String CuentaSoles { get; set; }

		[DataMember]
		public String CuentaDolares { get; set; }

        [DataMember]
        public Boolean indEndosar { get; set; }

        [DataMember]
        public String ctaSolesEndosada { get; set; }

        [DataMember]
        public String ctaDolaresEndosada { get; set; }

        [DataMember]
        public String ctaSolesDscto { get; set; }

        [DataMember]
        public String ctaDolaresDscto { get; set; }

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
        public String desCuentaSoles { get; set; }

        [DataMember]
        public String desCuentaDolares { get; set; }

        [DataMember]
        public String desComprobante { get; set; }

        [DataMember]
        public String desFile { get; set; }

        [DataMember]
        public String desCtaSolesEndosada { get; set; }

        [DataMember]
        public String desCtaDolaresEndosada { get; set; }

        [DataMember]
        public String desCtaSolesDscto { get; set; }

        [DataMember]
        public String desCtaDolaresDscto { get; set; }

    }   
}