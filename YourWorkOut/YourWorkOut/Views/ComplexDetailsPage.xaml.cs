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
    public partial class ComplexDetailPage : ContentPage
    {
        public ComplexEntity Item { get; } = new ComplexEntity();

        public ComplexDetailPage()
        {
            Title = "New Complex";
            picDuration.SelectedItem = EnumHelper.GetDescription(DurationEnum.s30);
        }

        public ComplexDetailPage(ComplexEntity selectedComplex)
        {
            InitializeComponent();
            picDuration.ItemsSource = EnumHelper.EnumerateEnumWithDescription<DurationEnum>().Select(x => x.Value).ToList();

            Item = selectedComplex;
            Title = "Edit Complex "+Item.Name;
            picDuration.SelectedItem = EnumHelper.GetDescription(Item.DurationTimePerExerciseInSeconds);
            txtName.Text = Item.Name;
        }



        public void OnSaveClicked(object sender, EventArgs eventArgs)
        {
            
        }

        public void OnStartClicked(object sender, EventArgs eventArgs)
        {
            
        }
    }
}