using MDM.DAL.Carr;
using MDM.Model.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MDM.BLL.Carr
{
    public interface ICarrierService
    {
        List<Carrier> GetAllCarriers();
        List<Durable> GetDurableTypes(); // 新增获取耐用品类型的方法
        Carrier GetCarrierByNo(string carrierNo);
        bool InsertCarrier(Carrier carrier);
        bool UpdateCarrier(Carrier carrier);
        bool DeleteCarrier(string carrierNo);
    }
    public class CarrierService : ICarrierService
    {
        private readonly CarrierRepository _repository;

        public CarrierService(CarrierRepository repository)
        {
            _repository = repository;
        }

        public List<Carrier> GetAllCarriers()
        {
            try
            {
                var carriers = _repository.GetAllCarriers();
                return carriers;
            }
            catch (Exception ex)
            {
                // Log exception
                return new List<Carrier>();
            }
        }

        public List<Durable> GetDurableTypes()
        {
            try
            {
                return _repository.GetDurableTypes();
            }
            catch (Exception ex)
            {
                // Log exception
                return new List<Durable>();
            }
        }

        public Carrier GetCarrierByNo(string carrierNo)
        {
            try
            {
                return _repository.GetCarrierByNo(carrierNo);
            }
            catch (Exception ex)
            {
                // Log exception
                return null;
            }
        }

        public bool InsertCarrier(Carrier carrier)
        {
            try
            {
                return _repository.InsertCarrier(carrier);
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public bool UpdateCarrier(Carrier carrier)
        {
            try
            {
                return _repository.UpdateCarrier(carrier);
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public bool DeleteCarrier(string carrierNo)
        {
            try
            {
                return _repository.DeleteCarrier(carrierNo);
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }
    }
}