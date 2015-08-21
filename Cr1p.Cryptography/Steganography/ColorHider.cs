using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cr1p.Cryptography.Steganography
{
    public abstract class ColorHider
    {

        public static Image HideInAlpha(byte[] buffer, Image img)
        {

            Bitmap bmp = (Bitmap)img;

            int pointer = 0;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (pointer >= buffer.Length) break;
                    bmp.SetPixel(x, y, Color.FromArgb(buffer[pointer], bmp.GetPixel(x,y)));
                    pointer++;
                }
                if (pointer >= buffer.Length) break;
            }

            return bmp;

        }

        public static byte[] ReadFromAlpha(Image buffer, ulong count = 0)
        {

            if (count == 0) count = (ulong)(buffer.Height * buffer.Width);

            Bitmap bmp = (Bitmap)buffer;
            byte[] data = new byte[count];

            ulong pointer = 0;
            for (int y = 0; y < buffer.Height; y++)
            {
                for (int x = 0; x < buffer.Width; x++)
                {

                    if (pointer >= count) break;

                    data[pointer] = bmp.GetPixel(x, y).A;
                    pointer++;

                }
                if (pointer >= count) break;
            }

            return data;

        }

        public static Image HideInRed(byte[] buffer, Image img)
        {

            Bitmap bmp = (Bitmap)img;

            int pointer = 0;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (pointer >= buffer.Length) break;
                    bmp.SetPixel(x, y, Color.FromArgb(bmp.GetPixel(x, y).A, buffer[pointer], bmp.GetPixel(x, y).G, bmp.GetPixel(x, y).B));
                    pointer++;
                }
                if (pointer >= buffer.Length) break;
            }

            return bmp;

        }

        public static byte[] ReadFromRed(Image buffer, ulong count = 0)
        {
            if (count == 0) count = (ulong)(buffer.Height * buffer.Width);

            Bitmap bmp = (Bitmap)buffer;
            byte[] data = new byte[count];

            ulong pointer = 0;
            for (int y = 0; y < buffer.Height; y++)
            {
                for (int x = 0; x < buffer.Width; x++)
                {

                    if (pointer >= count) break;

                    data[pointer] = bmp.GetPixel(x, y).R;
                    pointer++;

                }
                if (pointer >= count) break;
            }

            return data;
        }

        public static Image HideInGreen(byte[] buffer, Image img)
        {

            Bitmap bmp = (Bitmap)img;

            int pointer = 0;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (pointer >= buffer.Length) break;
                    bmp.SetPixel(x, y, Color.FromArgb(bmp.GetPixel(x, y).A, bmp.GetPixel(x,y).R, buffer[pointer], bmp.GetPixel(x, y).B));
                    pointer++;
                }
                if (pointer >= buffer.Length) break;
            }

            return bmp;

        }

        public static byte[] ReadFromGreen(Image buffer, ulong count = 0)
        {
            if (count == 0) count = (ulong)(buffer.Height * buffer.Width);

            Bitmap bmp = (Bitmap)buffer;
            byte[] data = new byte[count];

            ulong pointer = 0;
            for (int y = 0; y < buffer.Height; y++)
            {
                for (int x = 0; x < buffer.Width; x++)
                {

                    if (pointer >= count) break;

                    data[pointer] = bmp.GetPixel(x, y).G;
                    pointer++;

                }
                if (pointer >= count) break;
            }

            return data;
        }

        public static Image HideInBlue(byte[] buffer, Image img)
        {

            Bitmap bmp = (Bitmap)img;

            int pointer = 0;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (pointer >= buffer.Length) break;
                    bmp.SetPixel(x, y, Color.FromArgb(bmp.GetPixel(x, y).A, bmp.GetPixel(x,y).R, bmp.GetPixel(x, y).G, buffer[pointer]));
                    pointer++;
                }
                if (pointer >= buffer.Length) break;
            }

            return bmp;

        }

        public static byte[] ReadFromBlue(Image buffer, ulong count = 0)
        {
            if (count == 0) count = (ulong)(buffer.Height * buffer.Width);

            Bitmap bmp = (Bitmap)buffer;
            byte[] data = new byte[count];

            ulong pointer = 0;
            for (int y = 0; y < buffer.Height; y++)
            {
                for (int x = 0; x < buffer.Width; x++)
                {

                    if (pointer >= count) break;

                    data[pointer] = bmp.GetPixel(x, y).B;
                    pointer++;

                }
                if (pointer >= count) break;
            }

            return data;
        }

    }
}
