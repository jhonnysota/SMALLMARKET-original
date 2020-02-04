using System;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class CtaCte_DetE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idCtaCte { get; set; }

        [DataMember]
        public Int32 idCtaCteItem { get; set; }

        [DataMember]
        public String idDocumentoMov { get; set; }

        [DataMember]
        public String SerieMov { get; set; }

        [DataMember]
        public String NumeroMov { get; set; }

        [DataMember]
        public DateTime FechaMovimiento { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal? MontoMov { get; set; }

        [DataMember]
        public Decimal TipoCambio { get; set; }

        [DataMember]
        public String TipAccion { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String desGlosa { get; set; }

        [DataMember]
        public Boolean EsDetraccion { get; set; }

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
        public String desCuenta { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String indDebeHaber { get; set; }

        [DataMember]
        public Decimal Cargo { get; set; }

        [DataMember]
        public Decimal Abono { get; set; }

        [DataMember]
        public DateTime? FechaVencimiento { get; set; }

        [DataMember]
        public Boolean Seleccionar { get; set; }

    }   
}