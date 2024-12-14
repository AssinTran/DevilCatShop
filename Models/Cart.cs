using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class Cart
{
    [Key]
    [Required]
    [Length(32,32)]
    [DisplayName("Cart Id")]
    public string Id { get; set; } = null!;

    [Required]
    [Length(32,32)]
    [DisplayName("User Id")]
    public string UserId { get; set; } = null!;

    [Required]
    [Length(32,32)]
    [DisplayName("Product Id")]
    public string ProductId { get; set; } = null!;

    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}
