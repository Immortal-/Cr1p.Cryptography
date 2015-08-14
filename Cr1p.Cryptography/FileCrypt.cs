using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Cr1p.Cryptography
{
    public abstract class FileCrypt
    {

        public static void Crypt(string file, byte[] key, byte[] iv, bool encrypt = true, string algorithm = "aes")
        {

            if (!File.Exists(file)) throw new ArgumentException("File has to exist.");

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

                    if (encrypt) cryptor = aes.CreateEncryptor();
                    else cryptor = aes.CreateDecryptor();

                    break;

                case "des":
                    des = new DESCryptoServiceProvider();
                    des.Key = key;
                    des.IV = iv;

                    if (encrypt) cryptor = des.CreateEncryptor();
                    else cryptor = des.CreateDecryptor();

                    break;

                case "tripledes":
                    tripsDes = new TripleDESCryptoServiceProvider();
                    tripsDes.Key = key;
                    tripsDes.IV = iv;

                    if (encrypt) cryptor = tripsDes.CreateEncryptor();
                    else cryptor = tripsDes.CreateDecryptor();

                    break;

                default:
                    throw new ArgumentException(algorithm + " is not an implemented encryption algorithm. Use AES/DES/TripleDES.");

            }

            CryptoStreamMode mode;
            if (encrypt) mode = CryptoStreamMode.Write;
            else mode = CryptoStreamMode.Read;

            Random r = new Random();
            string newFilename = file;
            while (File.Exists(newFilename + ".tmp"))
            {
                newFilename += r.Next(0, 999999);
            }
            newFilename += ".tmp";

            using (FileStream input = new FileStream(file, FileMode.Open), output = new FileStream(newFilename, FileMode.Create))
            {

                CryptoStream cs;
                if (encrypt) cs = new CryptoStream(output, cryptor, mode);
                else cs = new CryptoStream(input, cryptor, mode);

                try
                {

                    if (encrypt) input.CopyTo(cs);
                    else cs.CopyTo(output);

                }
                catch (CryptographicException)
                {
                    throw new ArgumentException("Ensure you have the right key/IV.");
                }
                finally
                {
                    cs.Flush();
                    cs.Dispose();
                }

            }

            File.Delete(file);
            File.Move(newFilename, file);

        }
    }
}
