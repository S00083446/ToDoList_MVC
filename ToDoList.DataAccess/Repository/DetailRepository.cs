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
            var objFromDb = _db.SubjectDetails.FirstOrDefault( u => u.Id == obj.Id); // ok once inside repository, never outside of repo
            if (objFromDb != null)
            {
                //objFromDb.Title = obj.Title;
                //objFromDb.ISBN = obj.ISBN;
                //objFromDb.Price = obj.Price;
                //objFromDb.Price50 = obj.Price50;
                //objFromDb.ListPrice = obj.ListPrice;
                //objFromDb.Price100 = obj.Price100;
                //objFromDb.Description = obj.Description;
                //objFromDb.SubjectId = obj.SubjectId;
                //objFromDb.Author = obj.Author;
                //objFromDb.CoverTypeId = obj.CoverTypeId;
                //if (obj.ImageURL != null)
                //{
                //    objFromDb.ImageURL = obj.ImageURL;
                //}

                // restrict update, rather than update all
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
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
            throw new NotImplementedException();
        }
    }
}
