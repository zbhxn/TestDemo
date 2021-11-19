namespace _4_CallCustomStaticMethod
{
    public static class StringExts
    {
        public static bool NewContains(this string source, string valToCheck, StringComparison strComp)
        {
            return source.Contains(valToCheck, strComp);
        }

        private static string ToString(int obj)
        {
            return obj.ToString();
        }
    }
}
