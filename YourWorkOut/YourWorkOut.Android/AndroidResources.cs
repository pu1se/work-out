using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Environment = System.Environment;
using Android.Media;
using Android.Content.Res;
using Stream = System.IO.Stream;

[assembly: Dependency(typeof(YourWorkOut.Droid.AndroidResources))]
namespace YourWorkOut.Droid
{
    
    public class AndroidResources : IFileResources
    {
        public void Delete(string filename)
        {
            File.Delete(GetFilePath(filename));
        }

        public bool IsExists(string filename)
        {
            var filepath = GetFilePath(filename);
            var isExists = File.Exists(filepath);
            return isExists;
        }

        public string GetText(string filename)
        {
            var filepath = GetFilePath(filename);
            using (StreamReader reader = File.OpenText(filepath))
            {
                return reader.ReadToEnd();
            }
        }

        public void Save(string filename, Stream stream)
        {
            var filepath = GetFilePath(filename);

            using (var file = File.Create(filepath))
            {
                stream.CopyTo(file);
            }
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