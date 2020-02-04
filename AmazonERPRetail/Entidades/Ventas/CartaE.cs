using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class CartaE
    {
        public CartaE()
        {
            ListaCartaProductoDet = new List<CartaProductoDetE>();
        }

        [DataMember]		public Int32 idCarta { get; set; }
		[DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32? idLocal { get; set; }
		[DataMember]		public String Descripcion { get; set; }
		[DataMember]		public Boolean flagActivo { get; set; }
		[DataMember]		public DateTime? fecCese { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? fechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? fechaModificacion { get; set; }
		//Detalle
        [DataMember]
        public List<CartaProductoDetE> ListaCartaProductoDet { get; set; }

        
    }   
}