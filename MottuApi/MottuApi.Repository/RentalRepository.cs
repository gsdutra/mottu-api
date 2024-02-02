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
    }
}
