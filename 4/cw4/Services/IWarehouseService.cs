using cw4.Models.Dto;

namespace cw4.Services;

public interface IWarehouseService
{
    Task<int> FulfillOrderAsync(FulfillOrderDto command, CancellationToken cancellationToken);
}