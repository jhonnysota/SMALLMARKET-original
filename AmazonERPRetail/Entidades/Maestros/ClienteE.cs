using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class ClienteE
    {
        public ClienteE()
        {
            Persona = new Persona();
            ListaClienteAsociados = new List<ClienteAsociadosE>();
            ListaAvales = new List<ClienteAvalE>();
        }
            
        [DataMember]  
		public Int32 idPersona { get; set; }  
		
        [DataMember]  
		public Int32 idEmpresa { get; set; }  
		
        [DataMember]  
		public String SiglaComercial { get; set; }  
		
        [DataMember]  
		public Int32? TipoCliente { get; set; }  
		
        [DataMember]  
		public DateTime? fecInscripcion { get; set; }  
		
        [DataMember]  
		public DateTime? fecInicioEmpresa { get; set; }  
		
        [DataMember]  
		public Int32? tipConstitucion { get; set; }  
		
        [DataMember]  
		public Int32? tipRegimen { get; set; }  
		
        [DataMember]  
		public Int32? catCliente { get; set; } 
		
        [DataMember]  
		public bool indEstado { get; set; }  
		
        [DataMember]  
		public DateTime? fecBaja { get; set; }  
		
        [DataMember]  
		public String UsuarioRegistro { get; set; }  
		
        [DataMember]  
		public DateTime FechaRegistro { get; set; }  
		
        [DataMember]  
		public String UsuarioModificacion { get; set; }  
		
        [DataMember]  
		public DateTime FechaModificacion { get; set; }

        [DataMember]
        public bool indVinculada { get; set; }

        [DataMember]
        public String idMoneda{ get; set; } //JhonnySota

        //Extensiones
        [DataMember]
        public Persona Persona { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String DireccionCompleta { get; set; }

        [DataMember]
        public List<ClienteAsociadosE> ListaClienteAsociados { get; set; }

        [DataMember]
        public List<ClienteAvalE> ListaAvales { get; set; }

        [DataMember]
        public Int32 idCanalVenta { get; set; }

        [DataMember]
        public Boolean AgenteRetenedor { get; set; }

        [DataMember]
        public String DesPais { get; set; }

        [DataMember]
        public String DesDep { get; set; }

        [DataMember]
        public String DesDis { get; set; }

        [DataMember]
        public String DesPro { get; set; }

    }   
}