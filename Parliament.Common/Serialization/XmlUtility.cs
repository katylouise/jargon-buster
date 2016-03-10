using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace Parliament.Common.Serialization
{
    public class XmlUtility
    {
        public static string XSLTransformDocumentWithParams(string xml, string xslPath, XsltArgumentList args)
        {
            try
            {
                var xmlStringWriter = new StringWriter();
                var xmlDoc = new XmlDocument();
                var xsl = new XslCompiledTransform(true);

                xmlDoc.LoadXml(XmlClean(xml));
                xsl.Load(xslPath);
                xsl.Transform(new XmlNodeReader(xmlDoc), args, xmlStringWriter);

                return xmlStringWriter.ToString();
            }
            catch (XmlException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Error in XSLTransformDocumentWithParams", e);
            }
        }

        public static XmlCDataSection CreateCDataField(string content)
        {
            var document = new XmlDocument();
            return document.CreateCDataSection(content);
        }

        public static string XSLTransformDocumentWithParams(XmlDocument xmlDoc, string xslPath, XsltArgumentList args)
        {
            try
            {
                using (var xmlStringWriter = new StringWriter())
                {
                    var xsl = new XslCompiledTransform();
                    xsl.Load(xslPath);
                    xsl.Transform(xmlDoc, args, xmlStringWriter);

                    return xmlStringWriter.ToString();
                }             
            }
            catch (XmlException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Error in XSLTransformDocumentWithParams", e);
            }
        }

        public static string XmlClean(string xml)
        {
            xml = xml.Replace("&amp;#", "&#");
            xml = xml.Replace("/&/g", "&#38;");
            xml = xml.Replace("'", "&#39;");
            xml = xml.Replace("£", "&pound;");
            return xml;
        }

        public static string SerializeDataObject<T>(T source, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            using (var stream = new MemoryStream())
            using (TextWriter writer = new StreamWriter(stream, encoding))
            {
                var serializer = new XmlSerializer(typeof(T));
                var utf8 = encoding;

                serializer.Serialize(writer, source);
                var count = (int)stream.Length;
                var arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);

                return utf8.GetString(arr).Trim();
            }
        }

        public static bool CanDeserialize<T>(string sourceXml, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            var serializer = new XmlSerializer(typeof(T));
            using (XmlReader reader = new XmlTextReader(new MemoryStream(encoding.GetBytes(sourceXml))))
            {
                var canDeserialize = serializer.CanDeserialize(reader);
                reader.Close();
                return canDeserialize;
            }
        }

        public static T DeserializeXml<T>(string sourceXml, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            var serializer = new XmlSerializer(typeof(T));
            using (XmlReader reader = new XmlTextReader(new MemoryStream(encoding.GetBytes(sourceXml))))
            {
                var source = (T)serializer.Deserialize(reader);
                reader.Close();
                return source;
            }
        }

        public static string ReadToString(string xmlLocation)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlLocation);
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = new XmlTextWriter(stringWriter))
            {
                xmlDocument.WriteTo(xmlTextWriter);
                return xmlDocument.ToString();
            }
        }
    }
}
