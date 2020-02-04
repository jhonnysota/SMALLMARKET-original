using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class PedidoCabE
    {
        public PedidoCabE()
        {
            ListaPedidoDet = new List<PedidoDetE>();
            idPedidoEnlace = 0;
        }

        [DataMember]
        public Int32 idPedido { get; set; }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String codPedidoCad { get; set; }

		[DataMember]
		public string FecPedido { get; set; }

        [DataMember]
        public string FecCotizacion { get; set; }

        [DataMember]
        public string FecEntrega { get; set; }

        [DataMember]
        public Int32? idNotificar { get; set; }

        [DataMember]
        public Int32? idFacturar { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

		[DataMember]
		public String Observacion { get; set; }

        [DataMember]
        public String Indicaciones { get; set; }

		[DataMember]
		public String Estado { get; set; } //--Estados del Pedido P=Pedido C=Cotizado F=Facturado A=Anulado

        [DataMember]
		public String NroGuia { get; set; }

        [DataMember]
        public string FecFactura { get; set; }

        [DataMember]
        public String nroFactura { get; set; }

        [DataMember]
        public Int32? idFormaPago { get; set; } 
        
        [DataMember]
        public Int32? idTipCondicion { get; set; }
        
        [DataMember]
        public Int32? idCondicion { get; set; }
        
        [DataMember]
        public Int32? idVendedor { get; set; }
		
        [DataMember]
        public Int32? idEstablecimiento { get; set; }
        
        [DataMember]
        public Int32? idZona { get; set; }

        [DataMember]
        public Boolean Tipo { get; set; }

        [DataMember]
		public Decimal totsubTotal { get; set; }
        
        [DataMember]
        public Decimal totDscto1 { get; set; }
        
        [DataMember]
        public Decimal totDscto2 { get; set; }
        
        [DataMember]
        public Decimal totDscto3 { get; set; }
        
        [DataMember]
        public Decimal totIsc { get; set; }
        
        [DataMember]
        public Decimal totIgv { get; set; }
        
        [DataMember]
        public Decimal totTotal { get; set; }

        [DataMember]
        public Decimal Redondeo { get; set; }

        [DataMember]
        public Int32? idSucursalCliente { get; set; }
        
        [DataMember]
        public String PuntoPartida { get; set; }

        [DataMember]
        public String PuntoLlegada { get; set; }
        
        [DataMember]
        public Int32? TipoDoc { get; set; }

        [DataMember]
        public Int32? idTransporte { get; set; }

        [DataMember]
        public String indCotPed { get; set; } // P=Pedido C=Cotización

        [DataMember]
        public Int32 idPedidoEnlace { get; set; }

        [DataMember]
        public Int32? idDivision { get; set; }

        [DataMember]
        public Boolean CorreoEnviado { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? fechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? fechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public List<PedidoDetE> ListaPedidoDet { get; set; }


        [DataMember]
        public int idTipoPre { get; set; }  ///jhonny sota


        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desNotificador { get; set; }

        [DataMember]
        public String desFacturar { get; set; }

        [DataMember]
        public String DireccionCompleta { get; set; }

        [DataMember]
        public String dirNotificador { get; set; }

        [DataMember]
        public String desArticulo { get; set; }

        [DataMember]
        public Decimal PesoBruto { get; set; }

        [DataMember]
        public Decimal PesoNeto { get; set; }

        [DataMember]
        public String dirAlmacenIngreso { get; set; }

        [DataMember]
        public String Vendedor { get; set; }

        [DataMember]
        public String numDocVendedor { get; set; }

        [DataMember]
        public String RucCliente { get; set; }

        [DataMember]
        public String RucNotificador { get; set; }

        [DataMember]
        public String desCondicion { get; set; }

        [DataMember]
        public String NemoTipoDoc { get; set; }

        [DataMember]
        public Int32 idOrdenCompra { get; set; }

        [DataMember]
        public String numOrdenCompra { get; set; }

        [DataMember]
        public String RazonSocialTransporte { get; set; }

        [DataMember]
        public String RucTransporte { get; set; }

        [DataMember]
        public String telVendedor { get; set; }

        [DataMember]
        public String EmailVendedor { get; set; }

        [DataMember]
        public string DesEstado { get; set; }


    }   
}