using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents
{
    public class _HeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
