namespace Pharmacy.DataAccess.Extensions
{
    public static class MyExtensionMethods
    {
        public static string ToLowerFirstChar(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
            {
                return str;
            }
            return char.ToLower(str[0]) + str.Substring(1);
        }
    }
}