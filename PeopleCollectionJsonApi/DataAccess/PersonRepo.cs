using PeopleCollectionJsonApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace PeopleCollectionJsonApi.DataAccess
{
    public class PersonRepo : IPersonRepo
    {
        public List<Person> _people = new List<Person>();

        public PersonRepo()
        {
            _people = new List<Person>() {
                new Person{ Id = 1, Firstname = "Joe" },
                new Person{ Id = 1, Firstname = "Bob" },
                new Person{ Id = 1, Firstname = "Sue" }
            };
        }

        public IEnumerable<Person> GetAll()
        {
            return _people;
        }

        public Person Get(int id)
        {
            return _people.FirstOrDefault(x => x.Id == id);
        }

        public int Add(Person person)
        {
            person.Id = _people.Max(X => X.Id) + 1;
            _people.Add(person);
            return person.Id;

        }

        public void Update(Person person)
        {
            var existing = Get(person.Id);
            existing.Firstname = person.Firstname;
        }

        public void Remove(int id)
        {
            var existing = Get(id);
            _people.Remove(existing);
        }
    }
}
