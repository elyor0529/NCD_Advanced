
namespace NCD.Controllers
{
    using System.Web.Mvc;
    using NCD.Application.Services;
    using Ninject;
    using System.Threading.Tasks;
    using NCD.Application;
    using System.Linq;

    [Authorize]
    public class CriminalController : Controller
    {
        [Inject]
        public ISearchService SearchService { get; set; }

        [Inject]
        public IEmailService EmailService { get; set; }

        public ActionResult Index()
        {
            var model = new SearchViewModel
            {
                Email = User.Identity.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var criminals = SearchService.SearchCriminal(model).ToArray();

                if (criminals.Length == 0)
                {
                    ModelState.AddModelError("", "To see the results of your query, check your email");

                    return View(model);
                }

                await EmailService.SendAsync(model.Email, criminals);

                return View("Confirmation");
            }

            return View(model);
        }
    }
}
