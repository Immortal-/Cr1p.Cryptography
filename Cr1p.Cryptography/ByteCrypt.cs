using System;
using System.Drawing;
/*
* @Author: Cr1ppin
* @AuthorLink: https://github.com/Cr1ppin
* @GithubLink: https://github.com/Cr1ppin/Cr1p.Cryptography
* @UpdateBy: Immortal
*/
namespace Steganography.Library
{
    /// <summary>
    /// steganography is basically hiding data within other data.
    /// </summary>
    public abstract class ByteBitmap
    {
        /// <summary>
        ///  creates an image based on a byte[]
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image ToImage32(byte[] buffer, int width, int height)
        {
            if (buffer.Length%4 != 0) throw new ArgumentException("Buffer length needs to be a factor of 4.");

            using (var bmp = new Bitmap(width, height))
            {
                //foreach pixel row.
                var pointer = 0;
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        if (pointer >= buffer.Length) break;

                        var a = buffer[pointer];
                        var r = buffer[pointer + 1];
                        var g = buffer[pointer + 2];
                        var b = buffer[pointer + 3];

                        bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                        pointer += 4;
                    }

                    if (pointer >= buffer.Length) break;
                }

                return bmp;
            }
        }
        /// <summary>
        /// gets byte[] from image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static byte[] FromImage32(Image buffer)
        {
            var bmp = (Bitmap) buffer;
            var data = new byte[(buffer.Height*buffer.Width)*4];


            var pointer = 0;
            for (var y = 0; y < buffer.Height; y++)
                for (var x = 0; x < buffer.Width; x++)
                {
                    var c = bmp.GetPixel(x, y);

                    var a = c.A;
                    var r = c.R;
                    var g = c.G;
                    var b = c.B;

                    data[pointer] = a;
                    data[pointer + 1] = r;
                    data[pointer + 2] = g;
                    data[pointer + 3] = b;

                    pointer += 4;
                }

            return data;
        }
        /// <summary>
        ///  creates an image based on a byte[]
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image ToImage24(byte[] buffer, int width, int height)
        {
            if (buffer.Length%3 != 0) throw new ArgumentException("Buffer length needs to be a factor of 3.");

            using (var bmp = new Bitmap(width, height))
            {
                //foreach pixel row.
                var pointer = 0;
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        if (pointer >= buffer.Length) break;

                        var r = buffer[pointer];
                        var g = buffer[pointer + 1];
                        var b = buffer[pointer + 2];

                        bmp.SetPixel(x, y, Color.FromArgb(r, g, b));

                        pointer += 3; // Move 3 bytes ahead.
                    }

                    if (pointer >= buffer.Length) break;
                }

                return bmp;
            }
        }
        /// <summary>
        ///  creates an image based on a byte[]
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static byte[] FromImage24(Image buffer)
        {
            var bmp = (Bitmap) buffer;
            var data = new byte[(buffer.Height*buffer.Width)*3];


            var pointer = 0;
            for (var y = 0; y < buffer.Height; y++)
                for (var x = 0; x < buffer.Width; x++)
                {
                    var c = bmp.GetPixel(x, y);

                    var r = c.R;
                    var g = c.G;
                    var b = c.B;

                    data[pointer] = r;
                    data[pointer + 1] = g;
                    data[pointer + 2] = b;

                    pointer += 3;
                }

            return data;
        }
        /// <summary>
        ///  creates an image based on a byte[]
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static Image ToImage16(byte[] buffer, int height, int width)
        {
            if (buffer.Length%2 != 0) throw new ArgumentException("Buffer length needs to be a factor of 2.");

            using (var bmp = new Bitmap(width, height))
            {
                //foreach pixel row.
                var pointer = 0;
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        if (pointer >= buffer.Length) break;

                        var r = buffer[pointer];
                        var g = buffer[pointer + 1];

                        bmp.SetPixel(x, y, Color.FromArgb(r, g, 0));

                        pointer += 2; // Move 2 bytes ahead.
                    }

                    if (pointer >= buffer.Length) break;
                }

                return bmp;
            }
        }
        /// <summary>
        /// gets byte[] from image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static byte[] FromImage16(Image buffer)
        {
            var bmp = (Bitmap) buffer;
            var data = new byte[(buffer.Height*buffer.Width)*2];


            var pointer = 0;
            for (var y = 0; y < buffer.Height; y++)
                for (var x = 0; x < buffer.Width; x++)
                {
                    var c = bmp.GetPixel(x, y);

                    var r = c.R;
                    var g = c.G;

                    data[pointer] = r;
                    data[pointer + 1] = g;

                    pointer += 2;
                }

            return data;
        }
        /// <summary>
        /// creates an image based on a byte[]
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image ToImage8(byte[] buffer, int width, int height)
        {
            using (var bmp = new Bitmap(width, height))
            {
                //foreach pixel row.
                var pointer = 0;
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        if (pointer >= buffer.Length) break;

                        var r = buffer[pointer];

                        bmp.SetPixel(x, y, Color.FromArgb(r, 0, 0));

                        pointer++;
                    }

                    if (pointer >= buffer.Length) break;
                }

                return bmp;
            }
        }
        /// <summary>
        /// gets byte[] from image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static byte[] FromImage8(Image buffer)
        {
            var bmp = (Bitmap) buffer;
            var data = new byte[(buffer.Height*buffer.Width)*2];


            var pointer = 0;
            for (var y = 0; y < buffer.Height; y++)
                for (var x = 0; x < buffer.Width; x++)
                {
                    var c = bmp.GetPixel(x, y);

                    var r = c.R;

                    data[pointer] = r;

                    pointer++;
                }

            return data;
        }
    }
}
