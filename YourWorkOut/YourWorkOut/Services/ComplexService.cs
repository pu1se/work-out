using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWorkOut.DataStore.Entities;
using YourWorkOut.DataStore.Enums;
using YourWorkOut.ViewModels;

namespace YourWorkOut.Services
{
    public class ComplexService
    {
        public ExerciseService ExerciseService = new ExerciseService();
        private string ServiceKey = "ComplexList";
        private List<ComplexEntity> ComplexList { get; }

        public ComplexService()
        {
            appse
            if (App.Current.Properties.ContainsKey(ServiceKey) == false)
            {
                ComplexList = GetInitializedComplexList();
                App.Current.Properties[ServiceKey] = ComplexList;
            }
            ComplexList = App.Current.Properties[ServiceKey] as List<ComplexEntity>;
        }

        private List<ComplexEntity> GetInitializedComplexList()
        {
            var list = new List<ComplexEntity>
            {
                new ComplexEntity{Id=1, Name = "Complex 1", ComplexDurationTimeInSeconds = 60, DurationTimePerExerciseInSeconds = DurationEnum.s10},
                new ComplexEntity{Id=2, Name = "Complex 2", ComplexDurationTimeInSeconds = 30, DurationTimePerExerciseInSeconds = DurationEnum.s20},
                new ComplexEntity{Id=3, Name = "Complex 3", ComplexDurationTimeInSeconds = 120, DurationTimePerExerciseInSeconds = DurationEnum.s30},
                new ComplexEntity{Id=4, Name = "Complex 4", ComplexDurationTimeInSeconds = 120, DurationTimePerExerciseInSeconds = DurationEnum.s30},
            };

            var exersiciesList = ExerciseService.GetList();
            list[0].Exercise.AddRange(exersiciesList.Take(4));
            list[1].Exercise.AddRange(exersiciesList.Skip(4).Take(3));
            list[2].Exercise.AddRange(exersiciesList.Skip(7).Take(3));
            list[3].Exercise.AddRange(exersiciesList.Skip(8).Take(4));
            return list;
        }

        public List<ComplexEntity> GetList()
        {
            return ComplexList;
        }

        public ComplexEntity GetItem(int id)
        {
            return ComplexList.FirstOrDefault(x => x.Id == id);
        }

        public void Save(ComplexEntity complex)
        {
            ComplexList.Remove(ComplexList.First(x => x.Id == complex.Id));
            ComplexList.Add(complex);
            App.Current.Properties[ServiceKey] = ComplexList;
            App.Current.SavePropertiesAsync();
        }

    }
}
