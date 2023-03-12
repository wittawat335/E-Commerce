using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public string Status { get; set; } = null!;

    public string CreatedAt { get; set; } = null!;

    public string ModifiedAt { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();
}
