using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourWorkOut.DataStore.Enums;

namespace YourWorkOut.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            picDuration.ItemsSource = EnumHelper.EnumerateEnumWithDescription<DefaultDurationEnum>().Select(x => x.Value).ToList();
            picDuration.SelectedItem = EnumHelper.GetDescription(DefaultDurationEnum.s30);
        }

        public async void OnEditExercisesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExercisesListPage());
        }
    }
}