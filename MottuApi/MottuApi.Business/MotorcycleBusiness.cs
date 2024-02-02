using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                Motorcycle motorcycle = _motorcycleRepository.GetSingleMotorcyle(plate);
                if (motorcycle == null) throw new Exception("Not motorcycle found with this plate.");
                return motorcycle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Motorcycle?> GetMotorcycles()
        {
            try
            {
                List<Motorcycle> motorcycles = _motorcycleRepository.GetAllMotorcycles();
                return motorcycles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateMotorcycle(int id, string plate)
        {
            try
            {
                if (!ValidatePlate(plate)) throw new Exception("Invalid plate format. It must be only letters and numbers.");

                if (_motorcycleRepository.GetSingleMotorcyle(plate) != null) throw new Exception("There is already a motorcycle with the specified plate.");



                bool updated = _motorcycleRepository.UpdateMotorcycle(id, plate);
                return updated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int CreateMotorcycle(MotorcycleDto motorcycle)
        {
            try
            {
                if (!ValidatePlate(motorcycle.Plate)) throw new Exception("Invalid plate format. It must be only letters and numbers.");

                if (_motorcycleRepository.GetSingleMotorcyle(motorcycle.Plate) != null) throw new Exception("There is already a motorcycle with the specified plate.");

                Motorcycle newMotorcycle = new Motorcycle
                {
                    Plate = motorcycle.Plate,
                    Year = motorcycle.Year,
                    ModelId = motorcycle.ModelId

                };
                int createdId = _motorcycleRepository.CreateMotorcycle(newMotorcycle);
                return createdId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteMotorcycle (int id)
        {
            try
            {
                if (_motorcycleRepository.VerifyIfRentalExists(id) != null) throw new Exception("Cant delete motorcycle. There's already a rental going on.");
                _motorcycleRepository.DeleteMotorcycle(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<MotorcycleModel?> GetAllModels()
        {
            try
            {
                return _motorcycleRepository.GetMotorcycleModels();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool CreateModel(MotorcycleModelDto model)
        {
            try
            {
                MotorcycleModel newModel = new MotorcycleModel { Name = model.Name } ;
                return _motorcycleRepository.CreateModel(newModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static bool ValidatePlate(string input)
        {
            // Define the regular expression pattern
            string pattern = "^[A-Za-z]{3}\\d[A-Za-z0-9]\\d{2}$";

            // Create a Regex object and match the input against the pattern
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);

            // Return true if the input matches the pattern, otherwise false
            return match.Success;
        }
    }
}
