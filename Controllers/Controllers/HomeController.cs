using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace VueServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _env;

        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return PhysicalFile(Path.Combine(_env.WebRootPath, "index.html"), MimeMapping.KnownMimeTypes.Html);
        }
    }
}
