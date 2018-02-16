## BorderEast.ArangoDB.Client
[![Build Status](https://travis-ci.org/bordereast/arangodb-net-core.svg?branch=master)](https://travis-ci.org/bordereast/arangodb-net-core)

.NETCoreApp 2.0 ArangoDB Client Driver

Contributions welcome.

### AQL Based
For those who like to write pure AQL queries for ultimate flexibility. This will mainly focus on AQL string queries at first with convience methods for Insert, Update, Delete etc.

### Managed Foreign Keys
This client supports a managed foreign key feature. This allowa an entity to include a `List<T>` of another entity by setting a data annotation. This will work with two tables in the database but allow users to work the entity as if it was a single document. While this is duplicating some relational database features, this is the most common feature lacking in client libraries.

ArangoDB has an excellent join feature via AQL, and this is the next logical step on the client side. [Please see the documentation for examples](https://github.com/bordereast/arangodb-net-core/wiki)

### Connection Pools
This client manages connection pools. It has two connection pools, one for HTTP and one for VelocyStream(not implemented yet). All methods are Async and a connection is obtained immediatly before use and released immediatly afterwards. This is handled internally, so consumers won't need to worry about closing connections. Also, each HTTPClient object is left undisposed, but only used by one Database instance at a time. This cuts down on overhead of new connections but makes connection use consistent between the HTTP and yet to be implemented TCP protocols. Configurable to use the same HTTPClient for all connections, or differnt per connection. 

### Other Features
Document Update (PATCH) now returns the Arango old revision and new document. Will probably make this configurable to save network traffic. An UpdatedDocument class is returned from the `Client.DB().Update<T>(id, item)` method.

### Feature Status
Method | Status | Foreign Key Support
--- | --- | ---
AQL Query | Done | Manual
GetByKeyAsync | Done | Auto
UpdateAsync | Done | Auto
DeleteAsync | Done | N/A
InsertAsync | Done | Auto
InsertManyAsync | Done | Auto
GetAllAsync | Done | Auto
GetAllKeysAsync | Done | N/A
GetByExampleAsync | Done | Auto
CreateCollection | Done | N/A

### Credits
Based loosely on ideas taken from [ra0o0f](https://github.com/ra0o0f/arangoclient.net) and [yojimbo87](https://github.com/yojimbo87/ArangoDB-NET), this is a .NETCoreApp2 library.

#### Contributions by

https://github.com/irriss

https://github.com/Arkos-LoG

