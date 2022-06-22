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
    public class SubjectRepository : Repository<Subjects>, ISubjectRepository
    {
        private readonly ApplicationDbContext _db;

        public SubjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        //public void Save()
        //{
        //    _db.SaveChanges();
        //    //throw new NotImplementedException();
        //}

        public void Update(Subjects obj)
        {
            _db.Subjects.Update(obj);
            //throw new NotImplementedException();
        }
    }
}
