namespace WpfApp.Services
{
    public static class Utils
    {
        public static T Cast<T>(object target, T example)
        {
            return (T)target;
        }
    }
}
