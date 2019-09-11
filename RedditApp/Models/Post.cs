namespace RedditApp.Models
{
    public class Post
    {
        public long PostId { get; set; }
        public int Score { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
