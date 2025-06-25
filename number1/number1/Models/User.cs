using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace number1.Models;

public partial class User : IdentityUser
{
    [Required]
    public string? Username { get; set; }
    [Required]
    public int? Own { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<UserCard> UserCards { get; set; } = new List<UserCard>();
}
