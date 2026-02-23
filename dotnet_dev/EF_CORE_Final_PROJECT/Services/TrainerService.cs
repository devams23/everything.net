using EF_CORE_Final_PROJECT.Data;
using EF_CORE_Final_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE_Final_PROJECT.Services
{
    internal class TrainerService
    {
        private readonly AppDbContext _context;
        public TrainerService(AppDbContext context)
        {
            _context = context;
        }

        public void AddTrainer(Trainer trainer)
        {
            try
            {
                _context.Trainers.Add(trainer);

                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Trainer> GetAllTrainers()
        {
            try
            {
                var trainers = _context.Trainers.ToList();
                if (trainers.Count !=0)
                {
                    return trainers;   
                }

               else
                {
                    Console.WriteLine("No trainers found.");
                    return new List<Trainer>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Trainer>();
            }

        }



    }
}