using System;
using System.Text;
using Parliament.Common.ContentReader.Settings;
using Parliament.Common.Extensions;
using Parliament.Common.Interfaces;

namespace Parliament.Common.ContentReader
{
    using System.Net;

    public class UriContentReaderService : IUriContentReaderService
    {
        private const string _invalidUri = "The supplied uri of '{0}' is not valid";
        private readonly ContentReaderSettings _settings;

        public string ReturnCode { get; set; }
        public UriContentReaderService(IConfigurationBuilder configurationBuilder)
        {
            _settings = configurationBuilder.GetConfiguration<ContentReaderSettings>();
        }

        public string Read(string location, Encoding encoding = null)
        {
            try
            {
                var timeout = (_settings.MaxRequestTimeoutSeconds ?? 30) * 1000;
                using (var client = new ContentWebClient(timeout))
                {
                    client.Encoding = encoding ?? Encoding.UTF8;
                    return client.DownloadString(new Uri(location));
                }
            }
            catch (UriFormatException ex)
            {
                throw new UriFormatException(_invalidUri.FormatString(location), ex);
            }
            catch (WebException we)
            {
                var response = (HttpWebResponse)we.Response;
                var statusCode = response.StatusCode;
                throw new WebException("Error occured: " + statusCode);
            }
        }
    }
}