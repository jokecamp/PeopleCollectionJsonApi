using PeopleCollectionJsonApi.Model;
using System.Collections.Generic;

namespace PeopleCollectionJsonApi.DataAccess
{
    public interface IPersonRepo
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        int Add(Person person);
        void Update(Person person);
        void Remove(int id);
    }
}
