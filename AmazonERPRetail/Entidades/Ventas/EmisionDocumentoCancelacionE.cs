using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class EmisionDocumentoCancelacionE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public Int32 Item { get; set; }

        [DataMember]
        public string Fecha { get; set; }

        [DataMember]
        public Int32 idMedioPago { get; set; }

        [DataMember]
        public String idDocumentoReci { get; set; }

        [DataMember]
        public String numSerieReci { get; set; }

        [DataMember]
        public String numDocumentoReci { get; set; }

        [DataMember]
        public String idMonedaRecibida { get; set; }

        [DataMember]
        public Decimal MontoRecibido { get; set; }

        [DataMember]
        public Decimal tipCambio { get; set; }

        [DataMember]
        public String idMonedaDocum { get; set; }

        [DataMember]
        public Decimal MontoAplicar { get; set; }

        [DataMember]
        public Decimal Vuelto { get; set; }

        [DataMember]
        public Int32? idBanco { get; set; }

        [DataMember]
        public String numCuentaBanco { get; set; }

        [DataMember]
        public string fecAbono { get; set; }

        [DataMember]
        public Int32? idPlanilla { get; set; }

        [DataMember]
        public Boolean VariosCobros { get; set; }

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
        public String desMedioPago { get; set; }

        [DataMember]
        public String desMonedaDocu { get; set; }

        [DataMember]
        public String desMonedaRec { get; set; }

        [DataMember]
        public String desBanco { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String codPlanilla { get; set; }

        [DataMember]
        public Boolean Marcar { get; set; } //Para poder escoger uno o varias opciones de cancelaciones

        [DataMember]
        public bool IndTarjCredito { get; set; }

        [DataMember]
        public string RazonSocial { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public decimal TotalDoc { get; set; }

    }
}