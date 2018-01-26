using System;
using System.IO;
using Xamarin.Forms;
using Android.Media;
using Android.Content.Res;
using Xamarin.Forms;
using YourWorkOut.Droid;
using Xamarin.Forms;
using Environment = System.Environment;
using Android.Media;
using Android.Content.Res;
using Stream = System.IO.Stream;

[assembly: Dependency(typeof(AudioResource))]
namespace YourWorkOut.Droid
{
    public class AudioResource : IAudioResource
    {
        public AudioResource()
        {
        }

        public void PlayAudioFile(string fileName)
        {
            var filePath = GetFilePath(fileName);
            var player = new MediaPlayer();
            var fd = global::Android.App.Application.Context.Assets.OpenFd(filePath);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();
        }
        string GetFilePath(string filename)
        {
            return Path.Combine(GetDocsPath(), filename);
        }
        string GetDocsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}