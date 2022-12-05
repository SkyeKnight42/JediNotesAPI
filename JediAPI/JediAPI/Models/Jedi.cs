namespace JediAPI.Models
{
    public class JediNote
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Owner { get; set; }
        public string JediRank { get; set; }
    }
}
