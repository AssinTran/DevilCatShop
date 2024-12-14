using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class Order
{
    [Key]
    [Required]
    [DisplayName("Order Id")]
    [Length(32, 32)]
    public string Id { get; set; } = null!;

    [Required]
    [DisplayName("User Id")]
    [Length(32, 32)]
    public string UserId { get; set; } = null!;

    [Required]
    [DisplayName("Product Id")]
    [Length(32, 32)]
    public string ProductId { get; set; } = null!;

    [Required]
    [DisplayName("Quantity")]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    [DisplayName("Price")]
    [Range(0, double.MaxValue)]
    public double Price { get; set; }

    [Required]
    [DisplayName("Date")]
    public DateOnly Date { get; set; }

    [Required]
    [StringLength(150)]
    [DisplayName("Status")]
    [DefaultValue("processing")]
    public string Status { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}
