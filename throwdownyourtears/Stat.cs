using System;
using System.Collections.Generic;

namespace throwdownyourtears;

public partial class Stat
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Quantity { get; set; }

    public int Gain { get; set; }

    public int Shopid { get; set; }

    public virtual Shop? Shop { get; set; }
}
