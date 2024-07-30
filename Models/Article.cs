namespace foodyApi.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        public Article(string name, string imageUrl)
    {
        Name = name;
        ImageUrl = imageUrl;
    }
    
    }
}
