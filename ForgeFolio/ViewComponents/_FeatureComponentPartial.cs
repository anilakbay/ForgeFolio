using ForgeFolio.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents
{
    public class _FeatureComponentPartial:ViewComponent
    {
        private readonly ApplicationDbContext _portfolioContext;
        
        public _FeatureComponentPartial(ApplicationDbContext portfolioContext)
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
