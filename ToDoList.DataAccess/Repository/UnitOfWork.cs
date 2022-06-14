using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoListModels;

namespace ToDoList.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Subjects = new SubjectRepository(_db);
            Detail = new DetailRepository(_db);
        }
        public ISubjectRepository Subjects { get; private set; }
        public IDetailRepository Detail { get; private set; }


        public void Save()
        {
            _db.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
