using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using AndroidShowcase.Business.Abstract;
using AndroidShowcase.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidShowcase.Business.Concrete
{
    public class AndroidShowcaseRepository : IAndroidShowcaseRepository
    {
        //private AndroidRepositoryContext context = new AndroidRepositoryContext();

        private AmazonDynamoDBClient client = new AmazonDynamoDBClient();

        public IEnumerable<Note> Notes()
        {
            ScanRequest scanRequest = new ScanRequest("androidshowcase-mobilehub-757025675-Notes");            
            ScanResult result = client.Scan(scanRequest);

            var notes = new List<Note>();

            foreach(var n in result.Items)
            {
                var note = new Note() { NoteTitle = n["noteId"].S, NoteId = n["userId"].S, NoteContent = n["content"].S };
                notes.Add(note);
            }

            return notes;
        }

        public IEnumerable<Product> Products()
        {
            ScanRequest scanRequest = new ScanRequest("Products");
            ScanResult result = client.Scan(scanRequest);

            var products = new List<Product>();

            foreach (var p in result.Items)
            {
                var product = new Product() { ProductId = p["ProductId"].S, Name = p["Name"].S, Description = p["Description"].S, Cost = Decimal.Parse(p["Cost"].N) };
                products.Add(product);
            }

            return products;
        }
    }
}
