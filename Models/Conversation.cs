using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class Conversation
{
    [Key]
    [Required]
    [Length(32,32)]
    [DisplayName("Conversation Id")]
    public string Id { get; set; } = null!;

    [Required]
    [Length(32,32)]
    [DisplayName("Sender Id")]
    public string Sender { get; set; } = null!;

    [Required]
    [Length(32,32)]
    [DisplayName("Recevier Id")]
    public string Receiver { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    [ForeignKey(nameof(Receiver))]
    public virtual User ReceiverNavigation { get; set; } = null!;

    [ForeignKey(nameof(Sender))]
    public virtual User SenderNavigation { get; set; } = null!;
}
