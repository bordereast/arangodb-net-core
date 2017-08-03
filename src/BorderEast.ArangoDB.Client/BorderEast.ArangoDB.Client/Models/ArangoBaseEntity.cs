using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Models
{
    /// <summary>
    /// Base entity class which all entities must inherit from
    /// </summary>
    public class ArangoBaseEntity {

        /// <summary>
        /// Id in format 'collection/key'. Only set internally. Use _id in ad hoc queries.
        /// </summary>
        [JsonProperty(PropertyName = "_id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; internal set; }

        /// <summary>
        /// Primary key of entity, as as you would the Id in other databases. Use _key in ad hoc queries.
        /// </summary>
        [JsonProperty(PropertyName = "_key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        /// <summary>
        /// Revision of entity. Use _rev in ad hoc queries.
        /// </summary>
        [JsonProperty(PropertyName = "_rev", NullValueHandling = NullValueHandling.Ignore)]
        public string Revision { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedFunction { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public string UpdatedFunction { get; set; }
    }
}
