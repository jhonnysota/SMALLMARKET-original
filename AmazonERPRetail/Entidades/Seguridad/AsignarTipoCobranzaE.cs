using System;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public partial class AsignarTipoCobranzaE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idUsuario { get; set; }

		[DataMember]
		public Int32 idTipoPlanilla { get; set; }

		[DataMember]
		public Boolean AbrirPlanilla { get; set; }

		[DataMember]
		public Boolean CerrarPlanilla { get; set; }

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
        public Int32 idTipoPlanillaAnte { get; set; }

        [DataMember]
        public String desTipoPlanilla { get; set; }

        [DataMember]
        public String nomEmpresa { get; set; }

        [DataMember]
        public String nomLocal { get; set; }

        [DataMember]
        public String nomUsuario { get; set; }

        [DataMember]
        public String NemoTecnico { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String TipoCobro { get; set; }

    }   
}