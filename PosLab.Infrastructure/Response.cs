using PosLab.Infrastructure.Contracts;
using PosLab.Infrastructure.Enums;

namespace PosLab.Infrastructure;

public class Response
    : IResponse
{
    public MessageStatus Status { get; private set; }
    public Exception Exception { get; private set; }
    public string ExtraData { get; private set; }

    public Response(MessageStatus status, Exception excp, string extraData)
    {
        Status = status;
        Exception = excp;
        ExtraData = extraData;
    }
}