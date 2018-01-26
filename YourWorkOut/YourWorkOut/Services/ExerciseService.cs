using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWorkOut.DataStore.Entities;

namespace YourWorkOut.Services
{
    public class ExerciseService : BaseService<List<ExerciseEntity>>
    {
        private List<ExerciseEntity> ExerciseList { get; set; }

        public ExerciseService()
        {
            ExerciseList = GetData();
            if (ExerciseList == null)
            {
                ExerciseList = GetInitializedExerciseList();
                SaveData(ExerciseList);
            }
        }

        private List<ExerciseEntity> GetInitializedExerciseList()
        {
            var imageName = new Func<int, string>(id => "exercise-" + id + ".png");
            var list = new List<ExerciseEntity>
            {
                new ExerciseEntity{Id = 1, Name = "Jumping jacks"},
                new ExerciseEntity{Id = 2, Name = "Wall sit"},
                new ExerciseEntity{Id = 3, Name = "Push-up"},
                new ExerciseEntity{Id = 4, Name = "Abdominal crunch"},
                new ExerciseEntity{Id = 5, Name = "Step-up onto chair"},
                new ExerciseEntity{Id = 6, Name = "Squat"},
                new ExerciseEntity{Id = 7, Name = "Triceps dip on chair"},
                new ExerciseEntity{Id = 8, Name = "Plank"},
                new ExerciseEntity{Id = 9, Name = "High knees"},
                new ExerciseEntity{Id = 10, Name = "Lunge"},
                new ExerciseEntity{Id = 11, Name = "Push-up and rotation"},
                new ExerciseEntity{Id = 12, Name = "Side plank (left)"},
                new ExerciseEntity{Id = 13, Name = "Side plank (right)"},
            };

            foreach (var item in list)
            {
                item.ImageAsBytes = FileManager.EmbadedResource.GetImage(imageName(item.Id));
            }
            return list;
        }

        public List<ExerciseEntity> GetList()
        {
            return ExerciseList;
        }

        public ExerciseEntity GetItem(int id)
        {
            return ExerciseList.FirstOrDefault(x=>x.Id == id);
        }

        public void Save(ExerciseEntity complex)
        {
            ExerciseList.Remove(ExerciseList.First(x => x.Id == complex.Id));
            ExerciseList.Add(complex);
            SaveData(ExerciseList);
        }
    }
}
