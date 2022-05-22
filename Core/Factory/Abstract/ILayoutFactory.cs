using LayoutFactory.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace LayoutFactory.Core.Factory.Abstract
{
    public interface ILayoutFactory
    {
        LayoutViewModel Build(IPublishedContent? content);
    }
}
