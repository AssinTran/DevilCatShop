using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class User
{
    [Key]
    [Required]
    [Length(32, 32)]
    [DisplayName("User Id")]
    public string Id { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [DisplayName("First name")]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [DisplayName("Last name")]
    public string LastName { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [DisplayName("Email")]
    public string Email { get; set; } = null!;

    [Required]
    [DisplayName("Date of birth")]
    public DateOnly Birth { get; set; }

    [Required]
    [StringLength(150)]
    [DisplayName("Address")]
    public string Address { get; set; } = null!;

    [StringLength(100)]
    [DisplayName("Avatar")]
    public string? Avatar { get; set; }

    [Required]
    [StringLength(10)]
    [DisplayName("Phone number")]
    public string Phone { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Conversation> ConversationReceiverNavigations { get; set; } = new List<Conversation>();

    public virtual ICollection<Conversation> ConversationSenderNavigations { get; set; } = new List<Conversation>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey(nameof(Phone))]
    public virtual Account UAccount { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
