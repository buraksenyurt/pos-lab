using PosLab.Infrastructure.Contracts;
using PosLab.Network;

namespace PosLab.Implementation.SpaceY;
public class SpaceYApplication
    : IApplication
{
    public IDefinition Definition { get; private set; }
    public IRestChannel RestChannel { get; private set; }
    public string RootAddres { get; private set; }
    public List<IAction> Actions { get; private set; } = new List<IAction>();

    public SpaceYApplication(IRestChannel restChannel)
    {
        RestChannel = restChannel;
    }

    public IApplication AddAction(IAction action)
    {
        Actions.Add(action);
        return this;
    }

    public void RemoveAction(IAction action)
    {
        Actions.Remove(action);
    }

    public IApplication SetRootAddress(string rootAddress)
    {
        RootAddres = rootAddress;
        return this;
    }

    public async Task<IResponse> CallAction(IAction action, IRequest request)
    {
        return action.Call(RestChannel, request).Result;
    }

    public IApplication AddDefinition(IDefinition definition)
    {
        Definition = definition;
        return this;
    }
}
