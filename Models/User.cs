
namespace CodeFirstApproach.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        // Relationer
        // En användare kan ha många inlägg
        public List<Post> Posts { get; set; }

        // En användare kan ha många kommentarer
        public List<Comment> Comments { get; set; }
    }
}
