using AndroidShowcase.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidShowcase.Business.Abstract
{
    public interface IAndroidShowcaseRepository
    {
        IEnumerable<Note> Notes();
        IEnumerable<Product> Products();
        void DeleteProduct(string productId, string userId);
        Product GetProduct(string productId, string userId);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
    }
}
