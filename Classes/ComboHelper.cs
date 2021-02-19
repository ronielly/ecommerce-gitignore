using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Classes
{
    public class ComboHelper : IDisposable
    {
        private static EcommerceContext db = new EcommerceContext();

        public static List<Departaments> GetDepartaments()
        {
            var departaments = db.Departaments.ToList();
            departaments.Add(new Departaments
            {
                DepartamentsId = 0,
                Name = "[ Select the departament ]"
            });

            departaments = departaments.OrderBy(d => d.Name).ToList();

            return departaments;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}