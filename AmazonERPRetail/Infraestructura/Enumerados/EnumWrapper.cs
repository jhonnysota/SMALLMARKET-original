namespace Infraestructura.Enumerados
{
    public class EnumWrapper<TEnum> where TEnum : struct
    {
        private TEnum enumType;

        public int Value
        {

            get { return (int)(object)enumType; }

            set { enumType = (TEnum)(object)value; }

        }

        public TEnum EnumValue
        {

            get { return enumType; }

            set { enumType = value; }

        }

        public static implicit operator EnumWrapper<TEnum>(TEnum enumerate)
        {

            return new EnumWrapper<TEnum> { EnumValue = enumerate };

        }

        public static implicit operator TEnum(EnumWrapper<TEnum> enumType)
        {
            if (enumType == null) return default(TEnum);

            return enumType.EnumValue;
        }
    }


}
