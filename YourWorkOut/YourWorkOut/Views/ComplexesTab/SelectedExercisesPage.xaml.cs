using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourWorkOut.DataStore.Entities;
using YourWorkOut.Services;
using YourWorkOut.ViewModels;

namespace YourWorkOut.Views.ComplexesTab
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectedExercisesPage : ContentPage
	{
	    ExerciseService ExerciseService = new ExerciseService();
	    ComplexEntity SelectedComplex { get; }

        public SelectedExercisesPage (ComplexEntity selectedComplex)
		{
			InitializeComponent ();
		    Title = "Select Exercises for Complex";
		    SelectedComplex = selectedComplex;
		    var exercises = ExerciseService.GetList().Select(x=> new SelectedExerciseViewModel
		    {
		        Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                IsSelected = selectedComplex.Exercise.Select(y=>y.Id).Contains(x.Id)
		    }).ToList();

		    listExercises.ItemsSource = exercises;
		}


	    async void OnExerciseSelected(object sender, SelectedItemChangedEventArgs e)
	    {

	    }
    }
}