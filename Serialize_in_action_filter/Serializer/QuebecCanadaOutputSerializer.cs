using System;
using System.Xml.Serialization;

namespace OutputFormatter.API.Serializer
{
    public class QuebecCanadaOutputSerializer
    {
        public static readonly Lazy<QuebecCanadaOutputSerializer> lazyQuebecOutputSerializer =
            new Lazy<QuebecCanadaOutputSerializer>(() => new QuebecCanadaOutputSerializer());
        public static QuebecCanadaOutputSerializer Instance
        {
            get { return lazyQuebecOutputSerializer.Value; }
        }
        private QuebecCanadaOutputSerializer() { }
        public string Serialize(object outputObject)
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("WS", "http://www.qubeccanadaweatherstation.com/xml/namespaces/type");
            namespaces.Add("Metric", "http://www.qubeccanadaweatherstation.com/xml/namespaces/siunit/temperature");
            return XMLSerializer.Instance.Serialize(outputObject, namespaces);
        }
    }
}
