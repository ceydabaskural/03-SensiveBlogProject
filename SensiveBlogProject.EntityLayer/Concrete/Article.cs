using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlogProject.EntityLayer.Concrete
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CoverImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } //bunu yazmamızın amacı ilişkiyi kurmak için ve Article sınıfı üzerinden Category sınıfına ulaşmak için bunu kullanırız
    }
}
