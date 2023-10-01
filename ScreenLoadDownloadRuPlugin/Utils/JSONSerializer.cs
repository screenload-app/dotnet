using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ScreenLoadDownloadRuPlugin.Utils
{
    /// <summary>
    /// A simple helper class for the DataContractJsonSerializer
    /// </summary>
    public static class JSONSerializer
    {
        /// <summary>
        /// Helper method to serialize object to JSON
        /// </summary>
        /// <param name="jsonObject">JSON object</param>
        /// <returns>string</returns>
        public static string Serialize(object jsonObject)
        {
            var serializer = new DataContractJsonSerializer(jsonObject.GetType());

            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, jsonObject);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        /// <summary>
        /// Helper method to parse JSON to object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string jsonString)
        {
            var deserializer = new DataContractJsonSerializer(typeof(T));

            using (var stream = new MemoryStream())
            {
                byte[] content = Encoding.UTF8.GetBytes(jsonString);
                stream.Write(content, 0, content.Length);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)deserializer.ReadObject(stream);
            }
        }
    }
}
