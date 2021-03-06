﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YourWorkOut
{
    public class EmbadedResources
    {
        public byte[] GetImage(string imageName)
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

        public Stream GetAudio(string audioName)
        {
            var basePath = "YourWorkOut.Audio.";
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var audioStream = assembly.GetManifestResourceStream(basePath + audioName);
            return audioStream;
        }
    }
}
