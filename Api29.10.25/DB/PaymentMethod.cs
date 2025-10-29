using System;
using System.Collections.Generic;

namespace Api29._10._25.DB;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
