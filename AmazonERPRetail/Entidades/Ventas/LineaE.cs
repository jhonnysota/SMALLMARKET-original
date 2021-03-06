﻿using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class LineaE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public String idLinea { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

    }
}
