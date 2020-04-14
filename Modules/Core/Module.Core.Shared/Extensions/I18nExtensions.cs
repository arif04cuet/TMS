namespace Module.Core.Shared
{
    public static class I18nExtensions
    {
        public static string i18n(this string value, params object[] args)
        {
            if (args.Length > 0)
            {
                value = string.Format(value, args);
            }
            return value;
        }
    }
}
