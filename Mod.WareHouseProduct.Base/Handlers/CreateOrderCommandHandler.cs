using Infrastructure.Interfaces;
using MediatR;
using Mod.WareHouseProduct.Base.Commands;
using Mod.WareHouseProduct.Interfaces;
using Mod.WareHouseProduct.Models;

namespace Mod.WareHouseProduct.Base.Handlers;

public class CreateWareHouseProductCommandHandler: IRequestHandler<CreateWareHouseProductCommand, WareHouseProductModel>
{
    private readonly IWareHouseProductRepository _WareHouseProductRepository;
    private readonly IRabbitMqProducer _rabbitMqProducer;
    public CreateWareHouseProductCommandHandler(IWareHouseProductRepository WareHouseProductRepository, IRabbitMqProducer rabbitMqProducer)
    {
        _WareHouseProductRepository = WareHouseProductRepository;
        _rabbitMqProducer = rabbitMqProducer;
    }

    public async Task<WareHouseProductModel> Handle(CreateWareHouseProductCommand request, CancellationToken cancellationToken)
    {
        return await _WareHouseProductRepository.AddAsync(request.WareHouseProduct);
        // _rabbitMqProducer.SendProductMessage();
    }
}