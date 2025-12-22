using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class BaseShippingPartnerUtilities
    {

        /// <summary>
        /// Convert từ object sang dictionary từ các property có JsonPropertyAttribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dictionary<string, object> ToDictionaryFromJsonProperties<T>(T obj)
        {
            var dictionary = new Dictionary<string, object>();
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (property.GetValue(obj) != null)
                {
                    var jsonProperty = property.GetCustomAttribute<JsonPropertyAttribute>();
                    var name = property.Name;
                    if (jsonProperty != null)
                    {
                        name = jsonProperty.PropertyName;
                    }
                    var value = property.GetValue(obj);
                    // serialize and deserialize to remove reference and keep jsonProperty name
                    dictionary.Add(name, JsonConvert.DeserializeObject(JsonConvert.SerializeObject(value)));
                }
            }

            return dictionary;
        }
        /// <summary>
        /// Convert từ object sang dictionary string từ các property có JsonPropertyAttribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dictionary<string, string> ToDictionaryStringFromJsonProperties<T>(T obj)
        {
            var dictionary = new Dictionary<string, string>();
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (property.GetValue(obj) != null)
                {
                    var jsonProperty = property.GetCustomAttribute<JsonPropertyAttribute>();
                    var name = property.Name;
                    if (jsonProperty != null)
                    {
                        name = jsonProperty.PropertyName;
                    }
                    var value = property.GetValue(obj);
                    // serialize and deserialize to remove reference and keep jsonProperty name
                    dictionary.Add(name, JsonConvert.SerializeObject(value));
                }
            }

            return dictionary;
        }
    }
}