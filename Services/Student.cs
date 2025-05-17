using NIC_PRACTICAL.Models;
using NIC_PRACTICAL.Repository;
using System.Diagnostics.Eventing.Reader;

namespace NIC_PRACTICAL.Services
{
    public class Student<S> : IStudent<S> where S :class
    {
        private readonly ApplicationDBContext _ctx;
        public Student()
        {
            _ctx= new ApplicationDBContext();
        }

        public void Add(S entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public S GetById<S>(int id)
        {
            return _ctx.StudentDetails.Where(s=>s.Id==id);
            //throw new NotImplementedException();
        }

        public IEnumerable<S> GetStudents()
        {
            throw new NotImplementedException();
        }

        public void Update(S entity)
        {
            throw new NotImplementedException();
        }
        //private readonly IRepository _repo;
    }
}
