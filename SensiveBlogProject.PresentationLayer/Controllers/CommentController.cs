using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.EntityLayer.Concrete;

namespace SensiveBlogProject.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        public CommentController(ICommentService commentService, IArticleService articleService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _articleService = articleService;
            _userManager = userManager;
        }

        //[HttpGet]
        //public PartialViewResult AddComment()
        //{
        //    return PartialView();
        //}

        //[HttpPost]
        //public IActionResult AddComment(Comment comment)
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        // Kullanıcı giriş yapmamışsa, kayıt veya giriş sayfasına yönlendir
        //        return RedirectToAction("Index", "Login"); // "Hesap" controller'ında "KayitOl" action'ına yönlendir
        //    }

        //    comment.CreatedDate = DateTime.Now;
        //    comment.Status = true;

        //    // ArticleId doğruluğunu kontrol et
        //    var article = _articleService.TGetById(comment.ArticleId);

        //    if (article == null)
        //    {
        //        return NotFound("İlgili makale bulunamadı.");
        //    }

        //    _commentService.TInsert(comment);

        //    return RedirectToAction("AddComment", new { id = comment.ArticleId });
        //}

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            var comment = new Comment
            {
                ArticleId = id // İlgili makale ID'sini Comment modeline ekle
            };

            return PartialView(comment);
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            if (User.Identity.IsAuthenticated) // Kullanıcı oturum açmış mı?
            {
                // Oturum açmış kullanıcının bilgilerini alıyoruz
                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null)
                {
                    comment.CreatedDate = DateTime.Now;
                    comment.AppUserId = currentUser.Id; // Dinamik AppUserId atanıyor
                    comment.Status = true;

                    _commentService.TInsert(comment);
                    return RedirectToAction("Index", "Article", new { id = comment.ArticleId });
                }
            }

            // Kullanıcı authenticate değilse hata mesajı
            TempData["ErrorMessage"] = "Yorum yapabilmek için giriş yapmanız gerekiyor.";
            return RedirectToAction("Index", "Login", new { area = "Author" }); // Admin alanına yönlendirme
        }
    }
}
