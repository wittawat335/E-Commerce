using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Entities;

public partial class Review
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public string Description { get; set; } = null!;

    public string CreatedAt { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
