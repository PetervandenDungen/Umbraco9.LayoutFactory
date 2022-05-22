using LayoutFactory.Core.Factory.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace LayoutFactory.Core.Composer
{
    public class FactoryComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<ILayoutFactory, Factory.LayoutFactory>();
        }
    }
}
