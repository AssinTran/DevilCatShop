using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class Message
{
    [Key]
    [Required]
    [Length(32, 32)]
    [DisplayName("Message Id")]
    public string Id { get; set; } = null!;

    [Required]
    [StringLength(255)]
    [DisplayName("Message")]
    public string Content { get; set; } = null!;

    [Required]
    [Length(32, 32)]
    [DisplayName("Conversation Id")]
    public string Conversation { get; set; } = null!;

    [Required]
    [DisplayName("Time")]
    public DateTime Date { get; set; }

    [ForeignKey(nameof(Conversation))]
    public virtual Conversation ConversationNavigation { get; set; } = null!;
}
