using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        public MyRangeAttribute()
        {
            this.minValue = 12;
            this.maxValue = 90;
        }
        public override bool IsValid(object obj)
        {
            int number = (int)obj;

            if (number >= minValue && number <= maxValue)
            {
                return true;
            }

            return false;
        }
    }
}
