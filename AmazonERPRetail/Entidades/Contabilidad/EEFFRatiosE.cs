using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class EEFFRatiosE
    {
            
        [DataMember]












        public Decimal Monto { get; set; } //Para almacenar los montos calculados al sacar el reporte de los Ratios...
        
    }   
}