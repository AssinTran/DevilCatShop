using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models;

public partial class Role
{
    [Key]
    [Required]
    [DisplayName("Role Id")]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    [DisplayName("Role name")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
