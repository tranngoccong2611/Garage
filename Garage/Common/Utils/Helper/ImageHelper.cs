using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Common.Utils.Helper
{
    public static class ImageHelper
    {
        public static Image LoadImageFromFile(string path)
        {
            if (File.Exists(path))
            {
                return Image.FromFile(path);
            }
            return null;
        }
    }
}
