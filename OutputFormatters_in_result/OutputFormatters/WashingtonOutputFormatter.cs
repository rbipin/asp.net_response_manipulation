using Microsoft.AspNetCore.Mvc.Formatters;
using System.Xml;
using System.Xml.Serialization;

namespace OutputFormatter.API.OutputFormatter
{
    public class WashingtonOutputFormatter : XmlSerializerOutputFormatter
    {
        public WashingtonOutputFormatter()
        {

        }
        public WashingtonOutputFormatter(XmlWriterSettings xmlWriterSettings) : base(xmlWriterSettings)
        {

        }
        protected override void Serialize(XmlSerializer xmlSerializer, XmlWriter xmlWriter, object value)
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("WS", "http://www.wausweatherStation.com/xml/namespaces/type");
            namespaces.Add("Metric", "http://www.wausweatherstation.com/xml/namespaces/siunit/temperature");
            xmlSerializer.Serialize(xmlWriter, value, namespaces);
        }

    }
}
