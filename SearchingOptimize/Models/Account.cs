using System;
using System.Collections.Generic;

namespace SearchingOptimize.Models;

public partial class Account
{
    public Guid AccId { get; set; }

    public decimal AccBalance { get; set; }

    public string AccStatus { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? DeleteAt { get; set; }

}
