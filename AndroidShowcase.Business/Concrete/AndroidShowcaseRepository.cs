using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
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
                var product = new Product() { UserId = p["UserId"].S, ProductId = p["ProductId"].S, Name = p["Name"].S, Description = p["Description"].S, Cost = Decimal.Parse(p["Cost"].N) };
                products.Add(product);
            }

            return products;
        }

        public void DeleteProduct(string productId, string userId)
        {
            string tableName = "Products";

            var request = new DeleteItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "UserId", new AttributeValue { S = userId } }, { "ProductId", new AttributeValue { S = productId } } },
            };

            var response = client.DeleteItem(request);
        }

        public Product GetProduct(string productId, string userId)
        {
            string tableName = "Products";

            var request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "UserId", new AttributeValue { S = userId } }, { "ProductId", new AttributeValue { S = productId } } },
            };

            var p = client.GetItem(request);

            return new Product() { UserId = p.Item["UserId"].S, ProductId = p.Item["ProductId"].S, Name = p.Item["Name"].S, Description = p.Item["Description"].S, Cost = Decimal.Parse(p.Item["Cost"].N) };
        }

        public void InsertProduct(Product product)
        {
            var context = new DynamoDBContext(client);

            var newProduct = new Product
            {
                UserId = "us-east-1:84e7f96b-d785-4f5e-beb8-7fc988078558",
                ProductId = Guid.NewGuid().ToString(),
                Name = product.Name,
                Description = product.Description,
                Cost = product.Cost

            };            

            context.Save(newProduct);       
        }

        public void UpdateProduct(Product product)
        {
            var context = new DynamoDBContext(client);

            var productRetrived = context.Load<Product>(product.UserId, product.ProductId);

            productRetrived.Name = product.Name;
            productRetrived.Description = product.Description;
            productRetrived.Cost = product.Cost;

            context.Save(product);         
        }
    }
}
