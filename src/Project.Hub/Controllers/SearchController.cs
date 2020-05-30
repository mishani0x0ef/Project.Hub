using Microsoft.AspNetCore.Mvc;
using Project.Hub.Config.Entities.Common.Search;
using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Util;
using System.Threading.Tasks;

namespace Project.Hub.Controllers
{
    public class SearchController : Controller
    {
        private readonly IConfigurationProvider _provider;

        public SearchController(IConfigurationProvider provider)
        {
            _provider = provider;
        }

        public async Task<IActionResult> Index(string searchText)
        {
            var config = await _provider.GetConfig();
            var results = config.SearchFor(searchText);

            return View(new SearchResults
            {
                SearchText = searchText,
                Results = results,
            }); ;
        }
    }
}
