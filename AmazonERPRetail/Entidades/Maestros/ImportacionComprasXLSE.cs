using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class ImportacionComprasXLSE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String Diario { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String numCorrelativo { get; set; }

        [DataMember]
        public DateTime? fecOperacion { get; set; }

        [DataMember]
        public DateTime? fecEmision { get; set; }

        [DataMember]
        public DateTime? fecVencimiento { get; set; }

        [DataMember]
        public String idTipo { get; set; }

        [DataMember]
        public String SerieDocumento { get; set; }

        [DataMember]
        public String NumeroDocumento { get; set; }

        [DataMember]
        public String TipoDocIdentidad { get; set; }

        [DataMember]
        public String NumeroDocIdentidad { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String Glosa { get; set; }

        [DataMember]
        public String Moneda { get; set; }

        [DataMember]
        public Decimal BaseImponibleExportacion { get; set; }

        [DataMember]
        public Decimal BaseImponibleGravada { get; set; }

        [DataMember]
        public Decimal ImporteTotalExonerada { get; set; }

        [DataMember]
        public Decimal ImporteTotalInafecto { get; set; }

        [DataMember]
        public Decimal ISC { get; set; }

        [DataMember]
        public Decimal IGV { get; set; }

        [DataMember]
        public Decimal OtrosCargos { get; set; }

        [DataMember]
        public Decimal ImporteTotal { get; set; }

        [DataMember]
        public Decimal TipoCambio { get; set; }

        [DataMember]
        public DateTime? FechaRef { get; set; }

        [DataMember]
        public String idDocumentoRef { get; set; }

        [DataMember]
        public String serDocumentoRef { get; set; }

        [DataMember]
        public String numDocumentoRef { get; set; }

        [DataMember]
        public Decimal porIgv { get; set; }

        [DataMember]
        public String VTA { get; set; }

        [DataMember]
        public Decimal visaEgresos { get; set; }

        [DataMember]
        public Decimal masterEgresos { get; set; }

        [DataMember]
        public Decimal dinnersEgresos { get; set; }

        [DataMember]
        public Decimal americaEgresos { get; set; }

        [DataMember]
        public Decimal efectivoEgresos { get; set; }

        [DataMember]
        public Decimal ncEgresos { get; set; }

        [DataMember]
        public String DiarioEgresos { get; set; }

        [DataMember]
        public String numFileEgresos { get; set; }

        [DataMember]
        public DateTime? FechaEgresos { get; set; }

        [DataMember]
        public String CuentaEgresos { get; set; }

        [DataMember]
        public String CentroCostos { get; set; }

        [DataMember]
        public String Cuenta1 { get; set; }

        [DataMember]
        public String Cuenta2 { get; set; }

        [DataMember]
        public String Cuenta3 { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

        [DataMember]
        public Int32 Linea { get; set; }

    }
}
