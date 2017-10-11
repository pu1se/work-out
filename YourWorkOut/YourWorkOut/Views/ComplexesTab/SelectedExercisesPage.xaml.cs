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
        ComplexService ComplexService = new ComplexService();
	    ExerciseService ExerciseService = new ExerciseService();
	    ComplexEntity SelectedComplex { get; }

        public SelectedExercisesPage (ComplexEntity selectedComplex)
		{
			InitializeComponent ();
		    Title = "Select Exercises";
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
	        var selectedItem = e.SelectedItem as SelectedExerciseViewModel;
	        if (selectedItem == null)
	            return;

	        
	        var list = (listExercises.ItemsSource as IEnumerable<SelectedExerciseViewModel>).ToList();
	        var item = list.FirstOrDefault(x => x.Id == selectedItem.Id);
	        item.IsSelected = !item.IsSelected;
	        list[list.IndexOf(item)] = item;
	        listExercises.ItemsSource = list;

            listExercises.SelectedItem = null;
        }

	    public async void OnSaveClicked(object sender, EventArgs e)
	    {
	        var list = (listExercises.ItemsSource as IEnumerable<SelectedExerciseViewModel>).ToList();
	        list = list.Where(x => x.IsSelected).ToList();
	        SelectedComplex.Exercise = ExerciseService.GetList().Where(x=>list.Select(y=>y.Id).Contains(x.Id)).ToList();
	        ComplexService.Save(SelectedComplex);

	        await Navigation.PopAsync();
	    }
    }
}