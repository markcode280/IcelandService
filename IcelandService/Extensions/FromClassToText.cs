using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace IcelandService.Extensions
{
    public static class FromClassToText
    {
        public static List<string> ConvertPropertyToStringObj<T>(this T item) where T : new()
        {
            var stringToWrite = new List<string>();
            var t = new T();
            t = item;
            foreach (var prop in t.GetType().GetProperties())
            {
                stringToWrite.Add(prop.Name + ": " + prop.GetValue(t));

            }
            return stringToWrite;
        }

    }
}
