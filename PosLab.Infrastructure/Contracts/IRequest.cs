using PosLab.Infrastructure.Enums;

namespace PosLab.Infrastructure.Contracts;
public interface IRequest
{
    ContentType ContentType { get; }
    string Data { get; }
}
