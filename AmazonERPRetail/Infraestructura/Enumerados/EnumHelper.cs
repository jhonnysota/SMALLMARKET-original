using System;
using System.Collections.Generic;
using System.Reflection;

namespace Infraestructura.Enumerados
{
    #region Class EnumHelper
    /// <summary>
    /// Helper de enumerados
    /// </summary>
    public class EnumHelper
    {

        /// <summary>
        /// Retorna un diccionario con los valores y literales del enumerado.
        /// </summary>
        /// <returns>Diccionario</returns>
        public static Dictionary<byte, string> GetLiteralValues<TEnum>() where TEnum : struct
        {
            Type enumType = typeof(TEnum);
            if (!enumType.IsEnum)
                throw new ArgumentException(String.Format("El tipo debe ser un Enumerado.  El tipo pasado fue {0}", enumType));

            Dictionary<byte, string> values = new Dictionary<byte, string>();

            foreach (FieldInfo fi in enumType.GetFields())
            {
                LiteralValueAttribute[] attrs = fi.GetCustomAttributes(typeof(LiteralValueAttribute), false) as LiteralValueAttribute[];
                if (attrs != null && attrs.Length > 0)
                    values.Add((byte)Enum.Parse(enumType, fi.Name), attrs[0].Value);
                else if (!fi.IsSpecialName)
                {
                    values.Add((byte)Enum.Parse(enumType, fi.Name), fi.Name);
                }
            }
            return values;
        }

        /// <summary>
        /// Retorna el valor literal de un enumerado específico.
        /// </summary>
        /// <param name="value">Enumerado</param>
        /// <returns>Valor literal</returns>
        public static string GetLiteralValue<TEnum>(TEnum value) where TEnum : struct
        {
            string output;
            Type enumType = value.GetType();

            FieldInfo fi = enumType.GetField(value.ToString());
            LiteralValueAttribute[] attrs = fi.GetCustomAttributes(typeof(LiteralValueAttribute), false) as LiteralValueAttribute[];
            if (attrs != null && attrs.Length > 0)
            {
                output = attrs[0].Value;
            }
            else
            {
                output = value.ToString();
            }

            return output;
        }

        /// <summary>
        /// Retorna el tipo de fichero del enumerado TE_CODVALIDACION_SPEE.
        /// </summary>
        /// <param name="value">Enumerado</param>
        /// <returns>Valor literal</returns>
        public static string GetAdicionalInfo<TEnum>(TEnum value) where TEnum : struct
        {
            object output;
            Type enumType = value.GetType();

            FieldInfo fi = enumType.GetField(value.ToString());
            AdicionalInfoEnumAttribute[] attrs = fi.GetCustomAttributes(typeof(AdicionalInfoEnumAttribute), false) as AdicionalInfoEnumAttribute[];
            if (attrs != null && attrs.Length > 0)
            {
                output = attrs[0].Value;
            }
            else
            {
                throw new Exception("No se pudo recuperar la información del enumerado");
            }

            return output.ToString();
        }

        /// <summary>
        /// Convierte un valor literal en su correspondiente enumerado.
        /// </summary>
        /// <param name="literalValue">Literal value.</param>
        /// <param name="ignoreCase">No distinguir entre mayúsculas y minusculas</param>
        /// <returns>Enumerado asociado con el valor literal.</returns>
        public static TEnum ParseLiteral<TEnum>(string literalValue, bool ignoreCase = true) where TEnum : struct
        {
            object output = null;
            Type enumType = typeof(TEnum);
            string enumStringValue = null;
            try
            {

                if (!enumType.IsEnum)
                    throw new ArgumentException(String.Format("El tipo debe ser un Enumerado.  El tipo pasado fue {0}", enumType));

                foreach (FieldInfo fi in enumType.GetFields())
                {
                    LiteralValueAttribute[] attrs = fi.GetCustomAttributes(typeof(LiteralValueAttribute), false) as LiteralValueAttribute[];

                    if (attrs != null && attrs.Length > 0)
                        enumStringValue = attrs[0].Value;

                    if (string.Compare(enumStringValue, literalValue, ignoreCase) == 0)
                    {
                        output = Enum.Parse(enumType, fi.Name);
                        break;
                    }
                }

                if (output == null)
                {
                    throw new Exception("El enumerado de salida es null");
                }

                return (TEnum)output;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("No se pudo convertir el valor literal '{0}' en un enumerado de tipo {1}", literalValue, enumType.Name), ex);
            }
        }

        /// <summary>
        /// Convierte un valor string en su correspondiente enumerado.
        /// </summary>
        /// <param name="stringValue">String value.</param>
        /// <param name="ignoreCase">No distinguir entre mayúsculas y minusculas</param>
        /// <returns>Enumerado asociado con el valor string.</returns>
        public static object Parse<TEnum>(string stringValue, bool ignoreCase = true) where TEnum : struct
        {
            Type enumType = typeof(TEnum);

            if (!enumType.IsEnum)
                throw new ArgumentException(String.Format("El tipo debe ser un Enumerado.  El tipo pasado fue {0}", enumType));

            object output = Enum.Parse(enumType, stringValue, ignoreCase);

            return output;
        }

        public static string RecuperarTexto<TEnum>(int valorNumerico) where TEnum : struct
        {
            return Enum.GetName(typeof(TEnum), valorNumerico);
        }
    }

    #endregion

    #region Class LiteralValueAttribute

    /// <summary>
    /// Atributo para almacenar los valores literales de un enumerado.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class LiteralValueAttribute : Attribute
    {
        private readonly string _value;

        public LiteralValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }


    #endregion

    #region Class AdicionalInfoEnumAttribute
    /// <summary>
    /// Atributo para almacenar los valores literales de un enumerado.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class AdicionalInfoEnumAttribute : Attribute
    {
        private readonly object _value;

        public AdicionalInfoEnumAttribute(object value)
        {
            _value = value;
        }

        public object Value
        {
            get { return _value; }
        }
    }


    #endregion

}
