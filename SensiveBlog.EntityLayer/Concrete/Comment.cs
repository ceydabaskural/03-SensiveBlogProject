using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ArticleId { get; set; } //her bir yorumda makale id olmalı çünkü hangi makaleye yorum yapıldığını bulmalıyız
        public Article Article { get; set; } //yorum yapılan makalenin adını getirebilmek için
    }
}
