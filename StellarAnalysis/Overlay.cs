using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using AForge.Imaging;
using GCLib;

namespace StellarAnalysis
{
    class Overlay : IDisposable
    {
        public ImageManager image;

        SkyObject[] objects;

        int thickness;

        public Overlay(SkyObject[] objects, int width, int height, PixelFormat pixelFormat)
        {
            this.objects = objects;
            thickness = (int)(((double)width) * (10.0f / 5465.0f));
            BuildOverlay(width, height, pixelFormat);
        }

        public void BuildOverlay(int width, int height, PixelFormat pixelFormat)
        {
            try { image.Dispose(); }
            catch { }

            image = new ImageManager(width, height, Color.Black, pixelFormat);
            image.Unlock();

            for (int i = 0; i < objects.Length; i++)
            {
                Rectangle r = objects[i].ObjectBlob.Rectangle;
                Drawing.Rectangle(image.workingImage, r, Color.Red);
                for (int j = 1; j < thickness; j++)
                {
                    r = new Rectangle(r.X - 1, r.Y - 1, r.Width + 2, r.Height + 2);
                    Drawing.Rectangle(image.workingImage, r, Color.Red);
                }
            }
            image.Lock();

            image.CopyDisplayToBacking();
        }

        public void SelectObject(int index)
        {
            if ((index < 0) | (index > objects.Length))
                return;

            image.Unlock();
            Rectangle r = objects[index].ObjectBlob.Rectangle;
            Drawing.Rectangle(image.workingImage, r, Color.Blue);
            for (int j = 1; j < thickness; j++)
            {
                r = new Rectangle(r.X - 1, r.Y - 1, r.Width + 2, r.Height + 2);
                Drawing.Rectangle(image.workingImage, r, Color.Blue);
            }
            image.Lock();
        }

        public void Dispose()
        {
            try
            {
                image.Dispose();
            }
            catch
            {
            }
        }
    }
}
