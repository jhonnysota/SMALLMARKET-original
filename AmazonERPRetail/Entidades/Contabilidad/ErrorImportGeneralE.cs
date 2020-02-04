using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class ErrorImportGeneralE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public Int32 idUsuario { get; set; }

        [DataMember]
        public String Archivo { get; set; }

        [DataMember]
        public Int32 Linea { get; set; }

        [DataMember]
        public String NombreCampo { get; set; }

        [DataMember]
        public String ValorCampo { get; set; }

        [DataMember]
        public String Mensaje { get; set; }

        //Extensiones
        [DataMember]
        public String RazonSocial { get; set; }
        
    }   
}