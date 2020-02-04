using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class conCtaCteE
    {
            
        [DataMember]
		public Int32 idCtaCte { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public Int32 idPersona { get; set; }

        [DataMember]
        public DateTime? fecDocumento { get; set; }

        [DataMember]
        public DateTime? fecVencimiento { get; set; }

        [DataMember]
        public DateTime? fecCancelacion { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String serDocumento { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }
        
        [DataMember]
        public String idComprobante { get; set; }
        
        [DataMember]
        public String numFile { get; set; }
        
        [DataMember]
        public String numVoucher { get; set; }
        
        [DataMember]
        public String Glosa { get; set; }

        [DataMember]
        public DateTime? fecOperacion { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }
        
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        
        [DataMember]
        public String UsuarioModificacion { get; set; }
        
        [DataMember]
        public DateTime FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public List<conCtaCteItemE> ListaCtaCteItems { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String Ruc { get; set; }

        [DataMember]
        public String desLocal { get; set; }

        [DataMember]
        public Decimal CargoSoles { get; set; }

        [DataMember]
        public Decimal SaldoSoles { get; set; }

        [DataMember]
        public Decimal CargoDolares { get; set; }

        [DataMember]
        public Decimal SaldoDolares { get; set; }

        [DataMember]
        public Int32 FilaIndex { get; set; }

        [DataMember]
        public string MesPeriodo { get; set; }

        [DataMember]
        public Decimal tipCambio { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String Item { get; set; }

        [DataMember]
        public String TipoDoc { get; set; }

        [DataMember]
        public Int32 Estado { get; set; }

        [DataMember]
        public String desAbreviatura { get; set; }        

    }   
}