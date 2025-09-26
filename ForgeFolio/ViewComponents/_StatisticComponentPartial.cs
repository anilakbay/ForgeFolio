using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents
{
    public class _StatisticComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
