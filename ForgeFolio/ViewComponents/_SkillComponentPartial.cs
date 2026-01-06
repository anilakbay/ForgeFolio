using ForgeFolio.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents
{
    public class _SkillComponentPartial: ViewComponent
    {
        private readonly ApplicationDbContext _portfolioContext;
        
        public _SkillComponentPartial(ApplicationDbContext portfolioContext)
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
