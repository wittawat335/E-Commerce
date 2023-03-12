using E_CommerceAPI.Entities;

namespace E_CommerceAPI.ViewModels
{
    public class UserViewModel
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

    }
}
