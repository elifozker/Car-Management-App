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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = addedEntity.State = EntityState.Added; // eklenecek nesne
                context.SaveChanges(); // ekle
            }
        }

        public void Delete(Brand entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var deletedEntity = context.Entry(entity); // referansı yakala
                deletedEntity.State = EntityState.Deleted; // eklenecek nesne
                context.SaveChanges(); // ekle
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);

            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return filter == null ?
                    context.Set<Brand>().ToList()// filtre null ise bu çalışır (//db setteki oraya yerleş ve list olarak döndür)
                    : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
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
