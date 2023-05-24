namespace PosLab.Infrastructure.Contracts;
public interface IResponse
{
    MessageStatus Status { get; }
    Exception Exception { get; }
    string ExtraData { get; }
}