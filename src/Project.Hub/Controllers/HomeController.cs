using System.Web.Mvc;
using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Util;

namespace Project.Hub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfigurationProvider _provider;

        public HomeController()
        {
            _provider = ServicesFactory.Instance.GetConfigurationProvider();
        }

        public ActionResult Index()
        {
            return View(_provider.GetConfig());
        }

        public ActionResult Environment(string id)
        {
            var config = _provider.GetConfig();
            var environment = config.GetEnvironment(id);
            return View(environment);
        }
    }
}