using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class CategoriaVendedorE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idCategoria { get; set; }
		[DataMember]		public Int32 idVendedor { get; set; }
		[DataMember]		public String codCategoria { get; set; }
		[DataMember]		public String desCategoria { get; set; }
		[DataMember]		public Boolean indCatagoria { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }
        [DataMember]
        public List<CategoriaVendedorLineaE> oListaDetalle { get; set; }		//Extensiones
        [DataMember]
        public String codVendedor { get; set; }

        [DataMember]
        public String desVendedor { get; set; }

        [DataMember]
        public String codLinea { get; set; }

        [DataMember]
        public String desLinea { get; set; }
        
        //Adicional
        [DataMember]
        public String indRegistro { get; set; }
    }   
}