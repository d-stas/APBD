
using cw4.Repositories;

namespace cw4.Services;

public class WarehouseService : IWarehouseService
{
    private readonly IConfiguration _configuration;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IWarehouseRepository _warehouseRepository;


    public WarehouseService(IOrderRepository orderRepository, IProductRepository productRepository,
        IWarehouseRepository warehouseRepository, IConfiguration configuration)
    {
        _configuration = configuration;
    }

}