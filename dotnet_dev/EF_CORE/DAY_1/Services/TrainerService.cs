using EF_CORE.DAY_1.DATA;
using EF_CORE.DAY_1.MODELS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
    }

}
