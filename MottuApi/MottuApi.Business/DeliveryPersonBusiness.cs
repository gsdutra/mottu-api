using MottuApi.Model;
using MottuApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuApi.Business
{
    public class DeliveryPersonBusiness
    {
        private readonly DeliveryPersonRepository _deliveryPersonRepository;
        public DeliveryPersonBusiness(DeliveryPersonRepository deliveryPersonRepository)
        {
            _deliveryPersonRepository = deliveryPersonRepository;
        }
        public void AddData(DeliveryPerson deliveryPerson)
        {
            if (_deliveryPersonRepository.VerifyIfDataExists(deliveryPerson) != null)
                throw new Exception("Data already added.");
            _deliveryPersonRepository.AddData(deliveryPerson);
            return;
        }
    }
}
