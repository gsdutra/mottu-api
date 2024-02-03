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
        public void AddData(DeliveryPersonDto deliveryPerson, int userId)
        {
            if (!int.TryParse(deliveryPerson.Cnpj, out _) || !int.TryParse(deliveryPerson.Cnh, out _)) throw new Exception("Cnpj and Cnh must be numeric.");
            if ((int)deliveryPerson.CnhType < 0 || (int)deliveryPerson.CnhType > 2) throw new Exception("Invalid CnhType");
            DeliveryPerson newDeliveryPerson = new DeliveryPerson
            {
                UserId = userId,
                Name = deliveryPerson.Name,
                Cnpj = deliveryPerson.Cnpj,
                Cnh = deliveryPerson.Cnh
            };
            if (_deliveryPersonRepository.VerifyIfDataExists(newDeliveryPerson) != null)
                throw new Exception("Data already added.");
            _deliveryPersonRepository.AddData(newDeliveryPerson);
            return;
        }
    }
}
