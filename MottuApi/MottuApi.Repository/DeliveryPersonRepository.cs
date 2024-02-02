using MottuApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuApi.Repository
{
    public class DeliveryPersonRepository
    {
        private readonly DataContext _dataContext;
        public DeliveryPersonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddData(DeliveryPerson deliveryPerson)
        {
            _dataContext.DeliveryPeople.Add(deliveryPerson);
            _dataContext.SaveChanges();
            return;
        }
        public DeliveryPerson VerifyIfDataExists(DeliveryPerson deliveryPerson)
        {
            DeliveryPerson ret = _dataContext.DeliveryPeople.FirstOrDefault(deliveryPerson.UserId);
            return ret;
        }
    }
}
