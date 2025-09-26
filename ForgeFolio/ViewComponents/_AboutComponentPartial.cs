using ForgeFolio.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents
{
    public class _AboutComponentPartial: ViewComponent
    {
        private readonly MyPortfolioContext _portfolioContext;
        
        public _AboutComponentPartial(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        
        public IViewComponentResult Invoke()
        {
            ViewBag.aboutTitle = _portfolioContext.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutSubDescription = _portfolioContext.Abouts.Select(x => x.SubDescription).FirstOrDefault();
            ViewBag.aboutDetail = _portfolioContext.Abouts.Select(x => x.Details).FirstOrDefault();
            return View();
        }
    }
}
