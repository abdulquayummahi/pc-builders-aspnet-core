using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public int Stock { get; set; }

    public int Price { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
