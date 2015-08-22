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

            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < 1000; x++)
            {
                sb.Append("This is what I wish to hide into an image file.");
            }


            byte[] hi = ByteCrypt.Crypt(File.ReadAllBytes("C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe"), Hash.SHA256(new byte[5]), Hash.MD5(new byte[20]), true, "aes");

            ByteBitmap.ToImage8(hi, 500, 500).Save("8.png");
            ByteBitmap.ToImage16(hi, 500, 500).Save("16.png");
            //ByteBitmap.ToImage24(hi, 250, 250).Save("24.png");
            ByteBitmap.ToImage32(hi, 500, 500).Save("32.png");



        }
    }
}
