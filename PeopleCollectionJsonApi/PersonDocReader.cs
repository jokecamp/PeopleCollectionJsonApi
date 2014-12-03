using CollectionJson;
using PeopleCollectionJsonApi.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace PeopleCollectionJsonApi
{
    public class PersonDocReader : ICollectionJsonDocumentReader<Person>
    {
        public Person Read(IWriteDocument document)
        {
            var template = document.Template;
            var p = new Person();
            p.Firstname = template.Data.GetDataByName("firstname").Value;
            return p;
        }
    }

    public class PersonDocWriter : ICollectionJsonDocumentWriter<Person>
    {
        private readonly Uri _requestUri;

        public PersonDocWriter(HttpRequestMessage request)
        {
            _requestUri = request.RequestUri;
        }

        public IReadDocument Write(IEnumerable<Person> people)
        {
            var document = new ReadDocument();
            var collection = new Collection { Version = "1.0", Href = new Uri(_requestUri, "/people/") };
            document.Collection = collection;

            //collection.Links.Add(new Link { Rel = "Feed", Href = new Uri(_requestUri, "/people/rss") });

            foreach (var p in people)
            {
                if (p != null)
                {
                    var item = new Item { Href = new Uri(_requestUri, "/people/" + p.Id) };
                    item.Extensions().Model = "person";

                    item.Data.Add(new Data { Name = "firstname", Value = p.Firstname, Prompt = "First Name" });
                    collection.Items.Add(item);
                }
                else
                {
                    collection.Extensions().Error = new CollectionJson.Error() { Code = "404", Message = "Person not found", Title = "Missing Person" };
                }
            }

            var query = new Query { Rel = "search", Href = new Uri(_requestUri, "/people"), Prompt = "Search" };
            query.Data.Add(new Data { Name = "name", Prompt="Value to match against the Full Name" });
            collection.Queries.Add(query);

            var data = collection.Template.Data;
            data.Add(new Data { Name = "firstname", Prompt = "First Name" });
            return document;
        }
    }

}
