using LayoutFactory.Core.Factory.Abstract;
using LayoutFactory.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace LayoutFactory.Core.Factory
{
    internal sealed class LayoutFactory : ILayoutFactory
    {
        public LayoutViewModel Build(IPublishedContent? content)
        {
            var website = content;
            
            return new LayoutViewModel
            {
                TestProperty = Guid.NewGuid(),
            };
        }
    }
}
