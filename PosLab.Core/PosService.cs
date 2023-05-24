using PosLab.Implementation;
using PosLab.Infrastructure;
using PosLab.Infrastructure.Contracts;

namespace PosLab.Core;
public class PosService
{
    private readonly List<IApplication> _applications;
    public PosService()
    {
        _applications = new List<IApplication>();
    }

    public void AddApplication(IApplication application)
    {
        _applications.Add(application);
    }

    public IResponse Call(AppName appName, string actionName, IRequest request)
    {
        var app = _applications.FirstOrDefault(a => a.Definition.Name == appName.ToString());
        if (app == null)
        {
            return new FailResponse();
        }
        var action = app.Actions.FirstOrDefault(act => act.Name == actionName);
        if (action == null)
        {
            return new FailResponse();
        }
        var response = app.CallAction(action, request);
        return response.Result;
    }
}

