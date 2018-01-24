using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourWorkOut.DataStore.Entities;

namespace YourWorkOut.Views.ComplexesTab
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MakeingExercisePage : ContentPage
	{
        ComplexEntity SelectedComplex = new ComplexEntity();

		public MakeingExercisePage (ComplexEntity selectedComplex)
		{
			InitializeComponent ();
		    SelectedComplex = selectedComplex;

		    Title = "Executing " + SelectedComplex.Name;
		    selectedComplex.Exercise.Reverse();
            var exercises = new Stack<ExerciseEntity>(selectedComplex.Exercise);
		    
            
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                StartNewExercise(exercises, exercises.Count);
                return false;
            });

		}

	    public void StartNewExercise(Stack<ExerciseEntity> leftExercises, int numberOfAllExercises)
	    {
	        txtProgressExercises.Text = numberOfAllExercises - leftExercises.Count + " / " + numberOfAllExercises;
            progress.ProgressTo(100*(numberOfAllExercises - leftExercises.Count) * 1.0 / numberOfAllExercises, 500, Easing.Linear);
            
            if (leftExercises.Count == 0)
	        {
	            txtName.Text = "Your work out is completed";
	            imgImage.Source = null;
	            txtTimeLeft.Text = "You've crushed it!";
                return;
	        }


            /*var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
	        var file = EmbadedFilesHelper.GetAudio("beep-long.mp3");
	        player.Load(file);
	        player.Play();*/

            var currentExercise = leftExercises.Pop();

	        //await Audio.Manager.PlayBackgroundMusic("music.mp3");

            txtName.Text = currentExercise.Name;
	        imgImage.Source = currentExercise.Image;
	        var duration = int.Parse(SelectedComplex.DurationTimePerExerciseInSeconds.ToString().Substring(1));
	        txtTimeLeft.Text = duration.ToString();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
	        {
	            txtTimeLeft.Text = (--duration).ToString();

	            if (duration > 0)
	                return true;

                StartNewExercise(leftExercises, numberOfAllExercises);
	            return false;
	        });
        }
	}
}