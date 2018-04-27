using System.Collections.Generic;

namespace testDatatable.Models
{
    public interface IEmployeeRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Remove(int id);
        void Update(T item);
        void Save();
    }
}
