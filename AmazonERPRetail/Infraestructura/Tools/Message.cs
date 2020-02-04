using System;
using System.Runtime.Serialization;

namespace Infraestructura.Tools
{
    [Serializable]
    [DataContract]
    public class Message
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public MessageTypeEnum Type { get; set; }

        [DataMember]
        public MessagePriorityEnum Priority { get; set; }
    }


    [Serializable]
    [DataContract]
    public enum MessageTypeEnum
    {
        /// <summary>
        /// Resultados de una acción correcta (p.ej. Inserción)
        /// </summary>
        [EnumMember]
        Report = 0,

        /// <summary>
        /// Errores de todo tipo
        /// </summary>
        [EnumMember]
        Error = 1,

        /// <summary>
        /// Advertencias
        /// </summary>
        [EnumMember]
        Alert = 2,

        /// <summary>
        /// Información adicional que no impide la consecución del proceso
        /// </summary>
        [EnumMember]
        Info = 3
    }

    [Serializable]
    [DataContract]
    public enum MessagePriorityEnum
    {

        [EnumMember]
        Hight = 0,

        [EnumMember]
        Medium = 1,

        [EnumMember]
        Low = 2
    }
}
