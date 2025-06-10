using MDM.DAL.Carr;
using MDM.Model.UserEntities;
using System.Collections.Generic;

namespace MDM.BLL.Carr
{
    public interface ICarrierService
    {
        List<Carrier> GetAllCarriers();
        List<Durable> GetAllDurables();
        List<Carrier> GetCarriersByDurableId(string durableId);
    }

    public class CarrierService : ICarrierService
    {
        private readonly CarrierRepository _repository;

        public CarrierService(CarrierRepository repository)
        {
            _repository = repository;
        }

        public List<Carrier> GetAllCarriers() => _repository.GetAllCarriers();

        public List<Durable> GetAllDurables() => _repository.GetAllDurables();

        public List<Carrier> GetCarriersByDurableId(string durableId) => _repository.GetCarriersByDurableId(durableId);
    }
}
