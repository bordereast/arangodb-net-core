## BorderEast.ArangoDB.Client
.NETCoreApp1.1 ArangoDB Client Driver

[![Build Status](https://travis-ci.org/bordereast/arangodb-net-core.svg?branch=master)](https://travis-ci.org/bordereast/arangodb-net-core)

Contributions welcome, follow code style.

### AQL Based
For those who like to write pure AQL queries for ultimate flexibility. This will mainly focus on AQL string queries at first with convience methods for Insert, Update, Delete etc.

### Managed Foreign Keys
Currently working on a managed foreign key feature. This will allow an entity to include another entity with a data annotation describing the foreign key. This will produce two tables in the database but allow users to work the entity as if it was a single document. Understanding that this is duplicating some relational database features, this is the most common feature lacking in client libraries.

ArangoDB has an excellent join feature via AQL, and this is the next logical step on the client side.

### Connection Pools
This client manages connection pools. It has two connection pools, one for HTTP and one for VelocyStream(not implemented yet). All methods are Async and a connection is obtained immediatly before use and released immediatly afterwards. This is handled internally, so consumers won't need to worry about closing connections. Also, each HTTPClient object is left undisposed, but only used by one Database instance at a time. This cuts down on overhead of new connections but makes connection use consistent between the HTTP and yet to be implemented TCP protocols.

### Other Features
Document Update (PATCH) now returns the Arango old revision and new document. Will probably make this configurable to save network traffic. An UpdatedDocument class is returned from the `Client.DB().Update<T>(id, item)` method.

### Feature Status
Method | Status
--- | --- 
AQL Query | WIP
GetByKeyAsync | Done
UpdateAsync | Done
DeleteAsync | Done
InsertAsync | Done

### Credits
Based loosely on ideas taken from [ra0o0f](https://github.com/ra0o0f/arangoclient.net) and [yojimbo87](https://github.com/yojimbo87/ArangoDB-NET), this is a .NETCoreApp1.1 version.
