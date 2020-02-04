using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class ImpresionBarrasDetE
    {

        public ImpresionBarrasDetE()
        {
            oListaBarras = new List<ImpresionBarrasDetDetE>();
        }

        [DataMember]
		public Int32 idImpresion { get; set; }

		[DataMember]
		public Int32 idArticulo { get; set; }

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
        public List<ImpresionBarrasDetDetE> oListaBarras { get; set; }

        [DataMember]
        public List<ImpresionBarrasDetDetE> oListaBarrasEliminadas { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }
        
        [DataMember]
        public Int32 idArticuloAnte { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

        [DataMember]
        public Int32 codSerie { get; set; }

        [DataMember]
        public String nomSerie { get; set; }

        [DataMember]
        public Int32 idModelo { get; set; }

        [DataMember]
        public String desModelo { get; set; }

        [DataMember]
        public String desColor { get; set; }

        [DataMember]
        public String codBarras { get; set; }

    }   
}