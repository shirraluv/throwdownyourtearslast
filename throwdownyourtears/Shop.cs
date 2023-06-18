using System;
using System.Collections.Generic;

namespace throwdownyourtears;

public partial class Shop
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Iduser { get; set; }

    public virtual ICollection<Generalsale> Generalsales { get; } = new List<Generalsale>();

    public virtual ICollection<Historybuy> Historybuys { get; } = new List<Historybuy>();

    public virtual ICollection<Historysale> Historysales { get; } = new List<Historysale>();

    public virtual User IduserNavigation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual ICollection<Stat> Stats { get; } = new List<Stat>();
}
