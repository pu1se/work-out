using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourWorkOut.Services;

namespace YourWorkOut.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisesListPage : ContentPage
    {
        public ExerciseService Service { get; private set; }

        public ExercisesListPage()
        {
            InitializeComponent();
            Service = new ExerciseService();
            listExercises.ItemsSource = Service.GetList();
            Title = "Exercises";
        }

        async void OnAddExerciseClicked(object sender, EventArgs e)
        {
        }

        async void OnExerciseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
    }
}