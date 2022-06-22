using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ISubjectRepository Subjects { get; }
        IDetailRepository Detail { get; }
        ILecturerRepository Lecturer { get; }

        void Save();

    }
}
