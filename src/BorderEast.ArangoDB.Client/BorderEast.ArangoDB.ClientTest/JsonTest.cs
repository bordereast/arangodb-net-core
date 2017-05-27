using BorderEast.ArangoDB.Client.Database;
using BorderEast.ArangoDB.ClientTest.MockData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BorderEast.ArangoDB.ClientTest
{
    public class JsonTest
    {

        private JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new ArangoDBContractResolver(),
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
                Name = "Some Author"
            };

            var jsonStr = JsonConvert.SerializeObject(author, JsonSettings);

            Assert.DoesNotContain("Name", jsonStr);
            Assert.Contains("name", jsonStr);
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
