using System;
using System.Collections.Generic;

namespace throwdownyourtears;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Shop> Shops { get; } = new List<Shop>();
}
