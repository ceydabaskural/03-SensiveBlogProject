using SensiveBlog.EntityLayer.Concrete;

namespace SensiveBlog.EntityLayer
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Article> Articles { get; set; }
    }
}
