using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents
{
    public class _ContactComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
