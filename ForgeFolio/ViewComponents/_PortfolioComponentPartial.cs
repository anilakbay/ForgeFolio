using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents
{
    public class _PortfolioComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
