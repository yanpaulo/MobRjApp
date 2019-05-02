using System;
using System.Collections.Generic;
using System.Text;

namespace MobRjApp.Extensions
{
    /// <summary>
    /// Extension methods for the Object class.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Assigns this object's property values to o2's properties having the same name.
        /// </summary>
        /// <param name="o2">Object to which values will be copied to.</param>
        public static void CopyTo(this object o1, object o2)
        {
            foreach (var prop1 in o1.GetType().GetProperties())
            {
                var prop2 = o2.GetType().GetProperty(prop1.Name);
                prop2?.SetValue(o2, prop1.GetValue(o1));
            }
        }
    }
}
