using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MottuApi.Model;
using MottuApi.Repository;

namespace MottuApi.Business
{
    public class MotorcycleBusiness
    {
        private readonly MotorcycleRepository _motorcycleRepository;
        public MotorcycleBusiness(MotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public Motorcycle GetSingleMotorcyle(string plate)
        {
            try
            {
                Motorcycle ret = _motorcycleRepository.GetSingleMotorcyle(plate);
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
