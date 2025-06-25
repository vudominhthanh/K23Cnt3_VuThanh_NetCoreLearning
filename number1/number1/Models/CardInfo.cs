using System;
using System.Collections.Generic;

namespace number1.Models;

public partial class CardInfo
{
    public int CardId { get; set; }

    public string? NameCard { get; set; }

    public string? CardImage { get; set; }

    public double? Rate { get; set; }

    public int? Quantity { get; set; }

    public int? ExistsQuantity { get; set; }

    public string? Description { get; set; }

    public int? AlbumId { get; set; }

    public virtual Album? Album { get; set; }

    public virtual ICollection<UserCard> UserCards { get; set; } = new List<UserCard>();
}
