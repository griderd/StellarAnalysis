using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;

namespace StellarAnalysis
{
    public class ImageManager : IDisposable
    {
        Bitmap backingImage;
        public Bitmap display;
        public UnmanagedImage workingImage;

        public int Width { get { return display.Width; } }
        public int Height { get { return display.Height; } }

        public PixelFormat PixelFormat
        {
            get
            {
                return display.PixelFormat;
            }
        }

        public Bitmap DisplayImage
        {
            get
            {
                return display;
            }
        }

        public bool CanEdit { get; private set; }

        public ImageManager(int width, int height, Color background, PixelFormat pixelFormat)
        {
            backingImage = new Bitmap(width, height, pixelFormat);
            display = new Bitmap(width, height, pixelFormat);
            Unlock();
            Drawing.FillRectangle(workingImage, new Rectangle(0, 0, width, height), background);
            Lock();
            CopyDisplayToBacking();
        }

        public ImageManager(Bitmap bmp)
        {
            backingImage = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), bmp.PixelFormat);
            display = new Bitmap(backingImage);
        }

        public ImageManager(string path)
        {
            backingImage = new Bitmap(path);
            display = new Bitmap(backingImage);
        }

        /// <summary>
        /// Locks the image for editing and returns the display image.
        /// </summary>
        /// <returns>Returns the current display image.</returns>
        public Bitmap Lock()
        {
            CanEdit = false;
            display.Dispose();
            display = workingImage.ToManagedImage();
            workingImage.Dispose();
            workingImage = null;

            return display;
        }

        /// <summary>
        /// Unlocks the image for editing and returns the working image.
        /// </summary>
        /// <returns></returns>
        public void Unlock()
        {
            CanEdit = true;
            workingImage = UnmanagedImage.FromManagedImage(backingImage);
        }

        /// <summary>
        /// Copies the display image to the backing image. This saves any changes made during editing, but these changes cannot be undone.
        /// At the same time, it means that you don't have to keep track of changes you do make.
        /// </summary>
        public void CopyDisplayToBacking()
        {
            backingImage.Dispose();
            backingImage = display.Clone(new Rectangle(0, 0, display.Width, display.Height), display.PixelFormat);
        }

        public void Dispose()
        {
            try
            {
                backingImage.Dispose();
            }
            catch { }
            try
            {
                display.Dispose();
            }
            catch { }
            try
            {
                workingImage.Dispose();
            }
            catch { }
        }
    }
}
