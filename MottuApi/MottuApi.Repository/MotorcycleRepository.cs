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
        public Motorcycle? GetSingleMotorcyle(string plate)
        {
            Motorcycle mottu = _dataContext.Motorcycles.FirstOrDefault(x => x.Plate == plate);
            return mottu;
        }
        public List<Motorcycle?> GetAllMotorcycles()
        {
            List<Motorcycle> mottu = _dataContext.Motorcycles.ToList();
            return mottu;
        }
        public bool UpdateMotorcycle(int id, string plate)
        {
            Motorcycle mottu = _dataContext.Motorcycles.Find(id);
            mottu.Plate = plate;
            _dataContext.SaveChanges();
            return true;
        }
        public int CreateMotorcycle(Motorcycle motorcycle)
        {
            _dataContext.Motorcycles.Add(motorcycle);
            _dataContext.SaveChanges();
            return motorcycle.Id;
        }
        public Rental? VerifyIfRentalExists(int motorcycleId)
        {
            return _dataContext.Rentals.FirstOrDefault(x => x.MotorcycleId == motorcycleId);
        }
        public Motorcycle? FindById(int id)
        {
            return _dataContext.Motorcycles.Find(id);
        }
        public void DeleteMotorcycle(int id)
        {
            Motorcycle mottu = _dataContext.Motorcycles.Find(id);
            _dataContext.Motorcycles.Remove(mottu);
            _dataContext.SaveChanges();
            return;
        }
        public List<MotorcycleModel?> GetMotorcycleModels()
        {
            List<MotorcycleModel> models = _dataContext.MotorcycleModels.ToList();
            return models;
        }
        public bool CreateModel(MotorcycleModel model)
        {
            _dataContext.MotorcycleModels.Add(model);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
