using _1_GZipDemo;
using System.Text;

var source = "{\"pageIndex\":0,\"pageSize\":10,\"fullTextSearch\":\"\",\"filter\":{\"3\":[\"qiu\"]},\"sortField\":8,\"sortDesc\":true,\"sessionTimestamp\":null}";
var compressed = Utils.CompressString(source, Encoding.UTF8);
File.WriteAllBytes($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\gzip.txt", compressed);
var decompressed = Utils.DecompressString(new MemoryStream(compressed), Encoding.UTF8);
Console.WriteLine(source == decompressed);
Console.ReadKey();