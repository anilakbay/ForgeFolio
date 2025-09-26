using ForgeFolio.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents
{
    public class _ExperienceComponentPartial: ViewComponent
    {
        private readonly MyPortfolioContext _portfolioContext;
        
        public _ExperienceComponentPartial(MyPortfolioContext portfolioContext)
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
