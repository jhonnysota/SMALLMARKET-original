using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class PresupuestoDetE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idPresupuesto { get; set; }

        [DataMember]
        public Int32 idPresupuestoItem { get; set; }



        [DataMember]
        public Int32 idEEFFItem { get; set; }

        [DataMember]
        public String Anio { get; set; }

        [DataMember]
        public String Mes { get; set; }

        [DataMember]
        public Decimal Monto { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        //Detalle
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String DesItem { get; set; }

        [DataMember]
        public String NomMes { get; set; }

        
    }
}
