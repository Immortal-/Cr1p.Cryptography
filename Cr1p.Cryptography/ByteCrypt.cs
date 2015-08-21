using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Cr1p.Cryptography
{
    public abstract class ByteCrypt
    {

        /// <summary>
        /// Encrypts/decrypts a byte array
        /// </summary>
        /// <param name="buffer">Bytes to crypt</param>
        /// <param name="key">"Password" for encryption</param>
        /// <param name="iv">"Salt" for encryption. A starting point for encryption.</param>
        /// <param name="encrypt">Do you wish to encrypt or decrypt?</param>
        /// <param name="algorithm">Encryption algorithm. AES/DES/TripleDES</param>
        /// <returns></returns>
        public static byte[] Crypt(byte[] buffer, byte[] key, byte[] iv, bool encrypt = true, string algorithm = "aes")
        {

            AesCryptoServiceProvider aes = null;
            DESCryptoServiceProvider des = null;
            TripleDESCryptoServiceProvider tripsDes = null;

            ICryptoTransform cryptor;

            switch (algorithm.ToLower())
            {

                case "aes":
                    aes = new AesCryptoServiceProvider();
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Padding = PaddingMode.None;

                    if (encrypt) cryptor = aes.CreateEncryptor();
                    else cryptor = aes.CreateDecryptor();

                    break;

                case "des":
                    des = new DESCryptoServiceProvider();
                    des.Key = key;
                    des.IV = iv;
                    des.Padding = PaddingMode.None;

                    if (encrypt) cryptor = des.CreateEncryptor();
                    else cryptor = des.CreateDecryptor();

                    break;

                case "tripledes":
                    tripsDes = new TripleDESCryptoServiceProvider();
                    tripsDes.Key = key;
                    tripsDes.IV = iv;
                    tripsDes.Padding = PaddingMode.None;


                    if (encrypt) cryptor = tripsDes.CreateEncryptor();
                    else cryptor = tripsDes.CreateDecryptor();

                    break;

                default:
                    throw new ArgumentException(algorithm + " is not an implemented encryption algorithm. Use AES/DES/TripleDES.");

            }
            try
            {

                if (encrypt)
                {

                    using (MemoryStream input = new MemoryStream())
                    {

                        using (CryptoStream writer = new CryptoStream(input, cryptor, CryptoStreamMode.Write))
                        {

                            writer.Write(buffer, 0, buffer.Length);
                            writer.Flush();

                        }

                        return input.ToArray();

                    }

                }
                else
                {

                    using (MemoryStream input = new MemoryStream(buffer), decrypted = new MemoryStream())
                    {

                        using (CryptoStream reader = new CryptoStream(decrypted, cryptor, CryptoStreamMode.Write))
                        {

                            input.CopyTo(reader);
                            input.Flush();

                        }

                        return decrypted.ToArray();

                    }

                }

            }
            catch (CryptographicException)
            {
                throw new ArgumentException("Ensure you have the right key/IV.");
            }
            finally
            {

                                        cryptor.Dispose();
                if (aes != null)        aes.Dispose();
                if (des != null)        des.Dispose();
                if (tripsDes != null)   tripsDes.Dispose();

            }

        }

    }
}
