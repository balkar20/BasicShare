using MediatR;
using Mod.WareHouseProduct.Base.Queries;
using Mod.WareHouseProduct.Interfaces;
using Mod.WareHouseProduct.Models;

namespace Mod.WareHouseProduct.Base.Handlers;

public class GetAllWareHouseProductsQueryHandler: IRequestHandler<GetAllWareHouseProductsQuery, List<WareHouseProductModel>>
{
    private readonly IWareHouseProductRepository _WareHouseProductRepository;
    private readonly IWareHouseProductService _WareHouseProductService;

    public GetAllWareHouseProductsQueryHandler(IWareHouseProductRepository WareHouseProductRepository, IWareHouseProductService WareHouseProductService)
    {
        _WareHouseProductRepository = WareHouseProductRepository;
        _WareHouseProductService = WareHouseProductService;
    }
    
    public async Task<List<WareHouseProductModel>> Handle(GetAllWareHouseProductsQuery request, CancellationToken cancellationToken)
    {
        return await _WareHouseProductService.GetAllWareHouseProducts();
    }
}