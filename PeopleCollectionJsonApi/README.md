# Demo API

### Joe Kampschmidt

An adaptation of the [friends api sample](https://github.com/WebApiContrib/CollectionJson.Net) for education puproses.

## Required nuget packages

	Install-Package CollectionJson.Server
	Install-Package Microsoft.AspNet.WebApi.SelfHost
	Install-Package Autofac.WebApi2

## Gotchas

- Be careful of difference between `CollectionJson.Server.Compat.CollectionJsonController` vs `CollectionJson.Server.Compat.CollectionJson.Server`. Use the latter.