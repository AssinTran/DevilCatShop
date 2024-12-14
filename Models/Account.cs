using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class Account
{
    [Key]
    [Required]
    [Length(10, 10)]
    [DisplayName("Phone number")]
    public string Phonenumber { get; set; } = null!;

    [Required]
    [Length(8, 32)]
    [DisplayName("Password")]
    public string Password { get; set; } = null!;

    [NotMapped]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = null!;

    [Required]
    [DisplayName("Role Id")]
    public int RoleId { get; set; }

    [Required]
    [DefaultValue(false)]
    public bool Active { get; set; }

    [Required]
    [DefaultValue(true)]
    public bool Status { get; set; }

    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { get; set; } = null!;

    public virtual User? User { get; set; }
}
