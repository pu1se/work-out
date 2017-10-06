using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YourWorkOut.ViewModels
{
    public class SelectedExerciseViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ImageSource Image { get; set; }
        public bool IsSelected { get; set; }
    }
}
