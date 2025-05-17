namespace NIC_PRACTICAL.Services
{
    public interface IStudent<S> where S : class
    {
        IEnumerable<S> GetStudents();
        S GetById(int id);
        void Add(S entity);
        void Update(S entity);
        void Delete(int id);
    }

}
