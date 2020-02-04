using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class RegistroDiarioE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String desComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String numVoucher { get; set; }

        [DataMember]
        public String numItem { get; set; }

        [DataMember]
        public String idPersona { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal tipCambio { get; set; }

        [DataMember]
        public String idCCostos { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String serDocumento { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public DateTime? fecDocumento { get; set; }

        [DataMember]
        public DateTime? fecVencimiento { get; set; }

        [DataMember]
        public String desGlosa { get; set; }

        [DataMember]
        public String GlosaGeneral { get; set; }

        [DataMember]
        public String desReferenciaRep { get; set; }

        [DataMember]
        public Decimal impSoles { get; set; }

        [DataMember]
        public Decimal impDolares { get; set; }

        [DataMember]
        public String indDebeHaber { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public DateTime? fecOperacion { get; set; }

        [DataMember]
        public String Campo3 { get; set; }

        [DataMember]
        public String codPlanCuenta { get; set; }

        [DataMember]
        public String desCCostos { get; set; }

        [DataMember]
        public String codSunat { get; set; }

        [DataMember]
        public String TD { get; set; }

        [DataMember]
        public String Ruc { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public Decimal DebeSoles { get; set; }

        [DataMember]
        public Decimal HaberSoles { get; set; }

        [DataMember]
        public Decimal DebeDolares { get; set; }

        [DataMember]
        public Decimal HaberDolares { get; set; }

        [DataMember]
        public String tipPartidaPresu { get; set; }

        [DataMember]
        public String codPartidaPresu { get; set; }


        //Extensiones
        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desPeriodo { get; set; }

        [DataMember]
        public String desPartidaPresu { get; set; }

        [DataMember]
        public String Fecha { get; set; }

        //Revisando si sirven...
        [DataMember]
        public String c_des_cta { get; set; }

        [DataMember]
        public String c_des_aux { get; set; }

        [DataMember]
        public String c_cod_libro { get; set; } 

        [DataMember]
        public String Auxiliar { get; set; }

        [DataMember]
        public Decimal antAuxSolesDebe { get; set; }

        [DataMember]
        public Decimal antAuxSolesHaber { get; set; }

        [DataMember]
        public Decimal antSolesDebe { get; set; }

        [DataMember]
        public Decimal antSolesHaber { get; set; }

        [DataMember]
        public Decimal antDolarDebe { get; set; }

        [DataMember]
        public Decimal antDolarHaber { get; set; }

        [DataMember]
        public String Nivel2 { get; set; }

        [DataMember]
        public String cDesCta2 { get; set; }

        [DataMember]
        public Decimal antSolesDebe2 { get; set; }

        [DataMember]
        public Decimal antSolesHaber2 { get; set; }

        [DataMember]
        public Decimal antDolarDebe2 { get; set; }

        [DataMember]
        public Decimal antDolarHaber2 { get; set; }

        [DataMember]
        public String Nivel1 { get; set; }

        [DataMember]
        public String cDesCta1 { get; set; }

        [DataMember]
        public Decimal antSolesDebe1 { get; set; }

        [DataMember]
        public Decimal antSolesHaber1 { get; set; }

        [DataMember]
        public Decimal antDolarDebe1 { get; set; }

        [DataMember]
        public Decimal antDolarHaber1 { get; set; }

        [DataMember]
        public Decimal antSolesDebe0 { get; set; }

        [DataMember]
        public Decimal antSolesHaber0 { get; set; }

        //henry
        [DataMember]
        public String Nivel3 { get; set; }

        [DataMember]
        public String cDesCta3 { get; set; }

        [DataMember]
        public Decimal antSolesDebe3 { get; set; }

        [DataMember]
        public Decimal antSolesHaber3 { get; set; }

        [DataMember]
        public Decimal antDolarDebe3 { get; set; }

        [DataMember]
        public Decimal antDolarHaber3 { get; set; }

    }
}
