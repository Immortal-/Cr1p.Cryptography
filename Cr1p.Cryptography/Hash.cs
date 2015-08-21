using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Cr1p.Cryptography
{
    public abstract class Hash
    {

        /// <summary>
        /// Hashes a byte array using SHA256.
        /// </summary>
        /// <param name="buffer">Bytes to hash</param>
        /// <param name="loops">How many times to hash buffer</param>
        /// <returns></returns>
        public static byte[] SHA256(byte[] buffer, UInt64 loops = 1)
        {
            using (SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider()) for (UInt64 x = 0; loops > x; x++) buffer = sha.ComputeHash(buffer);
            return buffer;
        }

        /// <summary>
        /// Hashes a byte array using SHA512
        /// </summary>
        /// <param name="buffer">Bytes to hash</param>
        /// <param name="loops">How many times to hash the buffer</param>
        /// <returns></returns>
        public static byte[] SHA512(byte[] buffer, UInt64 loops = 1)
        {
            using (SHA512CryptoServiceProvider sha = new SHA512CryptoServiceProvider()) for (UInt64 x = 0; loops > x; x++) buffer = sha.ComputeHash(buffer);
            return buffer;
        }
        
        /// <summary>
        /// Hashses a byte array using MD5
        /// </summary>
        /// <param name="buffer">Bytes to hash</param>
        /// <param name="loops">How many times to hash the buffer</param>
        /// <returns></returns>
        public static byte[] MD5(byte[] buffer, UInt64 loops = 1)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) for (UInt64 x = 0; loops > x; x++) buffer = md5.ComputeHash(buffer);
            return buffer;
        }

        /// <summary>
        /// Hashes a string using SHA256
        /// </summary>
        /// <param name="buffer">String to hash</param>
        /// <param name="loops">How many times to hash the string</param>
        /// <returns></returns>
        public static CryptedString SHA256(string buffer, string encoding = "utf-8", UInt64 loops = 1)
        {
            return new CryptedString(SHA256(Encoding.GetEncoding(encoding).GetBytes(buffer), loops));
        }

        /// <summary>
        /// Hashes a string using SHA512
        /// </summary>
        /// <param name="buffer">String to hash</param>
        /// <param name="loops">How many times to hash the string</param>
        /// <returns></returns>
        public static CryptedString SHA512(string buffer, string encoding = "utf-8", UInt64 loops = 1)
        {
            return new CryptedString(Hash.SHA256(Encoding.GetEncoding(encoding).GetBytes(buffer),loops));
        }

        /// <summary>
        /// Hashes a string using MD5
        /// </summary>
        /// <param name="buffer">String to hash</param>
        /// <param name="loops">How many times to hash the string</param>
        /// <returns></returns>
        public static CryptedString MD5(string buffer, string encoding = "utf-8", UInt64 loops = 1)
        {
            return new CryptedString(MD5(Encoding.GetEncoding(encoding).GetBytes(buffer), loops));
        }

        /// <summary>
        /// Hashes a file using SHA256
        /// </summary>
        /// <param name="file">FileInfo of file you wish to hash.</param>
        /// <param name="loops">How many times to hash the file</param>
        /// <returns></returns>
        public static byte[] SHA256(System.IO.FileInfo file, UInt64 loops = 1)
        {
            return SHA256(System.IO.File.ReadAllBytes(file.FullName), loops);
        }

        /// <summary>
        /// Hashes a file using SHA512
        /// </summary>
        /// <param name="file">FileInfo of file you wish to hash.</param>
        /// <param name="loops">How many times to hash the file</param>
        /// <returns></returns>
        public static byte[] SHA512(System.IO.FileInfo file, UInt64 loops = 1)
        {
            return SHA512(System.IO.File.ReadAllBytes(file.FullName), loops);
        }

        /// <summary>
        /// Hashes a file using MD5
        /// </summary>
        /// <param name="file">FileInfo of file you wish to hash.</param>
        /// <param name="loops">How many times to hash the file</param>
        /// <returns></returns>
        public static byte[] MD5(System.IO.FileInfo file, UInt64 loops = 1)
        {
            return MD5(System.IO.File.ReadAllBytes(file.FullName), loops);
        }



    }
}
