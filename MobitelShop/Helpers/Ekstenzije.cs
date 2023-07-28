using System.Runtime.CompilerServices;

namespace MobitelShop.Helpers
{
    public static class Ekstenzije
    {
        public static byte[] ParsirajBase64(this string base64string)
        {
            base64string = base64string.Split(",")[1];
            return System.Convert.FromBase64String(base64string);
        }
    }
}
