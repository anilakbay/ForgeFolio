using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents
{
    public class _FooterComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
