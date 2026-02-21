using EF_CORE.DAY_1.DATA;
using EF_CORE.DAY_1.MODELS;
using Microsoft.EntityFrameworkCore;


namespace EF_CORE.DAY_1.Services
{
    internal class BatchService
    {

        private readonly AppDbContext? _dbContext;
        public BatchService(AppDbContext _appDbContext)
        {
            _dbContext = _appDbContext;
        }

        public int? AddSingleBatch(int courseId , int trainerId , DateTime date )
        {
            try
            {

                //int.TryParse(courseId, out var intcourseId);
                //int.TryParse(trainerId, out var inttrainerId);

                var course = _dbContext.Courses.First(course => course.Id == courseId);
                var trainer = _dbContext.Trainers.First(trainer => trainer.Id == trainerId);

                _dbContext.Batches.Add(new Batch { Course = course , Trainer = trainer , StartDate = date});

                _dbContext.SaveChanges();
                return courseId;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void getTrainers()
        {
            var trainers = _dbContext?.Trainers.Include(trainer => trainer.Batches);

            var batches = _dbContext.Students.Include(trainer => trainer.Courses).ThenInclude(course => course.Batches);

            foreach (var item in batches)
            {
                Console.WriteLine();
            }


        }

      
        // this is N+1 query Problem Function

        public void GetBatchWithCourses()
        {
            var batches = _dbContext.Batches.ToList();

            foreach (var batch in batches)
            {
                Console.WriteLine(batch.Course.Title);
            }
        }

    }
}
