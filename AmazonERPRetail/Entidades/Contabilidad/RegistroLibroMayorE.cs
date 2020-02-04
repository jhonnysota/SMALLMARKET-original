using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class RegistroLibroMayorE
    {
        [DataMember]
        public String AnioPeriodo { get; set; } 

        [DataMember]
        public String MesPeriodo { get; set; } 
        
        [DataMember]
        public String desPeriodo { get; set; }
        
        [DataMember]
        public String idComprobante { get; set; }
        
        [DataMember]
        public String numFile { get; set; }
        
        [DataMember]
        public String numVoucher { get; set; } 
        
        [DataMember]
        public String numItem { get; set; } 
        
        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public Decimal tipCambio { get; set; }
        
        [DataMember]
        public String idDocumento { get; set; } 
        
        [DataMember]
        public String serDocumento { get; set; } 
        
        [DataMember]
        public String numDocumento { get; set; } 
        
        [DataMember]
        public DateTime? fecDocumento { get; set; } 
        
        [DataMember]
        public DateTime? Fecha { get; set; }
        
        [DataMember]
        public String GlosaGeneral { get; set; }
        
        [DataMember]
        public Decimal impSoles { get; set; }
        
        [DataMember]
        public Decimal impDolares { get; set; }
        
        [DataMember]
        public String indDebeHaber { get; set; }
        
        [DataMember]
        public String desGlosa { get; set; }
        
        [DataMember]
        public Int32 idPersona { get; set; } 
        
        [DataMember]
        public String RazonSocial { get; set; }
        
        [DataMember]
        public String codCuenta { get; set; }
        
        [DataMember]
        public String desCuenta { get; set; }
        
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
        public String desCuenta2 { get; set; } 
        
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
        public String desCuenta1 { get; set; }
        
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
        
        [DataMember]
        public Decimal antDolarDebe0 { get; set; }
        
        [DataMember]
        public Decimal antDolarHaber0 { get; set; }
    
        [DataMember]
        public String Campo3 { get; set; } 
        
        [DataMember]
        public String codPlanCuenta { get; set; }
        
        [DataMember]
        public String desCostos { get; set; }
        
        [DataMember]
        public String codSunat { get; set; }
        
        [DataMember]
        public String TD { get; set; }

        [DataMember]
        public String RUC { get; set; }

    }
}
