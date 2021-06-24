using Models.DataContext;
using Models.Entities;
using Services.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.DataService
{
    public class StudentService : GenericRepository<Student>, IStudentService
    {
        private readonly EfDbContext _context;
        public StudentService(EfDbContext context) : base(context)
        {
            _context = context;
        }

      
    }
}



