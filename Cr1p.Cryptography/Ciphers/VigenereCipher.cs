using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cr1p.Cryptography.Ciphers
{
    public abstract class VigenereCipher
    {

        public static char[] Crypt(char[] buffer, char[] key, bool encrypt)
        {

            buffer = new string(buffer).ToUpper().ToCharArray(); // This cipher is only upper case. It's the "message" that matters.

            if (!isMod26(key)) throw new ArgumentException("Key may only contain English letters.");

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] ciphered = new char[buffer.Length];

            for (uint x = 0; x < buffer.Length; x++)
                if (isMod26(buffer[x]))
                    if (encrypt) ciphered[x] = alpha[(mod26(buffer[x]) + mod26(key[x % key.Length])) % alpha.Length];
                    else ciphered[x] = alpha[(alpha.Length + (mod26(buffer[x]) - mod26(key[x % key.Length]))) % alpha.Length];
                else ciphered[x] = buffer[x];

            return ciphered;
            
        }

        private static int mod26(char c)
        {

            c = new string(new char[] { c }).ToUpper().ToCharArray()[0]; // mod26 only returns 0-25 so we need to make sure we're only dealing with 26 letters. 

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            int r = Array.IndexOf(alpha, c);

            if (r >= 0) return r;
            else throw new ArgumentException("Char must be part of the English alphabet.");

        }
        private static bool isMod26(char c)
        {
            c = new string(new char[] { c }).ToUpper().ToCharArray()[0]; // mod26 only returns 0-25 so we need to make sure we're only dealing with 26 letters. 

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            int r = Array.IndexOf(alpha, c);

            if (r >= 0) return true;
            else return false;

        }
        private static bool isMod26(char[] c)
        {
            foreach (char cc in c) if(!isMod26(cc)) return false;
            return true;
        }


    }

}
