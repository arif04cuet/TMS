using Infrastructure;
using System.Threading.Tasks;

namespace Module.Core.Shared
{
    public interface IRazorViewRenderer : ITransientService
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
