using MottuApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuApi.Repository
{
    public class MotorcycleRepository
    {
        private readonly DataContext _dataContext;
        public MotorcycleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Motorcycle GetSingleMotorcyle(string plate)
        {
            Motorcycle mottu = _dataContext.Motorcycles.ToList()[0];
            return mottu;
        }
    }
}
