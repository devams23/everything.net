using EF_CORE.DAY_1.DATA;
using EF_CORE.DAY_1.MODELS;
using EF_CORE.DAY_1.Utils;
using Microsoft.EntityFrameworkCore;


namespace EF_CORE.DAY_1.Services
{
    internal class TrainerService
    {
        private readonly AppDbContext? _dbContext;
        public TrainerService(AppDbContext _appDbContext)
        {
            _dbContext = _appDbContext;
        }


        public void ShowTrainerwithBatches()
        {
            var trainer_batches = _dbContext.Trainers.Include(trainer => trainer.Batches);

            foreach (var trainer in trainer_batches)
            {
                Console.WriteLine("Trainer : " + trainer.Name);
                foreach (var batch
                    in trainer.Batches)
                {
                    Console.WriteLine(batch.Id);
                }
            }
        }

        public bool DeleteTrainer(int TrainerId)
        {

            try
            {

                var ExistingTrainers = _dbContext.Trainers.ToList();
                var ToBeDeleted = _dbContext.Trainers.FirstOrDefault(trainer => trainer.Id == TrainerId);

                ExistingTrainers.Remove(ToBeDeleted);

                _dbContext.SaveChanges();
                Console.WriteLine("SUCCESS!" + "TRAINER REMOVED");
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }

}
