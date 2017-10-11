using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YourWorkOut
{
    public static class EmbadedFilesHelper
    {
        public static ImageSource GetImage(string imageName)
        {
            var basePath = "YourWorkOut.Images.";
            var result = ImageSource.FromResource(basePath + imageName);
            return result;
        }
    }
}
