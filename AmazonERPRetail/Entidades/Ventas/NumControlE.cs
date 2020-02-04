using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class NumControlE
    {
        public NumControlE()
        {
            ListaNumControl = new List<NumControlDetE>();
        }
       
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idControl { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public Boolean swNotaCredito { get; set; }

		[DataMember]
		public Int32? idTipCondicion { get; set; }

		[DataMember]
		public Boolean regVenta { get; set; }

		[DataMember]
		public Boolean indCodigoBarras { get; set; }

		[DataMember]
		public Boolean indVisible { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Detalle
        [DataMember]
        public List<NumControlDetE> ListaNumControl { get; set; }

    }   
}