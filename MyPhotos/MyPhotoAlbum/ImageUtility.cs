﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Maining.MyPhotoAlbum
{
    public class ImageUtility
    {
        public static Rectangle ScaleToFit(Bitmap bmp, Rectangle targetArea)
        {
            Rectangle result = new Rectangle(targetArea.Location, targetArea.Size);

            // determine best fit: width or height
            if (result.Height * bmp.Width > result.Width * bmp.Height)
            {
                // Final width should match target,
                // determine and center height
                result.Height = result.Width * bmp.Height / bmp.Width;

                result.Y += (targetArea.Height - result.Height) / 2;


            }
            else
            {
                // Final height should match target,
                // determine and center height
                result.Width = result.Height * bmp.Width / bmp.Height;
                result.X += (targetArea.Width - result.Width) / 2;

            }
            return result;
        }
    }
}
