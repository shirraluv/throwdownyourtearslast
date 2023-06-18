using System;
using System.Collections.Generic;

namespace throwdownyourtears;

public partial class Provider
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Telegram { get; set; }

    public int Productid { get; set; }

    public virtual Product Product { get; set; } = null!;
}
