using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Cr1p.Cryptography;
using Cr1p.Cryptography.Ciphers;
using Cr1p.Cryptography.Steganography;
using System.Drawing;


namespace Cr1p.Cryptography.ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {

            byte[] hi = ASCIIEncoding.ASCII.GetBytes("This is what I wish to hide into an image file.".ToCharArray());

            ColorHider.HideInBlue(hi, Image.FromFile("crip.png")).Save("crip_hidden.png",System.Drawing.Imaging.ImageFormat.Png);
            byte[] newHi = ColorHider.ReadFromBlue(Image.FromFile("crip_hidden.png"),(ulong)hi.Length);

            Console.WriteLine(ASCIIEncoding.ASCII.GetChars(newHi));

            Console.Read();


        }
    }
}
