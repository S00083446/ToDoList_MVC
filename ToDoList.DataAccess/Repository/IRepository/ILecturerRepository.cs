using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using ToDoListModels;

namespace ToDoList.DataAccess.Repository.IRepository
{
    public interface ILecturerRepository : IRepository<Lecturer>
    {
        void Update(Lecturer obj);
    }
}
