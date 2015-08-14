using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Cr1p.Cryptography
{
    public class CryptedString : IDisposable
    {
        private byte[] _EncryptedBytes;

        public CryptedString(byte[] encryptedBytes)
        {
            _EncryptedBytes = encryptedBytes;
        }
        public CryptedString(string encryptedString, string encoding = "utf-8")
        {
            _EncryptedBytes = CharConverter.CharToByte(encryptedString.ToCharArray(), encoding);
        }

        public string ToString(string encoding = "utf-8")
        {
            return new String(CharConverter.ByteToChar(_EncryptedBytes, encoding));
        }
        public char[] GetChars(string encoding = "utf-8")
        {
            return CharConverter.ByteToChar(_EncryptedBytes, encoding);
        }
        public byte[] GetBytes()
        {
            return _EncryptedBytes;
        }
        public string GetHexString()
        {
            return BitConverter.ToString(_EncryptedBytes).Replace("-", String.Empty).ToLower();
        }
        public byte[] Create32ByteKey()
        {
            return Hash.SHA256(_EncryptedBytes);
        }
        public byte[] Create16ByteIV()
        {
            return Hash.MD5(_EncryptedBytes);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool b)
        {
            if (b)
            {
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    for (int x = 0; 35 > x; x++) rng.GetBytes(_EncryptedBytes); //Overwrite the encrypted bytes 35 times to ensure they can't be recovered.
                }
            }
        }
        ~CryptedString()
        {
            Dispose(true);
        }
    }
}
