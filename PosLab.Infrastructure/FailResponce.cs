namespace PosLab.Infrastructure;
public class FailResponse
    : Response
{
    public FailResponse()
        : base(MessageStatus.Fail, null, string.Empty)
    {
    }
}