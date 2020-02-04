using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class ComprasFileE
    {

        [DataMember]
		public Int32 idCompraFile { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

		[DataMember]
		public String numFile { get; set; }

        [DataMember]
        public Int32? codColumnaCoven { get; set; }

        [DataMember]
        public Boolean indColumnaIgv { get; set; }

        [DataMember]
        public Int32? codColumnaIgv { get; set; }

        [DataMember]
        public Boolean indCtaCorriente { get; set; }

        [DataMember]
        public Boolean AfectaOc { get; set; }

        [DataMember]
        public Boolean MostrarOp { get; set; }

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
        public List<ComprasFileE> oListaFiles { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String desComprobante { get; set; }

        [DataMember]
        public String desFile { get; set; }

        [DataMember]
        public String nomColumnaCoven { get; set; }

        [DataMember]
        public String nomColumnaIgv { get; set; }

        [DataMember]
        public ComprobantesFileE FileConta { get; set; }

    }
}