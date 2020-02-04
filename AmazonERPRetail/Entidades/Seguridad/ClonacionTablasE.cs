using System;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public class ClonacionTablasE
    {
            
        [DataMember]
		public Int32 idTabla { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public String TablaReal { get; set; }

        [DataMember]
        public Int32? Orden { get; set; }

        [DataMember]
        public Int32? idSistema { get; set; }

        [DataMember]
        public Boolean Transferido { get; set; }

        [DataMember]
        public Int32? idEmpresaTrans { get; set; }

        [DataMember]
        public Int32? idEmpresa { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public String RazonSocialTrans { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        //Extensores
        [DataMember]
        public Boolean Check { get; set; }

        [DataMember]
        public String ListaColumnas { get; set; }

        [DataMember]
        public String Eliminar { get; set; }

    }   
}