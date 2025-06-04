using MDM.DAL.Factory;
using MDM.Model.UserEntities;
using System;
using System.Collections.Generic;

namespace MDM.BLL.Factory
{
    public interface IFactoryService
    {
        // 获取所有工厂
        List<Model.UserEntities.Factory> GetAllFactories();

        // 根据ID获取工厂
        Model.UserEntities.Factory GetFactoryById(int factoryId);

        // 添加工厂
        bool AddFactory(string factoryType, string factoryDescription, string eventUser);

        // 更新工厂
        bool UpdateFactory(int factoryId, string factoryType, string factoryDescription, string eventUser, string eventRemark);

        // 删除工厂
        bool DeleteFactory(int factoryId);
    }


    public class FactoryService : IFactoryService
      {
        private readonly FactoryRepository _factoryRepository;

        public FactoryService(FactoryRepository factoryRepository)
        {
            _factoryRepository = factoryRepository;
        }

        public List<Model.UserEntities.Factory> GetAllFactories()
        {
            return _factoryRepository.GetAllFactories();
        }

        public Model.UserEntities.Factory GetFactoryById(int factoryId)
        {
            return _factoryRepository.GetFactoryById(factoryId);
        }

        public bool AddFactory(string factoryType, string factoryDescription, string eventUser)
        {
            var factory = new Model.UserEntities.Factory
            {
                FactoryType = factoryType,
                FactoryDescription = factoryDescription,
                EventUser = eventUser,
                EditTime = DateTime.Now,
                CreateTime = DateTime.Now,
                EventType = "CREATE"
            };

            return _factoryRepository.AddFactory(factory);
        }

        public bool UpdateFactory(int factoryId, string factoryType, string factoryDescription, string eventUser, string eventRemark)
        {
            var factory = _factoryRepository.GetFactoryById(factoryId);
            if (factory == null)
            {
                return false;
            }

            factory.FactoryType = factoryType;
            factory.FactoryDescription = factoryDescription;
            factory.EventUser = eventUser;
            factory.EventRemark = eventRemark;
            factory.EditTime = DateTime.Now;
            factory.EventType = "UPDATE";

            return _factoryRepository.UpdateFactory(factory);
        }

        public bool DeleteFactory(int factoryId)
        {
            return _factoryRepository.DeleteFactory(factoryId);
        }
    }
}
