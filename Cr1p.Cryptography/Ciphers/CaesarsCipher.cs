using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cr1p.Cryptography.Ciphers
{
    public abstract class CaesarsCipher
    {

        public static char[] Crypt(char[] buffer, bool encrypt)
        {

            buffer = new string(buffer).ToUpper().ToCharArray(); // This cipher is only upper case. It's the "message" that matters.
            char[] crypted = new char[buffer.Length];
            char[] cipher = "XYZABCDEFGHIJKLMNOPQRSTUVW".ToCharArray();
            char[] plain = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            for (uint x = 0; x < buffer.Length; x++)
            {
                bool found = false;
                byte at = 0;
                if(encrypt) 
                    foreach (char c in plain)
                    {
                        if (buffer[x] == c)
                        {
                            found = true;
                            crypted[x] = cipher[at];
                        }
                        at++;
                    }
                else 
                    foreach (char c in cipher)
                    {
                        if (buffer[x] == c)
                        {
                            found = true;
                            crypted[x] = plain[at];
                        }
                        at++;
                    }

                if (!found) crypted[x] = buffer[x];

            }
            return crypted;

        }

    }
}
