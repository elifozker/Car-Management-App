using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var addedEntity = context.Entry(entity); // referansı yakala
                addedEntity.State = EntityState.Added; // eklenecek nesne
                context.SaveChanges(); // ekle
            }
        }

        public void Delete(Car entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var deletedEntity = context.Entry(entity); // referansı yakala
                deletedEntity.State = EntityState.Deleted; // eklenecek nesne
                context.SaveChanges(); // ekle
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);

            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return filter == null ?
                    context.Set<Car>().ToList()// filtre null ise bu çalışır (//db setteki oraya yerleş ve list olarak döndür)
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var updatedEntity = context.Entry(entity); // referansı yakala
                updatedEntity.State = EntityState.Modified; // eklenecek nesne
                context.SaveChanges(); // ekle
            }
        }
    }
}
