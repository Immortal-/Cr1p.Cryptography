using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cr1p.Cryptography
{
    public abstract class CharConverter
    {

        public static byte[] CharToByte(char[] buffer, string encoding = "utf-8")
        {
            switch (encoding.ToLower())
            {

                case "ascii":
                    return Encoding.GetEncoding("ASCII").GetBytes(buffer);
                case "utf-7":
                case "utf7":
                    return Encoding.GetEncoding("UTF-7").GetBytes(buffer);

                case "utf-8":
                case "utf8":
                    return Encoding.GetEncoding("UTF-8").GetBytes(buffer);

                case "utf-16":
                case "utf16":
                    return Encoding.GetEncoding("UTF-16").GetBytes(buffer);

                case "utf-32":
                case "utf32":
                    return Encoding.GetEncoding("UTF-32").GetBytes(buffer);
                    

                default:
                    throw new Exception("Encoding not supported.");

            }
        }
        public static char[] ByteToChar(byte[] buffer, string encoding = "utf-8")
        {
            switch (encoding.ToLower())
            {

                case "ascii":
                    return Encoding.GetEncoding("ASCII").GetChars(buffer);
                case "utf-7":
                case "utf7":
                    return Encoding.GetEncoding("UTF-7").GetChars(buffer);

                case "utf-8":
                case "utf8":
                    return Encoding.GetEncoding("UTF-8").GetChars(buffer);

                case "utf-16":
                case "utf16":
                    return Encoding.GetEncoding("UTF-16").GetChars(buffer);

                case "utf-32":
                case "utf32":
                    return Encoding.GetEncoding("UTF-32").GetChars(buffer);


                default:
                    throw new Exception("Encoding not supported.");

            }
        }

        public static string HexString(byte[] buffer)
        {
            return BitConverter.ToString(buffer).Replace("-",String.Empty).ToLower();
        }
        public static string HexString(char[] buffer, string encoding = "utf-8")
        {
            switch (encoding.ToLower())
            {

                case "ascii":
                    return BitConverter.ToString(Encoding.GetEncoding("ASCII").GetBytes(buffer)).Replace("-",String.Empty).ToLower();
                case "utf-7":
                case "utf7":
                    return BitConverter.ToString(Encoding.GetEncoding("UTF-7").GetBytes(buffer)).Replace("-",String.Empty).ToLower();

                case "utf-8":
                case "utf8":
                    return BitConverter.ToString(Encoding.GetEncoding("UTF-8").GetBytes(buffer)).Replace("-",String.Empty).ToLower();

                case "utf-16":
                case "utf16":
                    return BitConverter.ToString(Encoding.GetEncoding("UTF-16").GetBytes(buffer)).Replace("-",String.Empty).ToLower();

                case "utf-32":
                case "utf32":
                    return BitConverter.ToString(Encoding.GetEncoding("UTF-32").GetBytes(buffer)).Replace("-", String.Empty).ToLower();


                default:
                    throw new Exception("Encoding not supported.");

            }
        }
        
    }
}
