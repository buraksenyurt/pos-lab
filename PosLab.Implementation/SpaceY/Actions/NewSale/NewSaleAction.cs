using PosLab.Infrastructure;
using PosLab.Infrastructure.Contracts;
using PosLab.Infrastructure.Enums;
using PosLab.Network;

namespace PosLab.Implementation.SpaceY.Actions.DirectSales;
public class NewSaleAction
    : IAction
{
    public string Name { get; private set; }
    public string Description { get; private set; } 
    public CallType CallType { get; private set; }
    public string Endpoint { get; private set; } = string.Empty;

    public IAction AddCallType(CallType callType)
    {
        CallType = callType;
        return this;
    }

    public IAction AddDescription(string description)
    {
        Description = description;
        return this;
    }

    public IAction AddEndpoint(string endpoint)
    {
        Endpoint = endpoint;
        return this;
    }

    public IAction AddName(string name)
    {
        Name = name;
        return this;
    }

    public async Task<IResponse> Call(IRestChannel restChannel, IRequest request)
    {
        return new Response(MessageStatus.Success, null, null);
    }
}
