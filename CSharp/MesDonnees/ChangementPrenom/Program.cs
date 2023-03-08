using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangementPrenom
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AdvContext();
            var ken = context.Person
                .Where(x => x.FirstName == "Ken")
                .ToList();

            ken.ForEach(k => k.FirstName = "Bobby");
            context.SaveChanges();
        }
    }
}
