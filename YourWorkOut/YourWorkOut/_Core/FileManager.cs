using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YourWorkOut
{
    public static class FileManager
    {
        static IFileResources _filesOnFile;
        public static IFileResources FileResource
        {
            get
            {
                if (_filesOnFile == null)
                    _filesOnFile = DependencyService.Get<IFileResources>();

                return _filesOnFile;
            }
        }

        static EmbadedResources _embadedResources;
        public static EmbadedResources EmbadedResource
        {
            get
            {
                if (_embadedResources == null)
                    _embadedResources = new EmbadedResources();
                return _embadedResources;
            }
        }

        private static IAudioResource _audioResource;
        public static void PlayAudioFile(string fileName)
        {
            if (_audioResource == null)
                _audioResource = DependencyService.Get<IAudioResource>();

            if (FileResource.IsExists(fileName) == false)
            {
                var audio = EmbadedResource.GetAudio(fileName);
                FileResource.Save(fileName, audio);
            }

            _audioResource.PlayAudioFile(fileName);
        }
    }
}
