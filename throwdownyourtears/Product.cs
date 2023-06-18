using System;
using System.Collections.Generic;

namespace throwdownyourtears;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int Quantity { get; set; }

    public int PurchasePrice { get; set; }

    public int Productsales { get; set; }

    public int Productgain { get; set; }

    public string Minimum { get; set; } = null!;

    public int Productbuys { get; set; }

    public int Productgain2 { get; set; }

    public int Shopid { get; set; }

    public virtual ICollection<Provider> Providers { get; } = new List<Provider>();

    public virtual Shop Shop { get; set; } = null!;
}
