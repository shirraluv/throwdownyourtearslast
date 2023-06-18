using System;
using System.Collections.Generic;

namespace throwdownyourtears;

public partial class Generalsale
{
    public int Id { get; set; }

    public int? Generalgain { get; set; }

    public int? Generalgain2 { get; set; }

    public int? Generalbuys { get; set; }

    public int? Generalquantity { get; set; }

    public int? Shopid { get; set; }

    public virtual Shop? Shop { get; set; }
}
