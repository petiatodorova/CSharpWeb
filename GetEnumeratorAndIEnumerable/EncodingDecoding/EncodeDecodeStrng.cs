using System;
using System.Text;

namespace EncodingDecoding
{
    class EncodeDecodeStrng
    {
        static void Main(string[] args)
        {
            // Create a UTF-8 encoding.
            UTF8Encoding utf8 = new UTF8Encoding();

            // A Unicode string with two characters outside an 8-bit code range.
            String unicodeString = $"Ala bala ала бала ЮяЩъ @";
            Console.WriteLine("Original string:");
            Console.WriteLine(unicodeString);

            // Encode the string.
            Byte[] encodedBytes = utf8.GetBytes(unicodeString);
            Console.WriteLine();
            Console.WriteLine($"Encoded bytes --> {string.Join("  |  ",encodedBytes)}");
            Console.WriteLine();

            // Decode bytes back to string.
            String decodedString = utf8.GetString(encodedBytes);
            Console.WriteLine();
            Console.WriteLine("Decoded bytes:");
            Console.WriteLine(decodedString);
        }
    }
}
