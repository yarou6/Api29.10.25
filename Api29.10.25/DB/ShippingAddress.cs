using System;
using System.Collections.Generic;

namespace Api29._10._25.DB;

public partial class ShippingAddress
{
    public int Id { get; set; }

    public string House { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public int PostalCode { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
