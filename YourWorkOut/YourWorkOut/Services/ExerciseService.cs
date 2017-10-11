using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWorkOut.DataStore.Entities;

namespace YourWorkOut.Services
{
    public class ExerciseService
    {
        private List<ExerciseEntity> List { get; set; }

        public ExerciseService()
        {
            var imageName = new Func<int, string>( id => "exercise-" + id + ".png" );

            List = new List<ExerciseEntity>
            {
                new ExerciseEntity{Id = 1, Name = "Jumping jacks"},
                new ExerciseEntity{Id = 2, Name = "Push up"},
                new ExerciseEntity{Id = 3, Name = "tmp 3"},
                new ExerciseEntity{Id = 4, Name = "tmp 3"},
                new ExerciseEntity{Id = 5, Name = "tmp 3"},
                new ExerciseEntity{Id = 6, Name = "tmp 3"},
                new ExerciseEntity{Id = 7, Name = "tmp 3"},
                new ExerciseEntity{Id = 8, Name = "tmp 3"},
                new ExerciseEntity{Id = 9, Name = "tmp 3"},
                new ExerciseEntity{Id = 10, Name = "tmp 10"},
                new ExerciseEntity{Id = 11, Name = "tmp 11"},
                new ExerciseEntity{Id = 12, Name = "tmp 12"},
                new ExerciseEntity{Id = 13, Name = "tmp 13"},
            };

            foreach (var item in List)
            {
                item.Image = EmbadedFilesHelper.GetImage(imageName(item.Id));
            }
        }

        public List<ExerciseEntity> GetList()
        {
            return List;
        }

        public ExerciseEntity GetItem(int id)
        {
            return List.FirstOrDefault(x=>x.Id == id);
        }
    }
}
