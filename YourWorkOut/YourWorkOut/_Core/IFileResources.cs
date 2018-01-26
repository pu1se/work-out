using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourWorkOut
{
    public interface IFileResources
    {
        bool IsExists(string filename);
        void Save(string filename, Stream stream);
        string GetText(string filename);
        void Delete(string filename);
    }
}
