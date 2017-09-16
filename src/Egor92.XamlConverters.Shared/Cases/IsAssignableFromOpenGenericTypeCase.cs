using System;
using System.Windows.Markup;

namespace Egor92.XamlConverters.Cases
{
    [ContentProperty("Value")]
    public abstract class IsAssignableFromOpenGenericTypeCase : ICase
    {
        public object Value { get; set; }

        public bool IsMatched(object item)
        {
            if (item == null)
                return false;

            var itemType = item.GetType();

            var openGenericType = GetOpenGenericType();
            return IsSubclassOfRawGeneric(openGenericType, itemType);
        }

        protected abstract Type GetOpenGenericType();

        private static bool IsSubclassOfRawGeneric(Type openGenericType, Type itemType)
        {
            while (itemType != null && itemType != typeof(object))
            {
                var cur = itemType.IsGenericType
                    ? itemType.GetGenericTypeDefinition()
                    : itemType;

                if (openGenericType == cur)
                    return true;

                itemType = itemType.BaseType;
            }

            return false;
        }
    }
}
