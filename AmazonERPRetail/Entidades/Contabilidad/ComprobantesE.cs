using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class ComprobantesE
    {
        public ComprobantesE()
        {
            ListaComprobantesFiles = new List<ComprobantesFileE>();
        }

        [DataMember]  
		public Int32 idEmpresa { get; set; }  

		[DataMember]  
		public String idComprobante { get; set; }

		[DataMember]
		public String Descripcion { get; set; }  

		[DataMember]
		public Int32 tpoComprobante { get; set; }

        [DataMember]
        public Boolean indTCVenta { get; set; }

        [DataMember]  
		public String UsuarioRegistro { get; set; }  

		[DataMember]  
		public DateTime? FechaRegistro { get; set; }  

		[DataMember]  
		public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public List<ComprobantesFileE> ListaComprobantesFiles { get; set; }

        [DataMember]
        public String desComprobanteComp { get; set; }

        [DataMember]
        public Boolean Check { get; set; }

    }   
}