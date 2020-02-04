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
    public partial class PresupuestoE
    {
        public PresupuestoE()
        {
            ListaPresupuestoDet = new List<PresupuestoDetE>();
        }
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idPresupuesto { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public String Anio { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public Int32 idEEFF { get; set; }

        //Detalle
        [DataMember]
        public List<PresupuestoDetE> ListaPresupuestoDet { get; set; }

        [DataMember]
        public String NomMoneda { get; set; }

    }
}
