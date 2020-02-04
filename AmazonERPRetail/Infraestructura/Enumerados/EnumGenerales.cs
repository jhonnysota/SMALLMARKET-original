using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Infraestructura.Enumerados
{
    public enum EnumGenerales
    {
    }


    public enum EnumOpcionMenuBarra
    {
        Nuevo = 1,
        Grabar = 2,
        Buscar = 3,
        Editar = 4,
        Anular = 5,
        Cancelar = 6,
        Cerrar = 7,

        Exportar = 8,
        Imprimir = 9,
        AgregarDetalle = 10,
        QuitarDetalle = 11
    }

    [DataContract]
    public enum EnumTipoEdicionCuadros
    {
        [EnumMember]
        Bloquear = 1,
        [EnumMember]
        Desbloquear = 2,
        [EnumMember]
        Descuadrado = 3,
        [EnumMember]
        Positivo = 4
    }

    [DataContract]
    public enum DGVHeaderImageAlignments
    {
        [EnumMember]
        Default = 0,
        [EnumMember]
        FillCell = 1,
        [EnumMember]
        SingleCentered = 2,
        [EnumMember]
        SingleLeft = 3,
        [EnumMember]
        SingleRight = 4,
        [EnumMember]
        Stretch = Default,
        [EnumMember]
        Tile = 5
    }

}
