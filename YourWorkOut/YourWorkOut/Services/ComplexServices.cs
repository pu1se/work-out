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
    public class ComplexServices
    {
        public ExerciseService ExerciseService = new ExerciseService();
        private List<ComplexEntity> ComplexList { get; }

        public ComplexServices()
        {
            ComplexList = new List<ComplexEntity>
            {
                new ComplexEntity{Id=1, Name = "Complex 1", DurationTimeInSeconds = 60, DurationTimePerExerciseInSeconds = DurationEnum.s10},
                new ComplexEntity{Id=2, Name = "Complex 2", DurationTimeInSeconds = 30, DurationTimePerExerciseInSeconds = DurationEnum.s20},
                new ComplexEntity{Id=3, Name = "Complex 3", DurationTimeInSeconds = 120, DurationTimePerExerciseInSeconds = DurationEnum.s30},
                new ComplexEntity{Id=4, Name = "Complex 4", DurationTimeInSeconds = 120, DurationTimePerExerciseInSeconds = DurationEnum.s30},                
            };

            var exersiciesList = ExerciseService.GetList();
            ComplexList[0].Exercise.AddRange(exersiciesList.Take(4));
            ComplexList[1].Exercise.AddRange(exersiciesList.Skip(4).Take(3));
            ComplexList[2].Exercise.AddRange(exersiciesList.Skip(7).Take(3));
            ComplexList[3].Exercise.AddRange(exersiciesList.Skip(8).Take(4));
        }

        public List<ComplexEntity> GetList()
        {
            return ComplexList;
        }

        public ComplexEntity GetItem(int id)
        {
            return ComplexList.FirstOrDefault(x => x.Id == id);
        }
    }
}
