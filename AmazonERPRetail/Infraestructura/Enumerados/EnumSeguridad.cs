using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Infraestructura.Enumerados
{
    [DataContract]
    public enum EnumSeguridad
    {
        [EnumMember]
        Administrador = 1,

        [EnumMember]
        //DESARROLLO
        //Cajero = 2,
        //PRODUCCION
        Cajero = 4,

        [EnumMember]
        JefeVentas = 3,

        [EnumMember]
        //DESARROLLO 
        //JefeDiseno = 4,
        //PRODUCCION
        JefeDiseno = 2,
        
        [EnumMember]
        JefeComercialTiendas= 6,

        [EnumMember]
        AsistenteRRHH= 7,
    }

     
    public enum EnumAccion
    {
        [EnumMember]
        AprobacionPedido = 1,
        [EnumMember]
        AprobacionDevolucion = 6,
        [EnumMember]
        //DESARROLLO
        //AprobacionDiseno = 4,
        //PRODUCCION
        AprobacionDiseno = 1,
        [EnumMember]
        AprobacionAperturaCajaVenta = 9,     
         [EnumMember]
        ReaperturaCaja = 10,
        [EnumMember]
        AprobacionPagoValeVencido = 11


    }
}
