using System;

namespace Egor92.XamlConverters.Cases
{
    public class RangeCase : ICase
    {
        #region Properties

        public double Min { get; set; }

        public double Max { get; set; }

        public bool IsMinStrictly { get; set; }

        public bool IsMaxStrictly { get; set; }

        #endregion

        #region Ctor

        public RangeCase()
        {
            Min = double.MinValue;
            Max = double.MaxValue;
        }

        #endregion

        public object Value { get; set; }

        public bool IsMatched(object value)
        {
            double @double;
            try
            {
                @double = Convert.ToDouble(value);
            }
            catch
            {
                return false;
            }

            return (IsMinStrictly && Min < @double || !IsMinStrictly && Min <= @double) &&
                   (IsMaxStrictly && Max > @double || !IsMaxStrictly && Max >= @double);
        }
    }
}
