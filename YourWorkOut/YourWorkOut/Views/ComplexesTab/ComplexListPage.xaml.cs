using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourWorkOut.DataStore.Entities;
using YourWorkOut.Services;

namespace YourWorkOut.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComplexListPage : ContentPage
    {
        ComplexService ComplexServices = new ComplexService();

        public ComplexListPage()
        {
            InitializeComponent();
            listComplexes.ItemsSource = ComplexServices.GetList().OrderBy(x=>x.Id);
        }

        async void OnAddComplexClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ComplexDetailPage());
        }

        async void OnComplexSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedComplex = e.SelectedItem as ComplexEntity;
            if (selectedComplex != null)
            {
                await Navigation.PushAsync(new ComplexDetailPage(selectedComplex));

                listComplexes.SelectedItem = null;
            }
        }
    }
}