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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var addedEntity = context.Entry(entity); // referansı yakala
                addedEntity.State = EntityState.Added; // eklenecek nesne
                context.SaveChanges(); // ekle
            }
        }

        public void Delete(Color entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var deletedEntity = context.Entry(entity); // referansı yakala
                deletedEntity.State = EntityState.Deleted; // eklenecek nesne
                context.SaveChanges(); // ekle
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);

            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return filter == null ?
                    context.Set<Color>().ToList()// filtre null ise bu çalışır (//db setteki oraya yerleş ve list olarak döndür)
                    : context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
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
