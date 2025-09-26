using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents
{
    public class _TestimonialComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
