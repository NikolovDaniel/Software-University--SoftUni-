using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    class Tracker
    {
        public void PrintMethodsByAuthors()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance
                                        | BindingFlags.Public
                                        | BindingFlags.Static);
            foreach (var methodInfo in methods)
            {
                if (methodInfo.CustomAttributes
                    .Any(n => n.AttributeType
                    == typeof(AuthorAttribute)))
                {
                    var attrs = methodInfo.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attrs)
                    {
                        Console.WriteLine($"{methodInfo.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}
