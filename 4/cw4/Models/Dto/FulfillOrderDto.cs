using System.ComponentModel.DataAnnotations;
 
namespace cw4.Models.Dto;

public class FulfillOrderDto
{
    [Required(ErrorMessage = "IdProduct is required.")]
    public int? IdProduct { get; set; }

    [Required(ErrorMessage = "IdWarehouse is required.")]
    public int? IdWarehouse { get; set; }

    [Required(ErrorMessage = "Amount is required")]
    [Range(1, int.MaxValue, ErrorMessage = "The amount must be greater than zero.")]
    public int? Amount { get; set; }

    [Required(ErrorMessage = "CreatedAt is required.")]
    public DateTime? CreatedAt { get; set; }
}
