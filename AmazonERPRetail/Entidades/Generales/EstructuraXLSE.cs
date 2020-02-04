using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public partial class EstructuraXLSE
    {
            
        [DataMember]
        public Int32 Item { get; set; }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 Tipo { get; set; }

		[DataMember]
		public String NombreCampo { get; set; }

		[DataMember]
		public Int32 Fila { get; set; }

		[DataMember]
		public Int32 Columna { get; set; }

        [DataMember]
        public Boolean Incluir { get; set; }

        [DataMember]
        public Boolean EsLineal { get; set; }

        [DataMember]
        public Int32 FilaInicio { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime FechaModificacion { get; set; }

        //Extensiones...
        [DataMember]
        public String desTipo { get; set; }

    }   
}