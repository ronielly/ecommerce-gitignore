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

            return departaments = departaments.OrderBy(d => d.Name).ToList();
        }

        public static List<Cities> GetCities()
        {
            var cities = db.Cities.ToList();
            cities.Add(new Cities
            {
                CitiesId = 0,
                Name = "[ Select the cities]"
            });

            return cities = cities.OrderBy(c => c.Name).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}