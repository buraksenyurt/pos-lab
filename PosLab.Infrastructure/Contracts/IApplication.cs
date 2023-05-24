using PosLab.Network;

namespace PosLab.Infrastructure.Contracts;
public interface IApplication
{
    IDefinition Definition { get; }
    string RootAddres { get; }
    List<IAction> Actions { get; }
    IRestChannel RestChannel { get; }

    IApplication SetRootAddress(string rootAddress);
    IApplication AddAction(IAction action);
    IApplication AddDefinition(IDefinition definition);
    void RemoveAction(IAction action);
    Task<IResponse> CallAction(IAction action, IRequest request);
}
