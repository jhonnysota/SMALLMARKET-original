using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class ImpresionBarrasE
    {

        public ImpresionBarrasE()
        {
            oListaArticulos = new List<ImpresionBarrasDetE>();
        }

        [DataMember]
		public Int32 idImpresion { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public DateTime FechaImpresion { get; set; }

		[DataMember]
		public String Observacion { get; set; }

        [DataMember]
        public Int32? idPedido { get; set; }

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
        public List<ImpresionBarrasDetE> oListaArticulos { get; set; }

        [DataMember]
        public List<ImpresionBarrasDetE> oListaArticulosEliminados { get; set; }

        [DataMember]
        public String codPedido { get; set; }

    }   
}