using System;
using System.Collections.Generic;

namespace SearchingOptimize.Models;

public partial class AccountType
{
    public Guid AccTypeId { get; set; }

    public string? AccType { get; set; }

    public decimal AccInterest { get; set; }
}
