using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourWorkOut.DataStore.Entities;

namespace YourWorkOut.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseComplexDetailPage : ContentPage
    {
        public ComplexEntity Item { get; }

        public ExerciseComplexDetailPage()
        {
            InitializeComponent();

            Item = new ComplexEntity();
        }

        public ExerciseComplexDetailPage(ComplexEntity selectedComplex)
        {
            InitializeComponent();

            Item = selectedComplex;
        }

        public void OnSaveClicked(object sender, EventArgs eventArgs)
        {
            
        }
    }
}