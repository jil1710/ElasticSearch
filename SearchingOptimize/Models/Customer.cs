using System;
using System.Collections.Generic;

namespace SearchingOptimize.Models;

public partial class Customer
{
    public Guid CusId { get; set; }

    public string CusName { get; set; } = null!;

    public string CusCity { get; set; } = null!;

    public string CusPhone { get; set; } = null!;

    public string CusPan { get; set; } = null!;

    public virtual Account Account { get; set; }

    public virtual AccountType AccountType { get; set; }    

    public virtual ICollection<TransactionHistory> TransactionHistory { get; set; } = new List<TransactionHistory>();       

    public DateTime? CreatedAt { get; set; }

    public DateTime? DeleteAt { get; set; }


}
