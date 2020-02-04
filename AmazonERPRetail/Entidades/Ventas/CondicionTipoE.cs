using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class CondicionTipoE
    {
        public CondicionTipoE()
        {
            ListaCondicionTipo = new List<CondicionE>();
        }

        [DataMember]
		public Int32 idTipCondicion { get; set; }

		[DataMember]
		public String desTipCondicion { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Detalle//
        [DataMember]
        public List<CondicionE> ListaCondicionTipo { get; set; }

    }   
}