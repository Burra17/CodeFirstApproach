
namespace CodeFirstApproach.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        // Relationer
        // Vem har skrivit kommentaren
        public int AuthorId { get; set; }
        public User Author { get; set; }

        // Vilken post hör kommentaren till
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
