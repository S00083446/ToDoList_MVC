using ToDoList.DataAccess.Repository.IRepository;
using ToDoListModels;

namespace ToDoListWeb.Controllers
{
    public interface ISubjectRepository : IRepository<Subjects>
    {
        void Update(Subjects obj);
        void Save();
    }
}