using System;
using System.Collections.Generic;

namespace number1.Models;

public partial class UserCard
{
    public int UserId { get; set; }

    public int CardId { get; set; }

    public int? OwnQuantity { get; set; }

    public virtual CardInfo Card { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
