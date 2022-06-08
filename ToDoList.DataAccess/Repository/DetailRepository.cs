using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoListModels;

namespace ToDoList.DataAccess.Repository
{
    public class DetailRepository : Repository<Detail>, IDetailRepository
    {
        private readonly ApplicationDbContext _db;

        public DetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        //public void Save()
        //{
        //    _db.SaveChanges();
        //    //throw new NotImplementedException();
        //}

        public void Update(Detail obj)
        {
            //_db.Details.Update(obj); // Drawback is we update all
            var objFromDb = _db.Details.FirstOrDefault( u => u.Id == obj.Id); // ok once inside repository, never outside of repo
            if (objFromDb != null)
            {
                // restrict update, rather thatn update all
                objFromDb.Description = obj.Description;
                objFromDb.StartDate = obj.StartDate;
                objFromDb.EndDate = obj.EndDate;
                objFromDb.DaysUntilEvent = obj.DaysUntilEvent;
                objFromDb.StartTime = obj.StartTime;
                objFromDb.Location = obj.Location;
                objFromDb.RoomName = obj.RoomName;
                objFromDb.Notes = obj.Notes;
                objFromDb.Cost = obj.Cost;
                objFromDb.PercentageOfTotalMarks = obj.PercentageOfTotalMarks;
                objFromDb.NumberOfParticpants = obj.NumberOfParticpants;
                objFromDb.SubjectsId = obj.SubjectsId;
                objFromDb.CoverTypeId = obj.CoverTypeId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }




            }
            //throw new NotImplementedException();
        }
    }
}
