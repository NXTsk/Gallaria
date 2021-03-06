using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Gallaria.API.Converters
{
    public static class ConverterExtensionMethods
    {
        /*
         * Converter from DTO to DTO
         */
        public static T CopyPropertiesTo<T>(this object sourceObject, T destinationObject)
        {
            foreach (PropertyInfo destinationProperty in destinationObject.GetType().GetProperties().Where(p => p.CanWrite))
            {
                if (!sourceObject.GetType().GetProperties().Any(sourceProp => sourceProp.Name == destinationProperty.Name && sourceProp.PropertyType == destinationProperty.PropertyType)) continue;
                var sourceProp = sourceObject.GetType().GetProperty(destinationProperty.Name);
                destinationProperty.SetValue(destinationObject, sourceProp.GetValue(sourceObject, null), null);
            }
            return destinationObject;
        }
    }
}
