namespace gamesforfriends.infra.Extensions
{
    using System.Text;
    public static class StringExtensions
    {
        public static string Md5(this string value)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var md5Bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            var builder = new StringBuilder();
            foreach (var item in md5Bytes)
            {
                builder.Append(item.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}