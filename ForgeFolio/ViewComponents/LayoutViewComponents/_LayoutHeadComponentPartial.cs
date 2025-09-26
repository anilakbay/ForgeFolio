using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents.LayoutViewComponents
{
    public class _LayoutHeadComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
