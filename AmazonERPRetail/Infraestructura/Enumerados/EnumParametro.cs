using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Infraestructura.Enumerados
{

    public enum EnumParametroImagenFondo
    {
        fondoEmpresa = 1,
        fondoLocal = 21
    }

    public enum EnumTipoRolPersona
    {
        [EnumMember]
        Cliente = 1,
        [EnumMember]
        Proveedor = 2,
        [EnumMember]
        Trabajador = 3,
        [EnumMember]
        Usuario = 4,
        [EnumMember]
        Chofer = 5,
        [EnumMember]
        Vendedor = 6,
        [EnumMember]
        OperadorLog = 7,
        [EnumMember]
        Bancos = 8,
        [EnumMember]
        FondosFijos = 9
    }

    [DataContract]
    public enum EnumOpcionGrabar
    {
        [EnumMember]
        Insertar = 1,
        [EnumMember]
        Actualizar = 2,
        [EnumMember]
        InsertarSimple = 3,
        [EnumMember]
        Eliminar = 4,
        [EnumMember]
        CambioNoPermitido = 5,
        [EnumMember]
        Anular = 6
    }

}
