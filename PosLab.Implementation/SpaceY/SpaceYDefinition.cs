
using PosLab.Infrastructure.Contracts;

namespace PosLab.Implementation.SpaceY;
public class SpaceYDefinition
    : IDefinition
{
    public string Name => "SpaceYPaymentSystem";
    public string Description => "Space Y firmasının Androdi tabanlı pos uygulaması. Rest servis çağrıları ile yönetilir.";
    public string Company => "SpaceY";
}
