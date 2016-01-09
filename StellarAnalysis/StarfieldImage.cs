using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using AForge.Imaging;
using AForge.Imaging.Filters;
using GCLib;

namespace StellarAnalysis
{
    class StarfieldImage : IDisposable
    {
        #region Fields

        List<IFilter> filters;
        List<SkyObject> objects;

        public ImageManager image;
        Overlay overlay;

        #endregion

        #region Properties

        public SkyObject[] Objects
        {
            get
            {
                return objects.ToArray();
            }
        }

        public IFilter[] Filters
        {
            get
            {
                return filters.ToArray();
            }
        }

        public Bitmap DisplayImage
        {
            get
            {
                return image.DisplayImage;
            }
        }

        #endregion

        #region Constructors

        public StarfieldImage(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            try
            {
                image = new ImageManager(path);
            }
            catch
            {
                throw;
            }

            filters = new List<IFilter>();
            objects = new List<SkyObject>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a filter to the filter list.
        /// </summary>
        /// <param name="filter"></param>
        public void AddFilter(IFilter filter)
        {
            filters.Add(filter);
        }

        public void RemoveFilter(Type filterType)
        {
            for (int i = 0; i < filters.Count; i++)
            {
                if (filters[i].GetType() == filterType)
                {
                    filters.RemoveAt(i);
                    i--;
                }
            }
        }

        public bool RemoveFilter(IFilter filter)
        {
            return filters.Remove(filter);
        }

        public bool RemoveObject(SkyObject obj)
        {
            return objects.Remove(obj);
        }

        /// <summary>
        /// Adds an object to the list.
        /// </summary>
        /// <param name="obj"></param>
        public void AddObject(SkyObject obj)
        {
            objects.Add(obj);
        }

        /// <summary>
        /// Clears all filters from the filter list.
        /// </summary>
        public void ClearFilters()
        {
            filters.Clear();
        }

        /// <summary>
        /// Clears all objects from the object list.
        /// </summary>
        public void ClearObjects()
        {
            objects.Clear();
        }

        /// <summary>
        /// Clears objects and filters from the lists.
        /// </summary>
        public void Clear()
        {
            ClearObjects();
            ClearFilters();
        }

        public void CountBlobs()
        {
            // Blob size for automatic should be set approimately 0.36% of the width of the image.
            int min = (int)(((double)image.Width) * (20.0f / 5465.0f));
            CountBlobs(min, min, image.Width, image.Height, true);
        }

        public void CountBlobs(int minWidth, int minHeight, int maxWidth, int maxHeight, bool coupled)
        {
            BlobCounter blobs = new BlobCounter();
            blobs.FilterBlobs = true;

            blobs.MinWidth = minWidth;
            blobs.MinHeight = minHeight;
            blobs.MaxWidth = maxWidth;
            blobs.MaxHeight = maxHeight;

            blobs.ProcessImage(image.DisplayImage);
            Blob[] objs = blobs.GetObjects(image.DisplayImage, false);

            for (int i = 0; i < objs.Length; i++)
            {
                SkyObject o = new SkyObject(objs[i]);
                objects.Add(o);
            }

            overlay = new Overlay(objects.ToArray(), image.Width, image.Height, image.PixelFormat);
            AddFilter(new Add(overlay.DisplayImage));
        }

        public void SelectObject(int index)
        {
            overlay.SelectObject(index);
        }

        public void Dispose()
        {
            try { image.Dispose(); }
            catch { }

            try { overlay.Dispose(); }
            catch { }

            image = null;
            overlay = null;
        }

        #region Filters

        public void AddInvertFilter()
        {
            AddFilter(new Invert());
        }

        public void AddGrayscaleFilter(double cr, double cg, double cb)
        {
            AddFilter(new Grayscale(cr, cg, cb));
        }

        public void AddGrayscaleRMY()
        {
            AddGrayscaleFilter(Grayscale.CommonAlgorithms.RMY.RedCoefficient,
                               Grayscale.CommonAlgorithms.RMY.GreenCoefficient,
                               Grayscale.CommonAlgorithms.RMY.BlueCoefficient);
        }

        public void AddGrayscaleBT709()
        {
            AddGrayscaleFilter(Grayscale.CommonAlgorithms.BT709.RedCoefficient,
                               Grayscale.CommonAlgorithms.BT709.GreenCoefficient,
                               Grayscale.CommonAlgorithms.BT709.BlueCoefficient);
        }

        public void AddGrayscaleY()
        {
            AddGrayscaleFilter(Grayscale.CommonAlgorithms.Y.RedCoefficient,
                               Grayscale.CommonAlgorithms.Y.GreenCoefficient,
                               Grayscale.CommonAlgorithms.Y.BlueCoefficient);
        }

        public void AddThresholdFilter(int value)
        {
            AddFilter(new Threshold(value));
        }

        public void AddGrayscaleToRBGFilter()
        {
            AddFilter(new GrayscaleToRGB());
        }

        public void AddBlobsFilter(int minWidth, int minHeight, int maxWidth, int maxHeight, bool coupled)
        {
            AddFilter(new BlobsFiltering(minWidth, minHeight, maxWidth, maxHeight, coupled));
        }

        #endregion 

        #endregion


        #region Private Methods

        void UpdateDisplay()
        {
            image.Unlock();

            UnmanagedImage temp = image.workingImage.Clone();
            for (int i = 0; i < filters.Count; i++)
            {
                temp = filters[i].Apply(image.workingImage);
                image.workingImage.Dispose();
                image.workingImage = temp.Clone();
                temp.Dispose();
            }

            image.Lock();
        }

        #endregion
    }
}
