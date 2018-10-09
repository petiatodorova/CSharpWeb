using System;
using System.Text;

namespace EncodeDecodeOK
{
    class Program
    {
         static void Main(string[] args)
        {
           // Create a UTF-8 encoding.
        UTF8Encoding utf8 = new UTF8Encoding();
        
        // A Unicode string with two characters outside an 8-bit code range.
        string unicodeString =
            "This Unicode string has 2 characters outside the " +
            "ASCII range:\n" +
            "Pi (\u03a0), and Sigma (\u03a3).";
        Console.WriteLine("Original string:");
        Console.WriteLine(unicodeString);

        // Encode the string.
        byte[] encodedBytes = utf8.GetBytes(unicodeString);
        Console.WriteLine();
        Console.WriteLine("Encoded bytes - Getbytes:");
        for (int ctr = 0; ctr < encodedBytes.Length; ctr++) {
            Console.Write("{0:X2} ", encodedBytes[ctr]);
            if ((ctr + 1) %  25 == 0)
               Console.WriteLine();
        }
        Console.WriteLine();
        
        // Decode bytes back to string.
        String decodedString = utf8.GetString(encodedBytes);
        Console.WriteLine();
        Console.WriteLine("Decoded bytes - Getstring:");
        Console.WriteLine(decodedString);
        }
    }
}
