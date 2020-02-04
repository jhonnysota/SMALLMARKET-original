using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public class NumControlCompraE
    {

        public NumControlCompraE()
        {
            ListaNumControlCompra = new List<NumControlCompraDetE>();
        }

        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idLocal { get; set; }
		[DataMember]		public Int32 idControl { get; set; }
		[DataMember]		public String Descripcion { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }


        //Detalle
        [DataMember]
        public List<NumControlCompraDetE> ListaNumControlCompra { get; set; }

    }   
}