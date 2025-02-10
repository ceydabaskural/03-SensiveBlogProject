using SensiveBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlogProject.BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        public List<Comment> TGetCommentsByArticleId(int id);
        public List<Comment> TGetCommentsByArticleIdAndAppUser(int id);
        Comment TGetCommentById(int commentId, int userId);
    }
}
