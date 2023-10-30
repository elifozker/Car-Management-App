using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal :EfEntityRepositoryBase<Car,CarDbContext>, ICarDal
    {

        public List<CarDetailDto> GetCarsDetails()
        {
            using (CarDbContext db = new CarDbContext())
            {

                var result = from c in db.Cars
                             join b in db.Brands
                             on c.BrandId equals b.Id
                             join co in db.Colors on
                             c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 CarName = c.Name,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();

            }
        }
    }
}
