using EF_CORE.DAY_1.DATA;
using EF_CORE.DAY_1.MODELS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE.DAY_1.Services
{
    internal class BatchService
    {

        private readonly AppDbContext? _dbContext;
        public BatchService(AppDbContext _appDbContext)
        {
            _dbContext = _appDbContext;
        }

        public string AddSingleBatch(string courseId , string trainerId)
        {
            try
            {
                int.TryParse(courseId, out var intcourseId);
                int.TryParse(trainerId, out var inttrainerId);

                var course = _dbContext.Courses.First(course => course.Id == intcourseId);
                var trainer = _dbContext.Trainers.First(trainer => trainer.Id == inttrainerId);

                _dbContext.Batches.Add(new Batch { Course = course , Trainer = trainer});

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


    }
}
