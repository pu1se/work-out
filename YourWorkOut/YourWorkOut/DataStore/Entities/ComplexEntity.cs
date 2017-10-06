using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWorkOut.DataStore.Enums;

namespace YourWorkOut.DataStore.Entities
{
    public class ComplexEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DurationTimeInSeconds { get; set; }
        public DurationEnum DurationTimePerExerciseInSeconds { get; set; } = DurationEnum.s30;
        public List<ExerciseEntity> Exercise { get; set; } = new List<ExerciseEntity>();
    }
}
