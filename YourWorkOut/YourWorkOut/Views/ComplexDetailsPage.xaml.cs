using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourWorkOut.DataStore.Entities;
using YourWorkOut.DataStore.Enums;

namespace YourWorkOut.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseComplexDetailPage : ContentPage
    {
        public ComplexEntity Item { get; } = new ComplexEntity();

        public ExerciseComplexDetailPage()
        {
            InitializeComponent();
            Title = "New Complex";
            BindingContext = this;
            picDuration.ItemsSource = EnumHelper.EnumerateEnumWithDescription<DurationEnum>().Select(x => x.Value).ToList();
            picDuration.SelectedItem = EnumHelper.GetDescription(DurationEnum.Default);
        }

        public ExerciseComplexDetailPage(ComplexEntity selectedComplex)
        {            
            InitializeComponent();
            Item = selectedComplex;
            Title = "Edit Complex "+Item.Name;
            BindingContext = this;

            picDuration.ItemsSource = EnumHelper.EnumerateEnumWithDescription<DurationEnum>().Select(x=>x.Value).ToList();
            picDuration.SelectedItem = EnumHelper.GetDescription(Item.DurationTimePerExerciseInSeconds);
        }

        public void OnSaveClicked(object sender, EventArgs eventArgs)
        {
            
        }

        public void OnStartClicked(object sender, EventArgs eventArgs)
        {
            
        }
    }
}