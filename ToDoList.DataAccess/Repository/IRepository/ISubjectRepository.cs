using System;
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
    public interface ISubjectRepository : IRepository<Subjects>
    {
        void Update(Subjects obj);
    }
}
