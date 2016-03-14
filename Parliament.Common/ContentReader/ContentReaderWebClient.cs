using System;
using System.Net;

namespace Parliament.Common.ContentReader
{
    public class ContentWebClient : WebClient
    {
        public int Timeout { get; set; }

        public ContentWebClient(int timeout)
        {
            Timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request != null)
            {
                request.Timeout = Timeout;
            }
            return request;
        }
    }
}