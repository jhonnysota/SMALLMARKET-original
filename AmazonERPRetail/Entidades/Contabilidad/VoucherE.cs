using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class VoucherE
    {
        public VoucherE()
        {
            ListaVouchers = new List<VoucherItemE>();
        }

        [DataMember]  
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }
		
        [DataMember]  
		public String AnioPeriodo { get; set; }  
		
        [DataMember]  
		public String MesPeriodo { get; set; }
		
        [DataMember]  
		public String numVoucher { get; set; }  
		
        [DataMember]
		public String idComprobante { get; set; }  
		
        [DataMember]
		public String numFile { get; set; }  
		
        [DataMember]  
		public DateTime? fecTransferencia { get; set; }  
		
        [DataMember]  
		public Int32? numItems { get; set; }  
		
        [DataMember]
		public String idMoneda { get; set; }  
		
        [DataMember]  
		public DateTime? fecOperacion { get; set; }  
		
        [DataMember]  
		public DateTime? fecDocumento { get; set; }  
		
        [DataMember]  
		public Decimal impDebeSoles { get; set; }  
		
        [DataMember]  
		public Decimal impHaberSoles { get; set; }  
		
        [DataMember]  
		public Decimal impDebeDolares { get; set; }  
		
        [DataMember]  
		public Decimal impHaberDolares { get; set; }  
		
        [DataMember]  
		public Decimal? impMonOrigDeb { get; set; }  
		
        [DataMember]  
		public Decimal? impMonOrigHab { get; set; }  
		
        [DataMember]
		public String GlosaGeneral { get; set; }  
		
        [DataMember]  
		public String indEstado { get; set; }  
		
        [DataMember]
		public Decimal? tipCambio { get; set; }  
		
        [DataMember]  
		public String RazonSocial { get; set; }  
		
        [DataMember]  
		public String numDocumentoPresu { get; set; }  
		
        [DataMember]  
		public String indHojaCosto { get; set; }  
		
        [DataMember]  
		public String numHojaCosto { get; set; }  
		
        [DataMember]  
		public String numOrdenCompra { get; set; }  
		
        [DataMember]  
		public String sistema { get; set; }

        [DataMember]
        public Boolean EsAutomatico { get; set; }
		
        [DataMember]  
		public String UsuarioRegistro { get; set; }  
		
        [DataMember]  
		public DateTime? FechaRegistro { get; set; }  
		
        [DataMember]  
		public String UsuarioModificacion { get; set; }  
		
        [DataMember]  
		public DateTime? FechaModificacion { get; set; }

        //OTROS CAMPOS
        [DataMember]
        public List<VoucherItemE> ListaVouchers { get; set; }

        [DataMember]
        public String desFile { get; set; }

        [DataMember]        
        public String desMoneda { get; set; }

        [DataMember]
        public String descomprobante { get; set; }        

        [DataMember]
        public Boolean Check { get; set; }

    }   
}