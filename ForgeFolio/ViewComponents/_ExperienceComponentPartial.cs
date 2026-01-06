using ForgeFolio.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents
{
    public class _ExperienceComponentPartial: ViewComponent
    {
        private readonly ApplicationDbContext _portfolioContext;
        
        public _ExperienceComponentPartial(ApplicationDbContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Experiences.ToList();
            return View(values);
        }
    }
}
