using LayoutFactory.Core.Factory.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace LayoutFactory.Core.Web.Controllers.Default
{
    public class DefaultController : RenderController
    {
        public const string LayoutViewModelKey = "17da3434-8de7-4e52-a167-4f4096574dff";

        private readonly ILogger<DefaultController> _logger;
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IConfiguration _config;
        private readonly ILayoutFactory _layoutFactory;

        public DefaultController(
            ILogger<DefaultController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IPublishedContentQuery publishedContentQuery,
            ILayoutFactory layoutFactory,
            IConfiguration config)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _logger = logger;
            _publishedContentQuery = publishedContentQuery;
            _config = config;

            _layoutFactory = layoutFactory;

            SetLayoutViewModel();
        }

        public override IActionResult Index()
        {
            return CurrentTemplate(CurrentPage);
        }

        private void SetLayoutViewModel()
        {
            if (ViewData[LayoutViewModelKey] == null)
            {
                var publishedContent = TryGeyPublishedContent();

                if (publishedContent != null)
                {
                    ViewData[LayoutViewModelKey] = _layoutFactory?.Build(publishedContent);
                }
            }
        }

        private IPublishedContent? TryGeyPublishedContent()
        {
            if (UmbracoContext == null || UmbracoContext?.PublishedRequest == null)
            {
                return null;
            }

            var publishedContentRequest = UmbracoContext?.PublishedRequest;
            IPublishedContent? content = null;
            try
            {
                content = publishedContentRequest != null ? publishedContentRequest.PublishedContent : CurrentPage;
            }
            catch (InvalidOperationException)
            {
            }

            return content ??
                (publishedContentRequest?.Domain != null
                    ? _publishedContentQuery.Content(publishedContentRequest.Domain.ContentId)
                    : _publishedContentQuery.ContentAtRoot().First());
        }
    }
}
