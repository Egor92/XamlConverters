using System;

namespace Egor92.XamlConverters.Cases
{
    public class TypeCase : ICase
    {
        public Type Type { get; set; }

        public bool IsStrictly { get; set; }

        public object Value { get; set; }

        public bool IsMatched(object value)
        {
            if (Type == null || value == null)
                return false;

            if (IsStrictly)
            {
                return Type == value.GetType();
            }

            return Type.IsInstanceOfType(value);
        }
    }
}
