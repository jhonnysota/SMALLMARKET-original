using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class CondicionDiasE
    {

        [DataMember]
		public Int32 idTipCondicion { get; set; }

		[DataMember]
		public Int32 idCondicion { get; set; }

		[DataMember]
		public Int32 Dias { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }		
        
        //Campos Adicionales
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public Int32 DiasAnte { get; set; }

    }   
}