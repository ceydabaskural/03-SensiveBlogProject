namespace SensiveBlogProject.PresentationLayer.Models
{
    //ekleme işlemi AspNetUser tablosunu kullanarak yaparız ancak bütün proplarını kullanmaya ihtiyacımız olmadığı için sadece kullanacağımız propları yazmak adına bir view model oluşturduk:
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
