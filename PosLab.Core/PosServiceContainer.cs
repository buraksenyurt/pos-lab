using PosLab.Implementation.SpaceY;
using PosLab.Implementation.SpaceY.Actions.CancelSale;
using PosLab.Implementation.SpaceY.Actions.DirectSales;
using PosLab.Infrastructure;
using PosLab.Network;

namespace PosLab.Core
{
    public class PosServiceContainer
    {
        public PosService PosService { get; private set; } = new PosService();
        public PosServiceContainer()
        {
            var rootAddress = "http://localhost:5001/api";

            var newSaleAction = new NewSaleAction()
                .AddName("NewSale")
                .AddDescription("Yeni ürün satışı")
                .AddEndpoint($"{rootAddress}/sales")
                .AddCallType(CallType.Post);

            var cancelAction = new CancelSaleAction()
                .AddName("CancelSale")
                .AddDescription("Satış iptali")
                .AddEndpoint($"{rootAddress}/sales/cancel")
                .AddCallType(CallType.Post);

            var spaceYPos = new SpaceYApplication(new RestChannel());
            spaceYPos
                .SetRootAddress(rootAddress)
                .AddDefinition(new SpaceYDefinition())
                .AddAction(newSaleAction)
                .AddAction(cancelAction);

            PosService.AddApplication(spaceYPos);
        }
    }
}
