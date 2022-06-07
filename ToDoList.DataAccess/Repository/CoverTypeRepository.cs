using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoListModels;

namespace ToDoList.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        //public void Save()
        //{
        //    _db.SaveChanges();
        //    //throw new NotImplementedException();
        //}

        public void Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
            //throw new NotImplementedException();
        }
    }
}
