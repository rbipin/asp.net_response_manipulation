using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Encodings;
using System.Text;
using System.IO;

namespace Serialize_in_action_filter.Serializer
{
    public sealed class XMLSerializer
    {
        private static readonly Lazy<XMLSerializer> lazyXmlSerializer =
            new Lazy<XMLSerializer>(() => new XMLSerializer());

        public static XMLSerializer Instance
        {
            get
            {
                return lazyXmlSerializer.Value;
            }
        }
        private XMLSerializer() {}

        public string Serialize(object objectToSerialize, XmlSerializerNamespaces xmlNamespaces)
        {
            var Serializer = new XmlSerializer(objectToSerialize.GetType()); 
            var serializerStream = new MemoryStream(); 
            Serializer.Serialize(serializerStream, objectToSerialize, xmlNamespaces); 
            serializerStream.Position = 0; 
            string serializedObject = Encoding.UTF8.GetString(serializerStream.GetBuffer()); 
            serializerStream.Close(); 
            serializedObject = serializedObject.Trim("\0".ToCharArray()); 
            return serializedObject;

        }
    }
}
