using BorderEast.ArangoDB.Client.Database;
using BorderEast.ArangoDB.ClientTest.MockData;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BorderEast.ArangoDB.ClientTest
{
    public class JsonTest
    {

        private readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new ArangoDBContractResolver(),
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            NullValueHandling = NullValueHandling.Include,
            DefaultValueHandling = DefaultValueHandling.Include,
            StringEscapeHandling = StringEscapeHandling.Default,
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        private readonly JsonSerializerSettings JsonSettingsCamelCase = new JsonSerializerSettings
        {
            ContractResolver = new ArangoDBContractResolver(new CamelCaseNamingStrategy()),
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            NullValueHandling = NullValueHandling.Include,
            DefaultValueHandling = DefaultValueHandling.Include,
            StringEscapeHandling = StringEscapeHandling.Default,
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        [Fact]
        public void NullListTest() {

            var author = new Author()
            {
                Name = "Some Author"
            };

            var jsonStr = JsonConvert.SerializeObject(author, JsonSettings);

            Author auth = JsonConvert.DeserializeObject<Author>(jsonStr);

            Assert.NotNull(auth.Books);
        }

        [Fact]
        public void CamelCaseTest() {

            var author = new Author()
            {
                Name = "Some Author",
                camelName = "Some Author"
            };

            // Default is now same case as object name
            var jsonStr = JsonConvert.SerializeObject(author, JsonSettings);

            Assert.DoesNotContain("name", jsonStr);
            Assert.Contains("Name", jsonStr);
            Assert.Contains("camelName", jsonStr);

            jsonStr = JsonConvert.SerializeObject(author, JsonSettingsCamelCase);

            Assert.DoesNotContain("\"Name", jsonStr, StringComparison.InvariantCulture);
            Assert.Contains("name", jsonStr);
            Assert.Contains("camelName", jsonStr);
        }

        [Fact]
        public void ForeignKeyTest() {

            var author = new Author()
            {
                Name = "Some Author",
                Key = "newauth",
                Books = new List<Book>()
                {
                    new Book()
                    {
                        Key = "newbook",
                        Name = "A Book Title"
                    }
                }
            };

            var jsonStr = JsonConvert.SerializeObject(author, JsonSettings);

            // foreign key converter should only serialize the book key
            Assert.DoesNotContain(author.Books.First().Name, jsonStr);
        }
    }
}
