namespace StudentInsight.Helpers.Utils
{
    public static class Func
    {
        public static string Trim(string value, bool toLower = false)
            => toLower ? value.Trim().ToLower() : value.Trim();
    }
}
