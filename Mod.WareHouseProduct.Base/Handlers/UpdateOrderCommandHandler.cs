using MediatR;
using Mod.WareHouseProduct.Base.Commands;
using Mod.WareHouseProduct.Interfaces;
using Mod.WareHouseProduct.Models;

namespace Mod.WareHouseProduct.Base.Handlers;

public class UpdateWareHouseProductCommandHandler: IRequestHandler<UpdateWareHouseProductCommand, WareHouseProductModel>
{
    private readonly IWareHouseProductRepository _WareHouseProductRepository;
    
    public UpdateWareHouseProductCommandHandler(IWareHouseProductRepository WareHouseProductRepository) => _WareHouseProductRepository = WareHouseProductRepository;

    public async Task<WareHouseProductModel> Handle(UpdateWareHouseProductCommand request, CancellationToken cancellationToken)
    {
        return await _WareHouseProductRepository.UpdateAsync(request.WareHouseProduct);
    }
}