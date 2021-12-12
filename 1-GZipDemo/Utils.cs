using System.IO.Compression;
using System.Text;

namespace _1_GZipDemo
{
    public class Utils
    {
        public static byte[] Compress(byte[] data)
        {
            // `compressed` will contain result of compression
            using var compressed = new MemoryStream();
            // source is our original uncompressed data
            using (var source = new MemoryStream(data))
            {
                using var gzip = new GZipStream(compressed, CompressionMode.Compress);
                // just write whole source into gzip stream with CopyTo
                source.CopyTo(gzip);
            }
            return compressed.ToArray();
        }

        public static byte[] CompressString(string s, Encoding encoding)
        {
            return Compress(encoding.GetBytes(s));
        }

        public static string CompressStringToBase64(string s, Encoding encoding)
        {
            return Convert.ToBase64String(CompressString(s, encoding));
        }

        public static byte[] Decompress(Stream source)
        {
            using (var gzip = new GZipStream(source, CompressionMode.Decompress))
            {
                using (var decompressed = new MemoryStream())
                {
                    gzip.CopyTo(decompressed);
                    return decompressed.ToArray();
                }
            }
        }

        public static byte[] Decompress(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return Decompress(ms);
            }
        }

        public static string DecompressString(Stream source, Encoding encoding)
        {
            return encoding.GetString(Decompress(source));
        }

        public static string Decompress(string source, Encoding encoding)
        {
            using (var ms = new MemoryStream(encoding.GetBytes(source)))
            {
                return encoding.GetString(Decompress(ms));
            }
        }
    }
}
