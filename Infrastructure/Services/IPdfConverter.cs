namespace Infrastructure.Services
{
    public interface IPdfConverter
    {
        byte[] Convert(string htmlContent);
    }
}
