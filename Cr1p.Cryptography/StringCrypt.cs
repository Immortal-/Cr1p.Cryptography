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
        /// Encrypts a string and returns a CryptedString
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
                            Encoding.GetEncoding(encoding).GetBytes(buffer),
                            Encoding.GetEncoding(encoding).GetBytes(key),
                            Encoding.GetEncoding(encoding).GetBytes(iv),
                            encrypt,
                            algorithm
                        )
                );

        }
        public static CryptedString Crypt(string buffer, CryptedString key, CryptedString iv, bool encrypt = true, string algorithm = "aes", string encoding = "utf-8")
        {

            return new CryptedString(
                        ByteCrypt.Crypt(
                            Encoding.GetEncoding(encoding).GetBytes(buffer),
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
