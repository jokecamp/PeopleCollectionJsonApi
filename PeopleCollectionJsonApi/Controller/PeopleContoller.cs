using CollectionJson;
using CollectionJson.Client;
using CollectionJson.Server;
using PeopleCollectionJsonApi.DataAccess;
using PeopleCollectionJsonApi.Model;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PeopleCollectionJsonApi.Controller
{
    /// <summary>
    /// API Endpoint
    /// </summary>
    public class PeopleController : CollectionJsonController<Person>
    {
        private IPersonRepo repo;

        public PeopleController(IPersonRepo repo, ICollectionJsonDocumentWriter<Person> writer, ICollectionJsonDocumentReader<Person> reader)
            : base(writer, reader)
        {
            this.repo = repo;
        }

        protected override int Create(IWriteDocument writeDocument, HttpResponseMessage response)
        {
            var person = Reader.Read(writeDocument);
            return repo.Add(person);
        }

        protected override IReadDocument Read(HttpResponseMessage response)
        {
            var readDoc = Writer.Write(repo.GetAll());
            return readDoc;
        }

        protected override IReadDocument Read(int id, HttpResponseMessage response)
        {
            var person = repo.Get(id);
            if (person == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return Writer.Write(person);
        }
        
        public HttpResponseMessage Get(string name)
        {
            var friends = repo.GetAll().Where(f => f.Firstname.IndexOf(name, StringComparison.OrdinalIgnoreCase) > -1);
            var readDocument = Writer.Write(friends);
            return readDocument.ToHttpResponseMessage();
        }

        protected override IReadDocument Update(int id, IWriteDocument writeDocument, HttpResponseMessage response)
        {
            var person = Reader.Read(writeDocument);
            person.Id = id;
            repo.Update(person);
            return Writer.Write(person);
        }

        protected override void Delete(int id, HttpResponseMessage response)
        {
            repo.Remove(id);
        }
    }
}
