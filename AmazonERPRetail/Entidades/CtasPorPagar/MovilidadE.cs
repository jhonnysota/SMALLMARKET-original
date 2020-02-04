using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class MovilidadE
    {

        public MovilidadE()
        {
            ListaMovilidadDet = new List<MovilidadDetE>();
        }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idMovilidad { get; set; }

		[DataMember]
		public DateTime Fecha { get; set; }

        [DataMember]
        public String Serie { get; set; }

        [DataMember]
        public String Numero { get; set; }

        [DataMember]
		public Int32 idPersona { get; set; }

        [DataMember]
        public Int32 tipGastoMovi { get; set; }

        [DataMember]
        public Boolean indEstado { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }


        //Extensiones
        [DataMember]
        public List<MovilidadDetE> ListaMovilidadDet { get; set; }

        [DataMember]
        public List<MovilidadDetE> ListaMovilidadEliminados { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String desEstado { get; set; }

        [DataMember]
        public Decimal Monto { get; set; }

        [DataMember]
        public Boolean indReparado { get; set; }

    }   
}