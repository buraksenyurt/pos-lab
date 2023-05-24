using PosLab.Infrastructure.Contracts;

namespace PosLab.Infrastructure;
public class Request
    : IRequest
{
    public ContentType ContentType { get; private set; }
    public string Data { get; private set; }

    public Request(string data, ContentType contentType)
    {
        Data = data;
        ContentType = contentType;
    }
}
