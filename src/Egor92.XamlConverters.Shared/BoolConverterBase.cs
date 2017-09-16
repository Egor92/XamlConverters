using System;
#if WPF
using Culture = System.Globalization.CultureInfo;

#elif WINDOWS_UWP
using Culture = System.String;

#endif

namespace Egor92.XamlConverters
{
    public abstract class BoolConverterBase<T> : ChainConverter<bool, T>
    {
        #region TrueValue

        private bool _isTrueValueInitialized;
        private T _trueValue;

        public T TrueValue
        {
            get
            {
                if (!_isTrueValueInitialized)
                {
                    _trueValue = GetDefaultTrueValue();
                    _isTrueValueInitialized = true;
                }
                return _trueValue;
            }
            set
            {
                _trueValue = value;
                _isTrueValueInitialized = true;
            }
        }

        protected virtual T GetDefaultTrueValue()
        {
            return default(T);
        }

        #endregion

        #region FalseValue

        private bool _isFalseValueInitialized;
        private T _falseValue;

        public T FalseValue
        {
            get
            {
                if (!_isFalseValueInitialized)
                {
                    _falseValue = GetDefaultFalseValue();
                    _isFalseValueInitialized = true;
                }
                return _falseValue;
            }
            set
            {
                _falseValue = value;
                _isFalseValueInitialized = true;
            }
        }

        protected virtual T GetDefaultFalseValue()
        {
            return default(T);
        }

        #endregion

        #region Overridden members

        protected sealed override T Convert(bool value, Type targetType, object parameter, Culture culture)
        {
            return ConvertFromBool(value);
        }

        protected sealed override bool ConvertBack(T value, Type targetType, object parameter, Culture culture)
        {
            return ConvertToBool(value);
        }

        #endregion

        private T ConvertFromBool(bool value)
        {
            return value
                ? TrueValue
                : FalseValue;
        }

        private bool ConvertToBool(T value)
        {
            return value.Equals(TrueValue);
        }
    }
}
