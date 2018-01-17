using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YourWorkOut
{
    public static class EmbadedFilesHelper
    {
        public static byte[] GetImage(string imageName)
        {
            var basePath = "YourWorkOut.Images.";
            var result = ImageSource.FromResource(basePath + imageName);
            var streamImageSource = result as StreamImageSource;
            var task = streamImageSource.Stream(System.Threading.CancellationToken.None);
            var stream = task.Result;
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
