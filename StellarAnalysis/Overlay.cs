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
        ImageManager overlay;

        SkyObject[] objects;

        int thickness;

        public Bitmap DisplayImage
        {
            get
            {
                return overlay.DisplayImage;
            }
        }

        public Overlay(SkyObject[] objects, int width, int height, PixelFormat pixelFormat)
        {
            this.objects = objects;
            thickness = (int)(((double)width) * (10.0f / 5465.0f));
            BuildOverlay(width, height, pixelFormat);
        }

        public void BuildOverlay(int width, int height, PixelFormat pixelFormat)
        {
            try { overlay.Dispose(); }
            catch { }

            overlay = new ImageManager(width, height, Color.Black, pixelFormat);
            overlay.Unlock();

            for (int i = 0; i < objects.Length; i++)
            {
                Rectangle r = objects[i].ObjectBlob.Rectangle;
                Drawing.Rectangle(overlay.workingImage, r, Color.Red);
                for (int j = 1; j < thickness; j++)
                {
                    r = new Rectangle(r.X - 1, r.Y - 1, r.Width + 2, r.Height + 2);
                    Drawing.Rectangle(overlay.workingImage, r, Color.Red);
                }
            }
            overlay.Lock();

            overlay.CopyDisplayToBacking();
        }

        public void SelectObject(int index)
        {
            if ((index < 0) | (index > objects.Length))
                return;

            overlay.Unlock();
            Rectangle r = objects[index].ObjectBlob.Rectangle;
            Drawing.Rectangle(overlay.workingImage, r, Color.Red);
            for (int j = 1; j < thickness; j++)
            {
                r = new Rectangle(r.X - 1, r.Y - 1, r.Width + 2, r.Height + 2);
                Drawing.Rectangle(overlay.workingImage, r, Color.Red);
            }
            overlay.Lock();
        }

        public void Dispose()
        {
            try
            {
                overlay.Dispose();
            }
            catch
            {
            }
        }
    }
}
