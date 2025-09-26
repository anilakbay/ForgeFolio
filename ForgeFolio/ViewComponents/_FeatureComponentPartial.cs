using ForgeFolio.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents
{
    public class _FeatureComponentPartial:ViewComponent
    {
        private readonly MyPortfolioContext _portfolioContext;
        
        public _FeatureComponentPartial(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Features.ToList();
            return View(values);
        }
    }
}
