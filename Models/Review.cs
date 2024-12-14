using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class Review
{
    [Key]
    [Required]
    [DisplayName("Review Id")]
    [Length(32, 32)]
    public string Id { get; set; } = null!;

    [Required]
    [StringLength(255)]
    [DisplayName("Content")]
    public string Content { get; set; } = null!;

    [Required]
    [Range(0, 5)]
    [DisplayName("Rate")]
    public double Rate { get; set; }

    [Required]
    [DisplayName("Date")]
    public DateOnly Date { get; set; }

    [Required]
    [Length(32, 32)]
    [DisplayName("User Id")]
    public string UserId { get; set; } = null!;

    [Required]
    [Length(32, 32)]
    [DisplayName("Product Id")]
    public string ProductId { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}
