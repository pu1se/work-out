using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace YourWorkOut.DataStore.Entities
{
    public class ExerciseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ImageSource Image {
            get
            {
                if (ImageAsBytes == null)
                    return null;

                return ImageSource.FromStream(()=>new MemoryStream(ImageAsBytes));
            }  
        }
        public byte[] ImageAsBytes { get; set; }
    }
}
