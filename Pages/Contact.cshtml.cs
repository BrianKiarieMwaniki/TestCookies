using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestCookies.Pages
{
    public class ContactModel : PageModel
    {
        public string Language {  get; set; }
        public void OnGet()
        {
            Language = "en";


        }
    }
}
