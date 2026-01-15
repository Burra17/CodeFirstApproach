
namespace CodeFirstApproach.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        // Relationer
        // Vem har skrivit inlägget
        public int AuthorId { get; set; }
        public User Author { get; set; }

        // Ett inlägg kan ha många kommentarer
        public List<Comment> Comments { get; set; }
    }
}
