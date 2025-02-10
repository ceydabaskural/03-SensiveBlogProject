using SensiveBlogProject.EntityLayer.Concrete;

namespace SensiveBlogProject.PresentationLayer.Areas.Author.Models
{
    //kullanıcının bütün bilgilerini değil sadece belli bilgilerini istediğimiz için bu modeli oluşturduk
    public class UserEditViewModel 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
