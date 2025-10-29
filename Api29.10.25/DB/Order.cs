using System;
using System.Collections.Generic;

namespace Api29._10._25.DB;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ShippingAddressId { get; set; }

    public int PaymentMethodId { get; set; }

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual ShippingAddress ShippingAddress { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
