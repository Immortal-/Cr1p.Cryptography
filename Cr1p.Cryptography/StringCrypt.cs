using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cr1p.Cryptography
{
    public abstract class StringCrypt
    {

        
        /// <summary>
        /// Encrypts a string and returns a hex string.
        /// </summary>
        /// <param name="buffer">Bytes to encrypt</param>
        /// <param name="key">"Password" for encryption</param>
        /// <param name="iv">"Salt" for encryption.</param>
        /// <param name="encrypt">Encrypt or decrypt</param>
        /// <param name="algorithm">AES/DES/TripleDES</param>
        /// <returns></returns>
        public static CryptedString Crypt(string buffer, string key, string iv, bool encrypt = true, string algorithm = "aes", string encoding = "utf-8")
        {

            return new CryptedString(
                        ByteCrypt.Crypt(
                            CharConverter.CharToByte(buffer.ToCharArray(), encoding),
                            CharConverter.CharToByte(key.ToCharArray(), encoding),
                            CharConverter.CharToByte(iv.ToCharArray(), encoding),
                            encrypt,
                            algorithm
                        )
                );

        }
        public static CryptedString Crypt(string buffer, CryptedString key, CryptedString iv, bool encrypt = true, string algorithm = "aes", string encoding = "utf-8")
        {

            return new CryptedString(
                        ByteCrypt.Crypt(
                            CharConverter.CharToByte(buffer.ToCharArray(), encoding),
                            key.GetBytes(),
                            iv.GetBytes(),
                            encrypt,
                            algorithm
                        )
                );

        }
        public static CryptedString Crypt(CryptedString buffer, CryptedString key, CryptedString iv, bool encrypt = true, string algorithm = "aes", string encoding = "utf-8")
        {

            return new CryptedString(
                        ByteCrypt.Crypt(
                            buffer.GetBytes(),
                            key.GetBytes(),
                            iv.GetBytes(),
                            encrypt,
                            algorithm
                        )
                );

        }



    }
}
