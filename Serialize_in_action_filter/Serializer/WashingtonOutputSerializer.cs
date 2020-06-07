using System;
using System.Xml.Serialization;

namespace OutputFormatter.API.Serializer
{
    public class WashingtonOutputSerializer
    {
        public static readonly Lazy<WashingtonOutputSerializer> lazyWashingtonSerializer =
            new Lazy<WashingtonOutputSerializer>(() => new WashingtonOutputSerializer());
        public static WashingtonOutputSerializer Instance
        {
            get { return lazyWashingtonSerializer.Value; }
        }
        private WashingtonOutputSerializer() { }
        public string Serialize(object outputObject)
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("WS", "http://www.wausweatherStation.com/xml/namespaces/type");
            namespaces.Add("Metric", "http://www.wausweatherstation.com/xml/namespaces/siunit/temperature");
            return XMLSerializer.Instance.Serialize(outputObject, namespaces);
        }
    }
}
