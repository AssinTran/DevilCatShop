using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class Product
{
    [Key]
    [Required]
    [Length(32, 32)]
    [DisplayName("Product Id")]
    public string Id { get; set; } = null!;

    [Required]
    [Length(32, 32)]
    [DisplayName("Category Id")]
    public string CategoryId { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [DisplayName("Product name")]
    public string Name { get; set; } = null!;

    [Required]
    [Range(0, int.MaxValue)]
    [DisplayName("Quantity")]
    public int Quantity { get; set; }

    [Required]
    [DisplayName("In stock")]
    [DefaultValue(true)]
    public bool InStock { get; set; }

    [Required]
    [StringLength(200)]
    [DisplayName("Image")]
    public string Image { get; set; } = null!;

    [Required]
    [DisplayName("Description")]
    public string Description { get; set; } = null!;

    [Required]
    [DisplayName("Price")]
    [Range(0, double.MaxValue)]
    public double Price { get; set; }

    [Required]
    [Length(32, 32)]
    [DisplayName("Product gallary")]
    public string ProductImg { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey(nameof(ProductImg))]
    public virtual ProductDetail ProductImgNavigation { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
