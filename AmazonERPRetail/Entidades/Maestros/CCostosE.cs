using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class CCostosE
    {
        public CCostosE()
        {
            ListaSeries = new List<CCostosNumControlDetE>();
        }

        [DataMember]
        public int idEmpresa { get; set; }
        
        [DataMember]
        public String idCCostos { get; set; }
        
        [DataMember]
        public String idCCostosSup { get; set; }
        
        [DataMember]
        public String desCCostos { get; set; }
        
        [DataMember]
        public Int32? numNivel { get; set; }
        
        [DataMember]
        public Boolean indBaja { get; set; }

        [DataMember]
        public Int32 idSistema { get; set; }
        
        [DataMember]
        public DateTime? fecBaja { get; set; }

        [DataMember]
        public String tipoCCosto { get; set; } //1=Administración 2=Ventas 3=Producción

        [DataMember]
        public String UsuarioRegistro { get; set; }
        
        [DataMember]
        public DateTime? FechaRegistro { get; set; }
        
        [DataMember]
        public String UsuarioModificacion { get; set; }
        
        [DataMember]
        public DateTime? FechaModifica { get; set; }

        [DataMember]
        public String AbrevCCostos { get; set; }

        //Extensiones
        [DataMember]
        public List<CCostosNumControlDetE> ListaSeries { get; set; }

        [DataMember]
        public String desTemporal { get; set; }

        [DataMember]
        public String DesTipoCCosto { get; set; }

    }
}