using EF_CORE_Final_PROJECT.Data;
using EF_CORE_Final_PROJECT.Models;


namespace EF_CORE_Final_PROJECT.Services
{
    internal class TrainingProgramService
    {
        private readonly AppDbContext _context;
        public TrainingProgramService(AppDbContext context)
        {
            _context = context;
        }

        public void AddTrainingProgram(TrainingProgram trainingProgram)
        {
            try
            {
                _context.TrainingPrograms.Add(trainingProgram);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void RemoveTrainingProgram(int trainingProgramId)
        {
            try
            {
            var trainingProgramtobeRemoved = _context.TrainingPrograms.FirstOrDefault(tp => tp.Id == trainingProgramId);

            if (trainingProgramtobeRemoved != null)
            {
                _context.TrainingPrograms.Remove(trainingProgramtobeRemoved);
            }

                _context.SaveChanges();

                Console.WriteLine("Training Program Removed Successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<TrainingProgram> GetAllTrainings()
        {
            try
            {
                var trainingPrograms = _context.TrainingPrograms.ToList();
                if (trainingPrograms.Count != 0)
                {
                    return trainingPrograms ;
                }
                else
                {
                    return new List<TrainingProgram>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<TrainingProgram>();
            }
        }

    }
}
