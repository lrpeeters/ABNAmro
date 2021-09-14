using System;

namespace ABNAmro.CrossCutting.Extensions
{
    public static class ObjectExtensions
    {
        public static TValue NullCheck<TValue>(this TValue value, string checkedField)
        {
            return value ?? throw new ArgumentNullException(checkedField);
        }
    }
}
