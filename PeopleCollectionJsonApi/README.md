# Demo API

### Joe Kampschmidt

An adaptation of the [friends api sample](https://github.com/WebApiContrib/CollectionJson.Net) for education puproses.

## Required nuget packages

	Install-Package CollectionJson.Server
	Install-Package Microsoft.AspNet.WebApi.SelfHost
	Install-Package Autofac.WebApi2

## Gotchas

- Be careful of difference between `CollectionJson.Server.Compat.CollectionJsonController` vs `CollectionJson.Server.Compat.CollectionJson.Server`. Use the latter.

## Example Output

```json
{
  "collection": {
    "version": "1.0",
    "href": "http://localhost:9200/people/",
    "items": [
      {
        "href": "http://localhost:9200/people/1",
        "data": [
          {
            "name": "firstname",
            "value": "Joe",
            "prompt": "First Name"
          }
        ],
        "model": "person"
      },
      {
        "href": "http://localhost:9200/people/1",
        "data": [
          {
            "name": "firstname",
            "value": "Bob",
            "prompt": "First Name"
          }
        ],
        "model": "person"
      },
      {
        "href": "http://localhost:9200/people/1",
        "data": [
          {
            "name": "firstname",
            "value": "Sue",
            "prompt": "First Name"
          }
        ],
        "model": "person"
      }
    ],
    "queries": [
      {
        "rel": "search",
        "href": "http://localhost:9200/people",
        "prompt": "Search",
        "data": [
          {
            "name": "name",
            "prompt": "Value to match against the Full Name"
          }
        ]
      }
    ],
    "template": {
      "data": [
        {
          "name": "firstname",
          "prompt": "First Name"
        }
      ]
    }
  }
}
```