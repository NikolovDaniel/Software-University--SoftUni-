﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {

            PropertyInfo[] properties = obj.GetType()
                .GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute customAttribute = (MyValidationAttribute)property.GetCustomAttribute(typeof(MyValidationAttribute), false);

                bool isValid = customAttribute.IsValid(property.GetValue(obj));

                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
