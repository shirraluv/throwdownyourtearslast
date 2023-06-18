using System;
using System.Collections.Generic;

namespace throwdownyourtears;

public partial class Historysale
{
    public int Id { get; set; }

    public string? Productname { get; set; }

    public int Productquantity { get; set; }

    public int Gain { get; set; }

    public int Shopid { get; set; }

    public DateTime Date { get; set; }

    public virtual Shop? Shop { get; set; }
}
