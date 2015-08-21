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
            _EncryptedBytes = Encoding.GetEncoding(encoding).GetBytes(encryptedString);
        }

        public string ToString(string encoding = "utf-8")
        {
            return new String(GetChars(encoding));
        }
        public char[] GetChars(string encoding = "utf-8")
        {
            return Encoding.GetEncoding(encoding).GetChars(_EncryptedBytes);
        }
        public byte[] GetBytes()
        {
            return _EncryptedBytes;
        }
        public string GetHexString()
        {
            return BitConverter.ToString(_EncryptedBytes).Replace("-", String.Empty).ToLower();
        }
        public CryptedString HashSHA(uint times = 1)
        {
            return new CryptedString(Hash.SHA256(_EncryptedBytes,times));
        }
        public CryptedString HashMD5(uint times = 1)
        {
            return new CryptedString(Hash.MD5(_EncryptedBytes,times));
        }

        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool b)
        {
            if (b)
            {
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    for (int x = 0; 35 > x; x++) rng.GetBytes(_EncryptedBytes); //Overwrite the encrypted bytes 35 times to ensure they can't be recovered.
                }
                _EncryptedBytes = null;
            }
        }
        ~CryptedString()
        {
            Dispose(true);
        }
    }
}
