using System;
using Xamarin.Forms;
using System.IO;
using Foundation;
using AVFoundation;
using Xamarin.Forms;
using YourWorkOut.iOS;

[assembly: Dependency(typeof(AudioResource))]
namespace YourWorkOut.iOS
{
    public class AudioResource : IAudioResource
    {
        public AudioResource()
        {
        }

        public void PlayAudioFile(string fileName)
        {
            string sFilePath = NSBundle.MainBundle.PathForResource
                (Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
            var url = NSUrl.FromString(sFilePath);
            var _player = AVAudioPlayer.FromUrl(url);
            _player.FinishedPlaying += (object sender, AVStatusEventArgs e) => {
                _player = null;
            };
            _player.Play();
        }
    }
}