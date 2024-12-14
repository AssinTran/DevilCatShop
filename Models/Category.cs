using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models;

public partial class Category
{
    [Key]
    [Required]
    [Length(32,32)]
    [DisplayName("Category Id")]
    public string Id { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [DisplayName("Category Name")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
