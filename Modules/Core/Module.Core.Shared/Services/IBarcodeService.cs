using Infrastructure;

namespace Module.Core.Shared
{
    public interface IBarcodeService : IScopedService
    {
        string Generate();
    }
}
