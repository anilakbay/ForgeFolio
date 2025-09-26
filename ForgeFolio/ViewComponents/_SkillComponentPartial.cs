using ForgeFolio.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents
{
    public class _SkillComponentPartial: ViewComponent
    {
        private readonly MyPortfolioContext _portfolioContext;
        
        public _SkillComponentPartial(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Skills.ToList();
            return View(values);
        }
    }
}
