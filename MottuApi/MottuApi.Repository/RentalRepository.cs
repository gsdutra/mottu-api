using MottuApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuApi.Repository
{
    public class RentalRepository
    {
        private readonly DataContext _dataContext;
        public RentalRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddRentalData(Rental rental)
        {
            _dataContext.Rentals.Add(rental);
            _dataContext.SaveChanges();
            return;
        }
        public Motorcycle getAvailableMotorcycle()
        {
            return new Motorcycle();
        }
        public List<RentalPlan> getAvailablePlans()
        {
            return _dataContext.RentalsPlan.ToList();
        }
        public RentalPlan GetPlan(int id)
        {
            return _dataContext.RentalsPlan.Find(id);
        }
    }
}
