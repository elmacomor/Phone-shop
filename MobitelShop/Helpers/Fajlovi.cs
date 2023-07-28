using Microsoft.Extensions.Primitives;

namespace MobitelShop.Helpers
{
    public class Fajlovi
    {
        public static byte[]? Ucitaj(string putanja)
        {
            try
            {
                return System.IO.File.ReadAllBytes(putanja);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static void Spremi(byte[] bajtovi, string putanja)
        {
            var directoryName = Path.GetDirectoryName(putanja);
            if (directoryName != null)
                System.IO.Directory.CreateDirectory(directoryName);
            using var fs = new FileStream(putanja, FileMode.Create, FileAccess.Write);
            fs.Write(bajtovi, 0, bajtovi.Length);
            fs.Close();
        }

    }
}
