using PosLab.Network;

namespace PosLab.Infrastructure.Contracts;
public interface IAction
{
    string Name { get; }
    string Description { get; }
    string Endpoint { get; }
    CallType CallType { get; }

    IAction AddName(string name);
    IAction AddDescription(string description);
    IAction AddCallType(CallType callType);
    IAction AddEndpoint(string endpoint);
    Task<IResponse> Call(IRestChannel restChannel, IRequest request);
}
