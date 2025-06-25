using System;
using System.Collections.Generic;

namespace number1.Models;

public partial class Album
{
    public int AlbumId { get; set; }

    public string? AlbumName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CardInfo> CardInfos { get; set; } = new List<CardInfo>();
}
