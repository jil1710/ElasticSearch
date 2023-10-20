using System;
using System.Collections.Generic;

namespace SearchingOptimize.Models;

public partial class TransactionHistory
{
    public Guid TranId { get; set; }

    public Guid? FromCusId { get; set; }

    public Guid? ToCusId { get; set; }

    public decimal Amount { get; set; }

    public string TansGateway { get; set; } = null!;

    public string TranMethod { get; set; } = null!;

    public string? TranDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? DeleteAt { get; set; }

}
