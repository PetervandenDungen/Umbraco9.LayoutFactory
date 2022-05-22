using LayoutFactory.Core.Factory.Abstract;
using LayoutFactory.Core.Web.Controllers.Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Web;

namespace LayoutFactory.Core.Web.Controllers
{
    public class HomeController : DefaultController
    {
        private readonly ILogger<DefaultController> _logger;
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IConfiguration _config;
        private readonly ILayoutFactory _layoutFactory;

        public HomeController(
            ILogger<HomeController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IPublishedContentQuery publishedContentQuery,
            ILayoutFactory layoutFactory,
            IConfiguration config)
            : base(logger, compositeViewEngine, umbracoContextAccessor, publishedContentQuery, layoutFactory, config)
        {
            _logger = logger;
            _publishedContentQuery = publishedContentQuery;
            _config = config;

            _layoutFactory = layoutFactory;
        }

        public override IActionResult Index()
        {
            return base.Index();
        }
    }
}
