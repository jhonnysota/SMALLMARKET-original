using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class ImpresionBarrasDetDetE
    {
            
        [DataMember]
		public Int32 idImpresion { get; set; }

		[DataMember]
		public Int32 idArticulo { get; set; }

		[DataMember]
		public Int32 Item { get; set; }

		[DataMember]
		public Int32 Talla { get; set; }

		[DataMember]
		public String codBarras { get; set; }

        [DataMember]
        public Int32 Cantidad { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModficacion { get; set; }

		[DataMember]
		public DateTime FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String desModelo { get; set; }

        [DataMember]
        public String abrevMaterial { get; set; }

        [DataMember]
        public String desColor { get; set; }

        [DataMember]
        public DateTime fecImpresion { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

        //Extensiones
        [DataMember]
        public ArticuloServE oArticulo { get; set; }

    }   
}