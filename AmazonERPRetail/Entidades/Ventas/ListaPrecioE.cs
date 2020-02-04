using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class ListaPrecioE
    {

        public ListaPrecioE()
        {
            ListaPreciosItem = new List<ListaPrecioItemE>();
        }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idListaPrecio { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public String Nombre { get; set; }

        [DataMember]
        public String NombreCorto { get; set; }

        [DataMember]
        public Boolean ParaTicket { get; set; }

        [DataMember]
        public Boolean Principal { get; set; }

		[DataMember]
		public Boolean indBaja { get; set; }

		[DataMember]
		public DateTime? FechaBaja { get; set; }

        [DataMember]
        public Int32 NroLista { get; set; }

        [DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

        //Detalle
        [DataMember]
        public List<ListaPrecioItemE> ListaPreciosItem { get; set; }
        
		[DataMember]
        public String desMoneda { get; set; }
        
    }   
}