using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cr1p.Cryptography.Steganography
{
    public abstract class ByteBitmap
    {

        public static Image ToImage32(byte[] buffer, int width, int height)
        {

            if (buffer.Length % 4 != 0) throw new ArgumentException("Buffer length needs to be a factor of 4.");

            using (Bitmap bmp = new Bitmap(width, height))
            {

                //foreach pixel row.
                int pointer = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (pointer >= buffer.Length) break;

                        byte a = buffer[pointer];
                        byte r = buffer[pointer + 1];
                        byte g = buffer[pointer + 2];
                        byte b = buffer[pointer + 3];

                        bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                        pointer += 4;
                    }

                    if (pointer >= buffer.Length) break;

                }

                return bmp;
            }
        }

        public static byte[] FromImage32(Image buffer)
        {

            Bitmap bmp = (Bitmap)buffer;
            byte[] data = new byte[(buffer.Height * buffer.Width) * 4];


            int pointer = 0;
            for (int y = 0; y < buffer.Height; y++) for (int x = 0; x < buffer.Width; x++)
                {


                    Color c = bmp.GetPixel(x, y);

                    byte a = c.A;
                    byte r = c.R;
                    byte g = c.G;
                    byte b = c.B;

                    data[pointer] = a;
                    data[pointer + 1] = r;
                    data[pointer + 2] = g;
                    data[pointer + 3] = b;

                    pointer += 4;


                }

            return data;


        }

        public static Image ToImage24(byte[] buffer, int width, int height)
        {

            if (buffer.Length % 3 != 0) throw new ArgumentException("Buffer length needs to be a factor of 3.");

            using (Bitmap bmp = new Bitmap(width, height))
            {

                //foreach pixel row.
                int pointer = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (pointer >= buffer.Length) break;

                        byte r = buffer[pointer];
                        byte g = buffer[pointer + 1];
                        byte b = buffer[pointer + 2];

                        bmp.SetPixel(x, y, Color.FromArgb(r, g, b));

                        pointer += 3; // Move 3 bytes ahead.
                    }

                    if (pointer >= buffer.Length) break;

                }

                return bmp;
            }

        }

        public static byte[] FromImage24(Image buffer)
        {

            Bitmap bmp = (Bitmap)buffer;
            byte[] data = new byte[(buffer.Height * buffer.Width) * 3];



            int pointer = 0;
            for (int y = 0; y < buffer.Height; y++) for (int x = 0; x < buffer.Width; x++)
                {


                Color c = bmp.GetPixel(x, y);

                byte r = c.R;
                byte g = c.G;
                byte b = c.B;

                data[pointer] = r;
                data[pointer + 1] = g;
                data[pointer + 2] = b;

                pointer += 3;


                }

            return data;

        }

        public static Image ToImage16(byte[] buffer, int height, int width)
        {

            if (buffer.Length % 2 != 0) throw new ArgumentException("Buffer length needs to be a factor of 2.");

            using (Bitmap bmp = new Bitmap(width, height))
            {

                //foreach pixel row.
                int pointer = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (pointer >= buffer.Length) break;

                        byte r = buffer[pointer];
                        byte g = buffer[pointer + 1];

                        bmp.SetPixel(x, y, Color.FromArgb(r, g, 0));

                        pointer += 2; // Move 2 bytes ahead.
                    }

                    if (pointer >= buffer.Length) break;

                }

                return bmp;
            }

        }

        public static byte[] FromImage16(Image buffer)
        {

            Bitmap bmp = (Bitmap)buffer;
            byte[] data = new byte[(buffer.Height * buffer.Width) * 2];



            int pointer = 0;
            for (int y = 0; y < buffer.Height; y++) for (int x = 0; x < buffer.Width; x++)
                {

                    Color c = bmp.GetPixel(x, y);

                    byte r = c.R;
                    byte g = c.G;

                    data[pointer] = r;
                    data[pointer + 1] = g;

                    pointer += 2;

                }

            return data;
        }

        public static Image ToImage8(byte[] buffer, int width, int height)
        {

            using (Bitmap bmp = new Bitmap(width, height))
            {

                //foreach pixel row.
                int pointer = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                        if (pointer >= buffer.Length) break;

                        byte r = buffer[pointer];

                        bmp.SetPixel(x, y, Color.FromArgb(r, 0, 0));

                        pointer++;

                    }

                    if (pointer >= buffer.Length) break;

                }

                return bmp;
            }
            

        }

        public static byte[] FromImage8(Image buffer)
        {

            Bitmap bmp = (Bitmap)buffer;
            byte[] data = new byte[(buffer.Height * buffer.Width) * 2];



            int pointer = 0;
            for (int y = 0; y < buffer.Height; y++) for (int x = 0; x < buffer.Width; x++)
                {

                    Color c = bmp.GetPixel(x, y);

                    byte r = c.R;

                    data[pointer] = r;

                    pointer++;

                }

            return data;
        }

    }
}
