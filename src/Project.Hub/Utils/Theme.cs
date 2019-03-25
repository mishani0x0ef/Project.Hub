namespace Project.Hub.Utils
{
    public class Theme
    {
        public const string CookieKey = "theme";
        public const string Dark = "theme-dark";
        public const string Light = "theme-light";

        public static string GetNext(string current) => current == Theme.Dark ? Theme.Light : Theme.Dark;
    }
}
