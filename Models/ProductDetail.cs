using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models;

public partial class ProductDetail
{
    [Key]
    [Required]
    [Length(32, 32)]
    [DisplayName("Product Gallary")]
    public string Id { get; set; } = null!;

    [Required]
    [StringLength(255)]
    [DisplayName("Main image")]
    public string MainImg { get; set; } = null!;

    [Required]
    [StringLength(255)]
    [DisplayName("Detail image")]
    public string? DetailImg { get; set; }

    [Required]
    [StringLength(255)]
    [DisplayName("Back image")]
    public string? BackImg { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
