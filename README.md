## BorderEast.ArangoDB.Client
DotNetCore ArangoDB Driver, WIP

Based loosely on ideas taken from [ra0o0f](https://github.com/ra0o0f/arangoclient.net) and [yojimbo87](https://github.com/yojimbo87/ArangoDB-NET), this is a .NETCoreApp1.1 ArangoDB Client Library.

### AQL Based
I like to write AQL queries for ultimate flexibility. This will mainly focus on AQL string queries at first with convience methods for Insert, Update, Delete etc.

### Managed Foreign Keys
I'm currently working on a managed foreign key feature. This will allow an entity to include another entity with a data annotation describing the foreign key. This will produce two tables in the database but allow users to work the entity as if it was a single document. I understand this is duplicating some relational database features, but I feel this is the most common feature lacking in client libraries. I don't feel this should be a database feature, as a Document based database shouldn't care how you model the data.

ArangoDB has an excellent join feature via AQL, and this is the next logical step on the client side.
