using System.Data.SqlClient;
using cw4.Models;
using Microsoft.AspNetCore.Server.Kestrel;

namespace cw4.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IConfiguration _configuration;

    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Product?> GetProductAsync(int idProduct, CancellationToken cancellationToken)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        var command = new SqlCommand
        {
            Connection = connection,
            CommandText = "SELECT COUNT(*) FROM Product WHERE IdProduct = @IdProduct"
        };
        command.Parameters.AddWithValue("@IdProduct", idProduct);
        var dr = await command.ExecuteReaderAsync(cancellationToken);

        Product? product = null;
        while (await dr.ReadAsync(cancellationToken))
        {
            
        }

    }

}