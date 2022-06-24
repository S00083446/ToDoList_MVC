using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoListModels;

namespace ToDoList.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            // Initialising our Repositories
            _db = db;
            Subjects = new SubjectRepository(_db);
            Detail = new DetailRepository(_db);
            Lecturer = new LecturerRepository(_db);
            MoreDetails = new MoreDetailsRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }
        public ISubjectRepository Subjects { get; private set; }
        public IDetailRepository Detail { get; private set; }
        public ILecturerRepository Lecturer { get; private set; }
        public IMoreDetailsRepository MoreDetails { get; private set; }
        public IApplicationUserRepository ApplicationUser{ get; private set; }

        public void Save()
        {
            _db.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
