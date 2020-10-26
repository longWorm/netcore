using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace netcore
{
    public class CarContext : DbContext
    {
        public CarContext(): base()
        {

        }

        public DbSet<CarModel> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Temp\netcore\netcore\cars.db");
    }

    class CarListDBManager: ICarManager
    {
        public CarListDBManager()
        {
            dbContext = new CarContext();
        }

        private CarContext dbContext;

        public int Load(CarList carList)
        {
            var cars = dbContext.Cars;
            int maxId = 0;

            foreach (CarModel car in cars)
            {
                if (car.Id > maxId)
                    maxId = car.Id;
                carList.Add(car);
            }

            return maxId;
        }

        public void Save(CarList carList)
        {
            foreach (var car in dbContext.Cars)
                dbContext.Cars.Remove(car);
            dbContext.SaveChanges();
            foreach (var car in carList)
                dbContext.Cars.Add(car);
            dbContext.SaveChanges();
        }
    }
}
