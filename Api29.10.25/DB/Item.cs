using System;
using System.Collections.Generic;

namespace Api29._10._25.DB;

public partial class Item
{
    public int Count { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
