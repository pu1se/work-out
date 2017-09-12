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
