using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class RetencionE
    {

        public RetencionE()
        {
            ListaRetencionItem = new List<RetencionItemE>();
        }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String serieCompRete { get; set; }

        [DataMember]
        public String numeroCompRete { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public Decimal MontoBase { get; set; }

        [DataMember]
        public Decimal MontoRetenido { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal TipoCambio { get; set; }

        [DataMember]
        public String Estado { get; set; } //C=Creado, E=Emitido, A=Anulado

        [DataMember]
        public Boolean flagVoucher { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }

        [DataMember]
        public String NumVoucher { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

        //Detalle
        [DataMember]
        public List<RetencionItemE> ListaRetencionItem { get; set; }

        //Extensiones
        [DataMember]
        public String NomPersona { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String serDocumento { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public DateTime FecDocumento { get; set; }

        [DataMember]
        public Decimal PorcRetencion { get; set; }

        [DataMember]
        public Decimal Monto { get; set; }

        [DataMember]
        public Decimal MontoSoles { get; set; }

        [DataMember]
        public Decimal MontoRetenidoSoles { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String DesPersona { get; set; }

        [DataMember]
        public String DireccionPersona { get; set; }
        
        [DataMember]
        public String Correo { get; set; }

        [DataMember]
        public String Linea { get; set; }

        [DataMember]
        public String td_proveedor { get; set; }

        [DataMember]
        public String ruc { get; set; }

        [DataMember]
        public String razonsocial { get; set; }

        [DataMember]
        public String CodigoSunat { get; set; }

        [DataMember]
        public String SerDocumento { get; set; }

        [DataMember]
        public Decimal Debe { get; set; }

        [DataMember]
        public Decimal Haber { get; set; }

        [DataMember]
        public String dirLocal { get; set; }

    }
}
