using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourWorkOut.DataStore.Entities;
using YourWorkOut.DataStore.Enums;
using YourWorkOut.Services;
using YourWorkOut.Views.ComplexesTab;

namespace YourWorkOut.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComplexDetailPage : ContentPage
    {
        ComplexEntity SelectedComplex { get; } = new ComplexEntity();
        ComplexService ComplexService = new ComplexService();

        public ComplexDetailPage()
        {
            InitControls();

            Title = "New Complex";
            picDuration.SelectedItem = EnumHelper.GetDescription(DurationEnum.s30);
        }

        public ComplexDetailPage(ComplexEntity selectedComplex)
        {
            SelectedComplex = selectedComplex;
            Title = $"Edit \"{SelectedComplex.Name}\"";
            InitControls();
            picDuration.SelectedItem = EnumHelper.GetDescription(SelectedComplex.DurationTimePerExerciseInSeconds);
        }

        void InitControls()
        {
            InitializeComponent();
            picDuration.ItemsSource = EnumHelper.EnumerateEnumWithDescription<DurationEnum>().Select(x => x.Value).ToList();
            txtName.Text = SelectedComplex.Name;
        }

        public void OnSaveClicked(object sender, EventArgs eventArgs)
        {
            SelectedComplex.Name = txtName.Text;
            SelectedComplex.DurationTimePerExerciseInSeconds =
                EnumHelper.Parse<DurationEnum>(picDuration.SelectedItem.ToString());

            ComplexService.Save(SelectedComplex);
        }

        public void OnStartClicked(object sender, EventArgs eventArgs)
        {
            
        }

        public async void OnEditExercisesListClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new SelectedExercisesPage(SelectedComplex));
        }
    }
}