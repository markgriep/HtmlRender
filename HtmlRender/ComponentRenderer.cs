using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;






namespace HtmlRender
{

        public class ComponentRenderer
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILoggerFactory _loggerFactory;

        public ComponentRenderer()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();
            _serviceProvider = serviceCollection.BuildServiceProvider();
            _loggerFactory = _serviceProvider.GetRequiredService<ILoggerFactory>();
        }

        public async Task<string> RenderComponentToStringAsync<TComponent>(Dictionary<string, object> parameters) where TComponent : IComponent
        {
            await using var htmlRenderer = new HtmlRenderer(_serviceProvider, _loggerFactory);
            var htmlContent = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
            {
                var parameterView = ParameterView.FromDictionary(parameters);
                var result = await htmlRenderer.RenderComponentAsync<TComponent>(parameterView);
                return result.ToHtmlString();
            });

            return htmlContent;
        }
    }







}
