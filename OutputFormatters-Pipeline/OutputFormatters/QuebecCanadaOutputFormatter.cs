using Microsoft.AspNetCore.Mvc.Formatters;
using System.Xml;
using System.Xml.Serialization;

namespace OutputFormatter.API
{
    public class QuebecCanadaOutputFormatter : XmlSerializerOutputFormatter
    {
        public QuebecCanadaOutputFormatter()
        {

        }
        public QuebecCanadaOutputFormatter(XmlWriterSettings xmlWriterSettings) : base(xmlWriterSettings)
        {

        }
        protected override void Serialize(XmlSerializer xmlSerializer, XmlWriter xmlWriter, object value)
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("WS", "http://www.qubeccanadaweatherstation.com/xml/namespaces/type");
            namespaces.Add("Metric", "http://www.qubeccanadaweatherstation.com/xml/namespaces/siunit/temperature");
            xmlSerializer.Serialize(xmlWriter, value, namespaces);
        }
    }
}
