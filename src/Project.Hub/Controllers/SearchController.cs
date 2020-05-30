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

        public async Task<IActionResult> Index(string query, bool isTag = false)
        {
            var config = await _provider.GetConfig();
            var results = isTag ? config.SearchForTag(query) : config.SearchByQuery(query);

            return View(new SearchResults
            {
                Query = isTag ? $"#{query}" : query,
                Results = results,
            }); ;
        }
    }
}
