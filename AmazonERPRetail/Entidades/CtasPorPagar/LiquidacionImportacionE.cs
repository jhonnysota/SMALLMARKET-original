using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class LiquidacionImportacionE
    {

        public LiquidacionImportacionE()
        {
            oListaImportacionesDet = new List<LiquidacionImportacionDetE>();
        }

        [DataMember]
        public Int32 idLiquidacion { get; set; }

        [DataMember]
        public String codLiquidacion { get; set; }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal Importe { get; set; }

        [DataMember]
        public Decimal TiCa { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String numVoucher { get; set; }

        [DataMember]
        public String Glosa { get; set; }

        [DataMember]
        public Int32? idCtaCte { get; set; }

        [DataMember]
        public Int32? idCtaCteItem { get; set; }

        [DataMember]
        public Boolean Estado { get; set; }

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
        public List<LiquidacionImportacionDetE> oListaImportacionesDet { get; set; }

        [DataMember]
        public List<LiquidacionImportacionDetE> oListaImportacionesDetDel { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String desComprobante { get; set; }

        [DataMember]
        public String desFile { get; set; }

        [DataMember]
        public String desEstado { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public DateTime FechaTmp { get; set; } //Para poder saber si la fecha ha cambiado y poder generar el código correcto...

        [DataMember]
        public String desMoneda { get; set; }

    }   
}