using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AdvContext();
            var tousLesProduits = context.Products;
            var tousLesVelos = context.Products
                .Where(x => x.ProductSubcategory.ProductCategory.Name == "Bikes")
                .ToList();

            tousLesVelos.ForEach(velo => velo.ListPrice /= 1.1M);
            context.SaveChanges();
        }
    }
}
