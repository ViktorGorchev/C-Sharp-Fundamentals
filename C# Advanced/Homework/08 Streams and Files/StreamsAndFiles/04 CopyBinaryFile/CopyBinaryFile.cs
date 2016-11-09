namespace _04_CopyBinaryFile
{
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            using (var source = new FileStream("../../Desert_Wallpaper.jpg", FileMode.Open))
            {
                using (var copy = new FileStream("../../Copy.jpg", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }

                        copy.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
