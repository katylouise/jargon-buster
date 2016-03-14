using System.Text;

namespace Parliament.Common.ContentReader
{
    public interface IUriContentReaderService
    {
        string Read(string location, Encoding encoding = null);
    }
}