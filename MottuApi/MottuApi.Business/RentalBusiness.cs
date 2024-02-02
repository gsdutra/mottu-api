using MottuApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MottuApi.Model;

namespace MottuApi.Business
{
    public class RentalBusiness
    {
        private readonly RentalRepository _rentalRepository;
        public RentalBusiness(RentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
        public int GetSimulationValue(RentalDto rental)
        {
            RentalPlan rentalPlan = _rentalRepository.GetPlan(rental.RentalPlanId);
            int numberOfDays = (rental.EndDate - rental.StartDate).Days;
            if (numberOfDays <= 0) throw new Exception("Number of days must be at least one.");
            int price = 0;

            price = numberOfDays * rentalPlan.DailyPrice;

            if (numberOfDays < rentalPlan.Days)
                price += (rentalPlan.Days - numberOfDays) * rentalPlan.DailyPrice * (rentalPlan.DailyFinePercentage / 100);
            else if (numberOfDays > rentalPlan.Days)
                price += (numberOfDays - rentalPlan.Days) * rentalPlan.ExtraDayPrice;
            return price;
        }
        public int RentMotorcycle(Rental rental)
        {
            return 0;
        }
        public List<RentalPlan> ConsultPlans()
        {
            return _rentalRepository.getAvailablePlans();
        }
    }
}
