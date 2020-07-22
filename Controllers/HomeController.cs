using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        
        public ViewResult Index()
        {
            return View();
        }

        [Route("aboutus")]
        public ViewResult Aboutus()
        {
            return View();
        }

        [Route("contactus")]
        public ViewResult Contactus()
        {
            return View();
        }
    }
}