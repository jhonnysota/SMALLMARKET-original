using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class VendedoresE
    {
        public VendedoresE()
        {
            Persona = new Persona();
            ListaVendedoresCartera = new List<VendedoresCarteraE>();
        }

        [DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public String codVendedor { get; set; }

		[DataMember]
		public Boolean indEstado { get; set; }

        [DataMember]
        public DateTime? fecBaja { get; set; }

        [DataMember]
        public Boolean indSupervisor { get; set; }

        [DataMember]
        public Boolean ManejaCartera { get; set; }

        [DataMember]
        public Int32 idDivision { get; set; }

        [DataMember]
        public Int32? idEstablecimiento { get; set; }

        [DataMember]
        public Int32? idZona { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
		public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
		public DateTime FechaModificacion { get; set; }

		//EXTENSORES
        [DataMember]
        public Persona Persona { get; set; }

        [DataMember]
        public String ApePaterno { get; set; }

        [DataMember]
        public String ApeMaterno { get; set; }

        [DataMember]
        public String Nombres { get; set; }
        
        [DataMember]
        public String NroDocumento { get; set; }

        [DataMember]
        public String NombresCom { get; set; }

        [DataMember]
        public Int32 idVendedor { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        //Detalle
        [DataMember]
        public List<VendedoresCarteraE> ListaVendedoresCartera { get; set; }

    }   
}